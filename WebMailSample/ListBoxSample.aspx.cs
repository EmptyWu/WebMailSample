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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            lb.SelectionMode = rbMode.SelectedValue == "Single"? ListSelectionMode.Single: ListSelectionMode.Multiple;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            foreach (ListItem l in lb.Items)
            {
                if (l.Selected)
                {
                    txt.Text += l.Text + Environment.NewLine;
                }
            }
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