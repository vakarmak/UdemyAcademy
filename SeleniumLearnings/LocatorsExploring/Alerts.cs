using FluentAssertions;
using FluentAssertions.Primitives;
using NUnit.Framework;
using OpenQA.Selenium;
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
}