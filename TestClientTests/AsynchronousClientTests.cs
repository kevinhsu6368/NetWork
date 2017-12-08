using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWNetwork;
using TestClient;


namespace Tests
{
    [TestClass()]
    public class AsynchronousClientTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegRawEventTest()
        {
            AsynchronousClient c = new AsynchronousClient();

            Login login = new Login("kevin", "123");
            c.RegRawEvent(1000, login.onRawEvent);
            Assert.AreEqual(1, c.lsRawEvent.Count);

            Login login2 = new Login("test", "555");
            c.RegRawEvent(2000, login2.onRawEvent);
            Assert.AreEqual(2, c.lsRawEvent.Count);
            //c.lsRawEvent.Count
        }


        [TestMethod()]
        public void RegRPCEventTest()
        {
            AsynchronousClient c = new AsynchronousClient();
            Login login = new Login("111","222");
            c.RegRPCEvent("Login", login.onRpcEvent);

            Assert.AreEqual(1,c.lsRPCEvent.Count);
        }


        [TestMethod()]
        public void ConnectCallbackTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReceiveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReceiveCallbackTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendCallbackTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CloseTest()
        {
            Assert.Fail();
        }


    }
}