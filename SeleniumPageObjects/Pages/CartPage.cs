using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoPageObjects.Pages
{

    public class CartPage
    {
        private IWebDriver driver;
        private By checkoutButton = By.Id("checkout");
        public CartPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public CheckoutInformationPage ClickCheckout()
        {
            driver.FindElement(checkoutButton).Click();
            return new CheckoutInformationPage(driver);
        }

    }
}
