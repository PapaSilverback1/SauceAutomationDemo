using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumPageObjects;

namespace TestProjectSelenium
{
    public class Tests
    {
        [TestFixture]
        public class GoogleTests
        {
            private IWebDriver _driver;
            private LoginPage _loginPage;

            [SetUp]
            public void SetUp()
            {
                // ChromeDriver is provided by Selenium.WebDriver.ChromeDriver NuGet package
                ChromeOptions options = new ChromeOptions();

                // Disable the "Save Password" prompt
                options.AddUserProfilePreference("credentials_enable_service", false);

                // Disable the "Offer to save passwords" setting
                options.AddUserProfilePreference("profile.password_manager_enabled", false);

                // Optionally, disable the "Unsafe Password" / "Change your password" warning/leak detection
                options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();
                _loginPage = new LoginPage(_driver);
                _loginPage.navigateTo("https://www.saucedemo.com/");// Arrange
            }

            [TearDown]
            public void TearDown()
            {
                _driver.Quit();
                _driver.Dispose();
            }
            [Test, Order(1)]
            public void UnsuccessfulLoginTest()
            {
                _loginPage.login("bad_user", "bad_password");
                string errorMessageExpected = "Epic sadface: Username and password do not match any user in this service";
                string actualErrorMessage = _loginPage.GetErrorMessage();
                Assert.AreEqual(errorMessageExpected, actualErrorMessage);

            }
            //just a comment
            [Test, Order(2)]
            public void SuccessfulLoginTest()
            {
                MainPage mainPage = _loginPage.login("standard_user", "secret_sauce");
                Assert.AreEqual("Swag Labs", mainPage.GetPageHeader());

            }
            [Test, Order(3)]
            public void TestCheckout()
            {
                MainPage mainPage = _loginPage.login("standard_user", "secret_sauce");
                mainPage.SelectBackPackItem();
                CartPage cartPage = mainPage.ClickCheckoutButton();
                CheckoutInformationPage checkoutInfoPage = cartPage.ClickCheckout();
                checkoutInfoPage.FillPersonalInformation("bob", "bobinson", "456");
                CheckoutOverviewPage checkoutOverviewPage = checkoutInfoPage.ClickContinueButton();
                CheckoutCompletePage checkoutCompletePage = checkoutOverviewPage.clickFinish();

                Assert.AreEqual("Thank you for your order!", checkoutCompletePage.GetCheckoutCompleteMessage());



            }
        }
    }
}