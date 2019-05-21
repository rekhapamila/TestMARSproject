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
    public sealed class AddCategory
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public AddCategory(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I clicked on the manage listing tab")]
        public void GivenIClickedOnTheManageListingTab()
        {
            Driver.driver.FindElement(By.LinkText("Manage Listings")).Click();
            Thread.Sleep(3000);
        }
        [When(@"I click on edit on a category")]
        public void WhenIClickOnEditOnACategory()
        {
            Driver.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr/td[8]/i[2]")).Click();
            Thread.Sleep(1000);
        }

        [When(@"i fill in all the mandatory fields")]
        public void WhenIFillInAllTheMandatoryFields()
        {
            Driver.driver.FindElement(By.Name("title")).SendKeys("NEW");
            Driver.driver.FindElement(By.Name("description")).SendKeys("NEW");
          //  Driver.driver.FindElement(By.Name("name")).SendKeys("Testing");
            var catid = Driver.driver.FindElement(By.Name("categoryId"));
            Thread.Sleep(1000);
            var selectElement = new SelectElement(catid);
            selectElement.SelectByValue("7");
            var subcatid = Driver.driver.FindElement(By.Name("subcategoryId"));
            Thread.Sleep(1000);
            var subselectElement = new SelectElement(subcatid);
            subselectElement.SelectByValue("5");
            Driver.driver.FindElement(By.XPath("//div[2]/div/div/div/div/input")).SendKeys("New");
            Driver.driver.FindElement(By.XPath("//div[2]/div/div/div/div/input")).SendKeys(Keys.Enter);
            Driver.driver.FindElement(By.XPath("//div[8]/div[4]/div/div/div/div/div/input")).SendKeys("New");
            Driver.driver.FindElement(By.XPath("//div[8]/div[4]/div/div/div/div/div/input")).SendKeys(Keys.Enter);
            Driver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(3000);
           // IAlert alert = Driver.driver.SwitchTo().Alert();
           // alert.Accept();
           // Thread.Sleep(3000);


        }

        [Then(@"the new category is displayed in the manage listing page")]
        public void ThenTheNewCategoryIsDisplayedInTheManageListingPage()
        {
            //Start the Reports
            try {
                
                
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Category");

                Thread.Sleep(1000);
                string ExpectedValue = "Business";
                string ActualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr/td[2]")).Text;
                Thread.Sleep(500);
                //Cleanup Language for next execution
               
                
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Category Successfully");
                    imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "CategoryAdded");
                    Driver.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr/td[8]/i[3]")).Click();
                    Thread.Sleep(3000);
                    Driver.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();

                    Thread.Sleep(500);

                }

                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "CategoryNotAdded");
                }

            }
            
                catch (Exception e)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                imageFile=SaveScreenShotClass.SaveScreenshot(Driver.driver, "Exception in Category");
            }

        }
    }
}
