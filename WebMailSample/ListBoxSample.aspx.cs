using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMailSample
{
    public partial class ListBoxSample : System.Web.UI.Page
    {
        private List<Temp> GetTemp
        {
            get
            {
                return (List<Temp>)ViewState["temp"];
            }
            set
            {
                ViewState["temp"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                txt.Text = id;
                GetTemp = new List<Temp>();
                bindListBox();
            }
        }

        private void bindListBox()
        {
            string sql = "select cate_id,categraph from Supplies_Categraph";
            lb.DataSource = ClassLibrary.SqlHelper.GetData(sql);
            lb.DataTextField = "categraph";
            lb.DataValueField = "cate_id";
            lb.DataBind();
        }

        protected void rbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb.SelectionMode = rbMode.SelectedValue == "Single" ? ListSelectionMode.Single : ListSelectionMode.Multiple;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            for (var i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Selected)
                {
                    //判斷id是否存在
                    if (!GetTemp.Any(x => x._id.Equals(lb.Items[i].Value)))
                    {
                        GetTemp.Add(new Temp()
                        {
                            _id = lb.Items[i].Value,
                            _text = lb.Items[i].Text
                        });
                    }
                    txt.Text += lb.Items[i].Text + Environment.NewLine;
                }
            }

            //foreach (ListItem l in lb.Items)
            //{
            //    if (l.Selected)
            //    {
            //        txt.Text += l.Text + Environment.NewLine;
            //    }
            //}
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            foreach (ListItem l in lb.Items)
            {
                txt.Text += l.Text + Environment.NewLine;
            }
        }
    }
}