using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using NUnit.Framework;

namespace CSharpSelFramework.Tests;

public class AutomationExercises : BaseTest
{
    [Test]
    // [TestCase("lichar@ukr.net", "Qwerty12345*")]
    [TestCaseSource(nameof(AddTestCaseData))]
    public void E2ETest(string username, string password)
    {
        var aeHomePage = new AeHomePage(GetDriver());
        var aeLoginPage = new AeLoginPage(GetDriver());

        NavigateTo("https://www.automationexercise.com/");

        aeHomePage.ClickOnLoginButton();
        aeLoginPage.EnterEmail(username);
        aeLoginPage.EnterPassword(password);
        aeLoginPage.ClickOnLoginButton();

        // Assert.That(aeLoginPage.GetLoginErrorMessage().Displayed, "Error login message was not displayed.");
    }

    #region private methods

    private static IEnumerable<TestCaseData> AddTestCaseData()
    {
        yield return new TestCaseData("lichar@ukr.net", "Qwerty12345*");
        // yield return new TestCaseData("lichar@ukr.net", "Qwerty12345");
        // yield return new TestCaseData("lichar@ukr.ne", "Qwerty12345*");
        yield return new TestCaseData(GetParsedJson().ExtractData("username"), GetParsedJson().ExtractData("password"));
    }
    #endregion
}