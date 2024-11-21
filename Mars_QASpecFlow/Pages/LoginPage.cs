using Mars_QASpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_QASpecFlow.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
            //Launch Mars Application
            driver.Navigate().GoToUrl("http://localhost:5000/");
            //Maximize chrome window
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            //Click on SignIn button
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
            signInButton.Click();
            //Enter Email Address
            IWebElement emailAddress=driver.FindElement(By.Name("email"));
            emailAddress.SendKeys("ebageorgegp@gmail.com");
            //Enter Password
            IWebElement password=driver.FindElement(By.Name("password"));
            password.SendKeys("Eba@123");
            //Click on Login Button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();  
        }
    }
}
