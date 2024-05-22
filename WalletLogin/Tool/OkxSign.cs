using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletLogin.Tool;

namespace WalletLogin
{
    public class OkxSign
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OkxSign));
        private ConfigHelper configHelper = new ConfigHelper();

        public void Sign()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            string walletType = "OKX";

            chromeHelper.NavigateURL(driver, walletType);

            Thread.Sleep(5000);

            var seleniumHelper = new SeleniumHelper();

            //点击确认按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div/div/div[5]/div/button[2]/span/div"))
            {
                log.Info("准备点击确认按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div[5]/div/button[2]/span/div")).Click();
                log.Info("点击确认按钮成功!");
            }
            else
            {
                log.Error("找不到确认按钮");
            }

            chromeHelper.CloseChromeDriver(driver);
        }
    }
}
