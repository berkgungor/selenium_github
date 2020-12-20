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
    class Class1
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
                driver.FindElement(By.Id("password")).SendKeys("*********");
                driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[4]/input[12]")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Log in was not succesful");
                throw;
            }

        }
        public void goRepo()
        {

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2);
            IWebElement search = driver.FindElement(By.Name("q"));
            search.SendKeys("karate");
            search.SendKeys(Keys.Enter);

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var tikla = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li.repo-list-item:nth-child(1) > div:nth-child(2) > div:nth-child(1) > a:nth-child(1)")));

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("test could not click to intuit/karate repo !!");
                throw;
            }
        }
            public void click_repo()
        {
            try
            {
                Thread.Sleep(2000);
                var repobuton = driver.FindElement(By.CssSelector("li.repo-list-item:nth-child(1) > div:nth-child(2) > div:nth-child(1) > a:nth-child(1)"));
                repobuton.Click();
            }
            catch
            {
                Console.WriteLine("test could not click to intuit/karate repo !!");                
            }

            Boolean StarFlag = true;

            try   // click to star
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                var star = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".pagehead-actions > li:nth-child(2) > div:nth-child(1) > form:nth-child(2) > button:nth-child(3) > svg:nth-child(1)")));
                star.Click();
               
            }
            catch
            {
                Console.WriteLine("star was not clicked !!");
                
            }

            if (StarFlag == true)
            {
                try
                {
                    Thread.Sleep(1000);
                    driver.FindElement(By.CssSelector(".pagehead-actions > li:nth-child(2) > div:nth-child(1) > form:nth-child(1) > button:nth-child(3) > svg:nth-child(1) > path:nth-child(1)")).Click();

                }
                catch
                {
                    Console.WriteLine("star stayed as clicked !!");
                    StarFlag = false;
                }
            }

            if(StarFlag == false)
            {
                Console.WriteLine("Test is not successfull");
            }
            else
            {
                Console.WriteLine("Test is succesful");
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
