using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMailSample
{
    public partial class uploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 假資料
            List<drp1Data> drp1data = new List<drp1Data>();
            drp1data.Add(new drp1Data { id = "", name = "請選擇" });
            drp1data.Add(new drp1Data { id = "1", name = "測試1" });
            drp1data.Add(new drp1Data { id = "2", name = "測試2" });
            //List<drp2Data> drp2data = new List<drp2Data>();
            //drp2data.Add(new drp2Data { drp1id = "1", id = "1", text= "子測試1+1" });
            //drp2data.Add(new drp2Data { drp1id = "1", id = "2", text = "子測試1+2" });
            //drp2data.Add(new drp2Data { drp1id = "1", id = "3", text = "子測試1+3" });

            //drp2data.Add(new drp2Data { drp1id = "2", id = "4", text = "子測試1+4" });
            //drp2data.Add(new drp2Data { drp1id = "2", id = "5", text = "子測試1+5" });
            //drp2data.Add(new drp2Data { drp1id = "2", id = "6", text = "子測試1+6" });
            #endregion

            if (!IsPostBack)
            {
                drp1.DataSource = drp1data;
                drp1.DataValueField = "id";
                drp1.DataTextField = "name";
                drp1.DataBind();
            }
        }

        protected void drp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<drp2Data> drp2data = new List<drp2Data>();
            drp2data.Add(new drp2Data { drp1id="",id = "", text = "請選擇" });

            drp2data.Add(new drp2Data { drp1id = "1", id = "1", text = "子測試1+1" });
            drp2data.Add(new drp2Data { drp1id = "1", id = "2", text = "子測試1+2" });
            drp2data.Add(new drp2Data { drp1id = "1", id = "3", text = "子測試1+3" });

            drp2data.Add(new drp2Data { drp1id = "2", id = "4", text = "子測試1+4" });
            drp2data.Add(new drp2Data { drp1id = "2", id = "5", text = "子測試1+5" });
            drp2data.Add(new drp2Data { drp1id = "2", id = "6", text = "子測試1+6" });
            string drpid = drp1.SelectedValue;
            drp2.DataSource = drp2data.Where(x => x.drp1id.Equals(drpid));
            drp2.DataValueField = "id";
            drp2.DataTextField = "text";
            drp2.DataBind();
        }
    }

    public class drp1Data {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class drp2Data
    {
        public string drp1id { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }
}