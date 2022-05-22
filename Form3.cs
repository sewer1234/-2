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
using System.Drawing.Printing;

namespace SLAY
{
    public partial class Form3 : Form
    {

        public int N = Convert.ToInt32(DataBank.N);
        double delta, s, xx;
        public double[] result = new double[DataBank.N];
        double eps;
        public bool diagonal;

        double[,] A = new double[DataBank.N, DataBank.N];
        double[] b = new double[DataBank.N];
        double[] X = new double[DataBank.N];


        public Form3()
        {
            InitializeComponent();
        }

        public bool DiagonallyDominant()
        {
            double[,] A = new double[N, N];

            for (int i = 0; i < N; i++)
            {
                int t = 0;
                while (t < N)
                {
                    A[t, i] = Convert.ToDouble(dataGridView1[t, i].Value);
                    t++;

                }

            }

            for (int i = 0; i < N; i++)
            {
                double s = 0;
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        s += Math.Abs(A[j, i]);
                    }
                }
                if (Math.Abs(A[i, i]) >= s)
                {
                    diagonal = true;
                    break;
                }
                else
                {
                    diagonal = false;
                }
            }
            return diagonal;
        }


        private void button5_Click(object sender, EventArgs e)
        {

            Hide();
            Form1 fm1 = new Form1();
            fm1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int r = 0; r < X.Length; r++)
                {
                    X[r] = 0;
                }

                try
                {
                    int t = 0, w;

                    while (t < b.Length)
                    {
                        b[t] = Convert.ToDouble(dataGridView2[0, t].Value);
                        t++;
                    }
                    for (w = 0; w < N; w++)
                    {
                        t = 0;
                        while (t < N)
                        {
                            A[t, w] = Convert.ToDouble(dataGridView1[t, w].Value);
                            t++;

                        }

                    }

                }
                catch
                {
                    MessageBox.Show("Введите коэффициенты при Х и свободные значения!",
                                         "Сообщение",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information,
                                         MessageBoxDefaultButton.Button1,
                                         MessageBoxOptions.DefaultDesktopOnly);

                }


                try
                {
                    eps = 0.1;
                    delta = 1;
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            eps = 0.1;
                            break;
                        case 1:
                            eps = 0.01;
                            break;
                        case 2:
                            eps = 0.001;
                            break;
                        case 3:
                            eps = 0.0001;
                            break;
                        case 4:
                            eps = 0.00001;
                            break;
                        case 5:
                            eps = 0.000001;
                            break;
                        case 6:
                            eps = 0.0000001;
                            break;
                        case 7:
                            eps = 0.00000001;
                            break;
                        case 8:
                            eps = 0.000000001;
                            break;
                    }



                }
                catch
                {
                    MessageBox.Show("Введите точность корректно!",
                   "Сообщение",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
                }
                int NN = N - 2;
                int rew;
                for (int fn = 0; fn < NN; fn++)
                {
                    double[] lz1 = new double[N];
                    double[] lz2 = new double[N];

                    for (int wer = 0; wer < N; wer++)
                    {
                        lz1[wer] = Convert.ToDouble(dataGridView1[wer, fn].Value);
                    }

                    for (int ff = fn+1; ff < N; ff++)
                    {           
                        for ( rew = 0; rew < N; rew++)
                        {
                             lz2[rew] = Convert.ToDouble(dataGridView1[rew, ff].Value);
                        }

                        if ( lz2.SequenceEqual(lz1) )
                            
                        {
                            for (int gh = 0; gh < N; gh++)
                            {
                                dataGridView1[gh, fn].Style.BackColor = Color.Blue;
                                dataGridView1[gh, ff].Style.BackColor = Color.Blue;
                            }
                            
                        }

                    }
                }


                int n = N;

                    bool IsDiagonal = DiagonallyDominant();
                    if (IsDiagonal == false)
                    {


                        DialogResult resualt = MessageBox.Show("Матрица не обладает диагональным преобладанием, возможно решение не будет найдено или найдено с ошибкой! Продолжить?",
                                        "Внимание",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information);
                        if (resualt == DialogResult.Yes)
                        {


                            while (delta >= eps)
                            {
                                textBox1.Text += "\r\n" + "Итерация " + (n - N + 1) + "\r\n";

                                for (int i = 0; i < N; i++)
                                {
                                    s = 0;

                                    for (int j = 0; j < N; j++)
                                    {
                                        if (i != j)
                                        {
                                            s = s + A[j, i] * X[j];
                                        }
                                    }

                                    xx = ((b[i] - s) / A[i, i]);
                                    delta = Math.Abs(xx - X[i]);
                                    textBox1.Text += "\r\n" + "X" + (i + 1) + " = " + xx + "    " + "e" + (i + 1) + "= " + delta + "\r\n";
                                    X[i] = xx;
                                    result[i] = xx;

                                }
                                n++;
                            }

                            dataGridView3.RowCount = N;
                            dataGridView3.ColumnCount = N;

                            dataGridView3.Columns[0].HeaderCell.Value = "Ответ";

                            for (int i = 0; i < N; i++)
                            {
                                dataGridView3.Rows[i].HeaderCell.Value = "X" + (1 + i) + "=";
                                dataGridView3[0, i].Value = result[i];

                            }
                        }
                    }
                    else
                    {

                        while (delta >= eps)
                        {
                            textBox1.Text += "\r\n" + "Итерация " + (n - N + 1) + "\r\n";

                            for (int i = 0; i < N; i++)
                            {
                                s = 0;

                                for (int j = 0; j < N; j++)
                                {
                                    if (i != j)
                                    {
                                        s = s + A[j, i] * X[j];
                                    }
                                }

                                xx = ((b[i] - s) / A[i, i]);
                                delta = Math.Abs(xx - X[i]);
                                textBox1.Text += "\r\n" + "X" + (i + 1) + " = " + xx + "    " + "e" + (i + 1) + "= " + delta + "\r\n";
                                X[i] = xx;
                                result[i] = xx;
                            }
                            n++;
                        }

                        dataGridView3.RowCount = N;
                        dataGridView3.ColumnCount = N;

                        dataGridView3.Columns[0].HeaderCell.Value = "Ответ";

                        for (int z = 0; z < N; z++)
                        {
                            dataGridView3.Rows[z].HeaderCell.Value = "X" + (1 + z) + "=";
                            dataGridView3[0, z].Value = result[z];

                        }

                    }


                }
            
            catch
            {

                MessageBox.Show("Произошла ошибка при вычислении, пожалуйста, проверьте введенные данные и побробуйте снова!",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information,
                                     MessageBoxDefaultButton.Button1,
                                     MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int t = 0, w;

            while (t < b.Length)
            {
                dataGridView2[0, t].Value = rand.NextDouble() * (300 + 100) - 100;
                t++;
            }
            for (w = 0; w < N; w++)
            {
                t = 0;
                while (t < N)
                {
                    dataGridView1[t, w].Value = rand.NextDouble() * (300 + 100) - 100;
                    t++;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 fm2 = new Form2();
            fm2.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowCount = N;
                dataGridView1.ColumnCount = N;
                dataGridView2.RowCount = N;
                dataGridView2.ColumnCount = 1;

                int j = 0;
                dataGridView2.Columns[0].HeaderCell.Value = "b";

                for (int i = 0; i < N; i++)
                {
                    dataGridView1.Columns[i].HeaderCell.Value = "X" + (i + 1);
                    dataGridView1.Rows[j].HeaderCell.Value = (j + 1) + ")";
                    dataGridView2.Rows[j].HeaderCell.Value = j + 1 + ")";
                    j++;
                }

            }
            catch
            {

            }


        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        private void очиститьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            for (int i = 0; i < N; i++)
            {
                dataGridView2[0, i].Value = null;
                dataGridView3[0, i].Value = null;
                b[i] = 0;
                X[i] = 0;


            }
            for (int i = 0; i < N; i++)
            {
                int j = 0;
                while (j < N)
                {
                    dataGridView1[i, j].Value = null;
                    A[i, j] = 0;
                    j++;

                }

            }
            textBox1.Text = null;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void открытьМратицуАToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 0;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;IMEX=1';";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.Close();
            con.Dispose();
            dataGridView1.DataSource = dt;
        }

        private void открытьМатрицуBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView2.RowCount = 0;
            dataGridView2.ColumnCount = 0;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;IMEX=1';";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.Close();
            con.Dispose();
            dataGridView2.DataSource = dt;
        }

        private void справкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = @"Справка.pdf";
            process.Start();
        }

        private void закрытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}
