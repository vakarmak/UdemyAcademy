using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearnings;

public class SeleniumFirst
{
    private IWebDriver _driver;
    
    [SetUp]
    public void StartBrowser()
    {
        // ChromeDriver is a class that implements IWebDriver interface to interact with the Chrome browser.
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
    }

    [Test]
    public void Test1()
    {
        _driver.Url = "https://www.google.com";
    }
}