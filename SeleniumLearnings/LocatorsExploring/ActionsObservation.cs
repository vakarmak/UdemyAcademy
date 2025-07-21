using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class ActionsObservation : UiTestFixture
{
    [Test]
    public void ActionsVariants()
    {
        const string url = "https://rahulshettyacademy.com/";
        Driver.Url = url;
        
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        var moreButton = Driver.FindElement(By.CssSelector("a.dropdown-toggle"));
        var a = new Actions(Driver);
        a.MoveToElement(moreButton).Perform(); // Наведение курсора на элемент "More"
        
        var aboutUsElement = Driver.FindElement(By.CssSelector("a[href = 'about-my-mission']"));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href = 'about-my-mission']"))); // Ожидание, пока элемент "About Us" станет видимым
        // Ожидание, пока элемент "About Us" станет видимым
        a.MoveToElement(aboutUsElement).Click().Perform(); // Клик на элемент "About Us"
    }

    [Test]
    public void DragAndDrop()
    {
        NavigateTo("https://demoqa.com/droppable");
        
        var source = Driver.FindElement(By.Id("draggable"));
        var target = Driver.FindElement(By.Id("droppable"));
        
        Actions!.DragAndDrop(source, target).Perform();
        Wait.Until(ExpectedConditions.TextToBePresentInElement(target, "Dropped!"));
        var droppedText = target.Text;
        droppedText.Should().Be("Dropped!", "Source element is not dropped on target element");
    }
}