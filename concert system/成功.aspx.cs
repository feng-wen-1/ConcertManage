using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 新增成功 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["b"] == "1")
                Label1.Text = "新增成功!";
            if (Session["b"] == "2")
                Label1.Text = "更新成功!";
            if (Session["b"] == "3")
                Label1.Text = "修改密码成功";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("管理员主页.aspx");
        }
    }
}