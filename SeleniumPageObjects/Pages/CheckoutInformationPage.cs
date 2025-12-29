using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoPageObjects.Pages
{
    public class CheckoutInformationPage
    {
        private IWebDriver driver;
        private By firstNameBox = By.Id("first-name");
        private By lastNameBox = By.Id("last-name");
        private By postalCodeBox = By.Id("postal-code");
        private By continueButton = By.Id("continue");
        private By cancelButton = By.Id("cancel");

        public CheckoutInformationPage(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void FillPersonalInformation(string firstName, string lastName, string postalCode)
        {
            driver.FindElement(firstNameBox).SendKeys(firstName);
            driver.FindElement(lastNameBox).SendKeys(lastName);
            driver.FindElement(postalCodeBox).SendKeys(postalCode);
            Thread.Sleep(4000);
        }
        ///need to add return type for next page
        public CheckoutOverviewPage ClickContinueButton()
        {
            driver.FindElement(continueButton).Click();
            return new CheckoutOverviewPage(driver);
        }
        public CartPage ClickCancelButton()
        {
            driver.FindElement(cancelButton).Click();
            return new CartPage(driver);
        }
    }
}
