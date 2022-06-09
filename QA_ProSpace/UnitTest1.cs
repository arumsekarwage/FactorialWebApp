using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace QA_ProSpace
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://z29vzcbmaw5kaw5nigzvcib5b3u.prospace.io/");
            driver.Manage().Window.Maximize();

            //validating each elements using different locators
            Assert.IsTrue(driver.FindElement(By.CssSelector("h1[class='margin-base-vertical text-center']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.CssSelector("span[class='icon-arrow-right']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("number")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("getFactorial")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//a[@href='/privacy.html']")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//a[@href='/terms.html']")).Displayed);

            driver.Quit();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://z29vzcbmaw5kaw5nigzvcib5b3u.prospace.io/");
            driver.Manage().Window.Maximize();

            //validating input text element
            driver.FindElement(By.Id("number")).SendKeys("5");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("120"));

            driver.FindElement(By.Id("number")).Clear();
            driver.FindElement(By.Id("number")).SendKeys("10");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("3628800"));

            driver.FindElement(By.Id("number")).Clear();
            driver.FindElement(By.Id("number")).SendKeys("123");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("1.2146304367025325e+205"));

            driver.FindElement(By.Id("number")).Clear();
            driver.FindElement(By.Id("number")).SendKeys("1000");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("null"));

            driver.FindElement(By.Id("number")).Clear();
            driver.FindElement(By.Id("number")).SendKeys("0");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("1"));

            driver.FindElement(By.Id("number")).Clear();
            driver.FindElement(By.Id("number")).SendKeys("!@#");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("Please enter an integer"));

            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("number")).SendKeys("abc");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("Please enter an integer"));

            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("number")).SendKeys("0.8");
            driver.FindElement(By.Id("getFactorial")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("resultDiv")).Text.Contains("Please enter an integer"));

            driver.Quit();
        }

        [TestMethod]
        public void TestMethod3()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://z29vzcbmaw5kaw5nigzvcib5b3u.prospace.io/");
            driver.Manage().Window.Maximize();

            //validating title and wordings
            Assert.AreEqual("Prospace factorial", driver.Title);
            Assert.IsTrue(driver.FindElement(By.CssSelector("h1[class='margin-base-vertical text-center']")).Text.Contains("Prospace factoral calculator"));
            Assert.IsTrue(driver.FindElement(By.Id("number")).GetAttribute("placeholder").Contains("Enter an integer"));
            Assert.IsTrue(driver.FindElement(By.Id("getFactorial")).Text.Contains("Calclate!"));
            driver.FindElement(By.XPath("//a[@href='/privacy.html']")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//body")).Text.Contains("This is the privacy document. We are not yet ready with it. Stay tuned!"));
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[@href='/terms.html']")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//body")).Text.Contains("This is the terms and conditions document. We are not yet ready with it. Stay tuned!"));

            driver.Quit();
        }
    }
}