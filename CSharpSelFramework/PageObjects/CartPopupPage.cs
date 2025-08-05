using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPopupPage
    {
        private readonly IWebDriver _driver;

        public CartPopupPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page elements 

        private readonly By _cartPopupButton = By.XPath("//img[@alt='Cart']");
        private readonly By _proceedButton = By.XPath("//button[contains(text(),'PROCEED TO CHECKOUT')]");

        // Methods to interact with the page elements
        
        public void ClickOnCartButton()
        {
            _driver.FindElement(_cartPopupButton).Click();
        }

        public void ClickOnProceedButton()
        {
            _driver.FindElement(_proceedButton).Click();
        }
    }
}
