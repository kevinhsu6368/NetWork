
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms.Layout;

public class NetEvent
{
    public NetEvent()
    {
        
    }

    public delegate void OnRawEvent(UInt16 msgID, byte [] datas);

    public delegate void OnRPCEvent(string functionName, Dictionary<string, string> datas);

}

public interface IRawEvent
{
    void OnRawEvent(UInt16 msgID, byte[] datas);

}

public interface IRPCEvent
{
    void OnRPCEvent(string functionName, Dictionary<string, string> datas);
}

public abstract class NetEventBase //: IRPCEvent, IRawEvent
{
    public NetEventBase()
    {
        onRawEvent = OnRawEvent;
        onRpcEvent = onRpcEvent;
    }

    public NetEvent.OnRawEvent onRawEvent;
    public NetEvent.OnRPCEvent onRpcEvent;
    public abstract void OnRPCEvent(string functionName, Dictionary<string, string> datas);
    

    public abstract void OnRawEvent(ushort msgID, byte[] datas);
 
}


public class Packet
{
    public enum PacketControl
    {        
        NONE = 0,
        DES_ECB = 1,
        DES2_ECB = 2,
        DES3_ECB = 3,
        DES_CBC = 4,
        DES2_CBC = 5,
        DES3_CBC = 6   
    }

    public Packet()
    {
        
    }

    #region Header

    public UInt32 packetLen;

    /// <summary>
    /// 封包資料格式
    ///     0x00: raw bytes data
    ///     0x01: utf8-json
    ///     0x02: utf8-xml
    /// </summary>
    public byte dataType;

    /// <summary>
    /// 加密控制碼
    /// Low byte:
    ///     0:不加密
    ///     1:DES-ECB
    ///     2:2DES-ECB
    ///     3:3DES-ECB
    ///     4:DES-CBC
    ///     5:2DES-CBC 
    ///     6:3DES-CBC
    /// High byte: key index
    ///     1 ~ F
    /// </summary>
    public byte dataControl = 0x00; // 8 個 byte ,保留字元
    #endregion

    #region Data
   
    // raw data
    public byte[] bsData;

    #endregion

    private void Update()
    {
        this.packetLen = (UInt16)(4 + 1 + 1 + this.bsData.Length);
    }

    public Packet(UInt16 msgID, byte[] datas, byte control)
    {
        this.dataType = 0x00;
        this.dataControl = control; 

        this.bsData = new byte[2 + datas.Length];
        byte[] bsMsgID = BitConverter.GetBytes(msgID);
        Array.Copy(bsMsgID, 0, bsData, 0, 2);
        Array.Copy(datas, 0, bsData, 2, datas.Length);
        Update();
    }

    public Packet(UInt16 msgID, byte[] datas, PacketControl control , uint keyIndex)
    {
        this.dataType = 0x00;

        if (keyIndex > 0x0F)
            keyIndex = 1; // 無效 key index , 改使用預設第一把 key
        

        this.dataControl =  (byte)((keyIndex<<4) + (int)control);

        this.bsData = new byte[2 + datas.Length];
        byte[] bsMsgID = BitConverter.GetBytes(msgID);
        Array.Copy(bsMsgID, 0, bsData, 0, 2);
        Array.Copy(datas, 0, bsData, 2, datas.Length);
        Update();
    }


    public Packet(string functionName, Dictionary<string, string> datas , byte control)
    {
        Update();
    }


    public byte[] FullData
    {
        get
        {
            byte[] bs = new byte[/*header*/ 4 + 1 + 1 + /*data*/ bsData.Length];

            byte[] bLen = BitConverter.GetBytes(this.packetLen);
            Array.Copy(bLen, 0, bs, 0, bLen.Length);

            bs[4] = dataType;
            bs[5] = dataControl;

            Array.Copy(bsData, 0, bs, 6, bsData.Length);

            return bs;
        }

    }

 
}

// State object for receiving data from remote device.  
public class StateObject
{
    // Client socket.  
    public Socket workSocket = null;

    // Size of receive buffer.  
    public const int BufferSize = 1024;

    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];

    // Received data string.  
    public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient
{
    // The port number for the remote device.  
    private const int port = 11000;

    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);

    // The response from the remote device.  
    private String response = String.Empty;
    private Socket client = null;

    public void Start(String ip,int port)
    {
        // Connect to a remote device.  
        try
        {
            if (client != null)
                return;

            // Establish the remote endpoint for the socket.  
            // The name of the   
            // remote device is "host.contoso.com".  
            //IPHostEntry ipHostInfo = Dns.Resolve("localhost");
            //ipHostInfo.AddressList[0];
            IPAddress ipAddress = IPAddress.Parse(ip); 
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.  
            client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();

            /*
            // Send test data to the remote device.  
            Send(client, "hello kevin !<EOF>");
            sendDone.WaitOne();


            // Send test data to the remote device.  
            Send(client, "This is a test<EOF>");
            sendDone.WaitOne();


            // Receive the response from the remote device.  
            Receive(client);
            receiveDone.WaitOne();

            // Write the response to the console.  
            Console.WriteLine("Response received : {0}", response);

            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            */

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public Dictionary<UInt16, NetEvent.OnRawEvent> lsRawEvent = new Dictionary<UInt16, NetEvent.OnRawEvent>();
    public Dictionary<string, NetEvent.OnRPCEvent> lsRPCEvent = new Dictionary<string, NetEvent.OnRPCEvent>();



    public bool RegRawEvent(UInt16 msgID, NetEvent.OnRawEvent callFunc)
    {
        try
        {
            lsRawEvent.Add(msgID, callFunc);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public bool RegRPCEvent(string funcName, NetEvent.OnRPCEvent callFunc)
    {
        try
        {
            lsRPCEvent.Add(funcName + "1", callFunc);
            lsRPCEvent.Add(funcName + "2", callFunc);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

     


    public void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.  
            connectDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Receive(Socket client)
    {
        try
        {
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.  
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket   
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);

                //receiveDone.Set();
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.  
                //receiveDone.Set();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Send(Socket client, String data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.Unicode.GetBytes(data);

        // Begin sending the data to the remote device.  
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    public void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.  
            //sendDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Send(string msg)
    {
        if (client == null)
            return;

        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.Unicode.GetBytes(msg);

        Send(byteData);

    }

    public void Send(byte [] buff)
    {
        if (client == null)
            return;

        // Begin sending the data to the remote device.  
        client.BeginSend(buff, 0, buff.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    public void Close()
    {
        client.Shutdown(SocketShutdown.Both);
        client.Close();
        client = null;
    }
 
}