using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            Console.WriteLine("URL Launched");
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
            Thread.Sleep(1000);
            Console.WriteLine("Computer Name Created");

            // Search for COmputer Name
            string name = string.Empty;
            SetValue.EnterValue(webDriver, "/html/body/section/div[2]/form/input[1]", "BlackBookUITest", "XPath");
            Thread.Sleep(1000);
            SetValue.ButtonClick(webDriver, "searchsubmit", "Id");
            name = GetMethod.GetValue(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a", "XPath");
            if (name == "BlackBookUITest")
                Console.WriteLine("Computer Name exists");
              
            //Modify Discontinued date
                SetValue.ButtonClick(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a","XPath");
                webDriver.FindElement(By.Id("discontinued")).Clear();
                SetValue.EnterValue(webDriver, "discontinued", "2022-09-01", "Id");
                Thread.Sleep(500);
                SetValue.ButtonClick(webDriver, "/html/body/section/form[1]/div/input", "XPath");
                Console.WriteLine("Discontinued Date Modified");

            // Verify modified discontinued date
            SetValue.EnterValue(webDriver, "/html/body/section/div[2]/form/input[1]", "BlackBookUITest", "XPath");
                Thread.Sleep(500);
                SetValue.ButtonClick(webDriver, "searchsubmit", "Id");
                DateTime date = Convert.ToDateTime(GetMethod.GetValue(webDriver, "/html/body/section/table/tbody/tr/td[3]", "XPath"));
                if (date == Convert.ToDateTime("2022-09-01"))
                    Console.WriteLine("Modified Discontinued date verified");

                //delete entries created
            bool check = true;


                while (check)
                    {

                //name = GetMethod.GetValue(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a", "XPath");
                //name2 = GetMethod.GetValue(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a", "XPath")
                if (GetMethod.GetValue(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a", "XPath") != "BlackBookUITest")
                {
                    check = false;
                    break;
                }
                else
                {
                    SetValue.ButtonClick(webDriver, "/html/body/section/table/tbody/tr[1]/td[1]/a", "XPath");
                    Thread.Sleep(500);
                    SetValue.ButtonClick(webDriver, "/html/body/section/form[2]/input", "XPath");
                }
                SetValue.EnterValue(webDriver, "/html/body/section/div[2]/form/input[1]", "BlackBookUITest", "XPath");
                        Thread.Sleep(500);
                        SetValue.ButtonClick(webDriver, "searchsubmit", "Id");
                        

            }

            if (check == false)
                Console.WriteLine("All Entries Deleted");

        }

        //[TearDown]
        //public void Clear()
        //{            
        //    webDriver.Close();
        //}
    }
}
