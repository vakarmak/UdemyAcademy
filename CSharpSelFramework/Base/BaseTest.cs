using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Base;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    protected WebDriverWait Wait = null!;
    protected Actions? Actions;
    protected IJavaScriptExecutor Js = null!;

    [SetUp]
    public void Setup()
    {
        var browserName = ConfigurationManager.AppSettings["browser"];
        if (string.IsNullOrWhiteSpace(browserName))
        {
            throw new InvalidOperationException("Browser name is not configured in AppSettings.");
        }
        InitBrowser(browserName);

        Driver.Manage().Window.Maximize();

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        Actions = new Actions(Driver);
        Js = (IJavaScriptExecutor)Driver;
    }

    public IWebDriver GetDriver()
    {
        return Driver;
    }

    protected void InitBrowser(string browserName)
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