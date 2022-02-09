using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        MySqlDataAdapter sqlDta = new MySqlDataAdapter();
        DataTable sqlDt = new DataTable();
        MySqlDataReader sqlRd;

        MySqlConnection con = new MySqlConnection("Data Source=local; Initial Catalog=sys; User Id=root; Password=frank#");
        MySqlCommand cmd;
        MySqlDataReader read;
        // SqlDataAdapter drr;

        string id;
        bool mode = true;
        string sql;

       

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Studentmanagement sa = new Studentmanagement();
            sa.Show();
        }
    }
}
