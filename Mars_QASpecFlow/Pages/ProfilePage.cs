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
    public class ProfilePage:Wait
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
        private readonly By skillButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        IWebElement skillButton;
        private readonly By addNewSkillButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        IWebElement addNewSkillButton;
        private readonly By addBtnLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        IWebElement addBtn;
        private readonly By lastSkillLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        IWebElement lastSkill;
        private readonly By editSkillButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        IWebElement editSkillButton;
        private readonly By updateSkillButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        IWebElement updateSkillButton;
        private readonly By deleteSkillButtonLocator = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
        IWebElement deleteSkillButton;

        //Method to add new languages to the profile
        public void AddNewLanguage(IWebDriver driver,string language,string level)
        {
            // Wait for some seconds
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            // Click on Add New button
            addNewButton=driver.FindElement(addNewButtonLocator);
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
        public string VerifyAddLanguage(IWebDriver driver,string language,string level)
        {
            driver.Navigate().Refresh();
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }
        //Method to edit languages in the profile
        public void EditLanguages(IWebDriver driver,string editedLanguage,string editedLanguageLevel)
        {
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
        public string VerifyUpdatedLanguage(IWebDriver driver,string editedLanguage)
        {
            driver.Navigate().Refresh();
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }

        //Method to delete language from profile
        public void DeleteLanguage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            deleteIcon = driver.FindElement(deleteIconLocator);
            deleteIcon.Click();
        }

        //Method to verify whether the language is deleted
        public string VerifyDeletedLanguage(IWebDriver driver,string languageToBeDeleted)
        {
            driver.Navigate().Refresh();
            languageName = driver.FindElement(languageNameLocator);
            return languageName.Text;
        }
        //Navigating to Skill page
        public void NavigatingToSkillspage(IWebDriver driver)
        {
            //Click on Skill button
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
        }
        //Method to add new skill to the profile
        public void AddNewSkill(IWebDriver driver,string skillName,string skillLevel)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 6);
            //Click on Skill  button
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            //Click on Add new Button
            addNewSkillButton = driver.FindElement(addNewSkillButtonLocator);
            addNewSkillButton.Click();
            //Add skill name
            IWebElement skillField = driver.FindElement(By.Name("name"));
            skillField.SendKeys(skillName);
            //Add skill level
            IWebElement skillLevelField = driver.FindElement(By.Name("level"));
            skillLevelField.SendKeys(skillLevel);
            //Click on Add button
            addBtn = driver.FindElement(addBtnLocator);
            addBtn.Click();  
        }

        //Method to verify whether skill is added to profile
        public string VerifyAddedSkill(IWebDriver driver, string skillName)
        {
            driver.Navigate ().Refresh();
            //Click on Skill button
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 6);
            //Identify last element
            lastSkill = driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }

        //Method to edit skills in the profile
        public void EditSkill(IWebDriver driver,string skillName,string skillLevel)
        {
            driver.Navigate().Refresh();
            //Click on Skill button
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            //Click on Edit button 
            editSkillButton = driver.FindElement(editSkillButtonLocator);
            editSkillButton.Click();
            //Update Skill name
            IWebElement editedLanguageTextbox = driver.FindElement(By.Name("name"));
            editedLanguageTextbox.Clear();
            editedLanguageTextbox.SendKeys(skillName);
            //Update Skill level
            IWebElement editedLanguageLevelTextbox = driver.FindElement(By.Name("level"));
            editedLanguageLevelTextbox.SendKeys(skillLevel);
            //Click on Update button
            IWebElement updateSkillButton = driver.FindElement(updateSkillButtonLocator);
            updateSkillButton.Click();
            Thread.Sleep(1000);
            
        }
        //Method to verify whether skill is edited 
        public string VerifyEditedSkill(IWebDriver driver,string skillName)
        {
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            lastSkill = driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }
        //Method to delete skill from profile
        public void DeleteSkill(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            //Click on Delete icon
            deleteSkillButton = driver.FindElement(deleteSkillButtonLocator);
            deleteSkillButton.Click();
        }
        //Method to verify whether skill is deleted
        public string VerifyDeletedSkill(IWebDriver driver,string skillName)
        {
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            lastSkill=driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }
    }
    
}