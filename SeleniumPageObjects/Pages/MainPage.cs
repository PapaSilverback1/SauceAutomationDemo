using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoPageObjects.Pages
{

    public class MainPage
    {

        private IWebDriver driver;
        private By Header = By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div");
        private By BackpackItem = By.Id("add-to-cart-sauce-labs-backpack");
        private By CheckoutButton = By.Id("shopping_cart_container");

        public MainPage(IWebDriver _driver)
        {
            driver = _driver;
        }
        public string GetPageHeader()
        {
            string headerString = driver.FindElement(Header).Text;      

            return headerString;
        }
        public void SelectBackPackItem()
        {
            driver.FindElement(BackpackItem).Click();
        }
        public CartPage ClickCheckoutButton()
        {
            driver.FindElement(CheckoutButton).Click();
            
            

            return new CartPage(driver);
        }
       

    }
}
