using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.PageObjects
{
    public class GreenKartProductsPage
    {
        private readonly IWebDriver Driver;

        public GreenKartProductsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
        }

        // Page elements
        [FindsBy(How = How.XPath, Using = "//div[@class = 'product']")]
        private readonly IList<IWebElement> productsList;

        By productName = By.XPath(".//h4[@class='product-name']");
        By addToCartButton = By.XPath(".//button[.='ADD TO CART']");

        // Methods to interact with the page elements
        public IList<IWebElement> GetProductsList()
        {
            return productsList;
        }

        public By GetProductName()
        {
            return productName;
        }

        public By GetAddToCartButton()
        {
            return addToCartButton;
        }
    }
}
