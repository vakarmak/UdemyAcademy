using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page elements

        private readonly By _placeOrderButton = By.XPath("//button[contains(text(),'Place Order')]");
        
        // Methods to interact with the page elements

        public By GetPlaceOrderButton()
        {
            return _placeOrderButton;
        }
        public void ClickOnPlaceOrderButton()
        {
            _driver.FindElement(_placeOrderButton).Click();
        }
    }
}