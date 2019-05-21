using System;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using static SpecflowPages.CommonMethods;
using static SpecflowPages.ConstantUtils;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public sealed class AddSkill
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public AddSkill(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

            [Given(@"I clicked on the Skill tab under Profile page")]
            public void GivenIClickedOnTheSkillTabUnderProfilePage()
            {
                //Click on Skills Tab
                Thread.Sleep(500);
                Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[1]/a[2]")).Click();
                // Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();
            }

            [When(@"I add a new Skill")]
            public void WhenIAddANewSkill()
            {
                //Add new Skill
                Thread.Sleep(500);
                // Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]")).Click();
                Driver.driver.FindElement(By.XPath("//form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]")).Click();

                Driver.driver.FindElement(By.Name("name")).SendKeys("Testing");
                var level = Driver.driver.FindElement(By.Name("level"));
                //create select element object 
                Thread.Sleep(1000);
                var selectElement = new SelectElement(level);
                selectElement.SelectByText("Expert");
                Thread.Sleep(500);
                Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();


            }

            [Then(@"that Skill should be displayed on my listings")]
            public void ThenThatSkillShouldBeDisplayedOnMyListings()
            {
                try
                {
                    //Start the Reports
                    //CommonMethods.ExtentReports();
                    Thread.Sleep(1000);
                    CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                    Thread.Sleep(1000);
                    string ExpectedValue = "Testing";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    //Cleanup Language for next execution
                    
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                   imageFile= SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                    Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[2]/i")).Click();
                    Thread.Sleep(500);
                }

                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillNotAdded");
                }

                }
                catch (Exception e)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "Exception in SkillAdded");
            }


            }
        }

    }



