﻿using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using static SpecflowPages.CommonMethods;
using static SpecflowPages.ConstantUtils;
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public sealed class AddLanguage
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public AddLanguage(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //Driver.driver.FindElement(By.LinkText("Profile")).Click();


        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Driver.driver.FindElement(By.XPath("//div[contains(text(), 'Add New')]"));

            //Add Language
            //  Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");
            Driver.driver.FindElement(By.Name("name")).SendKeys("English");

            //Click on Language Level
            // Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();
            //Choose the language level
            //  IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            // Lang.Click();


            var level = Driver.driver.FindElement(By.Name("level"));
            //create select element object 
            var selectElement = new SelectElement(level);
            selectElement.SelectByValue("Basic");


            //Click on Add button
            // Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
               // CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                //Cleanup Language for next execution
               
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    Thread.Sleep(500);
                    imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                    Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[2]/i")).Click();
                    Thread.Sleep(500);
                }

                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguagenotAdded");
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
               imageFile= SaveScreenShotClass.SaveScreenshot(Driver.driver, "ExceptioninLanguageAdded");
            }

        }



        }
    }
