﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChatGenerator
{
    //[TestFixture]
    public class ChatGeneratorClass 
    {
        public IWebDriver driver;
        private string baseUrl;
        //private const int volumizingCounter = 100;

        public ChatGeneratorClass()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArguments("--start-minimized");
            driver = new ChromeDriver(options);
            baseUrl = "http://pofig.livetex.ru/";
        }

        #region IDs
        private const string cssOnlineChatWindow = "span.lt-label-block__txt";
        private const string cssOnlineChatFirstMessageField = "label.lt-i-label.lt-i-label-text > textarea[name=\"message\"]";
        private const string cssOnlineChatNextMessageField = "div.lt-i-label__hint";
        private const string cssOnlineChatNameField = "label.lt-i-label.lt-i-label-user > div.lt-i-label__hint";

        private const string idInputStableSiteId = "stable_id";

        private const string linkTextDeleteCookie = "Удалить cookie LiveTex";
        private const string linkTextReload = "reload";
        private const string linkTextStableSite = "Stable";

        private const string xpathOnlineChatSendButton = "//div[5]/button";

        #endregion

        private void SetupTestChatGenerator()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);
            baseUrl = "http://pofig.livetex.ru/";
            //verificationErrors = new StringBuilder();
        }

        //[TestCase("103744", "TestText", "World", "Hello, this is my message!!!")]
        public void GenerateClientChat(string stableSiteId, // Site ID
            string widgetTitle, // The title of LiveTex widget on site with SiteID
            string userName, // Name of user starting chat with operator
            string msg, // First message that will be sent to operator
            string volumedMsg, // Text of volumizing message
            int volumizingCount, // NUmber of volumizing messages
            StringBuilder sb, // Log (used for logging thread activity)
            string threadName // Thread name
            )

        {
            DateTime start = DateTime.Now;            
            try
            {
                sb.AppendLine(">>>>> Thread \"" + threadName + "\" preparation started: " 
                    + start.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                #region Prepare
                Console.WriteLine(TestBase.msgTestPreparationStart);
                //SetupTestChatGenerator();

                OpenBaseUrl(baseUrl);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(By.Name(idInputStableSiteId)));

                Console.WriteLine(TestBase.msgTestPreparationEnd);
                #endregion

                sb.AppendLine("----- SetStableSiteId(...)");
                SetStableSiteId(stableSiteId);

                sb.AppendLine("----- DeleteCookie()");
                DeleteCookie();

                sb.AppendLine("----- ReloadPage()");
                ReloadPage();

                sb.AppendLine("----- OpenStableSite()");
                OpenStableSite();
                
                sb.AppendLine("----- WaitForChatWindow(...)");
                WaitForChatWindow(widgetTitle, 30);
                
                sb.AppendLine("----- OpenOnlineChatWindow()");
                OpenOnlineChatWindow();
                
                sb.AppendLine("----- EnterNameIntoOnlineChatWindow()");
                EnterNameIntoOnlineChatWindow(userName);

                sb.AppendLine("----- SendFirstMessageIntoOnlineChatWindow()");
                SendFirstMessageIntoOnlineChatWindow(msg);

                sb.AppendLine("----- Sleep(2000)");
                System.Threading.Thread.Sleep(2000);

                DateTime sending = DateTime.Now;
                sb.AppendLine("----- Start volumizing thread \"" + threadName + ". Time spent after start: " 
                    + (new TimeSpan(sending.Ticks - start.Ticks)).TotalMilliseconds.ToString());
                for (int i = 0; i < volumizingCount; i++)
                {
                    SendNextMessageIntoOnlineChatWindow(i.ToString() + "___" + volumedMsg);
                    System.Threading.Thread.Sleep(1000);
                }
                DateTime fin = DateTime.Now;
                sb.AppendLine("<<<<< Thread \"" + threadName + "\" finished: " + fin.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\r\n");
                sb.AppendLine("----- Thread \"" + threadName + "\" setup time: "
                    + (new TimeSpan(sending.Ticks - start.Ticks)).TotalMilliseconds.ToString());
                sb.AppendLine("----- Thread \"" + threadName + "\" volumizing time: " 
                    + (new TimeSpan(fin.Ticks - sending.Ticks)).TotalMilliseconds.ToString());
                sb.AppendLine("----- Thread \"" + threadName + "\" total work time: " 
                    + (new TimeSpan(fin.Ticks - start.Ticks)).TotalMilliseconds.ToString() + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                DateTime fin = DateTime.Now;
                sb.AppendLine("ERROR: " + ex.Message);
                sb.AppendLine("<<<<< Thread \"" + threadName + " finished: " + fin.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                sb.AppendLine("<<<<< Thread \"" + threadName + " work time: " 
                    + (new TimeSpan(fin.Ticks - start.Ticks)).TotalMilliseconds.ToString());
            }
        }
        
        //[TearDown]
        public void GarbageCleaner()
        {
            Console.WriteLine(TestBase.msgTearDownStart);
            driver.Quit();
            driver = null;
            Console.WriteLine(TestBase.msgTearDownEnd);
        }

        private void OpenBaseUrl(string BaseUrl)
        {
            try
            {
                driver.Navigate().GoToUrl(BaseUrl);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenBaseUrl threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void SetStableSiteId(string StableSiteId)
        {
            try
            {
                driver.FindElement(By.Id("stable_id")).Clear();
                driver.FindElement(By.Id("stable_id")).SendKeys(StableSiteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetStableSiteId threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void DeleteCookie()
        {
            try
            {
                driver.FindElement(By.LinkText(linkTextDeleteCookie)).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteCookie threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void ReloadPage()
        {
            try
            {
                driver.FindElement(By.LinkText(linkTextReload)).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReloadPage threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void OpenStableSite()
        {
            try
            {
                driver.FindElement(By.LinkText(linkTextStableSite)).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenStableSite threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void WaitForChatWindow(string ExpectedChatTitle, int DelayInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DelayInSeconds));
                IWebElement chatWindow = driver.FindElement(By.CssSelector(cssOnlineChatWindow));
                //wait.Until(ExpectedConditions.ElementExists(By.CssSelector(cssChatWindow)));
                wait.Until(ExpectedConditions.TextToBePresentInElement(chatWindow, ExpectedChatTitle));

                //IWebElement chatWindow = driver.FindElement(By.CssSelector("span.lt-label-block__txt"));
                //Assert.AreEqual(ExpectedChatTitle, chatWindow.Text);
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("WaitForChatWindow threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void OpenOnlineChatWindow()
        {
            try
            {
                driver.FindElement(By.CssSelector(cssOnlineChatWindow)).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenOnlineChatWindow threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void EnterNameIntoOnlineChatWindow(string Name)
        {
            try
            {
                driver.FindElement(By.CssSelector(cssOnlineChatNameField)).Click();
                driver.FindElement(By.Name("name")).Clear();
                driver.FindElement(By.Name("name")).SendKeys(Name);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("EnterNameIntoOnlineChatWindow threw an exception:\r\n" + ex.Message + TestBase.msgNewLine);
                Assert.Fail(ex.Message);
            }
        }

        private void SendFirstMessageIntoOnlineChatWindow(string Message)
        {
            try
            {
                driver.FindElement(By.CssSelector(cssOnlineChatFirstMessageField)).Clear();
                driver.FindElement(By.CssSelector(cssOnlineChatFirstMessageField)).SendKeys(Message);
                driver.FindElement(By.XPath(xpathOnlineChatSendButton)).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                string exMsg = "SendFirstMessageIntoOnlineChatWindow threw an exception:\r\n" + ex.Message + TestBase.msgNewLine;
                Console.WriteLine(exMsg);
                Assert.Fail(exMsg);
            }
        }

        private void SendNextMessageIntoOnlineChatWindow(string Message)
        {
            try
            {
                //driver.FindElement(By.CssSelector(cssOnlineChatNextMessageField)).Click();
                //driver.FindElement(By.Name("message")).Click();
                driver.FindElement(By.Name("message")).Clear();
                driver.FindElement(By.Name("message")).SendKeys(Message);
                driver.FindElement(By.Name("message")).SendKeys("\n");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                string exMsg = "SendNextMessageIntoOnlineChatWindow threw an exception:\r\n" + ex.Message + TestBase.msgNewLine;
                Console.WriteLine(exMsg);
                Assert.Fail(exMsg);
            }
        }
    }

}
