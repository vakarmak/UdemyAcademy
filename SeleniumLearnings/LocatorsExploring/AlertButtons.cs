using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class AlertButtons : UiTestFixture
{
    [Test]
    public void AlertButtonsTest()
    {
        const string url = "https://demoqa.com/alerts";
        Driver.Url = url;

        var elementForCapture = Driver.FindElement(By.Id("confirmButton"));
        Driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", elementForCapture);

        var confirmButton = Driver.FindElement(By.Id("confirmButton"));
        confirmButton.Click();

        var alert = Driver.SwitchTo().Alert();
        alert.Accept();

        var alertText = Driver.FindElement(By.Id("confirmResult"));

        Assert.That(alertText.Text, Is.EqualTo("You selected Ok"));
    }
}