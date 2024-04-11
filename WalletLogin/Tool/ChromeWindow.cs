using System;
using OpenQA.Selenium.Chrome;

namespace WalletLogin
{
    public class ChromeWindow
    {
        private static ChromeDriver driver;

        public static ChromeDriver GetChromeDriver()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();

                // 设置自定义的用户指纹
                //string customUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                //string customSEC_CH_UA_PLATFORM = "Windows+NT+10.0";
                //options.AddArgument($"--user-agent={customUserAgent}");

                // 设置本地已打开窗口调试
                options.DebuggerAddress = "localhost:9222";

                // 启动 Chrome 浏览器
                driver = new ChromeDriver(options);

            }
            return driver;
        }
    }
}

