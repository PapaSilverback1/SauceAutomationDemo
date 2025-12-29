using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoPageObjects.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By errorMessageField = By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3");
        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void navigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public MainPage login(string username, string password)
        {
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(loginButton).Click();
            
           
            return new MainPage(driver);
            
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageField).Text;
        }
    }
}
