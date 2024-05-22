using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WalletLogin
{
    public class MetaMaskLogin
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskLogin));
        private ConfigHelper configHelper = new ConfigHelper();

        public void Login()
        {
            var password = configHelper.ReadConfig("MetaMaskPassword");

            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            string walletType = "Metamask";

            chromeHelper.NavigateURL(driver, walletType);

            log.Info("成功打开MetaMask钱包.");

            // 在打开页面后等待3秒钟
            Thread.Sleep(3000);

            var seleniumHelper = new SeleniumHelper();

            if (seleniumHelper.ElementExistById(driver, "password"))
            {
                log.Info("准备填写密码:");
                driver.FindElement(By.Id("password")).SendKeys(password);
            }
            else
            {
                log.Error("找不到登录密码框");
            }

            // 在打开页面后等待3秒钟
            Thread.Sleep(3000);

            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[2]/div/div/button"))
            {
                log.Info("准备点击登录按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[2]/div/div/button")).Click();
                log.Info("点击登录按钮成功!");
            }
            else
            {
                log.Error("找不到登录按钮");
            }
            chromeHelper.CloseChromeDriver(driver);
        }
    }
}

