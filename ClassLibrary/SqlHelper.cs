using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SqlHelper
    {
        public static DataTable GetData(string strSQL)
        {
            DataTable dt = new DataTable();
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\SampleCode\WebMailSample\WebMailSample\App_Data\sample.mdf"";Integrated Security=True;Integrated Security=True";
            using (var conn = new SqlConnection(connstr))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (var cmd = new SqlCommand(strSQL, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
