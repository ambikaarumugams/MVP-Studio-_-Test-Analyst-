using OpenQA.Selenium;
using Reqnroll;
using NUnit.Framework;
using qa_dotnet_cucumber.Pages;

namespace qa_dotnet_cucumber.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly NavigationHelper _navigationHelper;

        public LoginSteps(LoginPage loginPage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _navigationHelper = navigationHelper;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _navigationHelper.NavigateTo("/login");
            Assert.That(_loginPage.IsAtLoginPage(), Is.True, "Should be on the login page");
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _loginPage.Login("tomsmith", "SuperSecretPassword!");
        }

        [Then("I should see the secure area")]
        public void ThenIShouldSeeTheSecureArea()
        {
            var successMessage = _loginPage.GetSuccessMessage();
            Assert.That(successMessage, Does.Contain("You logged into a secure area!"), "Should see successful login message");
        }
    }
}