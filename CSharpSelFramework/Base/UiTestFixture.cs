using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Base;

public class UiTestFixture
{
    private IWebDriver _driver = null!;
    protected WebDriverWait Wait = null!;
    protected Actions? Actions;
    protected IJavaScriptExecutor Js = null!;


    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        
        Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        Actions = new Actions(_driver);
        Js = (IJavaScriptExecutor)_driver;
    }
    
    protected void NavigateTo(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}