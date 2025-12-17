using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPageObjects
{
    public class CheckoutCompletePage
    {

        private IWebDriver driver;
        private By completeMessage = By.XPath("//*[@id=\"checkout_complete_container\"]/h2");

        public CheckoutCompletePage(IWebDriver _driver)
        {
            driver = _driver;
        }
        
        public string GetCheckoutCompleteMessage()
        {
            return driver.FindElement(completeMessage).Text;
        }

    }
}
