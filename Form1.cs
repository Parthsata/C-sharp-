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

namespace Employe
{
    public partial class Form1 : Form
    {
        static Regex validate_emailaddress = email_validation();  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }


        private static Regex email_validation()
        {
                         string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
            Regex validate_emailaddress = email_validation();

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
           try
            {
                if (validate_emailaddress.IsMatch(textBox5.Text) != true)
                {
                    MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Focus();
                    return;
                }

               string sql = "insert into Employe values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox7.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.Emp);
                DataTable dt = new DataTable(); 
                da.Fill(dt);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                MessageBox.Show("Your Data Inserted !!");
                Display();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Enter valid Mobile number or salary");
            }
        }


        public void Display()
        {
            string Sql = "select * from Employe";
            SqlDataAdapter da = new SqlDataAdapter(Sql, Class1.Emp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
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

        private void btndel_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = "delete from Employe where Emp_id='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.Emp);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                MessageBox.Show("Your Data Deleted !!");
                Display();
                clear();
            }
            else
            {
                MessageBox.Show("No Data Found!!");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string sql ="update Employe set Emp_FName ='" + textBox2.Text + "', Emp_MName ='" + textBox3.Text + "', Emp_LName ='" + textBox4.Text + "', Email ='" + textBox5.Text + "', Contact_No ='" + textBox6.Text + "', Joining_date ='" + dateTimePicker1.Text + "', Salary ='" + textBox7.Text + "' where Emp_id='" + textBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql , Class1.Emp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            MessageBox.Show("Data Updated Successfully.");
            Display();
            clear();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

    }
}
