using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 增删
{
    public partial class Login : System.Web.UI.Page
    {
        public static string strcon = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";//True";
        public static SqlConnection con = new SqlConnection(strcon);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //注册按钮代码
        protected void Button2_Click(object sender, EventArgs e)
        {
            //进入注册页面
            Response.Redirect("register.aspx");
        }
        //登录按钮代码
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(*) from YONGHU where UNO='" + TXTUNO.Text + "'AND UPS='"+TXTPS.Text+"'";
                //查询用户
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                if(i==0)
                {
                    Response.Write("<script>alert('账户或密码错误，请重新输入！')</script>");
                    TXTUNO.Text = "";
                    TXTPS.Text = "";
                }
                else
                {
                    Session["yonghuNO"]  = TXTUNO.Text;
                    //进入演唱会主页
                    Response.Redirect("Hompage.aspx");
                }
            }
            catch
            {
                Response.Write("数据库连接失败，请重试");
                con.Close();
            }
        }
    }
}