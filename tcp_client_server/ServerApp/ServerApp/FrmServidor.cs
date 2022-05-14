using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class FrmServidor : Form
    {
        public delegate void ClientCarrier(ConexionTCP conexionTcp);
        public event ClientCarrier OnClientConnected;
        public event ClientCarrier OnClientDisconnected;
        public delegate void DataRecieved(ConexionTCP conexionTCP, string data);
        public event DataRecieved OnDataRecieved;
        private List<ConexionTCP> connectedClients = new List<ConexionTCP>();

        public FrmServidor()
        {
            InitializeComponent();
        }

        private void FrmServidor_Load(object sender, EventArgs e)
        {
            CreateTCPServer();
        }

        private void CreateTCPServer()
        {
            OnDataRecieved += MensajeRecibido;
            OnClientConnected += ConexionRecibida;
            OnClientDisconnected += ConexionCerrada;

            Thread thread = new Thread(new ThreadStart(StartTCPServer));
            thread.Start();
        }

        private void StartTCPServer()
        {
            IPAddress local = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(local, 15810);
            listener.Start();

            while (true) // Enter the listening loop.
            {
                TcpClient client = listener.AcceptTcpClient();
                Socket socket = listener.AcceptSocket();

                var srvClient = new ConexionTCP(client)
                {
                    ReadThread = new Thread(LeerDatos)
                };

                srvClient.ReadThread.Start(srvClient);

                if (OnClientConnected != null)
                    OnClientConnected(srvClient);



                Thread thread = new Thread(LeerDatos);
                thread.Start();
            }
        }

        private void MensajeRecibido(ConexionTCP conexionTcp, string datos)
        {
            string cadenaTexto = datos;
            //var paquete = new Paquete(datos);
            //string comando = paquete.Comando;
            //if (comando == "login")
            //{
            //    string contenido = paquete.Contenido;
            //    List<string> valores = Mapa.Deserializar(contenido);

            //Invoke(new Action(() => textBox1.Text = valores[0]));
            //Invoke(new Action(() => textBox2.Text = valores[1]));

            //var msgPack = new Paquete("resultado", "OK");
            //    conexionTcp.EnviarPaquete(msgPack);
            //}
            //if (comando == "insertar")
            //{
            //    string contenido = paquete.Contenido;
            //List<string> valores = Mapa.Deserializar(contenido);
            //usuariosTableAdapter.Insert(valores[0], valores[1]);
            //var msgPack = new Paquete("resultado", "Registros en SQL: OK");
            conexionTcp.EscribirMsj("Ok: " + datos);
            //}
        }

        private void ConexionRecibida(ConexionTCP conexionTcp)
        {
            //lock (connectedClients)
            //    if (!connectedClients.Contains(conexionTcp))
            //        connectedClients.Add(conexionTcp);
            //Invoke(new Action(() => label1.Text = string.Format("Clientes: {0}", connectedClients.Count)));
        }

        private void ConexionCerrada(ConexionTCP conexionTcp)
        {
            //lock (connectedClients)
            //    if (connectedClients.Contains(conexionTcp))
            //    {
            //        int cliIndex = connectedClients.IndexOf(conexionTcp);
            //        connectedClients.RemoveAt(cliIndex);
            //    }
            //Invoke(new Action(() => label1.Text = string.Format("Clientes: {0}", connectedClients.Count)));
        }


        private void LeerDatos(object client)
        {
            var cli = client as Socket;

            do
            {
                if (cli == null) break;

                var socketStream = new NetworkStream(cli);

                var StreamReader = new StreamReader(socketStream);
                var StreamWriter = new StreamWriter(socketStream);

                //var escritor = new BinaryWriter(socketStream);
                //var lector = new BinaryReader(socketStream);

                //var micadena = lector.ReadString();
                var micadena = StreamReader.ReadToEnd();

            } while (true);

            //var cli = client as ConexionTCP;
            //var charBuffer = new List<int>();

            //do
            //{
            //    try
            //    {
            //        if (cli == null)
            //            break;
            //        if (cli.StreamReader.EndOfStream)
            //            break;
            //        int charCode = cli.StreamReader.Read();
            //        if (charCode == -1)
            //            break;
            //        if (charCode != 0)
            //        {
            //            charBuffer.Add(charCode);
            //            continue;
            //        }
            //        if (OnDataRecieved != null)
            //        {
            //            var chars = new char[charBuffer.Count];
            //            //Convert all the character codes to their representable characters
            //            for (int i = 0; i < charBuffer.Count; i++)
            //            {
            //                chars[i] = Convert.ToChar(charBuffer[i]);
            //            }
            //            //Convert the character array to a string
            //            var message = new string(chars);

            //            //Invoke our event
            //            OnDataRecieved(cli, message);
            //        }
            //        charBuffer.Clear();
            //    }
            //    catch (IOException)
            //    {
            //        break;
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message.ToString());

            //        break;
            //    }
            //} while (true);

            //if (OnClientDisconnected != null)
            //    OnClientDisconnected(cli);
        }
    }
}
