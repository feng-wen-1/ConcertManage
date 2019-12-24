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
    public partial class Ticketinfor : System.Web.UI.Page
    {
        public static string SqlStr = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
        SqlConnection sqlcon = new SqlConnection(SqlStr); //创建SqlConnectin对象
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                sqlcon.Open();
            //显示演唱会CONCERT信息
            string s1=Request.QueryString["name"];//查询页面传递的信息
            if (Session["CNAME"] != null)
                s1 = Session["CNAME"].ToString();
            
            
            //string sql1 = "select *from CONCERT where CNAME='" + Session["CNAME"].ToString()+"'";
            string sql1 = "select *from CONCERT1 where CNAME='" + s1 + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter(sql1,sqlcon);  //创建SqlDataAdapter对象
            SqlCommand cmd = new SqlCommand(sql1, sqlcon);
            DataSet ds = new DataSet();  //创建DataSet对象
            sqlda.Fill(ds, "concert");  //填充数据集
            DataTable dt1 = ds.Tables[0].DefaultView.ToTable();
            //加载图片
            MemoryStream MStream;
            MStream = new MemoryStream((byte[])dt1.Rows[0][8]);
            string base64 = Convert.ToBase64String(MStream.ToArray());
            Image1.ImageUrl = "data:image/png;base64," + base64;
            //
            
            lblcname.Text = dt1.Rows[0][4].ToString();
            lblctime.Text = dt1.Rows[0][5].ToString();
            lblpch.Text = dt1.Rows[0][6].ToString();
            lblcno.Text = dt1.Rows[0][7].ToString();

            //显示歌手VOCALIST信息和场馆
            string sql2 = "select *from VOCALIST,STADIUM1 where VNAME='" + dt1.Rows[0][0].ToString() + "' AND SNO='" + dt1.Rows[0][1].ToString() + "'";
            SqlDataAdapter sqlda2 = new SqlDataAdapter(sql2, sqlcon);  //创建SqlDataAdapter对象
            SqlCommand cmd2 = new SqlCommand(sql2, sqlcon);
            //DataSet ds2 = new DataSet();  //创建DataSet对象
            sqlda2.Fill(ds, "vocalist");
            DataTable dt2 = ds.Tables[1].DefaultView.ToTable();

            lblvname.Text= dt2.Rows[0][0].ToString();
            lblvcname.Text = dt2.Rows[0][1].ToString();
            lblvcadd.Text = dt2.Rows[0][2].ToString();
            lblvctel.Text = dt2.Rows[0][3].ToString();
            lblsadd.Text = dt2.Rows[0][5].ToString();

            //显示主办方信息
            string sql3 = "select *from HOLDER where HNAME='" + dt1.Rows[0][2].ToString() + "'";
            SqlDataAdapter sqlda3 = new SqlDataAdapter(sql3, sqlcon);
            SqlCommand cmd3 = new SqlCommand(sql3, sqlcon);
            DataSet ds2 = new DataSet();  //创建DataSet对象
            sqlda3.Fill(ds2, "holder");
            DataTable dt3 = ds2.Tables["holder"];
            

            hname.Text = dt3.Rows[0][0].ToString();
            hadd.Text = dt3.Rows[0][2].ToString();
            htel.Text = dt3.Rows[0][1].ToString();
            sqlcon.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //进入下单页面
            if (Session["yonghuNO"] == null)
            {
                Response.Write("<script>alert('您还未登录，请登录');window.location.href = 'Login.aspx';</script>");
                
            }
                
            else
            {
                Session["cno"] = lblcno.Text;
                Response.Redirect("下单页面.aspx");
            }
               
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hompage.aspx");
        }
    }
}