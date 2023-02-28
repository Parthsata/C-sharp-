using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class Emp
    {
       public static SqlConnection employe = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\EMPLOYE.mdf;Integrated Security=True;User Instance=True");
    }
}
