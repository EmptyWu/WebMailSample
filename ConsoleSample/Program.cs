using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");


            //步驟大概如下

            #region 1. 取得收信者資料
            //今天=7/12 => 發信 今天>= 7/11 && 今天<=7/18 && 確認狀態=N
            #endregion

            //這邊可能用迴圈 開始
            #region 2.組出主旨跟信件內容
            #endregion

            #region 3.發信&寫紀錄，紀錄可放在sendmail 內做
            sendmail("收件者", "主旨", "內容");
            #endregion
            //這邊可能用迴圈 結束

            //=> 寫入LOG 收件者id ，mail ,建立日期
            //Console.ReadLine();
            /*
             * 1.WEB*
             * 增加搜尋
             * 存 流水號 
             * 多一個欄位 (有沒有收到信)
             * 
             * 2.資料庫
             *  5*收件人  => WEB => DB 7=>ROWS =>7個id
             * 流水號ID,單號, subject，body ，mail ,建立日期,截止日期,確認狀態
             *  
             * 3. 寄信 console
             * 7 封信 to 5個收件人 cc 主管
             * -DB=> 建立一個發信log (new Table)
             * 一天內未回覆 => 7/10 +1 =7/11  =>dDay=7/18
             * 今天=7/12 => 發信 今天>= 7/11 && 今天<=7/18 && 確認狀態=N
             * 今天=7/13 => 發信 今天>= 7/11 && 今天<=7/18 && 確認狀態=N
             * 今天=7/14 => 發信 今天>= 7/11 && 今天<=7/18 && 確認狀態=N
             * ...
              * 今天=7/19 => 不發信
             * DateTime.Now.ToString("yyyyMMdd")
             * 寄信成功=>寫DB=>log 
             * (insert into DB)
             * 
             * body
             * 請點選下列網址進行確認確認
             * http://web/checkmail.aspx?id=2333
             * GET 
             * 4. WEB
             * 取得ID後
             * if(今天日期>dDay==true) {
             *  alert("超過截止日");return ; 導頁到首頁}
             *  else {
             * 更新DB 狀態 ，update_datetime
             * }
             * 
             * 
             */
        }

        /// <summary>
        /// 發送mail
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        static void sendmail(string to ,string subject,string body)
        {
            #region 設定部分
            //smtp伺服器
            string host = System.Configuration.ConfigurationManager.AppSettings["mailServer"].ToString();
            //smtp port
            int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["mailServerPort"].ToString());
            //寄件者
            string mailfrom = System.Configuration.ConfigurationManager.AppSettings["mailfrom"].ToString();
            #region SMTP 帳號與密碼#很重要，請寫在config，修改會比較方便
            string account = System.Configuration.ConfigurationManager.AppSettings["maileServerID"].ToString();
            string password = System.Configuration.ConfigurationManager.AppSettings["maileServerPW"].ToString();
            #endregion
            #endregion

            MailMessage MyMail = new MailMessage();
            MyMail.From = new System.Net.Mail.MailAddress(mailfrom);
            MyMail.To.Add("收件者Email"); //設定收件者Email
            //MyMail.Bcc.Add("密件副本的收件者Mail"); //加入密件副本的Mail          
            MyMail.Subject = "主旨";
            MyMail.Body = "信件內容"; //設定信件內容
            MyMail.IsBodyHtml = true; //是否使用html格式
            #region 發信部分
            SmtpClient MySMTP = new SmtpClient(host, port);
            MySMTP.EnableSsl = true;
           

            MySMTP.Credentials = new System.Net.NetworkCredential(account, password);
            try
            {

                MySMTP.Send(MyMail);
                MyMail.Dispose(); //釋放資源
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('發信成功');", true);
                //this.GetType(), "test1", "function Hello1(){alert('這是Block');}", true

            }
            catch (Exception ex)
            {
                //錯誤的話要寫入log
                ex.ToString();
            }
            #endregion
        }
    }
}
