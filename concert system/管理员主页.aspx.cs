using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 管理员主页 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["mzh"]
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("新增演唱会.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("修改.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("删除.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("修改用户密码.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("更新物流信息");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "个人信息")
            {
                Response.Redirect("管理员个人信息.aspx");
            }
            else if (e.Item.Text == "退出登录")
            {
                Response.Redirect("管理员登录.aspx");
            }
        }
    }
}