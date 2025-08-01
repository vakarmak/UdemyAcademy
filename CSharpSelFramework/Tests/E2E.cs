using CSharpSelFramework.PageObjects;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSelFramework.Utilities;

namespace CSharpSelFramework.Tests
{
    internal class E2E : BaseTest
    {
        [Test]
        public void E2ETest()
        {
            GreenKartProductsPage greenKartProductsPage = new GreenKartProductsPage(GetDriver());
            CartPopupPage cartPopupPage = new CartPopupPage(GetDriver());
            CartPage cartPage = new CartPage(GetDriver());

            NavigateTo("https://rahulshettyacademy.com/seleniumPractise/#/");

            var productsList = greenKartProductsPage.GetProductsList();
            
            foreach (var product in productsList)
            {
                var productName = product.FindElement(greenKartProductsPage.GetProductName()).Text;

                if (productName.Contains("Cauliflower") || productName.Contains("Cucumber"))
                {
                    productName.Should().Match(x => x.Contains("Cauliflower") || x.Contains("Cucumber"));
                    product.FindElement(greenKartProductsPage.GetAddToCartButton()).Click();
                }
            }

            cartPopupPage.OpenCart();
            var cartItems = cartPopupPage.GetCartItems();
            cartPopupPage.GetCartItems().Should().NotBeNullOrEmpty();

            Wait.Until(d => cartPopupPage.GetProceedToCheckoutButton().Displayed);
            cartPopupPage.GetProceedToCheckoutButton().Click();

            

            //Wait.Until(d => d.FindElement(By.XPath("//button[.='Place Order']")));
            //var placeOrderButton = Driver.FindElement(By.XPath("//button[.='Place Order']"));
            //placeOrderButton.Click();

            //Wait.Until(d => d.FindElement(By.XPath("//select[contains(.,'Select')]")));
            //var selectElement = new SelectElement(Driver.FindElement(By.XPath("//select[contains(.,'Select')]")));
            //selectElement.SelectByText("Ukraine");

            //var argeeButton = Driver.FindElement(By.XPath("//input[@class='chkAgree']"));
            //argeeButton.Click();
            //var purchaseButton = Driver.FindElement(By.XPath("//button[.='Proceed']"));
        }
    }
}
