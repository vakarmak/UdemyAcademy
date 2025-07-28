using CSharpSelFramework.Base;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.Tests
{
    internal class E2E : BaseTest
    {
        [Test]
        public void E2ETest()
        {
            NavigateTo("https://rahulshettyacademy.com/seleniumPractise/#/");

            var productsList = Driver.FindElements(By.XPath("//div[@class = 'product']"));
            foreach (var product in productsList)
            {
                if (product.Text.Contains("Beetroot") || product.Text.Contains("Cucumber"))
                {
                    var addToCartButton = product.FindElement(By.XPath(".//button[contains(text(), 'ADD TO CART')]"));
                    addToCartButton.Click();
                }
            }

            var cartCount = Driver.FindElement(By.XPath("//img[@alt='Cart']"));
            cartCount.Click();
            var cartItems = Driver.FindElements(By.CssSelector(".cart-item"));
            cartItems.Should().NotBeEmpty();

            Wait.Until(d => d.FindElement(By.XPath("//button[.='PROCEED TO CHECKOUT']")));
            var proceedToCheckoutButton = Driver.FindElement(By.XPath("//button[.='PROCEED TO CHECKOUT']"));
            proceedToCheckoutButton.Click();

            Wait.Until(d => d.FindElement(By.XPath("//button[.='Place Order']")));
            var placeOrderButton = Driver.FindElement(By.XPath("//button[.='Place Order']"));
            placeOrderButton.Click();

            Wait.Until(d => d.FindElement(By.XPath("//select[contains(.,'Select')]")));
            var selectElement = new SelectElement(Driver.FindElement(By.XPath("//select[contains(.,'Select')]")));
            selectElement.SelectByText("Ukraine");

            var argeeButton = Driver.FindElement(By.XPath("//input[@class='chkAgree']"));
            argeeButton.Click();
            var purchaseButton = Driver.FindElement(By.XPath("//button[.='Proceed']"));
        }
    }
}
