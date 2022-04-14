using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnimatedProgressIndicator
{
    public partial class MainForm : Form
    {
        private bool simulateError = false;

        public MainForm()
        {
            InitializeComponent();
            // set initial image
            this.pictureBox.Image = Properties.Resources.InformationImage;
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            // show animated image
            this.pictureBox.Image = Properties.Resources.AnimatedImage;
            // change button states
            this.buttonStart.Enabled = false;
            this.buttonCancel.Enabled = true;
            this.buttonError.Enabled = true;
            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            this.backgroundWorker.CancelAsync();
        }

        private void OnSimulateErrorClick(object sender, EventArgs e)
        {
            this.simulateError = true;
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (this.backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                // report progress
                this.backgroundWorker.ReportProgress(-1, string.Format("Performing step {0}...", i+1));
                // simulate operation step
                System.Threading.Thread.Sleep(rand.Next(100, 1000));
                if (this.simulateError)
                {
                    this.simulateError = false;
                    throw new Exception("Unexpected error!");
                }
            }
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                this.labelProgress.Text = (String) e.UserState;
            }
        }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // hide animation
            this.pictureBox.Image = null;
            // show result indication
            if (e.Cancelled)
            {
                this.labelProgress.Text = "Operation cancelled by the user!";
                this.pictureBox.Image = Properties.Resources.WarningImage;
            }
            else
            {
                if (e.Error != null)
                {
                    this.labelProgress.Text = "Operation failed: " + e.Error.Message;
                    this.pictureBox.Image = Properties.Resources.ErrorImage;
                }
                else
                {
                    this.labelProgress.Text = "Operation finished successfuly!";
                    this.pictureBox.Image = Properties.Resources.InformationImage;
                }
            }
            // restore button states
            this.buttonStart.Enabled = true;
            this.buttonCancel.Enabled = false;
            this.buttonError.Enabled = false;
        }
    }
}
