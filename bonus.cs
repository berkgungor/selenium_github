using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class bonus
    {
        IWebDriver driver = new FirefoxDriver();
       

        [SetUp]
        public void StartBrowser()
        {
            string link = "https://github.com/";
            driver.Navigate().GoToUrl(link);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
        }

        [Test]

        public void logIn()
        {

            try
            {
                driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[2]/div[2]/a[1]")).Click();
                driver.FindElement(By.Id("login_field")).SendKeys("brekgungor@gmail.com");
                driver.FindElement(By.Id("password")).SendKeys("**********");
                driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[4]/input[12]")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Log in was not succesful");
                throw;
            }

        }

        public void newRepo()
        {

            String repoName = "MyRepoName7";

            driver.FindElement(By.XPath("/html/body/div[1]/header/div[6]/details/summary")).Click();
            var delay = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            var repo = delay.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/header/div[6]/details/details-menu/a[1]")));
            try
            {
                repo.Click();
                Console.WriteLine("entered new repo page successfuly");
            }
            catch
            {
                Console.WriteLine("error while entering new repo tab.");
            }

            try
            {
                driver.FindElement(By.Id("repository_name")).SendKeys(repoName);
                driver.FindElement(By.Id("repository_gitignore_template_toggle")).Click();


            }
            catch
            {
                Console.WriteLine("error");
            }
            //scroll down the page
            var element = driver.FindElement(By.CssSelector("div.form-checkbox:nth-child(6) > label:nth-child(2)"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            //random selection
            Random num = new Random();
            int dropdown = num.Next(1, 9)+1;
            Console.WriteLine("label.select-menu-item:nth-child(" + dropdown + ") > span:nth-child(3)");
            try
            {
                driver.FindElement(By.CssSelector("div.unchecked:nth-child(5) > span:nth-child(4) > details:nth-child(1) > summary:nth-child(1)")).Click();
                driver.FindElement(By.CssSelector("#context-ignore-filter-field")).SendKeys("a");
                driver.FindElement(By.CssSelector("label.select-menu-item:nth-child(" + dropdown + ") > span:nth-child(3)")).Click();
                Console.WriteLine("gitignore selection is : " + dropdown);
            }
            catch
            {
                Console.WriteLine("gitignore selection is not done.");
            }

            try
            {
                driver.FindElement(By.XPath("/html/body/div[4]/main/div/form/div[4]/button")).Click();
                Console.WriteLine("repository has been created.");
            }
            catch
            {
                Console.WriteLine("repository could not be created.");
            }


            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string checkName = driver.FindElement(By.XPath("/html/body/div[4]/div/main/div[1]/div[1]/div/h1/strong/a")).Text;
            if (checkName == repoName)
            {
                Console.WriteLine("Repository has been created with correct values.");
            }
            else
            {
                Console.WriteLine("Repository has been created with wrong values.");
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
