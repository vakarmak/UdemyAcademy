using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects;

public class AeLoginPage
{
    private readonly IWebDriver _driver;

    public AeLoginPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(driver, this);
    }

    // Page elements

    [FindsBy(How = How.Name, Using = "email")]
    private readonly IWebElement _emailInput;

    [FindsBy(How = How.Name, Using = "password")]
    private readonly IWebElement _passwordInput;

    [FindsBy(How = How.XPath, Using = "//button[.='Login']")]
    private readonly IWebElement _loginButton;

    [FindsBy(How = How.XPath, Using = "//p[.='Your email or password is incorrect!']")]
    private readonly IWebElement _loginErrorMessage;

    // Methods to interact with the page elements

    public void EnterEmail(string email)
    {
        _emailInput.Clear();
        _emailInput.SendKeys(email);
    }
    public void EnterPassword(string password)
    {
        _passwordInput.Clear();
        _passwordInput.SendKeys(password);
    }

    public void ClickOnLoginButton()
    {
        _loginButton.Click();
    }
    public IWebElement GetLoginErrorMessage()
    {
        return _loginErrorMessage;
    }

}