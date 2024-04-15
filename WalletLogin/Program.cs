using System.Configuration;
using log4net;
using WalletLogin;
using Microsoft.Extensions.Configuration;
using WalletLogin.Tool;

public class Program
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    static void Main(string[] args)
    {
        //load Log4net
        try
        {
            string logFilePath = "C:\\Projects\\WalletLogin\\WalletLogin\\log4net.config";
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logFilePath));
            log.Info("log4net initialized successfully.");
        }
        catch (Exception ex)
        {
            log.Error(ex);
        }

        try
        {
            //登录
            //var metamaskLogin = new MetaMaskLogin();
            //metamaskLogin.Login();

            //链接钱包
            var metamaskConnect = new MetaMaskConnect();
            metamaskConnect.Connect();
                      
            //签名
            var metamaskSign = new MetaMaskSign();
            metamaskSign.SignAndLogin();

            //切换网络
            //var metamaskChangeNetwork = new MetaMaskChangeNetwork();
            //metamaskChangeNetwork.ChangeNetwork();

            //支付
            //var metamaskPay = new MetaMaskPay();
            //metamaskPay.Pay();
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
}
