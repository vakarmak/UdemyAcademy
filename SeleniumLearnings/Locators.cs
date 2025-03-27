using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearnings;

public class Locators
{
    private IWebDriver _driver;

    [SetUp]
    public void StartBrowser()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        
        _driver.Url = "https://demoqa.com/automation-practice-form";
    }

    [Test]
    public void LocatorsIdentification()
    {
        _driver.FindElement(By.Id("firstName")).SendKeys("Maksym");
        _driver.FindElement(By.Id("lastName")).SendKeys("Vakarchuk");
        _driver.FindElement(By.Id("userNumber")).SendKeys("1234567890");
        var genderCheckbox = _driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        
        _driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", genderCheckbox);
        genderCheckbox.Click();
        
        // CSS Selector
        // _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        
        // XPath
        var submitButton = _driver.FindElement(By.XPath("//button[@type='submit']"));
        
        _driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", submitButton);
        submitButton.Click();

        var modalWindowText = _driver.FindElement(By.Id("example-modal-sizes-title-lg")).Text;
        TestContext.Progress.WriteLine(modalWindowText);
        
        ((IJavaScriptExecutor)_driver).ExecuteScript("window.open('https://demoqa.com/broken');");
        
        // Anchor element locator
        var link = _driver.FindElement(By.XPath("//a[@href='https://demoqa.com']")); // //div[@class='row']/div[2]/div[2]/a[1] or (//div[@class='row']//a)[1]
        const string expectedUrl = "https://demoqa.com/";
        var hrefAttribute = link.GetAttribute("href");
        
        Assert.That(hrefAttribute, Is.EqualTo(expectedUrl));
        
        Thread.Sleep(3000);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        _driver.Quit();
    }
}