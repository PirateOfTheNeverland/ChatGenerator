using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChatGenerator
{
    public static class TestBase
    {
        private static IWebDriver webDriver;

        public const int deltaX = 30;
        public const int deltaY = 65;

        public const int maxValidationDepth = 3;
        public const int resultsPerPage = 10;
        public const int resultTreshold = 3;

        public const string baseUrl = "http://pofig.livetex.ru";
        public const string advancedSearchUrl = "http://www.google.ru/advanced_search";
        public const string titleBase = "Site for testing purposes";
        public const string titleStable = "Stable\n\ncheck";


        #region IDs
        public const string idInputStableSiteId = "stable_id";
        //public const string id

        public const string idListRenewalDate = "as_qdr_button";
        public const string idListOccuranceType = "as_occt_button";
        public const string idTxtAdvancedSearchORQuery = "as_oq";
        public const string idTxtRegularSearchQuery = "q";
        public const string idTxtRegularSearchQueryUpdated = "lst-ib";
        #endregion

        #region Console messages
        public static string msgActualResult = "Actual result: ";

        public static string msgException = "Exception occured: ";
        public static string msgExitCriteriaNotMet = "Test exit criteria have not been met\r\n";
        public static string msgExpectedResult = "Expected result: ";

        public static string msgNewLine = "\r\n";

        public static string msgTearDownStart = "TearDown script started\r\n";
        public static string msgTearDownEnd = "TearDown script has finished\r\n";

        public static string msgTestPreparationStart = "Test preparation block started\r\n";
        public static string msgTestPreparationEnd = "Test preparation block has finished\r\n";

        public static string msgValidationFailed = "Validation has failed\r\n";
        public static string msgValidationFinished = "Validation has finished\r\n";
        public static string msgValidationPassed = "ValidationPassed";
        public static string msgValidationPointReached = "Validation point reached\r\n";
        public static string msgValidationStarted = "Validation started\r\n"; 
                        
        #endregion

        public static void CleanGarbage()
        { 
            TestBase.WebDriver.Quit();
            webDriver = null;
        }

        public static IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = new ChromeDriver();
                }

                return webDriver;
            }
        }

        public static string SearchQueryCompose(string first, string second, string third)
        {
            return first + " " + second + " " + third;
        }

        public static string SearchQueryCompose(string first, string second, string third, string separator)
        {
            return first + separator + second + separator + third;
        }

        public static string SearchQueryMakeFixed(string query)
        {
            return "\"" + query + "\"";
        }

        public static string GooglePagingComposePageXpathById(int pageNum)
        {
            return "//table[@id='nav']/tbody/tr/td[" + (pageNum+1) + "]/a";//"//a[contains(text(),'" + pageNum + "')]";
        }

        public static string GoogleSearchResultXpathById(int resNum)
        {
            return "//li[" + resNum + "]/div/h3/a";
        }

        public static string GoogleSearchSuggestionXpathById(int sugNum)
        {
            return "//li[" + sugNum + "]/div/div[2]";
        }
    }
}
