using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WalletLogin
{
    public class SeleniumHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public bool ElementExistById(ChromeDriver driver, string locator)
        {
            try
            {
                driver.FindElement(By.Id(locator));
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public bool ElementExistByClassName(ChromeDriver driver, string locator)
        {
            try
            {
                driver.FindElement(By.ClassName(locator));
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public bool ElementExistByXPath(ChromeDriver driver, string locator)
        {
            try
            {
                driver.FindElement(By.XPath(locator));
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }
    }
}

