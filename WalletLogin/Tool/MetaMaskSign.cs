using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletLogin.Tool
{
    public class MetaMaskSign
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskSign));
        private ConfigHelper configHelper = new ConfigHelper();
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();

        public void Sign()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            chromeHelper.NavigateURL(driver);

            driver.Navigate().Refresh();

            Thread.Sleep(5000);

            //点击签名按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div[4]/footer/button[2]"))
            {
                log.Info("准备点击签名按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div[4]/footer/button[2]")).Click();
                log.Info("点击签名按钮成功!");
            }
            else
            {
                log.Error("找不到签名按钮");
            }
        }

        public void SignAndLogin()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            chromeHelper.NavigateURL(driver);

            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            //点击签名按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div[4]/footer/button[2]"))
            {
                log.Info("准备点击签名按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div[4]/footer/button[2]")).Click();
                log.Info("点击签名按钮成功!");
            }
            else
            {
                log.Error("找不到签名按钮");
            }

            Thread.Sleep(3000);

            //点击登录按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div[5]/footer/button[2]"))
            {
                log.Info("准备点击登录按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div[5]/footer/button[2]")).Click();
                log.Info("点击登录按钮成功!");
            }
            else
            {
                log.Error("找不到登录按钮");
            }
        }
    }
}
