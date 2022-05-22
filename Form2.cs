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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int tmp = 0;
                tmp = Convert.ToInt32(textBox1.Text);
                if (tmp > 1 && tmp <656 )
                {
                    DataBank.N = Convert.ToInt32(textBox1.Text);
                    Hide();
                    Form3 fm3 = new Form3();
                    fm3.Show();
                }
                else
                {
                    MessageBox.Show("Количество уравнений должно быть от 2 до 655",
                                   "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information,
                                   MessageBoxDefaultButton.Button1,
                                   MessageBoxOptions.DefaultDesktopOnly);

                }

            }
            catch
            {
                MessageBox.Show("Введите количество уравнений",
                                "Сообщение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }

        }

            private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }
    }
}
