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
        
        var mainFrame = Driver.SwitchTo().Frame("courses-iframe"); // Switch to the iframe
        var allAccessPlanButton = mainFrame.FindElement(By.XPath("//a[text()='All Access plan']"));
        
        allAccessPlanButton.Click();
        
        Wait.Until(d => Driver.FindElement(By.CssSelector("h1")).Displayed);
        
        var accessPlanTitle = mainFrame.FindElement(By.CssSelector("h1")).Text;
        TestContext.Progress.WriteLine(accessPlanTitle);
        
        var frameParent = Driver.SwitchTo().DefaultContent(); // Switch back to the main content
        
        var titleElement = frameElement.FindElement(By.XPath("//h1[text()='Practice Page']")).Text;
        TestContext.Progress.WriteLine(titleElement);
    }
}