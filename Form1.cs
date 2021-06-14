using System;
using System.IO;
using System.Windows.Forms;

namespace Tlab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*C:\Users\Egor\source\repos\Tlab2\Resources\TextFile1.txt*/
            /*@"C:\Users\Egor\Desktop\Text1.txt"*/
            string[] lines = File.ReadAllLines(@"C:\Users\Egor\source\repos\Tlab2\Resources\Text1.txt");
            string[] values;
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('/');
                string[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j];
                }

                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[0, i].FormattedValue.ToString() == Searchbox.Text.Trim())
                {
                    dataGridView1.CurrentCell = dataGridView1[0, i];
                    return;
                }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                string[] lines = File.ReadAllLines(open.FileName);
                string[] values;
                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('/');
                    string[] row = new string[values.Length];
                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j];
                    }

                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            /*save.FileName = "unknown.txt";*/
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName, false, System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (i != 0)
                        {
                            sw.WriteLine("");
                        }
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                sw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");
                                if (j == 0)
                                    sw.Write("/");
                            }
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fp = new Form2();
            fp.ShowDialog();
        }
    }
}