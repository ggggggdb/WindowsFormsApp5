using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.DataFormats;
using Microsoft.SqlServer.Server;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        NpgsqlConnection con;
        public Form1()
        {
            InitializeComponent();
            con = new NpgsqlConnection("Server = localhost;Port=5432;User Id=postgres;Password=MLG_HocK_135;DataBase=sqlharp");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2(con);
            f1.ShowDialog();
        }
    }
}
