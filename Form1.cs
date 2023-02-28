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

namespace WindowsFormsApplication17
{
    public partial class Form1 : Form
    {

     
        public Form1()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            string qtype = "insert";
            string tblnm = "stud_info";
            string values = textbox1.Text + textBox2.Text ;
            divA.Crud(qtype,tblnm,values);
            
        }
        public void loaddata()
        {
            string Sql = "select * from stud_info";
            SqlDataAdapter da = new SqlDataAdapter(Sql, divA.pp);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddata();
        }
      
    }
}
