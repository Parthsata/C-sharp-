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

namespace CRUD_WITH_CLASS
{
    public partial class Form1 : Form
    {
        int rc = 0, rp = -1;
        int rollno = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qtype = "insert";
            string tblnm = "Stud";
            string values = textBox1.Text + "','" + textBox2.Text; 
            Class1.Crud(qtype, tblnm, values);

        }
        public void Display()
        {
            string Sql = "select * from Stud";
            SqlDataAdapter da = new SqlDataAdapter(Sql, Class1.pp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "update Stud set Name ='" + textBox2.Text + "' where Roll_No='" + textBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.pp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Data Updated Successfully.");
            Display();
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qtype = "Delete";
            string tblnm = "Stud";
            string values = textBox2.Text + "','" + textBox1.Text;
            Class1.Crud(qtype, tblnm, values);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rp = 0;
            Navigate();

        }
        public void Navigate()
        {
            try
            {
                string sql = "select *from Stud";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.pp);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rollno = dt.Rows.Count - 1;
                textBox1.Text = dt.Rows[rp][0].ToString();
                textBox2.Text = dt.Rows[rp][1].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No Data Found!!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string sql = "select *from Stud";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.pp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            textBox1.Text = dt.Rows[dt.Rows.Count - 1][0].ToString();
            textBox2.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rp != rollno)
            {
                rp = rp + 1;
                Navigate();
            }
            else
            {
                MessageBox.Show("No Data Found!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (rp > 0)
            {
                rp -= 1;
                Navigate();
            }
            else
            {
                MessageBox.Show("No Data Found!!");
            }
        }

    }
}
