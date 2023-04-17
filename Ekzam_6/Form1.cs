using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ekzam_6
{
    public partial class Form1 : Form
    {

        Connecting connect = new Connecting();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();

            dataGridView1.Columns.Add("S1","Логин");
            dataGridView1.Columns.Add("S2", "Пароль");

            SqlCommand command = new SqlCommand("select * from USERS", connect.GetConnection());

            using (var reader = command.ExecuteReader()) 
            {

                while (reader.Read())
                {

                    dataGridView1.Rows.Add(reader["PASSWORD"].ToString(), reader["LOGIN"].ToString());

                }
            
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = "txt|*.txt";

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ) 
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "     ");
                    }

                    streamWriter.WriteLine();

                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");

                connect.Close();
            }
        }
    }
}
