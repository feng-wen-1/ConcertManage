using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 更新物流信息 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            DropDownList1.Visible = false;
            TextBox2.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Button2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string s = TextBox1.Text.Trim().ToString();
            string str = "select * from ed where eno='"+s+"'";
            SqlCommand sqlcmd = new SqlCommand(str, conn);
            object temp = sqlcmd.ExecuteScalar();
            if(temp.ToString()=="")
            {
                Label3.Visible = true;
                Label3.Text = "订单不存在！";
            }
            if(temp.ToString()!="")
            {
                Label1.Visible = true;
                Label2.Visible = true;
                TextBox2.Visible = true;
                DropDownList1.Visible = true;
                Button2.Visible = true;
                string s1 = "select cstatus from ed where eno='"+s+"'";
                string ss1="select em from ed where eno='"+s+"'";
                SqlCommand s2 = new SqlCommand(s1, conn);
                SqlCommand ss2 = new SqlCommand(ss1, conn);
                object s3 = s2.ExecuteScalar();
                object ss3 = ss2.ExecuteScalar();
                int x = Convert.ToInt32(s3.ToString());
                if (x== 1)
                    DropDownList1.Text = "未发货";
                else
                    DropDownList1.Text = "已发货";
                TextBox2.Text = ss3.ToString();
            }
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string str = "update ed set em='" + TextBox2.Text.Trim().ToString() + "' where eno='" + TextBox1.Text.Trim().ToString() + "'";
            string st1 = "update ed set cstatus='" + Convert.ToString(1) + "'  where eno='" + TextBox1.Text.Trim().ToString() + "'";
            string st2 = "update ed set cstatus='" + Convert.ToString(2) + "'  where eno='" + TextBox1.Text.Trim().ToString() + "'";
            SqlCommand s1 = new SqlCommand(str, conn);
            object te = s1.ExecuteScalar();
            if (DropDownList1.SelectedItem.ToString() == "未发货")
            {
                SqlCommand s = new SqlCommand(st1, conn);
                object ss = s.ExecuteScalar();
            }
            if (DropDownList1.SelectedItem.ToString() == "已发货")
            {
                SqlCommand s = new SqlCommand(st2, conn);
                object ss = s.ExecuteScalar();
            }
            Session["b"] = "2";
            Response.Redirect("成功.aspx");
            conn.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("管理员主页.aspx");
        }
    }
}