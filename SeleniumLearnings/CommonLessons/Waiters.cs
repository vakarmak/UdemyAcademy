using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.CommonLessons;

public class Waiters : UiTestFixture
{
    [Test]
    [TestCase("https://demoqa.com/dynamic-properties")]
    public void ExplicitWaiter(string url)
    {
        Driver.Url = url;
        
        var buttonForCapture = Driver.FindElement(By.XPath("//button[@id='enableAfter']"));
        Driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", buttonForCapture);
        
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        var button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("visibleAfter")));
        
        Assert.That(button.Displayed, Is.True);
        
        // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // example of implicit wait // global timeout impact all elements
    }
}