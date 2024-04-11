using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WalletLogin
{
    public class MetaMaskChangeNetwork
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MetaMaskChangeNetwork));
        private ConfigHelper configHelper = new ConfigHelper();
        private static SeleniumHelper seleniumHelper = new SeleniumHelper();

        public void ChangeNetwork()
        {
            var strNetworkType = configHelper.ReadConfig("NetworkType");
            NetworkType networkType = (NetworkType)Enum.Parse(typeof(NetworkType), strNetworkType);

            log.Info("读取网络类型枚举值成功：" + networkType);

            ChromeDriver driver = ChromeWindow.GetChromeDriver();

            ChromeHelper chromeHelper = new ChromeHelper();

            chromeHelper.NavigateURL(driver);

            Thread.Sleep(3000);

            //点击切换网络按钮
            if (seleniumHelper.ElementExistByXPath(driver, "//*[@id=\"app-content\"]/div/div[2]/div/div[1]/button"))
            {
                log.Info("准备点击切换网络按钮!");
                driver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[2]/div/div[1]/button")).Click();
                log.Info("点击切换网络按钮成功!");
            }
            else
            {
                log.Error("找不到切换网络按钮");
            }

            Thread.Sleep(4000);
            //根据枚举值选择网络
            switch (networkType)
            {
                case NetworkType.Ethereum:
                    ChangeToEth(driver);
                    break;
                case NetworkType.Linea:
                    ChangeToLinea(driver);
                    break;
                case NetworkType.zkSync:
                    ChangeToZkSync(driver);
                    break;
                case NetworkType.Arb:
                    ChangeToArb(driver);
                    break;
                case NetworkType.Op:
                    ChangeToOp(driver);
                    break;
                case NetworkType.Bsc:
                    ChangeToBsc(driver);
                    break;
                case NetworkType.Polygon:
                    ChangeToPolygon(driver);
                    break;
                case NetworkType.Avax:
                    ChangeToAvax(driver);
                    break;
                case NetworkType.opBNB:
                    ChangeToOpBNB(driver);
                    break;
                case NetworkType.Base:
                    ChangeToBase(driver);
                    break;
                case NetworkType.PolygonzkEVM:
                    ChangeToPolygonzkEVM(driver);
                    break;
                case NetworkType.zkFair:
                    ChangeToZkFair(driver);
                    break;
                case NetworkType.Holesky:
                    ChangeToHolesky(driver);
                    break;
                case NetworkType.Taiko:
                    ChangeToTaiko(driver);
                    break;
                case NetworkType.Sepolia:
                    ChangeToSepolia(driver);
                    break;
            }
        }

        //切换至ETH主网
        public void ChangeToEth(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[1]"))
            {
                log.Info("准备点击ETH网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[1]")).Click();
                log.Info("点击ETH网络按钮成功!");
            }
            else
            {
                log.Error("找不到ETH网络按钮");
            }
        }

        //切换至Linea
        public void ChangeToLinea(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[2]"))
            {
                log.Info("准备点击Linea网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[2]")).Click();
                log.Info("点击Linea网络按钮成功!");
            }
            else
            {
                log.Error("找不到Linea网络按钮");
            }
        }

        //切换至zkSync
        public void ChangeToZkSync(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[3]"))
            {
                log.Info("准备点击zkSync网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[3]")).Click();
                log.Info("点击zkSync网络按钮成功!");
            }
            else
            {
                log.Error("找不到zkSync网络按钮");
            }
        }

        //切换至Arb
        public void ChangeToArb(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[4]"))
            {
                log.Info("准备点击Arb网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[4]")).Click();
                log.Info("点击Arb网络按钮成功!");
            }
            else
            {
                log.Error("找不到Arb网络按钮");
            }
        }

        //切换至Op
        public void ChangeToOp(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[5]"))
            {
                log.Info("准备点击Op网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[5]")).Click();
                log.Info("点击Op网络按钮成功!");
            }
            else
            {
                log.Error("找不到Op网络按钮");
            }
        }

        //切换至Bsc
        public void ChangeToBsc(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[6]"))
            {
                log.Info("准备点击Bsc网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[6]")).Click();
                log.Info("点击Bsc网络按钮成功!");
            }
            else
            {
                log.Error("找不到Bsc网络按钮");
            }
        }

        //切换至Polygon
        public void ChangeToPolygon(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[7]"))
            {
                log.Info("准备点击Polygon网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[7]")).Click();
                log.Info("点击Polygon网络按钮成功!");
            }
            else
            {
                log.Error("找不到Polygon网络按钮");
            }
        }

        //切换至Avax
        public void ChangeToAvax(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[8]"))
            {
                log.Info("准备点击Avax网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[8]")).Click();
                log.Info("点击Avax网络按钮成功!");
            }
            else
            {
                log.Error("找不到Avax网络按钮");
            }
        }

        //切换至Base
        public void ChangeToBase(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[9]"))
            {
                log.Info("准备点击Base网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[9]")).Click();
                log.Info("点击Base网络按钮成功!");
            }
            else
            {
                log.Error("找不到Base网络按钮");
            }
        }

        //切换至Taiko
        public void ChangeToTaiko(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[10]"))
            {
                log.Info("准备点击Taiko网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[10]")).Click();
                log.Info("点击Taiko网络按钮成功!");
            }
            else
            {
                log.Error("找不到Taiko网络按钮");
            }
        }

        //切换至opBNB
        public void ChangeToOpBNB(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[11]"))
            {
                log.Info("准备点击opBNB网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[11]")).Click();
                log.Info("点击opBNB网络按钮成功!");
            }
            else
            {
                log.Error("找不到opBNB网络按钮");
            }
        }


        //切换至PolygonzkEVM
        public void ChangeToPolygonzkEVM(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[12]"))
            {
                log.Info("准备点击PolygonzkEVM网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[12]")).Click();
                log.Info("点击PolygonzkEVM网络按钮成功!");
            }
            else
            {
                log.Error("找不到PolygonzkEVM网络按钮");
            }
        }

        //切换至ZkFair
        public void ChangeToZkFair(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[13]"))
            {
                log.Info("准备点击zkFair网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[13]")).Click();
                log.Info("点击zkFair网络按钮成功!");
            }
            else
            {
                log.Error("找不到zkFair网络按钮");
            }
        }

        //切换至Holesky
        public void ChangeToHolesky(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[3]/div/div[19]"))
            {
                log.Info("准备点击Holesky网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[3]/div/div[19]")).Click();
                log.Info("点击Holesky网络按钮成功!");
            }
            else
            {
                log.Error("找不到Holesky网络按钮");
            }
        }

        //切换至Sepolia
        public void ChangeToSepolia(ChromeDriver driver)
        {
            if (seleniumHelper.ElementExistByXPath(driver, "/html/body/div[3]/div[3]/div/section/div[5]/div[1]"))
            {
                log.Info("准备点击Sepolia网络按钮!");
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/section/div[5]/div[1]")).Click();
                log.Info("点击Sepolia网络按钮成功!");
            }
            else
            {
                log.Error("找不到Sepolia网络按钮");
            }
        }
    }
}

