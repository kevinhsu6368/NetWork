using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 

namespace JWNetwork
{
    public class AsynchronousServer
    {
        public class ClientPacket
        {
            private ClientPacket()
            {
                
            }

            public ClientPacket(Client c, byte[] data)
            {
                this.c = c;
                this.data = new byte[data.Length];
                Array.Copy(data, 0,this.data, 0, data.Length);
            }
            public Client c;
            public byte[] data;
        }

        public static ManualResetEvent clientConnected = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        public bool isRunning = false;

        public int bindPort = 8888;
        public int acceptSize = 10;

        private TcpListener tcpServer = null;

        Queue<byte[]> lsRecvBytes = new Queue<byte[]>();

        Queue<ClientPacket> lsRecvClientPackets = new Queue<ClientPacket>();

        Thread t_ProcRecv ;//= new Thread(new ParameterizedThreadStart(DoProcRecv));

        private static void DoProcRecv(object obj)
        {
            AsynchronousServer server = (AsynchronousServer) obj;
            while (server.isRunning)
            {
                Thread.Sleep(100);
                if (server.lsRecvClientPackets.Count == 0)
                    continue;

                try
                {
                    ClientPacket p = server.lsRecvClientPackets.Dequeue();
                    Client c = p.c;
                    if (server.packetType == PacketType.Data) // json-utf8
                    {
                        string json = Encoding.UTF8.GetString(p.data);
                        Console.WriteLine(json);

                        // parser json 
                        string[] lsLines = json.Replace("\r\n", "\n").Replace("\n","").Split(',');
                        string function = "";
                        Dictionary<string,string> data = new Dictionary<string, string>();
                        foreach (var line in lsLines)
                        {
                            string[] ss = line.Replace("\"","").Split(':');
                            if (ss.Length != 2)
                                continue;
                            string key = ss[0].Trim(new [] {' ','\t','{','}'});
                            string value = ss[1].Trim(new[] { ' ', '\t' ,',','{','}'});
                            if (key == "Function")
                            {
                                function = value;
                            }
                            else
                            { 
                                data.Add(key,value);
                            }
                        }

                        NetEvent.OnRPCEvent callBack = server.lsRPCEvent[function];
                        if (callBack != null)
                            callBack(c,function, data);

      

                    }
                    else if (server.packetType == PacketType.HeaderAndData)
                    {
                        
                    }


                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                }



            }
        }

        /// 封包樣式
        /// </summary>
        public PacketType packetType = PacketType.Data;


        public void Start(int acceptSize, int bindPort)
        {
            this.acceptSize = acceptSize;
            this.bindPort = bindPort;
            this.tcpServer = new TcpListener(this.bindPort);
            tcpServer.Start(this.acceptSize);
            DoBeginAcceptSocket(tcpServer);

           
            t_ProcRecv = new Thread(new ParameterizedThreadStart(DoProcRecv));
            isRunning = true;
            t_ProcRecv.Start(this);
        }

        public void Stop()
        {
            if (!isRunning)
                return ;

            foreach (Client c in lsClient)
            {
                try
                {
                    c.socket.Shutdown(SocketShutdown.Both);
                    c.socket.Close();
                }
                catch (Exception ex)
                {
                    
                }

            }
            lsClient.Clear();

            try
            {
                tcpServer.Stop();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
            

            isRunning = false;
        }

        public Dictionary<UInt16, NetEvent.OnRawEvent> lsRawEvent = new Dictionary<UInt16, NetEvent.OnRawEvent>();

        public Dictionary<string, NetEvent.OnRPCEvent> lsRPCEvent = new Dictionary<string, NetEvent.OnRPCEvent>();

        public NetEvent.OnConnected onConnected = null;

        public NetEvent.OnDisconnected onDisconnected = null;

        public NetEvent.OnConnecteTimeout onConnecteTimeout = null;

        public NetEvent.OnAcceptClient onAcceptClient = null;

        public NetEvent.OnKillClient onKillClient = null;

        public bool RegRawEvent(NetEventBase target, UInt16 msgID, NetEvent.OnRawEvent callFunc)
        {
            try
            {
                target.server = this;
                lsRawEvent.Add(msgID, callFunc);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool RegRPCEvent(NetEventBase target, string funcName, NetEvent.OnRPCEvent callFunc)
        {
            try
            {
                target.server = this;
                
                lsRPCEvent.Add(funcName , callFunc);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void SendPacket(Client c,Packet p)
        {
            //Send(c,p.FullData);
            if (this.packetType == PacketType.Data)
            {
                Send(c,p.bsData);
            }
            else if (this.packetType == PacketType.HeaderAndData)
            {
                Send(c,p.FullData);
            }
        }

        public void SendPacket(Client c, UInt16 msgID, byte[] datas)
        {
            Packet p = new Packet(msgID, datas);
            SendPacket(c,p);
        }

        public void SendPacket(Client c, UInt16 msgID, byte[] datas, PacketControl control, UInt16 keyIndex)
        {
            Packet p = new Packet(msgID, datas, control, keyIndex);
            SendPacket(c,p);
        }

        /// <summary>
        /// 發送 RPC - JSON(utf8) 字串封包
        /// </summary>
        /// <param name="function"></param>
        /// <param name="data"></param>
        public void SendRPC(Client c,string function, Dictionary<string, string> data)
        {
            //Dictionary<string,string > loginData = new Dictionary<string, string>();
            //loginData.Add("Name","Kevin");
            //loginData.Add("Pwd", "12345");
            //SendRPC("Login", loginData);


            Packet p = new Packet(function, data, 0x00);
            SendPacket(c,p);

        }

        public void DeleteClients()
        {
            for (int i = 0; i < lsWillDeleteClient.Count; i++)
            {
                Client c = lsWillDeleteClient[i];
                lsClient.Remove(c);
                Console.WriteLine("Delete Client Object .. finished");
            }
            lsWillDeleteClient.Clear();
        }

        public void SendMsgToAll(string msg)
        {
            foreach (Client c in lsClient)
            {
                Send(c, msg);
            }
        }
        public void SendRawDataToAll(byte [] datas)
        {
            foreach (Client c in lsClient)
            {
                Send(c, datas);
            }
        }


        // Accept one client connection asynchronously.
        public void DoBeginAcceptSocket(TcpListener listener)
        {
            // Set the event to nonsignaled state.
            clientConnected.Reset();

            // Start to listen for connections from a client.
            Console.WriteLine("Waiting for a connection...");

            // Accept the connection. 
            // BeginAcceptSocket() creates the accepted socket.
            listener.BeginAcceptSocket(
                new AsyncCallback(DoAcceptSocketCallback), listener);
            // Wait until a connection is made and processed before 
            // continuing.
            //clientConnected.WaitOne();
        }

        public class Client
        {
            public static UInt32 count = 0;

            public Client(Socket s)
            {
                this.socket = s;
                this.playerID = ++count;
                try
                {
                    this.ip = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
                    this.connectID = ((IPEndPoint) socket.RemoteEndPoint).Port;
                }
                catch (Exception ex)
                {
                    
                }
                
            }

            public const int buffSize = 1024 * 10;//1024 * 10;
            public Socket socket;

            public byte[] recvBuff = new byte[buffSize];
            public StringBuilder sb_recv = new StringBuilder();

            public Queue<byte[]> lsRecvBytes = new Queue<byte[]>();


            public byte[] sendBuff = new byte[buffSize];
            public StringBuilder sb_send = new StringBuilder();

            public UInt32 playerID = 0;

            public bool isLogin = false;

            public string ip;

            public int connectID;


        }

        public List<Client> lsClient = new List<Client>();

        // Process the client connection.
        public void DoAcceptSocketCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            // End the operation and display the received data on the
            //console.
            try
            {
               /// if (!listener.Server.Connected)
               //     return;

                Socket clientSocket = listener.EndAcceptSocket(ar);
                Client c = new Client(clientSocket);
                lsClient.Add(c);
                if (onAcceptClient != null)
                    onAcceptClient(c);

                // Process the connection here. (Add the client to a 
                // server table, read data, etc.)
                Console.WriteLine("Client connected completed");

                // read
                clientSocket.BeginReceive(c.recvBuff, 0, Client.buffSize, 0, new AsyncCallback(DoRecvCallback), c);

                // send
                //clientSocket.BeginSend(c.sendBuff, 0, c.sendBuff.Length, 0, new AsyncCallback(DoSendCallback), c);

                // Signal the calling thread to continue.
                //clientConnected.Set();

                // next connecter
                DoBeginAcceptSocket(tcpServer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
        }


        public void Send(Client c, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.Unicode.GetBytes(data);

            Send(c, byteData);


            // Begin sending the data to the remote device.  
            //c.socket.BeginSend(byteData, 0, byteData.Length, 0,
            //    new AsyncCallback(DoSendCallback), c);
        }


        public void Send(Client c, byte[] buff)
        {
            // Begin sending the data to the remote device.  
            try
            {
                c.socket.BeginSend(buff, 0, buff.Length, 0,
                new AsyncCallback(DoSendCallback), c);
            }
            catch (SocketException es)
            {
                Console.WriteLine(es.ToString());
                DeleteClient(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*
        public static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        */

        public void DoSendCallback(IAsyncResult ar)
        {
            Client c = (Client)ar.AsyncState;
            if (c.socket.Connected == false)
                return;
            try
            {
                int bytesSent = c.socket.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
            }
            catch (SocketException es)
            {
                Console.WriteLine(es.ToString());
                DeleteClient(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //sendDone.Set();

        }

        

        public void DoRecvCallback(IAsyncResult ar)
        {
            Client c = (Client)ar.AsyncState;

            try
            {
                if (c.socket.Connected == false)
                    return;
                SocketError errCode;
                int read = c.socket.EndReceive(ar,out errCode);

                if (read > 0)
                {
                    //c.sb_recv.Append(Encoding.ASCII.GetString(c.recvBuff, 0, read));
                    string strContent = Encoding.Unicode.GetString(c.recvBuff, 0, read);
                    //strContent = c.sb_recv.ToString();

                    byte[] bsRead = new byte[read];
                    Array.Copy(c.recvBuff, bsRead, read);
                    Console.WriteLine("Read Raw Data = " + StringTools.Bin2Hex(bsRead));

                    Console.WriteLine(String.Format("Read {0} byte from socket" +
                                       "data = {1} ", read, strContent));

                    ClientPacket cp = new ClientPacket(c, bsRead);
                    this.lsRecvClientPackets.Enqueue(cp);

                    //lsRecvBytes.Enqueue();
                    // parser 
                    /*
                    byte[] data = bsRead;
                    if (data[5] == 0x00) // raw data
                    {
                        UInt32 len = BitConverter.ToUInt32(data, 0);

                        

                        byte [] packetData = new byte[data.Length-6];
                        Array.Copy(data,6,packetData,0,data.Length-6);

                        UInt16 msgID = BitConverter.ToUInt16(packetData,0);
                        byte [] msgData = new byte[packetData.Length-2];
                        Array.Copy(packetData,2,msgData,0,packetData.Length-2);

                        string str = Encoding.UTF8.GetString(msgData);

                        switch (msgID)
                        {
                            case 1000:
                                Console.WriteLine("User Login : " + str);
                                break;

                            case 1001:
                                Console.WriteLine("User Regist : " + str);
                                break;

                            default:
                                Console.WriteLine("unknow message(" + msgID.ToString() + ")" + str);
                                
                                break;
                        }


                    }
                    */
                    c.socket.BeginReceive(c.recvBuff, 0, Client.buffSize, 0,
                                             new AsyncCallback(DoRecvCallback), c);
                }
                else
                {
                    /*
                    if (c.sb_recv.Length > 1)
                    {
                        //All of the data has been read, so displays it to the console
                        string strContent;
                        strContent = c.sb_recv.ToString();
                        Console.WriteLine(String.Format("Read {0} byte from socket" +
                                           "data = {1} ", strContent.Length, strContent));
                    }
                    */
                    //c.socket.Close();
                    DeleteClient(c);
                }

                // parser 


            }
            catch (SocketException es)
            {
                Console.WriteLine(es.ToString());
                DeleteClient(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private List<Client> lsWillDeleteClient = new List<Client>();

        public void DeleteClient(Client c)
        {
            c.socket.Shutdown(SocketShutdown.Both);
            c.socket.Close();
            if (this.onKillClient != null)
                this.onKillClient(c);

            lsClient.Remove(c);
            //lsWillDeleteClient.Add(c);

            //this.timer1.Start();
        }
    }
}
