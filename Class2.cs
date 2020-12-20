using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Class2
    {
        IWebDriver driver = new FirefoxDriver();
        [SetUp]
        public void StartBrowser()
        {
            string link = "https://github.com/";
            driver.Navigate().GoToUrl(link);
            driver.Manage().Window.Maximize();
         
        }

        [Test]

        public void logIn()
        {

            try
            {
                driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[2]/div[2]/a[1]")).Click();
                driver.FindElement(By.Id("login_field")).SendKeys("brekgungor@gmail.com");
                driver.FindElement(By.Id("password")).SendKeys("***********");
                driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[4]/input[12]")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Log in was not succesful");
                throw;
            }

        }
        Boolean testFlag = false;
        

        public void goProfile()
        {
            Thread.Sleep(2000);
            IWebElement profile = driver.FindElement(By.XPath("/html/body/div[1]/header/div[7]/details/summary"));

            try
            {
                profile.Click();
               
            }
            catch(Exception ex)
            {
                Console.WriteLine("profile icon is not working !!!");
                testFlag = true;
            }
            Thread.Sleep(1000);
            IWebElement settings = driver.FindElement(By.XPath("/html/body/div[1]/header/div[7]/details/details-menu/a[8]"));
            try
            {               
                settings.Click();
            }
            catch
            {
                Console.WriteLine("settings tab is not working !!!");
                testFlag = true;

            }
            
        }
        String name1 = "MyName";
        String bio1 = "MyInfo";
        public void ClearandFill()
        {
            IWebElement name = driver.FindElement(By.Id("user_profile_name"));
            IWebElement bio = driver.FindElement(By.Id("user_profile_bio"));
        z:
            try
            {
                name.Clear();
                bio.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("name and bio could not be deleted !!!");
            }

            string value = driver.FindElement(By.XPath("//*[@id='user_profile_name']")).GetAttribute("value");

           
            if (string.IsNullOrEmpty(value))
            {
                name.SendKeys(name1);
                bio.SendKeys(bio1);

            }
            else
            {
                goto z;
                
            }

            IWebElement Update = driver.FindElement(By.XPath("/html/body/div[4]/main/div/div/div[2]/div[2]/div[1]/form/div/p[2]/button"));
            try
            {
                Update.Click();
                Console.WriteLine("profile changes are updated.");
            }
            catch
            {
                Console.WriteLine("profile changes could not updated.");
            }
        }

        public void checkInfo()
        {
            string value = driver.FindElement(By.XPath("//*[@id='user_profile_name']")).GetAttribute("value");
            var data = driver.FindElement(By.Id("user_profile_bio")).Text;
            

            if ((value == name1)&&(data == bio1))
            {
                Console.WriteLine("changes are updated successfuly.");
            }
            else
            {
                Console.WriteLine("changes could not be updated successfuly.");
            }
        }

        public void logOut()
        {
            IWebElement profile = driver.FindElement(By.XPath("/html/body/div[1]/header/div[7]/details/summary"));
            profile.Click();

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
                var tikla = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/header/div[7]/details/details-menu/form/button")));
                tikla.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("uaer could not sign out.");
                throw;
            }
        }


        [TearDown]
        public void EndTest()
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
