using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aurora.Configs.Param;
using Aurora.SignalR.Config;
using Aurora.SignalR.Hub;
using NLog;

namespace Aurora.SignalR.FrameConsole
{
    class Program
    {
        private static Logger m_Log = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            Arguments arguments = new Arguments(args);
            string entityName = arguments.HasParameter("name") ? arguments["name"] : Environment.MachineName;
            string mode = arguments.GetParameter<string>("mode");
            switch (mode)
            {
                case "server":
                    LaunchServer();
                    break;
                case "client":
                    LaunchClient(entityName);
                    break;
                default:
                    System.Console.WriteLine("No mode specified");
                    break;
            }
        }

        private static void LaunchClient(string entityName)
        {
            m_Log.Warn($">> Start Client {entityName}");
            
            SignalRConfig config = (SignalRConfig)System.Configuration.ConfigurationManager.GetSection("SignalR");
            Client.Client m_Client = new Client.Client(config);
            m_Client.Connected += ClientOnConnected;
            m_Client.Disconnected += ClientOnDisconnected;
            m_Log.Warn("<< Start Client");
            Thread.Sleep(1000);
            string connectionId = m_Client.InvokeMethod<string>("Register", entityName, 0).Result;
            Thread.Sleep(-1);
        }

        private static void ClientOnDisconnected()
        {
            m_Log.Warn($"** OnDisconnected");
        }

        private static void ClientOnConnected()
        {
            m_Log.Warn($"** OnConnected");
        }

        private static void LaunchServer()
        {
            m_Log.Warn(">> Start Broker");
            SignalRConfig config = (SignalRConfig)System.Configuration.ConfigurationManager.GetSection("SignalR");
            IDisposable m_BrokerServer = Service.Start(config);
            
            m_Log.Warn("<< Start Broker");
         
            Thread.Sleep(-1);
        }

    }
}
