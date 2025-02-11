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
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        _driver.Url = "https://www.demoblaze.com/";
        TestContext.Progress.WriteLine(_driver.Title);
        TestContext.Progress.WriteLine(_driver.Url);
        // TestContext.Progress.WriteLine is used to write to the test output.
        _driver.Close();
        //_driver.Quit();
        // The difference between Close and Quit is that Close closes the current window whereas Quit closes all the windows.
        
    }
}