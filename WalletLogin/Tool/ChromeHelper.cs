﻿using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Diagnostics;

namespace WalletLogin
{
    public class ChromeHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ChromeHelper));
        private ConfigHelper configHelper = new ConfigHelper();

        public void NavigateURL(ChromeDriver driver, string walletType)
        {
            string targetUrl = string.Empty;
            // 根据钱包类型定义要打开的页面URL
            switch (walletType)
            {
                case "Metamask":
                    targetUrl = configHelper.ReadConfig("MetamaskWalletAdress");
                    break;
                case "OKX":
                    targetUrl = configHelper.ReadConfig("OKXWalletAdress");
                    break;
                default:
                    targetUrl = configHelper.ReadConfig("MetamaskWalletAdress");
                    break;
            }

            // 获取当前浏览器窗口中所有打开的窗口句柄
            List<string> windowHandles = new List<string>(driver.WindowHandles);

            // 是否找到目标页面的标志
            bool foundTargetPage = false;

            // 遍历所有窗口句柄，查找是否已经打开了目标页面
            foreach (string handle in windowHandles)
            {
                // 切换到当前窗口
                driver.SwitchTo().Window(handle);

                // 获取当前窗口中的页面URL
                string currentUrl = driver.Url;

                // 判断当前页面是钱包页面
                if (currentUrl.Contains(targetUrl))
                {
                    foundTargetPage = true;
                    break;
                }
            }

            // 如果找到了钱包页面，则使用已经打开的钱包页面
            if (foundTargetPage)
            {
                log.Info("已存在钱包页面。");
            }
            else
            {
                if (walletType == "Metamask")
                {
                    string newPageUrl = "chrome://new-tab-page/";
                    // 遍历所有窗口句柄，查找空白新页面
                    foreach (string handle in windowHandles)
                    {
                        // 切换到当前窗口
                        driver.SwitchTo().Window(handle);

                        // 获取当前窗口中的页面URL
                        string currentUrl = driver.Url;

                        // 判断当前页面是否是空页面
                        if (currentUrl == newPageUrl)
                        {
                            log.Info("没有找到钱包页面，将在" + newPageUrl + "新打开页面：" + targetUrl);
                            driver.Navigate().GoToUrl(targetUrl);
                        }
                    }
                }
                else
                {
                    log.Info("没有找到钱包页面");
                }
            }
        }

        public void NavigateURL(ChromeDriver driver, string walletType, string targetUrl)
        {
            // 获取当前浏览器窗口中所有打开的窗口句柄
            List<string> windowHandles = new List<string>(driver.WindowHandles);

            // 是否找到目标页面的标志
            bool foundTargetPage = false;

            // 遍历所有窗口句柄，查找是否已经打开了目标页面
            foreach (string handle in windowHandles)
            {
                // 切换到当前窗口
                driver.SwitchTo().Window(handle);

                // 获取当前窗口中的页面URL
                string currentUrl = driver.Url;

                // 判断当前页面是钱包页面
                if (currentUrl.Contains(targetUrl))
                {
                    foundTargetPage = true;
                    break;
                }
            }

            // 如果找到了钱包页面，则使用已经打开的钱包页面
            if (foundTargetPage)
            {
                log.Info("已存在钱包页面。");
            }
            else
            {
                string newPageUrl = "chrome://new-tab-page/";
                // 遍历所有窗口句柄，查找空白新页面
                foreach (string handle in windowHandles)
                {
                    // 切换到当前窗口
                    driver.SwitchTo().Window(handle);

                    // 获取当前窗口中的页面URL
                    string currentUrl = driver.Url;

                    // 判断当前页面是否是空页面
                    if (currentUrl == newPageUrl)
                    {
                        log.Info("没有找到钱包页面，将在" + newPageUrl + "新打开页面：" + targetUrl);
                        driver.Navigate().GoToUrl(targetUrl);
                    }
                }
            }
        }

        public void CloseChromeDriver(ChromeDriver driver)
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
              log.Error("关闭 ChromeDriver 进程时出现异常：" + ex.Message);
            }
        }
    }
}

