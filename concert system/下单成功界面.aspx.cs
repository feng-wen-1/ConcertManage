using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class 下单成功界面 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = Session["oNO"].ToString();
            Label4.Text = "未发货";
            Label5.Text = Session["kuaidiNO"].ToString();

        }
           

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("订单信息页面.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hompage.aspx");
        }
    }
}