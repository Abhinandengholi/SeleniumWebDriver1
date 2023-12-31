﻿using AssignmentNunit.PageObjects;
using AssignmentNunit.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit.TestScripts
{
    [TestFixture]
    internal class UserManagementTest : CoreCodes
    {
        //Asserts

        [Test, Order(1), Category("Regression Test")]
        public void CreateAcccountTest()
        {
            var homepage = new NaaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            var productlist = homepage.TypeSearch("eyewear");
            Thread.Sleep(2000);
            var productpage = productlist.SelectProduct();
            Thread.Sleep(2000);
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                driver.SwitchTo().Window(handle);
            }
            productpage.SizecheckClick();
            productpage.ClickAddCart();
            string urllink = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            Assert.AreEqual(driver.FindElement(By.XPath("//a[contains(text(),'LRG4')]")).GetAttribute("href"), urllink);
        }

    }
    
}
