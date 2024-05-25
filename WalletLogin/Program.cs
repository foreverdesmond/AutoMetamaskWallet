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
            //Metamask登录
            //var metamaskLogin = new MetaMaskLogin();
            //metamaskLogin.Login();

            //链接钱包
            //var metamaskConnect = new MetaMaskConnect();
            //metamaskConnect.Connect();

            //签名
            //var metamaskSign = new MetaMaskSign();
            //metamaskSign.SignAndLogin();

            //切换网络
            //var metamaskChangeNetwork = new MetaMaskChangeNetwork();
            //metamaskChangeNetwork.ChangeNetwork();

            //支付
            //var metamaskPay = new MetaMaskPay();
            //metamaskPay.Pay();

            //复制钱包地址
            //var metamaskCopyWalletAdress = new MetaMaskCopyWalletAdress();
            //metamaskCopyWalletAdress.CopyWalletAdress();

            //OKX登录
            var okxLogin = new OkxLogin();
            okxLogin.Login();

            //OKX链接钱包
            //var okxConncet = new OkxConnect();
            //okxConncet.Connect();

            //OKX签名
            //var okxSign = new OkxSign();
            //okxSign.Sign();

            //OKX支付
            //var okxPay = new OkxPay();
            //okxPay.Pay();

            //OKX确认
            //var okxConfrim = new OKConfirm();
            //okxConfrim.Confirm();            
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
}
