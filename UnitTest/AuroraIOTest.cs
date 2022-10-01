using System;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Threading;
using Aurora.IO.NamedPipe;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AuroraUnitTestLegacy
{
    [TestClass]
    public class AuroraIOTest
    {
        private const string pipeName = "Samadhi_Pipeline";

        private void InitServer()
        {
            Server<string[]> srv = new Server<string[]>(pipeName);
            srv.Start();
            srv.ClientMessageReceived += SrvOnClientMessageReceived;
        }

        private void ClientSent(params string[] data)
        {
            Client<string[]> clnt = new Client<string[]>(pipeName);
            if (clnt.Start())
            {
                clnt.Send(data);
                clnt.Stop();
            }
        }
        [TestMethod]
        public void TestClient()
        {
            ClientSent(@"c:\log\Safe\Ba.Configß.log", @"c:\log\Safe\Ba.AdminBrokerä.log");
            Thread.Sleep(3000);
            ClientSent(@"c:\log\Safe\Ba.Config1.log", @"c:\log\Safe\Ba.AdminBroker1.log");
        }
        [TestMethod]
        public void TestAll()
        {
            InitServer();
            TestClient();            
            Thread.Sleep(-1);
        }

        [TestMethod]
        public void TestServer()
        {
            InitServer();
            
            Thread.Sleep(-1);
        }

        private void SrvOnClientMessageReceived(string[] message)
        {
            foreach(var element in message)
                Console.WriteLine(element);
        }
        
    }
}
