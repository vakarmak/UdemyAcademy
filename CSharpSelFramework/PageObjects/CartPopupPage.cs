using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPopupPage
    {
        private readonly IWebDriver _driver;

        public CartPopupPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page elements 
        [FindsBy(How = How.XPath, Using = "//img[@alt='Cart']")]
        private readonly IWebElement _openCart = null!;

        [FindsBy(How = How.CssSelector, Using = ".cart-items")]
        private readonly IList<IWebElement> _cartItems = null!;

        [FindsBy(How = How.XPath, Using = "//button[.='PROCEED TO CHECKOUT']")]
        private readonly IWebElement _proceedToCheckoutButton = null!;

        // Methods to interact with the page elements
        public void OpenCart()
        {
            _openCart.Click();
        }

        public IList<IWebElement> GetCartItems()
        {
            return _cartItems;
        }

        public IWebElement GetProceedToCheckoutButton()
        {
            return _proceedToCheckoutButton;
        }
    }
}
