using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Utilities;

public class BaseTest
{
    // private IWebDriver _driver = null!;
    public ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>(); // For parallel execution
    protected WebDriverWait Wait = null!;
    protected Actions? Actions;
    protected IJavaScriptExecutor Js = null!;
    private IConfiguration _configuration = null!;

    public ExtentReports extent;
    public ExtentTest test;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var workingDirectory = AppContext.BaseDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
        var reportsDir = Path.Combine(projectDirectory, "Reports");
        Directory.CreateDirectory(reportsDir);
        var reportPath = Path.Combine(reportsDir, "TestReport.html");
        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        extent.AddSystemInfo("Host", Environment.MachineName);
    }

    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // важно: откуда читать файл
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var browserName = _configuration["browser"];
        if (string.IsNullOrWhiteSpace(browserName))
        {
            throw new InvalidOperationException("Browser name is not configured in appSettings.");
        }

        InitBrowser(browserName);

        _driver.Value.Manage().Window.Maximize();

        Wait = new WebDriverWait(_driver.Value, TimeSpan.FromSeconds(5));
        Actions = new Actions(_driver.Value);
        Js = (IJavaScriptExecutor)_driver.Value;
    }

    protected IWebDriver GetDriver()
    {
        return _driver.Value;
    }

    private void InitBrowser(string browserName)
    {
        switch (browserName)
        {
            case "Chrome":
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                _driver.Value = new ChromeDriver();
                break;
            case "Edge":
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                _driver.Value = new EdgeDriver();
                break;
        }
    }

    protected void NavigateTo(string url)
    {
        _driver.Value.Navigate().GoToUrl(url);
    }

    protected static JsonReader GetParsedJson()
    {
        return new JsonReader();
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        DateTime time = DateTime.Now;
        var fileName = "Screenshot_ " + time.ToString("h_mm_ss") + ".png";
        var stackTrace = TestContext.CurrentContext.Result.StackTrace;

        if (status == TestStatus.Failed)
        {
            test.Fail("Test failed", CaptureScreenshot(_driver.Value, fileName));
            test.Log(Status.Fail, "Test Failed with log trace" + stackTrace);
        }
        else if (status == TestStatus.Passed)
        {
        }

        extent.Flush();
        _driver.Value.Quit();
    }

    public Media CaptureScreenshot(IWebDriver driver, string screenshotName)
    {
        var ts = (ITakesScreenshot)driver;
        var screenshot = ts.GetScreenshot().AsBase64EncodedString;
        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
    }
}