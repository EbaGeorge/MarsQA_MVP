using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_QASpecFlow.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public void Initialise()
        {
            // create driver
            driver = new ChromeDriver();

        }
        public void DeleteAllRecords()
        {
            try
            {
                while (true)
                {
                    IWebElement deleteButton;
                    try
                    {
                        Wait.WaitToBeVisible(driver, "XPath", "(//td[@class='right aligned']//i[@class='remove icon'])[1]", 15);
                        deleteButton = driver.FindElement(By.XPath("(//td[@class='right aligned']//i[@class='remove icon'])[1]"));
                        deleteButton.Click();
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine("All records deleted");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete button is not interactable");
            }

        }

    }
}

