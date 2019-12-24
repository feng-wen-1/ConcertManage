using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 删除 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Button2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s1 = TextBox1.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            String str1 = "select CNAME from CONCERT1 where CNO = '" + s1 + "'";
            if (s1=="")
            {
                Label1.Visible = true;
                Label1.Text = "对不起，无此演唱会";
            }
            else
            {
                Button2.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String s2 = TextBox1.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            String str1 = "delete from CONCERT1 where CNO = '" + s2 + "'";
            SqlCommand sq1 = new SqlCommand(str1, conn);
            object text1 = sq1.ExecuteScalar();
        }
    }
}