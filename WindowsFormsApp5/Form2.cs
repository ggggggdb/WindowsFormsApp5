using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection con;
        int id = 0;
        public Form2(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            update();
        }
        void update()
        {
            string sql = "Select * from clients";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Адресс";
            dataGridView1.Columns[4].HeaderText = "Номер телефона";


        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != "" && textBox2.Text != "")
            {

                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO client (name,adress,phone) VALUES (:name,:adress,:phone)", con);
                com.Parameters.AddWithValue("name", textBox1.Text);
                com.Parameters.AddWithValue("adress", textBox2.Text);
                com.Parameters.AddWithValue("phone", textBox3.Text);
                com.ExecuteNonQuery();
                Close();
                update();
            }

            else
            {
                MessageBox.Show("Ti durik");
            }
        }
    }

}
