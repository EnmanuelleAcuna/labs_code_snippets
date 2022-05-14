using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class FrmCliente : Form
    {
        public static ConexionTCP conexionTCP = new ConexionTCP();
        public static string IPADDRESS = "127.0.0.1";
        public const int PORT = 15810;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            conexionTCP.OnDataRecieved += MensajeRecibido;

            bool conectado = conexionTCP.Connectar(IPADDRESS, PORT);

            if (conectado)
            {
                LblResultados.Text = "Conectado";
            }
            else
            {
                MessageBox.Show("Error conectando con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (conexionTCP.TCPClient.Connected)
            {
                conexionTCP.EscribirMsj(textBox1.Text);
            }
        }

        private void MensajeRecibido(string datos)
        {
            Invoke(new Action(() => LblResultados.Text = string.Format("Respuesta: {0}", datos)));
        }

        private void ClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
