using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class DropdownLocators : UiTestFixture
{
    [Test]
    public void DropdownTest()
    {
        const string url = "https://demoqa.com/select-menu";
        Driver.Url = url;
        
        // Select element is used to interact with dropdowns

        // var dropdownOld = Driver.FindElement(By.Id("oldSelectMenu"));
        // var s = new SelectElement(dropdownOld);
        // s.SelectByText("Black");
        // s.SelectByValue("5"); // for old types of dropdowns there is a value for each option
        // s.SelectByIndex(5); // Select by index is also available, count starts from 0
        
        // Work with regular selectors where the value is not select but div
        
        var dropdownForCapture = Driver.FindElement(By.XPath("//div[contains(text(),'Select Option')]"));
        Driver.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'})", dropdownForCapture);
        
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        var dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Select Option')]")));
        dropdown.Click();
        
        
    }
}