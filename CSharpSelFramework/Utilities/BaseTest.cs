using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Utilities;

public class BaseTest
{
    private IWebDriver _driver = null!;
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

        _driver.Manage().Window.Maximize();

        Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        Actions = new Actions(_driver);
        Js = (IJavaScriptExecutor)_driver;
    }

    protected IWebDriver GetDriver()
    {
        return _driver;
    }

    private void InitBrowser(string browserName)
    {
        switch (browserName)
        {
            case "Chrome":
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                _driver = new ChromeDriver();
                break;
            case "Edge":
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                _driver = new EdgeDriver();
                break;
        }
    }

    protected void NavigateTo(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    protected static JsonReader GetParsedJson()
    {
        return new JsonReader();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}