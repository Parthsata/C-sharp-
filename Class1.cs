using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Employe
{
    class Class1
    {
        public static SqlConnection Emp = new SqlConnection( @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Parth sata\Employe\Employe\Emp_info.mdf;Integrated Security=True;User Instance=True");

        public static SqlConnection stud { get; set; }
    }
}
