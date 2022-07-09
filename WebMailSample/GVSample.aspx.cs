using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMailSample
{
    public partial class GVSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            string SQL = @"select * from Supplies_Items";
            gv.DataSource = GetData(SQL);
            gv.DataBind();
        }

        private DataTable GetData(string strSQL)
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

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            bind(); //取資料   
        }
    }
}