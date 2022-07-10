using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace WebMailSample
{
    public partial class MailPage : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBody.Text = "測試";
                txtSubject.Text = "測試";
                txtToMail.Text = "chunhsing0921@gmail.com";
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtSubject.Text = "";
            txtToMail.Text = "";
        }

        /// <summary>
        /// 發信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            #region 設定部分
            //smtp伺服器
            string host = System.Configuration.ConfigurationManager.AppSettings["mailServer"].ToString();
            //smtp port
            int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["mailServerPort"].ToString());
            //寄件者
            string mailfrom= System.Configuration.ConfigurationManager.AppSettings["mailfrom"].ToString();
            #endregion

            MailMessage MyMail = new MailMessage();
            MyMail.From = new System.Net.Mail.MailAddress(mailfrom);
            MyMail.To.Add(txtToMail.Text); //設定收件者Email
            //MyMail.Bcc.Add("密件副本的收件者Mail"); //加入密件副本的Mail          
            MyMail.Subject = txtSubject.Text;
            MyMail.Body = txtBody.Text; //設定信件內容
            MyMail.IsBodyHtml = true; //是否使用html格式
            #region 發信部分
            SmtpClient MySMTP = new SmtpClient(host,port);
            MySMTP.EnableSsl = true;
            #region SMTP 帳號與密碼#很重要，請寫在config或是非 前端葉面
            string account = "emptywu@myoffices.cc";
            string password = "hxW29!jwxV";
            #endregion
            
            MySMTP.Credentials = new System.Net.NetworkCredential(account, password);
            try
            {
                
                MySMTP.Send(MyMail);
                MyMail.Dispose(); //釋放資源
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('發信成功');",true);
                //this.GetType(), "test1", "function Hello1(){alert('這是Block');}", true

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                ex.ToString();
            }
            #endregion
        }
    }

   
}