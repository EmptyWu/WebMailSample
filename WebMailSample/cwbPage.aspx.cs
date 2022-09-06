using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Helper;
using Newtonsoft.Json.Linq;

namespace WebMailSample
{
    public partial class cwbPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cwbauthCode = "CWB-DC966CC8-937B-471A-9D0D-619ADA34EE64";
                cwbHelper cwb = new cwbHelper();
                var cwbdata = cwb.getJson($"https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?&Authorization={cwbauthCode}");
                foreach (JObject data in cwbdata)
                {
                    string loactionname = (string)data["locationName"]; //地名
                    string weathdescrible = (string)data["weatherElement"][0]["time"][0]["parameter"]["parameterName"]; //天氣狀況
                    string pop = (string)data["weatherElement"][1]["time"][0]["parameter"]["parameterName"];  //降雨機率
                    string mintemperature = (string)data["weatherElement"][2]["time"][0]["parameter"]["parameterName"]; //最低溫度
                    string maxtemperature = (string)data["weatherElement"][4]["time"][0]["parameter"]["parameterName"]; //最高溫度
                    string str=$"{loactionname}天氣:{ weathdescrible } 溫度:{ mintemperature }°c-{ maxtemperature }°c 降雨機率:{ pop }%";
                    Response.Write($"{str}<BR>");
                }
            }
        }
    }
}