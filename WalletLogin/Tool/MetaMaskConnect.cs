using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletLogin
{
    public class MetaMaskConnect
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskConnect));
        private ConfigHelper configHelper = new ConfigHelper();
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();

        public void Connect()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            chromeHelper.NavigateURL(driver);

            driver.Navigate().Refresh();

            Thread.Sleep(5000);

            //点击下一步按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[1]/div/div[3]/div[2]/footer/button[2]"))
            {
                log.Info("准备下一步按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[1]/div/div[3]/div[2]/footer/button[2]")).Click();
                log.Info("点击下一步按钮成功!");
            }
            else
            {
                log.Error("找不到下一步按钮");
            }

            Thread.Sleep(5000);

            //点击链接按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[1]/div/div[3]/div[2]/footer/button[2]"))
            {
                log.Info("准备链接按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[1]/div/div[3]/div[2]/footer/button[2]")).Click();
                log.Info("点击链接按钮成功!");
            }
            else
            {
                log.Error("找不到链接按钮");
            }
        }
    }
}
