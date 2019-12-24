using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Email_TextChanged(object sender, EventArgs e)
        {

        }
        public static string strcon = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";//True";
        public static SqlConnection con = new SqlConnection(strcon);
        //注册按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //如果数据库状态是关闭则打开链接
                if (con.State == ConnectionState.Closed)
                    con.Open();
                if ((UserNO.Text != "") && (Password.Text != ""))
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "select count(*) from YONGHU where UNO='" + UserNO.Text + "'";
                    //查询用户名是否已被注册
                    int i = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (i == 1)
                    {
                        Response.Write("<script>alert('该用户名已被注册，请重新输入！')</script>");
                        UserNO.Text = "";
                        Password.Text = "";
                        ConfirmPassword.Text = "";
                        NickName.Text = "";
                    }
                    else
                    {
                        //将输入的用户名密码信息存入数据表
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "insert into YONGHU(UNO,UPS,UN,UMAIL) values('" + UserNO.Text + "','" + Password.Text + "','" + NickName.Text + "','" +Email.Text+ "')";
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        
                        UserNO.Text = "";
                        Password.Text = "";
                        ConfirmPassword.Text = "";
                        NickName.Text = "";
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('该用户名和密码不能为空，请重新输入！')</script>");
                }

            }
            catch
            {
               Response.Write("数据库连接失败，请重试！");
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}