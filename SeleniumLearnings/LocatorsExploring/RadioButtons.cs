using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class RadioButtons : UiTestFixture
{
    [Test]
    public void RadioButtonTest()
    {
        const string url = "https://demoqa.com/radio-button";
        Driver.Url = url;

        var elementForCapture = Driver.FindElement(By.XPath("//div[contains(text(),'Do you like the site?')]"));
        Driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", elementForCapture);

        // work with multiple radio buttons without using element index
        IList<IWebElement> radioButtons = Driver.FindElements(By.CssSelector("input[type='radio']"));
        foreach (var radioButton in radioButtons)
        {
            if (!radioButton.GetAttribute("value").Equals("Yes")) continue;
            radioButton.Click();
            Assert.That(radioButton.GetAttribute("value"), Is.EqualTo("Yes"));
        }
    }
}