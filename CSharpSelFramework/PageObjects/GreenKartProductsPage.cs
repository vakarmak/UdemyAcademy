using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class GreenKartProductsPage
    {
        private readonly IWebDriver _driver;

        public GreenKartProductsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page elements
        [FindsBy(How = How.XPath, Using = "//div[@class = 'product']")]
        private readonly IList<IWebElement> _productsList = null!;

        private readonly By _productName = By.XPath(".//h4[@class='product-name']");
        private readonly By _addToCartButton = By.XPath(".//button[.='ADD TO CART']");

        // Methods to interact with the page elements
        public IList<IWebElement> GetProductsList()
        {
            return _productsList;
        }

        public By GetProductName()
        {
            return _productName;
        }

        public By GetAddToCartButton()
        {
            return _addToCartButton;
        }
    }
}
