using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 修改用户mim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s1 = TextBox1.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            String str1 = "select UPS from yonghu where UNO = '" + s1 + "'";
            String str2 = "select UN from yonghu where UNO ='" + s1 + "'";
            SqlCommand sq1 = new SqlCommand(str1, conn);
            SqlCommand sq2 = new SqlCommand(str2, conn);
            object text1 = sq1.ExecuteScalar();
            object text2 = sq2.ExecuteScalar();
            String x1 = Convert.ToString(text1);
            String x2 = Convert.ToString(text2);
            if (s1 == "")
            {
                Label3.Visible = true;
            }
            else
            {
                Label1.Visible = true;
                Label2.Visible = true;
                Button2.Visible = true;
                TextBox2.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label2.Text = x1;
                Label5.Text = x2;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String s2 = TextBox2.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            String str2 = "update yonghu set UPS ='" + s2 + "' where UNO ='"+ TextBox1.Text.Trim().ToString() + "'";
            SqlCommand sq2 = new SqlCommand(str2, conn);
            object text2 = sq2.ExecuteScalar();
        }
    }
}