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
        SkillPage skillPage;
        //SkillPage skillPage =new SkillPage();
        public SkillFeatureStepDefinitions()
        { 
            skillPage = new SkillPage();
        }
            [When(@"I navigate to the Skills page")]
            public void WhenINavigateToTheSkillsPage()
            {

            }

            [When(@"I added a new skill with '([^']*)','([^']*)'")]
            public void WhenIAddedANewSkillWith(string skill, string skillLevel)
            {

                skillPage.AddNewSkill(skill, skillLevel);
            }

            [Then(@"the skill should be added successfully with new '([^']*)'")]
            public void ThenTheSkillShouldBeAddedSuccessfullyWithNew(string skill)
            {
                string newSkill = skillPage.VerifyAddedSkill(skill);
                Assert.That(newSkill == skill, "Skill is not added");
            }

            [When(@"I updated skill with '([^']*)' and '([^']*)' as '([^']*)','([^']*)'")]
            public void WhenIUpdatedSkillWithAndAs(string skill, string skillLevel, string editedSkill, string editedSkillLevel)
            {
                skillPage.EditSkill(skill, skillLevel, editedSkill, editedSkillLevel);
            }

            [Then(@"the skill should be updated successfully with new '([^']*)','([^']*)'")]
            public void ThenTheSkillShouldBeUpdatedSuccessfullyWithNew(string skill, string skillLevel)
            {
                string editSkill = skillPage.VerifyEditedSkill(skill);
                Assert.That(editSkill == skill, "Skill is not updated");
            }

            [When(@"I added new skill with '([^']*)','([^']*)'")]
            public void WhenIAddedNewSkillWith(string skill, string skillLevel)
            {
                skillPage.AddNewSkill(skill, skillLevel);
            }

            [When(@"I deleted newly added skill with '([^']*)' and '([^']*)'")]
            public void WhenIDeletedNewlyAddedSkillWithAnd(string skill, string skillLevel)
            {
                skillPage.DeleteSkill(skill, skillLevel);

            }
            [Then(@"skill with name '([^']*)' should be deleted successfully")]
            public void ThenSkillWithNameShouldBeDeletedSuccessfully(string skill)
            {
                string lastSkill = skillPage.VerifyDeletedSkill(skill);
                Assert.That(lastSkill != skill, "Skill is not deleted");
            }

            [When(@"I added new skill with blank '([^']*)' and blank '([^']*)'")]
            public void WhenIAddedNewSkillWithBlankAndBlank(string skill, string skillLevel)
            {
                skillPage.AddSkillWithBlankSkillAndLevel(skill, skillLevel);
            }

            [Then(@"skill with blank '([^']*)' and blank '([^']*)' is not added to the profile")]
            public void ThenSkillWithBlankAndBlankIsNotAddedToTheProfile(string p0, string p1)
            {

                IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
                Assert.That(msg.Text == "Please enter skill and experience level", "Failure");
            }

            [When(@"I added an already existing skill with '([^']*)' and '([^']*)'")]
            public void WhenIAddedAnAlreadyExistingSkillWithAnd(string skill, string skillLevel)
            {

                skillPage.AddAlreadyExistingSkill(skill, skillLevel);
            }

            [Then(@"already existing skill is not added to the profile")]
            public void ThenAlreadyExistingSkillIsNotAddedToTheProfile()
            {
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 15);
                IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
                Assert.That(msg.Text == "This skill is already exist in your skill list.", "Failure");
            }

            [When(@"I add skill with blank '([^']*)' and '([^']*)'")]
            public void WhenIAddSkillWithBlankAnd(string skill, string skillLevel)
            {
                skillPage.AddSkillWithBlankSkill(skill, skillLevel);

            }

            [Then(@"skill with blank '([^']*)' is not added to profile")]
            public void ThenSkillWithBlankIsNotAddedToProfile(string skill)
            {
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 15);
                IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
                Assert.That(msg.Text == "Please enter skill and experience level", "Failure");
            }

            [When(@"I add skill with '([^']*)' and blank '([^']*)'")]
            public void WhenIAddSkillWithAndBlank(string skill, string skillLevel)
            {
                skillPage.AddSkillWithBlankLevel(skill, skillLevel);
            }

            [Then(@"skill with blank '([^']*)' is not added to the profile")]
            public void ThenSkillWithBlankIsNotAddedToTheProfile(string p0)
            {
                Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 15);
                IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
                Assert.That(msg.Text == "Please enter skill and experience level", "Failure");
            }
        
    }
}
