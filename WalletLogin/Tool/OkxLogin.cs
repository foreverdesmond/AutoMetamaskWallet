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
    public class OkxLogin
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OkxLogin));
        private ConfigHelper configHelper = new ConfigHelper();

        public void Login()
        {
            var password = configHelper.ReadConfig("OKXPassword");

            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            string walletType = "OKX";

            chromeHelper.NavigateURL(driver, walletType);

            log.Info("成功打开OKX钱包.");

            // 在打开页面后等待2秒钟
            Thread.Sleep(2000);

            var seleniumHelper = new SeleniumHelper();

            List<string> passInputLists = new List<string>();
            passInputLists.Add("//*[@id=\"app\"]/div/div/div/div[3]/form/div[1]/div/div/div/div/div/input");

            foreach (var passInput in passInputLists) 
            {
                if (seleniumHelper.ElementExistByXPath(driver, passInput))
                {
                    log.Info("准备填写密码:");
                    driver.FindElement(By.XPath(passInput)).SendKeys(password);
                }
                else
                {
                    log.Error("找不到登录密码框");
                    chromeHelper.CloseChromeDriver(driver);
                }
            }
            

            // 在打开页面后等待2秒钟
            Thread.Sleep(2000);
            List<string> unlockBtnLists = new List<string>();
            unlockBtnLists.Add("//*[@id=\"app\"]/div/div/div/div[3]/form/div[2]/div/div/div/button");

            foreach (var unlockBtn in unlockBtnLists)
            {
                if (seleniumHelper.ElementExistByXPath(driver, unlockBtn))
                {
                    log.Info("准备点击登录按钮!");
                    driver.FindElement(By.XPath(unlockBtn)).Click();
                    log.Info("点击登录按钮成功!");
                }
                else
                {
                    log.Error("找不到登录按钮");
                    chromeHelper.CloseChromeDriver(driver);
                }

            }
            chromeHelper.CloseChromeDriver(driver);
        }
    }
}
