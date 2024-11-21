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
    public class LanguageStepDefinitions : CommonDriver
    {
        LoginPage login = new LoginPage();
        ProfilePage profile = new ProfilePage();

        [BeforeScenario]
        public void Setup()
        {
            driver=new  ChromeDriver();
        }
        //Method to call Login fucntionality
        [Given(@"I logged into Mars portal successfully")]
        public void GivenILoggedIntoMarsPortalSuccessfully()
        {
            login.LoginActions(driver);
        }

        //Navigation to profile page
        [When(@"I navigate to the Profile page")]
        public void WhenINavigateToTheProfilePage()
        {
         Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div/div[1]/div[2]/div/span", 6);
         IWebElement profileName = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/span"));
         Assert.That(profileName.Text == "Hi Eba", "Unsuccessful login");
        }

        //Method call to add new languages
        [When(@"I added a new language with '([^']*)','([^']*)'")]
        public void WhenIAddedANewLanguageWith(string language, string level)
        {
            profile.AddNewLanguage(driver,language,level);
        }

        //Method call to verify addition of language
        [Then(@"the Language should be added successfully with new '([^']*)','([^']*)'")]
        public void ThenTheLanguageShouldBeAddedSuccessfullyWithNew(string language, string level)
        {
            string languageName=profile.VerifyAddLanguage(driver,language,level);
            Assert.That(languageName == language, "Language is not added");
        }

        //Method call to edit language
        [When(@"I updated language with '([^']*)','([^']*)'")]
        public void WhenIUpdatedLanguageWith(string editedLanguage, string editedLanguageLevel)
        {
            profile.EditLanguages(driver, editedLanguage, editedLanguageLevel);
        }


        //Method call to verify updation of languages
        [Then(@"the Language should be updated successfully with new '([^']*)','([^']*)'")]
        public void ThenTheLanguageShouldBeUpdatedSuccessfullyWithNew(string editedLanguage, string editedLanguageLevel)
        {
            string updatedLanguage = profile.VerifyUpdatedLanguage(driver, editedLanguage);
            Assert.That(updatedLanguage == editedLanguage, "Language is not updated");
        }

        //Method call to delete language
        [When(@"I deleted newly added language")]
        public void WhenIDeletedNewlyAddedLanguage()
        {
            profile.DeleteLanguage(driver);
        }

        //Method call to verify deletion of languages
        [Then(@"language with name '([^']*)' should be deleted successfully")]
        public void ThenLanguageWithNameShouldBeDeletedSuccessfully(string languageToBeDeleted)
        {
            string deletedLanguage = profile.VerifyDeletedLanguage(driver, languageToBeDeleted);
            Assert.That(deletedLanguage != languageToBeDeleted, "Language is not deleted");
        }

        //Method call to add language with blank language and blank language level
        [When(@"I added new language with blank '([^']*)' and '([^']*)'")]
        public void WhenIAddedNewLanguageWithBlankAnd(string language, string languageLevel)
        {
            profile.AddNewLanguage(driver, language, languageLevel); 
        }
        //Method to verify the pop up
        [Then(@"language is not added to the profile")]
        public void ThenLanguageIsNotAddedToTheProfile()
        {
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "Please enter language and level", "Failure");
        }

        //Method call to add language that is already existing
        [When(@"I added language with already existing '([^']*)' and '([^']*)'")]
        public void WhenIAddedLanguageWithAlreadyExistingAnd(string language, string languageLevel)
        {
            profile.AddNewLanguage(driver, language, languageLevel);
        }

        //Method to verify pop up 
        [Then(@"Language should not be added to the profile")]
        public void ThenLanguageShouldNotBeAddedToTheProfile()
        {
            Thread.Sleep(1000);
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(msg.Text == "This language is already exist in your language list.", "Failure");
        }

        //Method call to add language with blank language 
        [When(@"I add language with blank '([^']*)' and '([^']*)'")]
        public void WhenIAddLanguageWithBlankAnd(string language, string languageLevel)
        {
            profile.AddNewLanguage(driver, language, languageLevel);
        }

        //Method to verify pop up
        [Then(@"Language with blank '([^']*)' is not added to profile")]
        public void ThenLanguageWithBlankIsNotAddedToProfile(string language)
        {
            IWebElement msg = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(msg.Text == "Please enter language and level", "Failure");
        }

        //Method to add language with blank languageLevel
        [When(@"I add language with '([^']*)' and blank '([^']*)'")]
        public void WhenIAddLanguageWithAndBlank(string language, string languageLevel)
        {
            profile.AddNewLanguage(driver, language, languageLevel);
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Quit();
        }

    }
}
