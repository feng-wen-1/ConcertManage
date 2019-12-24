using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 管理员注册 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string s1 = TextBox1.Text.Trim().ToString();
            string s2 = TextBox2.Text.Trim().ToString();
            string str = "update man set mzh='"+s1+"' where yqma='"+ Session["yqma"]+ "'  update man set mp='" + s2 + "' where yqma='" + Session["yqma"] + "'";
            SqlCommand sqlcmd = new SqlCommand(str, conn);
            object temp = sqlcmd.ExecuteScalar();
            conn.Close();
            Response.Redirect("管理员登录.aspx");
        }
    }
}