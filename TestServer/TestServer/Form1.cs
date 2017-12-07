﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;

namespace TestServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            
            tcpServer.Start(10);
            DoBeginAcceptSocket(tcpServer);
        }

        public static ManualResetEvent clientConnected = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);


        TcpListener tcpServer = new TcpListener(8888);

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
            public Client(Socket s)
            {
                this.socket = s;
            }

            public const int buffSize = 1024*10;//1024 * 10;
            public Socket socket;

            public byte[] recvBuff = new byte[buffSize];
            public StringBuilder sb_recv = new StringBuilder();


            public byte[] sendBuff = new byte[buffSize];
            public StringBuilder sb_send = new StringBuilder();

            
        }

        public List<Client> lsClient = new List<Client>();

        // Process the client connection.
        public void DoAcceptSocketCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            // End the operation and display the received data on the
            //console.
            Socket clientSocket = listener.EndAcceptSocket(ar);
            Client c = new Client(clientSocket);
            lsClient.Add(c);

            // Process the connection here. (Add the client to a 
            // server table, read data, etc.)
            Console.WriteLine("Client connected completed");

            // read
            clientSocket.BeginReceive(c.recvBuff, 0, Client.buffSize,0 ,new AsyncCallback(DoRecvCallback), c);

            // send
            //clientSocket.BeginSend(c.sendBuff, 0, c.sendBuff.Length, 0, new AsyncCallback(DoSendCallback), c);

            // Signal the calling thread to continue.
            clientConnected.Set();

            // next connecter
            DoBeginAcceptSocket(tcpServer);
        }


        public void Send(Client c, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.Unicode.GetBytes(data);

            Send(c,byteData);


            // Begin sending the data to the remote device.  
            //c.socket.BeginSend(byteData, 0, byteData.Length, 0,
            //    new AsyncCallback(DoSendCallback), c);
        }


        public void Send(Client c,byte [] buff)
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

                int read = c.socket.EndReceive(ar);

                if (read > 0)
                {
                    //c.sb_recv.Append(Encoding.ASCII.GetString(c.recvBuff, 0, read));
                    string strContent = Encoding.Unicode.GetString(c.recvBuff, 0, read);
                    //strContent = c.sb_recv.ToString();

                    byte [] bsRead = new byte[read];
                    Array.Copy(c.recvBuff, bsRead, read);
                    Console.WriteLine("Read Raw Data = " + StringTools.Bin2Hex(bsRead));

                    Console.WriteLine(String.Format("Read {0} byte from socket" +
                                       "data = {1} ", read, strContent));

                    c.socket.BeginReceive(c.recvBuff, 0, Client.buffSize, 0,
                                             new AsyncCallback(DoRecvCallback), c);
                }
                else
                {
                    if (c.sb_recv.Length > 1)
                    {
                        //All of the data has been read, so displays it to the console
                        string strContent;
                        strContent = c.sb_recv.ToString();
                        Console.WriteLine(String.Format("Read {0} byte from socket" +
                                           "data = {1} ", strContent.Length, strContent));
                    }
                    //c.socket.Close();
                }
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
            //lsClient.Remove(c);
            lsWillDeleteClient.Add(c);
            this.timer1.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {

            foreach (Client c in lsClient)
            {
                c.socket.Close();
            }

            tcpServer.Stop();
            
        }

        private void btn_SendMSG_Click(object sender, EventArgs e)
        {
            string txt = this.txt_send.Text; // "這個是 Test !!!";
            
            foreach (Client c in lsClient)
            {
                Send(c, txt);
            }
        }

        private void btn_SendHex_Click(object sender, EventArgs e)
        {
            string txt = this.txt_sendHex.Text; // "這個是 Test !!!";

            byte[] bs = new byte[] { 0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a};

            foreach (Client c in lsClient)
            {
                Send(c, bs);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            for(int i=0;i<lsWillDeleteClient.Count;i++)
            {
                Client c = lsWillDeleteClient[i];
                lsClient.Remove(c);
                Console.WriteLine("Delete Client Object .. finished");
            }
            lsWillDeleteClient.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Type t = typeof(IBullHunterPlayer);
            PropertyInfo [] ps = t.GetProperties();
        }
    }
}
