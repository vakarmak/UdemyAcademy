using FluentAssertions;
using FluentAssertions.Primitives;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class Alerts : UiTestFixture
{
    [Test]
    public void TestAlert()
    {
        const string url = "https://rahulshettyacademy.com/AutomationPractice/";
        Driver.Url = url;
        
        var name = "John Doe";
        
        var inputField = Driver.FindElement(By.Id("name"));
        var confirmButton = Driver.FindElement(By.Id("confirmbtn"));
        
        inputField.SendKeys(name);
        var inputFieldValue = inputField.GetAttribute("value"); //обязательно нужно получить значение поля ввода перед нажатием кнопки подтверждения
        confirmButton.Click();

        var alertPopup = Driver.SwitchTo().Alert();
        
        var alertText = alertPopup.Text;
        alertText.Should().Be($"Hello {inputFieldValue}, Are you sure you want to confirm?", "Alert text mismatch");
        alertPopup.Accept();
        
        StringAssert.Contains(name, alertText); // проверка, что имя присутствует в тексте алерта
    }
    
    [Test]
    public void AutoSuggestiveDropDown()
    {
        const string url = "https://rahulshettyacademy.com/AutomationPractice/";
        Driver.Url = url;
        
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        var countryNameInputField = Driver.FindElement(By.Id("autocomplete"));
        
        countryNameInputField.SendKeys("uk");
        wait.Until(d => d.FindElement(By.CssSelector(".ui-menu-item div")).Displayed);

        IList<IWebElement> options = Driver.FindElements(By.CssSelector(".ui-menu-item div"));
        options.Should().NotBeEmpty("There should be at least one option displayed after typing 'uk'.");

        foreach (var option in options)
        {
            if (option.Text.Equals("Ukraine"))
            {
                option.Click();
            }
        }
    }
}