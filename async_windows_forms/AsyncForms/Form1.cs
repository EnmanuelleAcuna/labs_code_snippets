using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e) {
            LlamarMetodo();
            LblEstado.Text = "Ejecutando...";
            progressBar1.Show();
        }

        private async void LlamarMetodo() {
            string Saludo = await SaludarAsync("Amélie");
            LblSaludo.Text = Saludo;
            LblEstado.Text = "Listo...";
            progressBar1.Hide();
        }

        private Task<string> SaludarAsync(string Nombre) {
            Task<string> Tarea = Task.Factory.StartNew(() => Saludar(Nombre));
            return Tarea;
        }

        private string Saludar(string Nombre) {
            Thread.Sleep(10000);
            string Saludo = string.Format("Hola {0}", Nombre);
            return Saludo;
        }
    }
}
