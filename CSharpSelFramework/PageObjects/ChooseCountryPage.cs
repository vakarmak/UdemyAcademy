using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects;

public class ChooseCountryPage
{
    private readonly IWebDriver _driver;

    public ChooseCountryPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    // Page elements
    
    private readonly By _countrySelect = By.XPath("//select[contains(.,'Select')]");
    private readonly By _agreeCheckbox = By.XPath("//input[@type='checkbox']");
    private readonly By _proceedButton = By.XPath("//button[contains(text(),'Proceed')]");

    private readonly By _thankYouTitle = By.XPath("//span[contains(text(), 'Thank you, your order has been placed')]");
    
    // Methods to interact with the page elements

    public By GetCountrySelect()
    {
        return _countrySelect;
    }

    public void ClickOnAgreeCheckbox()
    {
        _driver.FindElement(_agreeCheckbox).Click();
    }

    public void ClickOnProceedButton()
    {
        _driver.FindElement(_proceedButton).Click();
    }

    public By GetThankYouTitle()
    {
        return _thankYouTitle;
    }
}