using Mars_QASpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Mars_QASpecFlow.Pages
{
    public class LanguagePage : CommonDriver
    {
        private readonly By addNewButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        IWebElement addNewButton;
        private readonly By addButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        IWebElement addButton;
        private readonly By languageNameLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        IWebElement languageName;
        private readonly By editButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]");
        IWebElement editButton;
        private readonly By updateButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        IWebElement updateButton;
        private readonly By deleteIconLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]");
        IWebElement deleteIcon;


        //Method to add new languages to the profile
        public void AddNewLanguage(string language, string level)
        {
            driver.Navigate().Refresh();
            // Wait for some seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div",15);        
            // Click on Add New button
            addNewButton = driver.FindElement(addNewButtonLocator);
            addNewButton.Click();
            //Add Language
            IWebElement addLanguage = driver.FindElement(By.Name("name"));
            addLanguage.SendKeys(language);
            //Add Language Level
            IWebElement languageLevel = driver.FindElement(By.Name("level"));
            languageLevel.SendKeys(level);
            //Click on Add button
            addButton = driver.FindElement(addButtonLocator);
            addButton.Click();
        }

        //Method to verify whether the languages are added to the profile
        public string VerifyAddLanguage(string language, string level)
        {
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 15);
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }
        //Method to edit languages in the profile
        public void EditLanguages(string language, string languageLevel, string editedLanguage, string editedLanguageLevel)
        {
            AddNewLanguage(language, languageLevel);
            VerifyAddLanguage(editedLanguage, languageLevel);
            driver.Navigate().Refresh();
            //Click on Edit button
            editButton = driver.FindElement(editButtonLocator);
            editButton.Click();
            //Update Languages
            IWebElement editedLanguageTextbox = driver.FindElement(By.Name("name"));
            editedLanguageTextbox.Clear();
            editedLanguageTextbox.SendKeys(editedLanguage);
            //Update Language level
            IWebElement editedLanguageLevelTextbox = driver.FindElement(By.Name("level"));
            editedLanguageLevelTextbox.SendKeys(editedLanguageLevel);
            //Click on Update button
            updateButton = driver.FindElement(updateButtonLocator);
            updateButton.Click();
            Thread.Sleep(1000);

        }
        //Method to verify whether the language is updated
        public string VerifyUpdatedLanguage(string editedLanguage)
        {
            driver.Navigate().Refresh();
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }

        //Method to delete language from profile
        public void DeleteLanguage(string language, string languageLevel)
        {
            AddNewLanguage(language, languageLevel);
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]", 15);
            deleteIcon = driver.FindElement(deleteIconLocator);
            deleteIcon.Click();
        }

        //Method to verify whether the language is deleted
        public string VerifyDeletedLanguage(string languageToBeDeleted)
        {
            driver.Navigate().Refresh();           
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }


    }

}