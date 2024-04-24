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
    public class OkxPay
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OkxPay));
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();
        private ConfigHelper configHelper = new ConfigHelper();

        public void Pay()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            string walletType = "OKX";

            chromeHelper.NavigateURL(driver, walletType);

            Thread.Sleep(2000);

            //根据配置判断是否自动支付
            bool autoPay = false;
            string strAutoPay = configHelper.ReadConfig("AutoPay");
            string strGasLevel = configHelper.ReadConfig("GasLevel");
            if (strAutoPay == "1")
            {
                autoPay = true;
            }

            if (autoPay)
            {
                Thread.Sleep(2000);

                //GasLevel为1，直接支付
                if (strGasLevel == "1")
                {
                    //点击确认按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div/div/div[7]/div"))
                    {
                        log.Info("准备点击确认按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div[7]/div")).Click();
                        log.Info("点击确认按钮成功!");
                    }
                    else
                    {
                        log.Error("找不到确认按钮!");
                    }
                }
                //GasLevel为0，调低Gas支付
                else
                {
                    //点击编辑gas按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div/div/div[3]/div/div/div[2]"))
                    {
                        log.Info("准备点击编辑gas按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div[3]/div/div/div[2]")).Click();
                        log.Info("点击编辑gas按钮成功!");
                    }
                    else
                    {
                        log.Error("找不到编辑gas按钮!");
                    }

                    Thread.Sleep(2000);

                    //点击慢速按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div[2]/div[2]/div[1]/div[1]"))
                    {
                        log.Info("准备点击慢速按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[2]/div[1]/div[1]")).Click();
                        log.Info("点击慢速按钮成功!");
                    }
                    else
                    {
                        log.Error("找不到慢速按钮!");
                    }

                    Thread.Sleep(2000);
                    //点击确认按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app\"]/div/div/div/div/div/div[7]/div"))
                    {
                        log.Info("准备点击确认按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/div/div/div[7]/div")).Click();
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
}
