using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace concert_system
{
    public partial class 管理员登录1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text.Trim().ToString();
            string s2 = TextBox2.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string str1 = "select * from man where mzh='"+s1+"'";
            string str2 = "select * from man where mzh='"+s1+"' and mp='"+s2+"'";
            SqlCommand sc1 = new SqlCommand(str1, conn);
            object t1 = sc1.ExecuteScalar();
            string x = Convert.ToString(t1);
            if (x == "")
            {
                Label1.Visible = true;
                Label1.Text = "账号或密码错误";
            }
            else if(x!="")
            {
                SqlCommand sc2 = new SqlCommand(str2, conn);
                object t2 = sc2.ExecuteScalar();
                string x2 = Convert.ToString(t2);
                if (x2 == "")
                {
                    Label1.Visible = true;
                    Label1.Text = "账号或密码错误";
                }
                else if (x2 != "")
                {
                    Session["mzh"] = s1;
                    Response.Redirect("管理员主页.aspx"); }
            }

        }
    }
}