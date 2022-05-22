using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SLAY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {

            Hide();
            Form2 fm2 = new Form2();
            fm2.Show();

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = @"Справка.pdf";
            process.Start();

        }

        private void закрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
