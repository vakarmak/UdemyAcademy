using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class FrameExploring : UiTestFixture
{
    [Test]
    public void FrameExploringTest()
    {
        NavigateTo("https://rahulshettyacademy.com/AutomationPractice/");

        var frameElement = Driver.FindElement(By.Id("courses-iframe"));
        
        Js.ExecuteScript("arguments[0].scrollIntoView(true);", frameElement);
        
        var mainFrame = Driver.SwitchTo().Frame("courses-iframe");
        var allAccessPlanButton = mainFrame.FindElement(By.XPath("//a[text()='All Access plan']"));
        
        allAccessPlanButton.Click();
    }
}