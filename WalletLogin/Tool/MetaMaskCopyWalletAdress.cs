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
    public class MetaMaskCopyWalletAdress
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskCopyWalletAdress));
        private ConfigHelper configHelper = new ConfigHelper();
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();

        public void CopyWalletAdress()
        {
            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            string walletType = "Metamask";

            chromeHelper.NavigateURL(driver, walletType);

            Thread.Sleep(2000);

            //点击复制钱包地址按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[2]/div/div[2]/div/div"))
            {
                log.Info("准备复制钱包地址到剪贴板!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[2]/div/div[2]/div/div")).Click();
                log.Info("成功复制钱包地址到剪贴板!");
            }
            else
            {
                log.Error("找不钱包地址按钮!");
            }
        }
    }
}
