using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Class1 data = new Class1();
            data.StartBrowser();
            data.logIn();
            data.goRepo();
            data.click_repo();
            data.EndTest();
            

            Class2 data2 = new Class2();
            data2.StartBrowser();
            data2.logIn();
            data2.goProfile();
            data2.ClearandFill();
            data2.checkInfo();
            data2.logOut();
            data2.EndTest();

            
            bonus data3 = new bonus();
            data3.StartBrowser();
            data3.logIn();
            data3.newRepo();
            data3.EndTest();

        }
    }
}
