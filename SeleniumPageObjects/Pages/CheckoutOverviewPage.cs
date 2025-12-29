using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoPageObjects.Pages
{
    public class CheckoutOverviewPage
    {
        private IWebDriver driver;
        private By finishButton = By.Id("finish");
        private By totalTextDiv = By.XPath("//*[@id=\"checkout_summary_container\"]/div/div[2]/div[8]");

        public CheckoutOverviewPage(IWebDriver _driver)
        {
            driver = _driver;
        } 

        public CheckoutCompletePage clickFinish()
        {
            driver.FindElement(finishButton).Click();
            return new CheckoutCompletePage(driver);
        }
        
        public bool IsCorrectTotal(string total)
        {
            string actualTotal = driver.FindElement(totalTextDiv).Text;
            return actualTotal.Contains(total);
        }

    }
}
