using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatGenerator
{
    public static class ChatGeneratorHelperClass
    {
        public static void SendKeysRegularSearchQuery(string queryString)
        {
            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtRegularSearchQuery));
            query.SendKeys(queryString);
            System.Threading.Thread.Sleep(1000);
        }

        public static void SendKeysAdvancedSearchORQuery(string queryString)
        {
            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtAdvancedSearchORQuery));
            query.SendKeys(queryString);
            System.Threading.Thread.Sleep(1000);
        }

        public static void SubmitRegularSearchQuery()
        {
            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtRegularSearchQuery));
            query.Submit();
        }

        public static void SubmitRegularSearchQueryAndWaitForTitle(string title)
        {
            var wait = new WebDriverWait(TestBase.WebDriver, TimeSpan.FromSeconds(10));

            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtRegularSearchQuery));
            query.Submit();
            wait.Until((d) => { return d.Title.StartsWith(title); });
        }

        public static void SubmitAdvancedSearchQuery()
        {
            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtAdvancedSearchORQuery));
            query.Submit();
        }

        public static void SubmitAdvancedSearchQueryAndWaitForTitle(string title)
        {
            var wait = new WebDriverWait(TestBase.WebDriver, TimeSpan.FromSeconds(10));

            IWebElement query = TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtAdvancedSearchORQuery));
            query.Submit();
            wait.Until((d) => { return d.Title.StartsWith(title); });
        }

        public static void SelectListOccuranceType(string liValue)
        {
            Point occuranceTypeLocation = new Point();
            string xpath = "//li[@value=\"" + liValue + "\"]";

            Console.WriteLine(">>>>> Looking for listbox OccuranceType");
            //IWebElement listOccType = TestBase.WebDriver.FindElement(By.Id("as_occt_button"));
            RemoteWebElement listOccType = (RemoteWebElement)TestBase.WebDriver.FindElement(By.Id(TestBase.idListOccuranceType));
            var hack = listOccType.LocationOnScreenOnceScrolledIntoView;

            occuranceTypeLocation = hack;// listOccType.Location;
            Console.WriteLine(">>>>> Mouse operations: cursor pos is: X={0}, Y={1}", occuranceTypeLocation.X + TestBase.deltaX, occuranceTypeLocation.Y + TestBase.deltaY);

            MouseOperations.SetCursorPosition(occuranceTypeLocation.X + TestBase.deltaX, occuranceTypeLocation.Y + TestBase.deltaY);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);

            Console.WriteLine(">>>>> Looking for OccuranceType option value: {0}", liValue);
            System.Threading.Thread.Sleep(1000);
            listOccType.FindElement(By.XPath(xpath)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        public static void SelectListRenewalDate(string liValue)
        {
            Point renewalDateLocation = new Point();
            string xpath = "//li[@value=\"" + liValue + "\"]";

            Console.WriteLine(">>>>> Looking for listbox RenewalDate");
            //IWebElement listOccType = TestBase.WebDriver.FindElement(By.Id("as_occt_button"));
            RemoteWebElement listOccType = (RemoteWebElement)TestBase.WebDriver.FindElement(By.Id(TestBase.idListRenewalDate));
            var hack = listOccType.LocationOnScreenOnceScrolledIntoView;

            renewalDateLocation = hack;// listOccType.Location;
            Console.WriteLine(">>>>> Mouse operations: cursor pos is: X={0}, Y={1}", renewalDateLocation.X + TestBase.deltaX, renewalDateLocation.Y + TestBase.deltaY);

            MouseOperations.SetCursorPosition(renewalDateLocation.X + TestBase.deltaX, renewalDateLocation.Y + TestBase.deltaY);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);

            Console.WriteLine(">>>>> Looking for RenewalDate option value: {0}", liValue);
            System.Threading.Thread.Sleep(1000);
            listOccType.FindElement(By.XPath(xpath)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        public static string SelectListSearchSuggestion(int index)
        {
            //Point renewalDateLocation = new Point();
            string xpath = TestBase.GoogleSearchSuggestionXpathById(index);
            string sugText = "";

            Console.WriteLine(">>>>> Looking for listbox Suggestion");
            RemoteWebElement query = (RemoteWebElement)TestBase.WebDriver.FindElement(By.Name(TestBase.idTxtRegularSearchQuery));

            //for (int i = 0; i < index; i++)
            query.SendKeys(OpenQA.Selenium.Keys.ArrowDown);

            RemoteWebElement listSugItem = (RemoteWebElement)TestBase.WebDriver.FindElement(By.XPath(xpath));

            sugText = listSugItem.Text;

            Console.WriteLine(">>>>> Looking for Suggestion option: {0}", sugText);
            System.Threading.Thread.Sleep(1000);
            listSugItem.Click();//.FindElement(By.XPath(xpath)).Click();
            System.Threading.Thread.Sleep(1000);

            return sugText;
        }

        public static string ClickPageAndWaitForTitle(int pageId, string title)
        {
            string msg = "";
            try
            {
                Console.WriteLine(">>> ClickPageAndWaitForTitle({0}, {1})", pageId, title);
                int startPage = (pageId - 1) * 10;
                string condition = "start=" + startPage.ToString();
                var wait = new WebDriverWait(TestBase.WebDriver, TimeSpan.FromSeconds(10));

                RemoteWebElement page =
                    (RemoteWebElement)TestBase.WebDriver.FindElement(By.XPath(TestBase.GooglePagingComposePageXpathById(pageId)));

                Point hack = page.LocationOnScreenOnceScrolledIntoView;

                MouseOperations.SetCursorPosition(hack.X, hack.Y + TestBase.deltaY);

                page.Click();
                System.Threading.Thread.Sleep(2000);
                wait.Until((d) => { return d.Url.Contains(condition); });
                Console.WriteLine(">>>>> Page " + pageId + ": " + TestBase.WebDriver.Url);
                Assert.True(TestBase.WebDriver.Url.Contains(condition), "Wrong page. Expected page: " + pageId);
                msg = TestBase.msgValidationPassed;
            }
            catch (NoSuchElementException)
            {
                msg = "ERROR: Requested paging link does not exist. Page number = " + pageId;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            catch (ElementNotVisibleException)
            {
                msg = "ERROR: Requested paging link is not visible. Page number = " + pageId;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            catch (AssertionException assEx)
            {
                msg = "ERROR: " + assEx.Message;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            finally
            {
                //Console.WriteLine(msg + TestBase.msgNewLine);
            }
            return msg;
        }

        public static string ClickSearchResultAndValidate(int resNum, Regex regEx, string title, bool SearchInTitle)
        {
            string msg = "";
            string baseWindow = TestBase.WebDriver.CurrentWindowHandle;
            try
            {
                Console.WriteLine(">>> ClickSearchResultAndValidate({0}, {1}, {2}, {3})", resNum, regEx.ToString(), title, SearchInTitle.ToString());
                var wait = new WebDriverWait(TestBase.WebDriver, TimeSpan.FromSeconds(10));

                RemoteWebElement result =
                    (RemoteWebElement)TestBase.WebDriver.FindElement(By.XPath(TestBase.GoogleSearchResultXpathById(resNum)));

                Point hack = result.LocationOnScreenOnceScrolledIntoView;

                MouseOperations.SetCursorPosition(hack.X, hack.Y + TestBase.deltaY);

                result.Click();
                //Console.WriteLine("<<<<< Title text: " + result.Text);
                //wait.Until((d) => { return d.Title.StartsWith(result.Text); });


                ICollection<String> set = TestBase.WebDriver.WindowHandles;
                string newWindow = set.ToArray()[1];

                TestBase.WebDriver.SwitchTo().Window(newWindow);
                Console.WriteLine("<<<<< Title: " + TestBase.WebDriver.Title);
                Console.WriteLine("<<<<< Validation conditions: " + regEx.ToString());

                string src;
                if (SearchInTitle) src = TestBase.WebDriver.Title;
                else src = TestBase.WebDriver.PageSource;
                Match match = regEx.Match(src);

                if (match.Success)
                {
                    msg = TestBase.msgValidationPassed;
                    Console.WriteLine("<<<<< Position in page source: " + match.Index);
                }
                else
                {
                    msg = TestBase.msgValidationFailed;
                }
            }
            catch (NoSuchElementException)
            {
                msg = "ERROR: Requested result link does not exist. Result number = " + resNum;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            catch (ElementNotVisibleException)
            {
                msg = "ERROR: Requested result link is not visible. Result number = " + resNum;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            catch (AssertionException assEx)
            {
                msg = "ERROR: " + assEx.Message;
                Console.WriteLine(msg + TestBase.msgNewLine);
            }
            finally
            {
                TestBase.WebDriver.Close();
                TestBase.WebDriver.SwitchTo().Window(baseWindow);
            }
            return msg;
        }

        public static void ValidateSearchResults(Regex regEx, string title, bool searchInTitle)
        {
            int pageCounter = 0;
            try
            {
                Console.WriteLine(TestBase.msgValidationStarted);

                for (int j = 1; j < TestBase.maxValidationDepth + 1; j++)
                {
                    Console.WriteLine(">>>>> Validating page {0}", j);
                    for (int i = 1; i < TestBase.resultsPerPage + 1; i++)
                    {
                        string res = ClickSearchResultAndValidate(i, regEx, title, searchInTitle);
                        Console.WriteLine("<<<<< Validation result: " + res);
                        if (res == TestBase.msgValidationPassed)
                            pageCounter++;
                        if (pageCounter >= TestBase.resultTreshold) break;
                    }
                    if (pageCounter >= TestBase.resultTreshold)
                    {
                        pageCounter = 0;

                        string res1;
                        if (j < TestBase.maxValidationDepth)
                            res1 = ClickPageAndWaitForTitle(j + 1, title);
                        else res1 = TestBase.msgValidationPassed;

                        System.Threading.Thread.Sleep(10000);
                        Assert.AreEqual(TestBase.msgValidationPassed, res1);
                    }
                    else Assert.Fail(TestBase.msgExitCriteriaNotMet);
                }

            }
            catch (AssertionException assEx)
            {
                Assert.Fail(assEx.Message);
            }
        }
    }
}
