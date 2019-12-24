using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class Hompage : System.Web.UI.Page
    {
        
        //创建链接数据库的字符串
        public static string SqlStr = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
        SqlConnection sqlcon = new SqlConnection(SqlStr); //创建SqlConnectin对象
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load();
                Menu1.Visible = false;
                        
            }
            if(Session["yonghuNO"] != null)
            {
                string sql = "select *from yonghu where UNO='" + Session["yonghuNO"].ToString() + "'";
                SqlDataAdapter sqlda = new SqlDataAdapter();  //创建SqlDataAdapter对象
                                                              //给SqlDataAdapter的SelectCommand赋值
                sqlda.SelectCommand = new SqlCommand(sql, sqlcon);
                DataSet ds = new DataSet();  //创建DataSet对象
                sqlda.Fill(ds, "user");  //填充数据集
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                Button1.Visible = false;
                Menu1.Visible = true;
                Menu1.Items[0].Text=dt.Rows[0][2].ToString();
            }

        }
        //将数据库中的图片导入到imagebotton控件中
        protected void load()
        {
            
            SqlDataAdapter sqlda = new SqlDataAdapter();  //创建SqlDataAdapter对象
                                                //给SqlDataAdapter的SelectCommand赋值
            sqlda.SelectCommand = new SqlCommand("select *from CONCERT1", sqlcon);
            DataSet ds = new DataSet();  //创建DataSet对象
            sqlda.Fill(ds,"concert1");  //填充数据集
            DataTable dt = ds.Tables[0].DefaultView.ToTable();
            
            //定义i记录数据库中有几行
            int t = dt.Rows.Count;
            ImageButton[] image = new ImageButton[] { ImageButton1, ImageButton2,ImageButton3, ImageButton4, ImageButton5 };
            Label[] cname = new Label[] { cname1, cname2, cname3, cname4, cname5};
            //第一张图片使用数据库中存储的图片创建内存数据流
            MemoryStream[] mstream = new MemoryStream[t];
            String[] base64 = new string[t ];
            /*
            MemoryStream MStream1 = new MemoryStream((byte[])dt.Rows[0][8]);
            string base641 = Convert.ToBase64String(MStream1.ToArray());
            ImageButton1.ImageUrl = "data:image/png;base64," + base641;
            MemoryStream MStream2 = new MemoryStream((byte[])dt.Rows[1][8]);
            string base642 = Convert.ToBase64String(MStream2.ToArray());
            ImageButton2.ImageUrl = "data:image/png;base64," + base642;*/
            for (int i = 0; i < t; i++)
            {
                image[i].Visible = true;
                cname[i].Visible = true;
                cname[i].Text = dt.Rows[i][4].ToString();
                mstream[i] =new MemoryStream((byte[])dt.Rows[i][8]);
                base64[i] = Convert.ToBase64String(mstream[i].ToArray());
                image[i].ImageUrl = "data:image/png;base64," + base64[i];
            }
                        

        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        //图片按钮
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Session["imageurl"] = ImageButton4.ImageUrl;
            Session["CNAME"] = cname1.Text.ToString();
            Response.Redirect("Ticketinfor.aspx");
            
        }
        //登录按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            
        }
        //搜索按钮
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["name"] = TextBox1.Text;
            Response.Redirect("search.aspx");
        }
        

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["CNAME"] = cname2.Text.ToString();
            Response.Redirect("Ticketinfor.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "个人中心")
            {
                Response.Redirect("users.aspx?uno=" + Session["yonghuNO"].ToString());
            }
            else if (e.Item.Text == "订单管理")
            {
                Response.Redirect("Dingdan.aspx?uno=" + Session["yonghuNO"].ToString());
            }
            else if (e.Item.Text == "退出登录")
            {
                Session["yonghuNO"] = null;
                Button1.Visible = true;
                Menu1.Visible = false;
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["CNAME"] = cname3.Text.ToString();
            Response.Redirect("Ticketinfor.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["CNAME"] = cname4.Text.ToString();
            Response.Redirect("Ticketinfor.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Session["CNAME"] = cname5.Text.ToString();
            Response.Redirect("Ticketinfor.aspx");
        }
    }
}