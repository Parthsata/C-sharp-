using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            string Sql = "select * from Employe_information";
            SqlDataAdapter da = new SqlDataAdapter(Sql, Emp.employe);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
        }

        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }


        private void btninsert_Click(object sender, EventArgs e)
        {

            Regex validate_emailaddress = email_validation();
            if (validate_emailaddress.IsMatch(textBox5.Text) != true)
            {
                MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                return;
            }
            

            if (textBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && dateTimePicker1.Value.ToString() != "" && textBox7.Text != "")
            {
                try
                {
                    string sql = "insert into Employe_information values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox7.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Emp.employe);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                    MessageBox.Show("Your Data Inserted !!");
                    Display();
                    clear();
                }catch(Exception ex){
                    MessageBox.Show("Please Enter valid Mobile Number !!");
                }
            }
            else
            {
                MessageBox.Show("Please Fill The Data For Insert!!");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = "delete from Employe_information where Emp_id='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Emp.employe);        
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                MessageBox.Show("Your Data Deleted !!");
                Display();
                clear();
            }
            else
            {
                MessageBox.Show("Please Select Data For Delete!!");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && dateTimePicker1.Value.ToString() != "" && textBox7.Text != "")
            {
                string sql = "update Employe_information set Emp_Name = '" + textBox2.Text + "',Emp_Mname = '" + textBox3.Text + "',Emp_Lname = '" + textBox4.Text + "',Email = '" + textBox5.Text + "',Contact_no = '" + textBox6.Text + "',Joining_date = '" + dateTimePicker1.Value.ToString() +"',Salary = '" + textBox7.Text + "' where Emp_id = '" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Emp.employe);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                MessageBox.Show("Data Updated Successfully.");
                Display();
                clear();
            }
            else
            {
                MessageBox.Show("Please Fill the Record !!");
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sql = "select * from Employe_information where Emp_id='" + textBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(Sql, Emp.employe);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count == 1)
            {
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox5.Text = dt.Rows[0][4].ToString();
                textBox6.Text = dt.Rows[0][5].ToString();
                dateTimePicker1.Text = dt.Rows[0][6].ToString();
                textBox7.Text = dt.Rows[0][7].ToString();
                
            }
            else
            {
                MessageBox.Show("No Such Record!");
                clear();
            }  
        } 

    }
}
