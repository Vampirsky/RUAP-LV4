using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php?route=common/home");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("name@mail.ru");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            driver.FindElement(By.LinkText("Laptops & Notebooks")).Click();
            driver.FindElement(By.LinkText("See All Laptops & Notebooks")).Click();
            driver.FindElement(By.CssSelector("div.image > a > img.img-responsive")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[5]/a/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("button-payment-address")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("button-shipping-address")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("button-shipping-method")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.Id("button-payment-method")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("button-confirm")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Continue")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click(); 
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Logout")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Continue")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
