using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearnings.Base;

public class UiTestFixture
{
    protected IWebDriver Driver;
    protected WebDriverWait Wait;
    protected Actions? Actions;


    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        Actions = new Actions(Driver);
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