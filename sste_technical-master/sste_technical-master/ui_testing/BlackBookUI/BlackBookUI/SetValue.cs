using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace BlackBookUI
{
    class SetValue
    {
        //Pass Text
        public static void EnterValue(IWebDriver driver, string element,string value,string elementType)
        {
            if(elementType=="Id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            else if (elementType == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);
            else if (elementType == "XPath")
                driver.FindElement(By.XPath(element)).SendKeys(value);
        }

        //Click button
        public static void ButtonClick(IWebDriver driver, string element,string elementtype)
        {
            if(elementtype=="Id")
                driver.FindElement(By.Id(element)).Click();
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).Click();
            if (elementtype == "XPath")
                driver.FindElement(By.XPath(element)).Click();

        }

        //Dropdown select

        public static void DropDownSelect(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
               new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);


        }
    }
}
