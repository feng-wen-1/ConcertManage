using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 管理员登录 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string s = TextBox1.Text.Trim().ToString();
            string str = "select yqma from man where yqma='"+ s+"'";
            SqlCommand sqlcmd = new SqlCommand(str, conn);
            object temp = sqlcmd.ExecuteScalar();
            if(Convert.ToString(temp)=="")
            {
                Label1.Visible = true;
                Label1.Text = "邀请码无效!";
            }
            if(Convert.ToString(temp) != "")
            {
                Session["yqma"] = s;
                Response.Redirect("管理员注册.aspx");
            }
                
            conn.Close();
        }
    }
}