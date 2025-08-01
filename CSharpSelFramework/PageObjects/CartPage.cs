using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    internal class CartPage
    {
        private readonly IWebDriver Driver;

        public CartPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
        }

        // Page elements
        [FindsBy(How = How.XPath, Using = "//tbody")]
        private readonly IList<IWebElement> cartItemsTable;

        By cartProduct = By.XPath("//tr");

        // Methods to interact with the page elements
        public IList<IWebElement> GetCartItems()
        {
            return cartItemsTable;
        }

        public By GetCartProduct()
        {
            return cartProduct;
        }
    }
}
