using Mars_QASpecFlow.Pages;
using Mars_QASpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Mars_QASpecFlow.StepDefinitions
{
    [Binding]
  
    public class SkillFeatureStepDefinitions:CommonDriver
    {
        ProfilePage profilePage=new ProfilePage();
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        //Method to navigate to skills page
        [When(@"I navigate to the Skills page")]
        public void WhenINavigateToTheSkillsPage()
        {
        
        }
        //Method call to add new skill to the profile
        [When(@"I added a new skill with '([^']*)','([^']*)'")]
        public void WhenIAddedANewSkillWith(string skill, string skillLevel)
        {
            
            profilePage.AddNewSkill(driver,skill, skillLevel);
        }

        //Method call to verify whether skill is added to profile
        [Then(@"the skill should be added successfully with new '([^']*)'")]
        public void ThenTheSkillShouldBeAddedSuccessfullyWithNew(string skill)
        {
            string skills = profilePage.VerifyAddedSkill(driver, skill);
            Assert.That(skills == skill, "Skill is not added");
        }

        //Method call to edit skill
        [When(@"I updated skill with '([^']*)','([^']*)'")]
        public void WhenIUpdatedSkillWith(string skill, string skillLevel)
        {
            profilePage.EditSkill(driver, skill, skillLevel);
        }

        //Method call to verify whether skill is updated
        [Then(@"the skill should be updated successfully with new '([^']*)','([^']*)'")]
        public void ThenTheSkillShouldBeUpdatedSuccessfullyWithNew(string skill, string skillLevel)
        {
            string updatedSkill=profilePage.VerifyEditedSkill(driver, skill);
            Assert.That(updatedSkill == skill, "Skill is not updated");
        }

        //Method call to delete skill
        [When(@"I deleted newly added skill")]
        public void WhenIDeletedNewlyAddedSkill()
        {
            profilePage.DeleteSkill(driver);
        }

        //Method call verify whether skill is deleted
        [Then(@"skill with name '([^']*)' should be deleted successfully")]
        public void ThenSkillWithNameShouldBeDeletedSuccessfully(string skill)
        {
            string deleteSkill=profilePage.VerifyDeletedSkill(driver, skill);
            Assert.That(skill != deleteSkill, "Skill is deleted");
        }

        //Method call to add skill without skill and skill level
        [When(@"I added new skill without '([^']*)' and '([^']*)'")]
        public void WhenIAddedNewSkillWithoutAnd(string skill, string skillLevel)
        {
            profilePage.AddNewSkill(driver, skill, skillLevel);
        }

        //Method call to verify pop up
        [Then(@"skill is not added to the profile")]
        public void ThenSkillIsNotAddedToTheProfile()
        {
           
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "Please enter skill and experience level", "Failure");
        }

        //Method call to add already existing skill
        [When(@"I added an already existing skill with '([^']*)' and '([^']*)'")]
        public void WhenIAddedAnAlreadyExistingSkillWithAnd(string skill, string skillLevel)
        {
            profilePage.AddNewSkill(driver, skill, skillLevel);
        }

        //Method call to verify pop up
        [Then(@"already existing skill is not added to the profile")]
        public void ThenAlreadyExistingSkillIsNotAddedToTheProfile()
        {
            Thread.Sleep(1000);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "This skill is already exist in your skill list.", "Failure");
        }

        //Method call to add skill with blank skill 
        [When(@"I add skill with blank '([^']*)' and '([^']*)'")]
        public void WhenIAddSkillWithBlankAnd(string skill, string skillLevel)
        {
            profilePage.AddNewSkill(driver, skill, skillLevel);
        }

        //Method call to verify pop up
        [Then(@"skill with blank '([^']*)' is not added to profile")]
        public void ThenSkillWithBlankIsNotAddedToProfile(string skill)
        {
            
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 7);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "Please enter skill and experience level", "Failure");
        }

        //Method call to add skill with blank skillLevel
        [When(@"I add skill with '([^']*)' and blank '([^']*)'")]
        public void WhenIAddSkillWithAndBlank(string skill, string skillLevel)
        {
            profilePage.AddNewSkill(driver, skill, skillLevel);
        }


    }
}
