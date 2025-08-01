using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page elements
        [FindsBy(How = How.XPath, Using = "//tbody")]
        private readonly IList<IWebElement> _cartItemsTable = null!;

        private readonly By _cartProduct = By.XPath("//tr");

        // Methods to interact with the page elements
        public IList<IWebElement> GetCartItems()
        {
            return _cartItemsTable;
        }

        public By GetCartProduct()
        {
            return _cartProduct;
        }
    }
}
