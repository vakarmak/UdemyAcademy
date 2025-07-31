using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPopupPage
    {
        private readonly IWebDriver Driver;

        public CartPopupPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
        }

        // Page elements 
        [FindsBy(How = How.XPath, Using = "//img[@alt='Cart']")]
        private readonly IWebElement openCart;

        [FindsBy(How = How.CssSelector, Using = ".cart-items")]
        private readonly IList<IWebElement> cartItems;

        [FindsBy(How = How.XPath, Using = "//button[.='PROCEED TO CHECKOUT']")]
        private readonly IWebElement proceedToCheckoutButton;

        // Methods to interact with the page elements
        public void OpenCart()
        {
            openCart.Click();
        }

        public IList<IWebElement> GetCartItems()
        {
            return cartItems;
        }

        public IWebElement GetProceedToCheckoutButton()
        {
            return proceedToCheckoutButton;
        }
    }
}
