using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CRUD_WITH_CLASS
{
    class Class1
    {
        public static SqlConnection pp = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Stud_info.mdf;Integrated Security=True;User Instance=True");
        public static DataTable dt = new DataTable();

        public static void Crud(string qtype, string tblnm, string values)
        {
            string sql = "";

            if (qtype == "insert")
            {
                sql = "insert into " + tblnm + " values (' " + values + " ')";
            }

            if (qtype == "Delete")
            {
                 sql = "delete from " + tblnm + " where Roll_No='" + values + "'";
            }

            if (qtype == "Delete")
            {
                sql = "update " + tblnm + "set Name " + values + "'";

            }

            SqlDataAdapter da = new SqlDataAdapter(sql, pp);
            da.Fill(dt);
        }
      
    }
         
}
