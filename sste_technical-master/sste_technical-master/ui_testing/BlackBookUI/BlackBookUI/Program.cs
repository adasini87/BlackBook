using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackBookUI
{
    class Program
    {

        // Browser Reference
        IWebDriver webDriver = new ChromeDriver();
        
        public static void Main(string[] args)        {

            //IWebDriver webDriver = new ChromeDriver();
            //SetValue sv = new SetValue();
            
            ////Call inherited methods and pass values
            //sv.ButtonClick(webDriver, "add", "Id");
            //sv.EnterValue(webDriver, "/html/body/section/form/fieldset/div[1]/div/input", "BlackBookUITest", "XPath");
            ////Thread.Sleep(2000);
            //sv.EnterValue(webDriver, "introduced", "2020-09-01", "Id");
            //sv.EnterValue(webDriver, "discontinued", "2021-09-01", "Id");
            //sv.DropDownSelect(webDriver, "company", "Evans & Sutherland", "Id");
            //sv.ButtonClick(webDriver, "/html/body/section/form/div/input", "XPath");
        }

        [SetUp]
        public void Launch()
        {
            webDriver.Navigate().GoToUrl("https://computer-database.herokuapp.com/computers");
        }

        [Test]
        public void UITest()
        {
            //Call inherited methods and pass values
            SetValue.ButtonClick(webDriver, "add", "Id");
            Thread.Sleep(2000);
            SetValue.EnterValue(webDriver, "/html/body/section/form/fieldset/div[1]/div/input", "BlackBookUITest", "XPath");
            //Thread.Sleep(2000);
            SetValue.EnterValue(webDriver, "introduced", "2020-09-01", "Id");
            SetValue.EnterValue(webDriver, "discontinued", "2021-09-01", "Id");
            SetValue.DropDownSelect(webDriver, "company", "Evans & Sutherland", "Id");
            SetValue.ButtonClick(webDriver, "/html/body/section/form/div/input", "XPath");
        }

        //[TearDown]
        //public void Clear()
        //{            
        //    webDriver.Close();
        //}
    }
}
