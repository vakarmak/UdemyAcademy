using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects;

public class AeHomePage
{
    private readonly IWebDriver _driver;
    public AeHomePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    // Page elements

    [FindsBy(How = How.XPath, Using = "//a[@href='/login']")]
    private readonly IWebElement _loginButton;

    [FindsBy(How = How.XPath, Using = "//a[.=' Logout']")]
    private readonly IWebElement _logoutButton;

    // Methods to interact with the page elements

    public void ClickOnLoginButton()
    {
        _loginButton.Click();
    }

    public IWebElement GetLogoutButton()
    {
        return _logoutButton;
    }
}