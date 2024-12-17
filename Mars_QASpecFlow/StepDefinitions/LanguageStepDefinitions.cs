using Mars_QASpecFlow.Pages;
using Mars_QASpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.Profiler;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace Mars_QASpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {

        LoginPage login;
        LanguagePage profile;
        public LanguageStepDefinitions()
        {
            login = new LoginPage();
            profile=new LanguagePage();
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            Initialise();
            LoginAndDeleteLanguages();
            DeleteSkill();
        }
        public void LoginAndDeleteLanguages()
        {
            login.LoginActions(driver);
            DeleteAllRecords();
        }
        public void DeleteSkill()
        {

            IWebElement skillButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillButton.Click();
            DeleteAllRecords();
        }
        [Given(@"I logged into Mars portal successfully")]
        public void GivenILoggedIntoMarsPortalSuccessfully()
        {
           //login.LoginActions(driver);
        }

        [When(@"I navigate to the Profile page")]
        public void WhenINavigateToTheProfilePage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div/div[1]/div[2]/div/span", 15);
            IWebElement profileName = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/span"));
            Assert.That(profileName.Text == "Hi Eba", "Unsuccessful login");
        }

        [When(@"I added a new language with '([^']*)','([^']*)'")]
        public void WhenIAddedANewLanguageWith(string language, string languageLevel)
        {
            profile.AddNewLanguage(language, languageLevel);
        }

        [Then(@"the Language should be added successfully with new '([^']*)','([^']*)'")]
        public void ThenTheLanguageShouldBeAddedSuccessfullyWithNew(string language, string languageLevel)
        {
           string addedLanguage=profile.VerifyAddLanguage(language, languageLevel);
           Assert.That(addedLanguage == language, "Language is not added");

        }

        [When(@"I updated language with '([^']*)' and '([^']*)' with '([^']*)','([^']*)'")]
        public void WhenIUpdatedLanguageWithAndWith(string language, string languageLevel, string editedLanguage, string editedLanguageLevel)
        {
            profile.EditLanguages(language,languageLevel,editedLanguage, editedLanguageLevel);
        }

        [Then(@"the Language should be updated successfully with new '([^']*)','([^']*)'")]
        public void ThenTheLanguageShouldBeUpdatedSuccessfullyWithNew(string editedLanguage, string editedLanguageLevel)
        {
            string updatedLanguage=profile.VerifyUpdatedLanguage(editedLanguage);
            Assert.That(updatedLanguage == editedLanguage, "Language is not updated");
        }

        [When(@"I add new language with '([^']*)' and '([^']*)'")]
        public void WhenIAddNewLanguageWithAnd(string newLanguage, string newLanguageLevel)
        {
            profile.AddNewLanguage(newLanguage, newLanguageLevel);
        }


        [When(@"I deleted newly added language with '([^']*)' and '([^']*)'")]
        public void WhenIDeletedNewlyAddedLanguageWithAnd(string language, string languageLevel)
        {
            profile.DeleteLanguage(language, languageLevel);
        }

        [Then(@"language with name '([^']*)' should be deleted successfully")]
        public void ThenLanguageWithNameShouldBeDeletedSuccessfully(string languageToBeDeleted)
        {
            string lastLanguage=profile.VerifyDeletedLanguage(languageToBeDeleted);
            Assert.That(lastLanguage != languageToBeDeleted, "Language is not deleted");
        }

        [When(@"I added new language with blank '([^']*)' and blank '([^']*)'")]
        public void WhenIAddedNewLanguageWithBlankAndBlank(string language, string languageLevel)
        {
            profile.AddNewLanguage(language, languageLevel);
        }

        [Then(@"language is not added to the profile")]
        public void ThenLanguageIsNotAddedToTheProfile()
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 15);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "Please enter language and level", "Failure");
        }

        [When(@"I added language with already existing '([^']*)' and '([^']*)'")]
        public void WhenIAddedLanguageWithAlreadyExistingAnd(string language, string languageLevel)
        {
            profile.AddNewLanguage(language, languageLevel);
            profile.AddNewLanguage(language, languageLevel);
        }

        [Then(@"Language should not be added to the profile")]
        public void ThenLanguageShouldNotBeAddedToTheProfile()
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]", 15);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "This language is already exist in your language list.", "Failure");
        }

        [When(@"I add language with blank '([^']*)' and '([^']*)'")]
        public void WhenIAddLanguageWithBlankAnd(string language, string languageLevel)
        {
            profile.AddNewLanguage(language, languageLevel);
        }

        [Then(@"Language with blank '([^']*)' is not added to profile")]
        public void ThenLanguageWithBlankIsNotAddedToProfile(string language)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div",15);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(msg.Text == "Please enter language and level", "Failure");
        }

        [When(@"I add language with '([^']*)' and blank '([^']*)'")]
        public void WhenIAddLanguageWithAndBlank(string language, string languageLevel)
        {
            profile.AddNewLanguage(language, languageLevel);
        }

        [Then(@"Language with blank '([^']*)' is not added to language profile")]
        public void ThenLanguageWithBlankIsNotAddedToLanguageProfile(string language)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 15);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(msg.Text =="Please enter language and level", "Failure");
        }
        [AfterScenario]
        public void CloseDriver()
        {
            DeleteAllRecords();
            driver.Quit();
        }


    }

}
