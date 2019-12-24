using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 管理员个人信息 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            unxiugai();
            Label4.Text = Session["mzh"].ToString();
            Label6.Visible = false;
        }
        void unxiugai()
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Label2.Visible = false;
            Label1.Visible = false;
            Label3.Visible = false;
            Label5.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
        }
        void xiugai()
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button1.Visible = false;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("管理员主页.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            xiugai();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            unxiugai();
            Button1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string str = "select mp from man where mzh='" + Session["mzh"].ToString() + "'";
            SqlCommand sc = new SqlCommand(str, conn);
            object pass = sc.ExecuteScalar();
            string ss = "update man set mp='"+TextBox2.Text.Trim().ToString()+"'";
            string s = pass.ToString();
            if(s.Trim().ToString()!=TextBox1.Text.Trim().ToString())
            {
                Label5.Visible = true;
                Label5.Text = "密码错误";
                xiugai();
            }
            if(s.Trim().ToString() == TextBox1.Text.Trim().ToString())
            {
                Label5.Visible = false;
                if(TextBox2.Text.Trim().ToString()!=TextBox3.Text.Trim().ToString())
                {
                    Label6.Visible = true;
                    Label6.Text = "两次密码不一致！";
                }
                else if (TextBox2.Text.Trim().ToString() == TextBox3.Text.Trim().ToString())
                {
                    Label6.Visible = false;
                    SqlCommand c = new SqlCommand(ss, conn);
                    object c1 = c.ExecuteScalar();
                    Session["b"] = "3";
                    Response.Redirect("成功.aspx");
                }
            }
            conn.Close();
        }
    }
}