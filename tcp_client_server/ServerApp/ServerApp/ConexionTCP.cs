using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp
{
    public class ConexionTCP
    {
        public TcpClient TCPClient;
        public StreamReader StreamReader;
        public StreamWriter StreamWriter;
        public Thread ReadThread;

        public delegate void DataCarrier(string data);
        public event DataCarrier OnDataRecieved;

        public delegate void DisconnectNotify();
        public event DisconnectNotify OnDisconnect;

        public delegate void ErrorCarrier(Exception e);
        public event ErrorCarrier OnError;

        public ConexionTCP(TcpClient client)
        {
            TCPClient = client;
            NetworkStream networkStream = client.GetStream();
            StreamReader = new StreamReader(networkStream);
            StreamWriter = new StreamWriter(networkStream);
        }

        public void EscribirMsj(string datos)
        {
            try
            {
                StreamWriter.Write(datos + "\0");
                StreamWriter.Flush();
            }
            catch (Exception e)
            {
                if (OnError != null)
                    OnError(e);
            }
        }
    }
}
