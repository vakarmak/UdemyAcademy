using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumLearnings.Base;

namespace SeleniumLearnings.LocatorsExploring;

public class SortWebTables : UiTestFixture
{
    [Test]
    public void SortTable()
    {
        const string url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        Driver.Url = url;
        
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        ArrayList a = new ArrayList();
        
        SelectElement paginationDropdown = new SelectElement(Driver.FindElement(By.Id("page-menu")));
        paginationDropdown.SelectByValue("20");
        IList<IWebElement> initialVegetableNames = Driver.FindElements(By.XPath("//tr/td[1]"));
        foreach (var veg in initialVegetableNames)
        {
            a.Add(veg.Text);
        }
        TestContext.Progress.WriteLine("Before Sorting:");
        foreach (var element in a)
        {
            TestContext.Progress.WriteLine(element);
        }
        
        a.Sort();
        TestContext.Progress.WriteLine("----------------------------------------");
        TestContext.Progress.WriteLine("After Sorting:");
        foreach (var element in a)
        {
            TestContext.Progress.WriteLine(element);
        }
        
        IWebElement sortButton = Driver.FindElement(By.CssSelector("th[aria-label*='Veg/fruit name']"));
        sortButton.Click();

        ArrayList b = new ArrayList();
        IList<IWebElement> sortedVegetableNames = Driver.FindElements(By.XPath("//tr/td[1]"));
        foreach (var veg in sortedVegetableNames)
        {
            b.Add(veg.Text);
        }
        
        Assert.That(a, Is.EqualTo(b), $"The {a} list does not match the {b} list.");
    }
}