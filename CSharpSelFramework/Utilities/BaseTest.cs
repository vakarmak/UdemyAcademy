using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Utilities;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    protected WebDriverWait Wait = null!;
    protected Actions? Actions;
    protected IJavaScriptExecutor Js = null!;
    private IConfiguration _configuration = null!;

    [SetUp]
    public void Setup()
    {
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

        Driver.Manage().Window.Maximize();

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        Actions = new Actions(Driver);
        Js = (IJavaScriptExecutor)Driver;
    }

    protected IWebDriver GetDriver()
    {
        return Driver;
    }

    private void InitBrowser(string browserName)
    {
        switch (browserName)
        {
            case "Chrome":
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                Driver = new ChromeDriver();
                break;
            case "Firefox":
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                Driver = new FirefoxDriver();
                break;
            case "Edge":
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                Driver = new EdgeDriver();
                break;
        }
    }

    protected void NavigateTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}