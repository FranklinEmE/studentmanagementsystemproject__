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
    public partial class Studentmanagement : Form
    {
        public Studentmanagement()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Data Source=localhost; Initial Catalog=sys; User Id=root; Password=frank#");
        MySqlCommand cmd;
        MySqlDataReader read;
        // SqlDataAdapter drr;

        string IDSTUDENT;
        bool mode = true;
        string sql;

        public void load()
        {

            try
            {

                sql = "select * from studentmanagement";
                cmd = new MySqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                //drr = new SqlDataAdapter(sql, con);
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6], read[7], read[8], read[9]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getID(String IDSTUDENT)
        {
            sql = "select * from studentmanagement where IDSTUDENT = '" + IDSTUDENT + "' ";

            cmd = new MySqlCommand(sql, con);
            con.Open();
            read = cmd.ExecuteReader();


            while (read.Read())
            {
            
                txtFirstName.Text = read[1].ToString();
                txtLastName.Text = read[2].ToString();
                txtGender.Text = read[3].ToString();
                txtAge.Text = read[4].ToString();
                txtAddress.Text = read[5].ToString();
                txtNationality.Text = read[6].ToString();
                txtCourse.Text = read[7].ToString();
                txtGrade.Text = read[8].ToString();
                txtFees.Text = read[9].ToString();

            }

            con.Close();
        }


        private void Studentmanagement_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void save(object sender, EventArgs e)
        {
           
       
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string course = txtCourse.Text;
            string gender = txtGender.Text;
            string nationality = txtNationality.Text;
            string grade = txtGrade.Text;
            string fees = txtFees.Text;
            string address = txtAddress.Text;
            string age = txtAge.Text;

            if (mode == true)
            {
                sql = "insert into studentmanagement(STUFIRSTNAME, STULASTNAME, STUCOURSE, STUGENDER, STUNATIONALITY, STUGRADE, STUFEES, STUADDRESS, STUAGE) values(@firstname, @lastname, @course, @gender, @nationality, @grade, @fees, @address, @age)";
                con.Open();
                cmd = new MySqlCommand(sql, con);
        
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@nationality", nationality);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@fees", fees);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@age", age);

                MessageBox.Show("Record Addddedddd");
                cmd.ExecuteNonQuery();

      
                txtFirstName.Clear();
                txtLastName.Clear();
                txtCourse.Clear();
                txtGender.Clear();
                txtNationality.Clear();
                txtGrade.Clear();
                txtFees.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                txtFirstName.Focus();
            }
            else
            {
                IDSTUDENT = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "update studentmanagement set IDSTUDENT = @IDSTUDENT, firstname = @firstname, lastname = @lastname, course = @course, gender = @gender, gender = @gender, nationality = @nationality, grade = @grade, fees = @fees, address = @address, age = @age  where IDSTUDENT = @IDSTUDENT";
                con.Open();
                cmd = new MySqlCommand(sql, con);
   
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@nationality", nationality);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@fees", fees);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@age", age);

                MessageBox.Show("Record Updatedddddd");
                cmd.ExecuteNonQuery();

                txtId.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtCourse.Clear();
                txtGender.Clear();
                txtNationality.Clear();
                txtGrade.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                txtFirstName.Focus();
                button1.Text = "Save";
                mode = true;


            }
            con.Close();
        }

        private void clear(object sender, EventArgs e)
        {
            
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCourse.Clear();
            txtGender.Clear();
            txtNationality.Clear();
            txtGrade.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtFirstName.Focus();
            button1.Text = "Save";
            mode = true;
        }

        private void refresh(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                mode = false;
                IDSTUDENT = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getID(IDSTUDENT);
                button1.Text = "Edit";
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                mode = false;
                IDSTUDENT = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "delete from studentmanagement where IDSTUDENT = @IDSTUDENT";
                con.Open();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IDSTUDENT", IDSTUDENT);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleteeeeeee");
                con.Close();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGender_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

