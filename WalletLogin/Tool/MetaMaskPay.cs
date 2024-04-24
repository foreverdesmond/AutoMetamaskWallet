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

            string walletType = "Metamask";

            chromeHelper.NavigateURL(driver, walletType);

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
            string strAutoPay = configHelper.ReadConfig("AutoPay");
            string strGasLevel = configHelper.ReadConfig("GasLevel");
            if (strAutoPay == "1")
            {
                autoPay = true;
            }
            if (autoPay)
            {
                Thread.Sleep(3000);

                //GasLevel为1，直接支付
                if (strGasLevel == "1")
                {
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
                //GasLevel为0，调低Gas支付
                else
                {
                    //点击编辑gas按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[3]/div/div[3]/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/h6[1]/div/button"))
                    {
                        log.Info("准备点击编辑gas按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[3]/div/div[3]/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/h6[1]/div/button")).Click();
                        log.Info("点击编辑gas按钮成功!");
                    }
                    else
                    {
                        log.Error("找不到编辑gas按钮!");
                    }

                    Thread.Sleep(2000);

                    //点击小乌龟按钮
                    if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"popover-content\"]/div/div/section/div[2]/div/div/div[1]/button[1]"))
                    {
                        log.Info("准备点击小乌龟按钮!");
                        driver.FindElement(By.XPath("//*[@id=\"popover-content\"]/div/div/section/div[2]/div/div/div[1]/button[1]")).Click();
                        log.Info("点击小乌龟按钮成功!");
                    }
                    else
                    {
                        log.Error("找不到小乌龟按钮!");
                    }

                    Thread.Sleep(2000);

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
}
