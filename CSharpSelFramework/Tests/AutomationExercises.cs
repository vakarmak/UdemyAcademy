using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSelFramework.Tests;

// [Parallelizable(ParallelScope.Children)] // Run tests in parallel in class
[Parallelizable(ParallelScope.Self)] // Run all test not only inside the class in parallel
public class AutomationExercises : BaseTest
{
    [Test]
    // [TestCase("lichar@ukr.net", "Qwerty12345*")]
    [TestCaseSource(nameof(AddTestCaseData))]
    [Parallelizable(ParallelScope.All)] // Run data sets in parallel but sequentially for each test
    public void E2ETest(string username, string password)
    {
        var aeHomePage = new AeHomePage(GetDriver());
        var aeLoginPage = new AeLoginPage(GetDriver());

        NavigateTo("https://www.automationexercise.com/");

        aeHomePage.ClickOnLoginButton();
        aeLoginPage.EnterEmail(username);
        aeLoginPage.EnterPassword(password);
        aeLoginPage.ClickOnLoginButton();

        Assert.That(aeHomePage.GetLogoutButton().Displayed, "User is not logged in.");
    }

    [Test]
    public void E2ETestGreenKart()
    {
        var greenKartProductsPage = new GreenKartProductsPage(GetDriver());
        var cartPopupPage = new CartPopupPage(GetDriver());
        var cartPage = new CartPage(GetDriver());
        var chooseCountryPage = new ChooseCountryPage(GetDriver());

        NavigateTo("https://rahulshettyacademy.com/seleniumPractise/#/");

        var productsList = greenKartProductsPage.GetProductsList();

        foreach (var product in productsList)
        {
            var productName = product.FindElement(greenKartProductsPage.GetProductName()).Text;

            if (productName.Contains("Cauliflower") || productName.Contains("Cucumber"))
            {
                product.FindElement(greenKartProductsPage.GetAddToCartButton()).Click();
            }
        }

        cartPopupPage.ClickOnCartButton();
        cartPopupPage.ClickOnProceedButton();

        Wait.Until(ExpectedConditions.ElementToBeClickable(cartPage.GetPlaceOrderButton()));
        cartPage.ClickOnPlaceOrderButton();

        Wait.Until(ExpectedConditions.ElementToBeClickable(chooseCountryPage.GetCountrySelect()));
        var selectCountry = new SelectElement(GetDriver().FindElement(chooseCountryPage.GetCountrySelect()));
        selectCountry.SelectByText("Ukraine");
        chooseCountryPage.ClickOnAgreeCheckbox();
        chooseCountryPage.ClickOnProceedButton();

        Wait.Until(d => d.FindElement(chooseCountryPage.GetThankYouTitle()));
        chooseCountryPage.GetThankYouTitle().Should().NotBeNull();
    }

    #region private methods

    private static IEnumerable<TestCaseData> AddTestCaseData()
    {
        yield return new TestCaseData("lichar@ukr.net", "Qwerty12345*");
        // yield return new TestCaseData("lichar@ukr.net", "Qwerty12345");
        yield return new TestCaseData("lichar@ukr.ne", "Qwerty12345*");
        yield return new TestCaseData(GetParsedJson().ExtractData("username"),
            GetParsedJson().ExtractData("password")); // does not show in the test runner
    }
    #endregion
}