using Mars_QASpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_QASpecFlow.Pages
{
    public class SkillPage:CommonDriver 
    {
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


        //Navigating to Skill page
        public void NavigatingToSkillspage()
        {
            ////Click on Skill button
            //skillButton = driver.FindElement(skillButtonLocator);
            //skillButton.Click();
        }
        //Method to add new skill to the profile
        public void AddNewSkill(string skillName, string skillLevel)
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
        public string VerifyAddedSkill(string skillName)
        {
            driver.Navigate().Refresh();
            //Click on Skill button
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 6);
            //Identify last element
            lastSkill = driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }

        //Method to edit skills in the profile
        public void EditSkill(string skillName, string skillLevel,string editedSkill,string editedSkillLevel)
        {
            AddNewSkill(skillName, skillLevel);
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
            editedLanguageTextbox.SendKeys(editedSkill);
            //Update Skill level
            IWebElement editedLanguageLevelTextbox = driver.FindElement(By.Name("level"));
            editedLanguageLevelTextbox.SendKeys(editedSkillLevel);
            //Click on Update button
            IWebElement updateSkillButton = driver.FindElement(updateSkillButtonLocator);
            updateSkillButton.Click();
            Thread.Sleep(1000);

        }
        //Method to verify whether skill is edited 
        public string VerifyEditedSkill(string skillName)
        {
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            lastSkill = driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }
        //Method to delete skill from profile
        public void DeleteSkill(string skill,string skillLevel)
        {
            AddNewSkill(skillLevel, skillLevel);
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            //Click on Delete icon
            deleteSkillButton = driver.FindElement(deleteSkillButtonLocator);
            deleteSkillButton.Click();
        }
        //Method to verify whether skill is deleted
        public string VerifyDeletedSkill(string skillName)
        {
            driver.Navigate().Refresh();
            skillButton = driver.FindElement(skillButtonLocator);
            skillButton.Click();
            lastSkill = driver.FindElement(lastSkillLocator);
            return lastSkill.Text;
        }

        public void AddSkillWithBlankSkillAndLevel(string skill, string skillLevel)
        {
            AddNewSkill(skill, skillLevel);
        }
        public void AddAlreadyExistingSkill(string skill, string skillLevel)
        {
            
            AddNewSkill(skill, skillLevel);
            AddNewSkill(skill, skillLevel);
        }
        public void AddSkillWithBlankSkill(string skill, string skillLevel)
        {
            AddNewSkill(skill, skillLevel);
        }
        public void AddSkillWithBlankLevel(string skillLevel, string skillName)
        {
            AddNewSkill(skillName, skillLevel);
        }
    }
}
