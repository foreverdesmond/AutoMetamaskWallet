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
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskLogin));
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

            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div[3]/form/div[1]/div/div/div/div/div/input"))
            {
                log.Info("准备填写密码:");
                driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div[3]/form/div[1]/div/div/div/div/div/input")).SendKeys(password);
            }
            else
            {
                log.Error("找不到登录密码框");
            }

            // 在打开页面后等待2秒钟
            Thread.Sleep(2000);

            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div[3]/form/div[2]/div/div/div/button"))
            {
                log.Info("准备点击登录按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div[3]/form/div[2]/div/div/div/button")).Click();
                log.Info("点击登录按钮成功!");
            }
            else
            {
                log.Error("找不到登录按钮");
            }
        }
    }
}
