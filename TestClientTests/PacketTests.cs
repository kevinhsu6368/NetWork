using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWNetwork;

namespace JWNetwork.Tests
{
    [TestClass()]
    public class PacketTests
    {
        [TestMethod()]
        public void RPCJson_PacketTest()
        {
            //Dictionary<string, string> datas = new Dictionary<string, string>();
            Hashtable datas = new Hashtable();
            datas.Add("Account", "Kevin");
            datas.Add("CheckPassword", "true");
            datas.Add("Password", "SDB");
            Packet p = new Packet("C2S_Login", datas, 0x00);
            byte[] bs = p.bsData;
            string json = Encoding.UTF8.GetString(bs);

        }
    }
}

namespace Tests
{
    [TestClass()]
    public class PacketTests
    {
        [TestMethod()]
        [Description("測試 Packet 建構子,基本資料是否正確")]
        public void PacketTest()
        {
            Packet p = new Packet(1000,new byte[] {01,02,03,04},00 ); // 4b + 1b + 1b + 2b(100) + 4b(01020304)
            Assert.AreEqual(p.packetLen, (uint)12);
            CollectionAssert.AreEqual(p.bsData, new byte[] { 0xe8, 0x03, 0x01,0x02, 0x03, 0x04 });

        }


        [TestMethod()]
        public void PacketTest2()
        {
            Packet p = new Packet(1000,new byte[] {01,02,03,04},PacketControl.DES3_ECB,5 );
            Assert.AreEqual(p.packetLen, actual: (uint)12);
            Assert.AreEqual(p.dataType,0x00);
            Assert.AreEqual(p.dataControl, 0x53);
            CollectionAssert.AreEqual(p.bsData, new byte[] {  0xe8, 0x03,
                                                              0x01, 0x02, 0x03, 0x04 });
            CollectionAssert.AreEqual(p.FullData, new byte[] {0x0c,0x00,0x00,0x00, // packet len
                                                              0x00,  // packet data type
                                                              0x53,  // packet data control
                                                              0xe8, 0x03, // packet data - msgID
                                                              0x01, 0x02, 0x03, 0x04 }); // packet data - data

        }

        [TestMethod()]
        public void PacketTest3()
        {
            Packet p = new Packet(1000, new byte[] { 01, 02, 03, 04 }, PacketControl.DES_CBC, 800);
            Assert.AreEqual(p.dataControl, 0x14); // high byte : key index 超過 0xF 將重置為 0x1
        }

         
    }
}