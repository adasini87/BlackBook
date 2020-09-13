using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace BlackBookUI
{
    class GetMethod
    {
        //Get Text
        public static string GetValue(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                return driver.FindElement(By.Id(element)).Text;
            else if (elementType == "Name")
                return driver.FindElement(By.Name(element)).Text;
            else if (elementType == "XPath")
                return driver.FindElement(By.XPath(element)).Text;
            else return string.Empty;
        }
    }
}
