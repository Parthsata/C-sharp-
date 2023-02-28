using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApplication17
{
    
    class divA
    {

        public static SqlConnection pp = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\project.mdf;Integrated Security=True;User Instance=True");
       public  static DataTable dt = new DataTable();

       public static void Crud(string qtype, string tblnm, string values)
       {
           string sql = "";
           if (qtype == "insert")
           {
               sql = "insert into" + tblnm + "values('" + values + "')" ; 
           }

           SqlDataAdapter da = new SqlDataAdapter(sql, pp);
           da.Fill(dt);   
           
       }
    }
}
