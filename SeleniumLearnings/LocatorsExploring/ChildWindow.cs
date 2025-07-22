using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class ChildWindow : UiTestFixture
{
    [Test]
    public void ChildWindowTest()
    {
        NavigateTo("https://rahulshettyacademy.com/AutomationPractice/");

        var newTabButton = Driver.FindElement(By.Id("opentab"));
        newTabButton.Click();
        
        var tabsHandler = Driver.WindowHandles;
        tabsHandler.Should().HaveCount(2, "There should be two tabs opened after clicking the 'newTabButton' button.");
        
        var childTab = tabsHandler[1];
        Driver.SwitchTo().Window(childTab);
        
        var childTabTitle = Driver.FindElement(By.XPath("//img[@alt='Logo']"));
        Wait.Until(d => childTabTitle.Displayed);
        childTabTitle.Displayed.Should().BeTrue();
    }
}