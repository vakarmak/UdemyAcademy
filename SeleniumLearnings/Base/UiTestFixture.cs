using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearnings.Base;

public class UiTestFixture
{
    protected IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}