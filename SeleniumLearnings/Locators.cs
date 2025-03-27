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
        // _driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        
        // XPath
        var submitButton = _driver.FindElement(By.XPath("//button[@type='submit']"));
        
        _driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", submitButton);
        submitButton.Click();

        var modalWindowText = _driver.FindElement(By.Id("example-modal-sizes-title-lg")).Text;
        TestContext.Progress.WriteLine(modalWindowText);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        _driver.Quit();
    }
}