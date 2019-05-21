using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            //Enter Url
           //Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a[2]")).Click();
            Driver.driver.FindElement(By.LinkText("Sign In")).Click();

            //Enter Username
            Driver.driver.FindElement(By.Name("email")).SendKeys("rekhapamila@gmail.com");

            //Enter password
            Driver.driver.FindElement(By.Name("password")).SendKeys("pami1980");
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();
            Thread.Sleep(5000);

            
        }

    }
}
