using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSelFramework.Tests
{
    [Parallelizable(ParallelScope.Self)] // Run all test not only inside the class in parallel
    internal class E2E : BaseTest
    {
        [Test]
        [Category("Smoke")]
        public void E2ETest()
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
    }
}
