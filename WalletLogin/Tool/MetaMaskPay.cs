using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WalletLogin
{
    public class MetaMaskPay
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskPay));
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();
        private ConfigHelper configHelper = new ConfigHelper();

        public void Pay()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            chromeHelper.NavigateURL(driver);

            Thread.Sleep(3000);

            //点击活动按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div/div/div[2]/div/ul/li[3]"))
            {
                log.Info("准备点击活动按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div/div/div[2]/div/ul/li[3]")).Click();
                log.Info("点击活动按钮成功!");
            }
            else
            {
                log.Error("找不到活动按钮");
            }

            Thread.Sleep(3000);

            //点击待批准按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div/div/div[2]/div/div/div/div/div/div"))
            {
                log.Info("准备点击待批准按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div/div/div[2]/div/div/div/div/div/div")).Click();
                log.Info("点击待批准按钮成功!");
            }
            else
            {
                log.Error("找不到待批准按钮!");
            }

            //根据配置判断是否自动支付
            bool autoPay = false;
            string strAutoPay=configHelper.ReadConfig("AutoPay");
            if (strAutoPay== "1")
            {
                autoPay = true;
            }
            if (autoPay)
            {
                Thread.Sleep(3000);

                //点击确认按钮
                if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div[3]/div[3]/footer/button[2]"))
                {
                    log.Info("准备点击确认按钮!");
                    driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div[3]/div[3]/footer/button[2]")).Click();
                    log.Info("点击确认按钮成功!");
                }
                else
                {
                    log.Error("找不到确认按钮!");
                }
            }
            
        }
    }
}
