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
    public partial class Dingdan : System.Web.UI.Page
    {
        public static string Sqlstr = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
        SqlConnection sqlcon = new SqlConnection(Sqlstr); //创建SqlConnectin对象
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string sql = "select  *from BUY where UNO='123'";
                string sql = "select *from BUY where UNO='"+ Request.Params["uno"].ToString()+"'";
                if (sqlcon.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                    sqlcon.Open();
                DataSet ds1 = new DataSet();//建立数据集对象
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);//建立适配器对象,并初始化，执行sql语句，得到查询数据
                da.Fill(ds1, "buy");//将查询数据填充到数据集的表中
                GridView1.DataSource = ds1.Tables["buy"];//将datagridview与数据源绑定
                DataTable dt1 = ds1.Tables[0].DefaultView.ToTable();
                GridView1.DataKeyNames = new string[] { "ONO" };
                GridView1.DataBind();
            }
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            
            Session["oNO"] = GridView1.Rows[i].Cells[2].Text;
            if (sqlcon.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                sqlcon.Open();
            string sql = "select cno from ticket where oNO='" + Session["oNO"].ToString() + "'";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
            object temp1 = sqlcmd.ExecuteScalar();
            Session["cno"] = temp1.ToString();
            Response.Redirect("订单信息页面.aspx");
            sqlcon.Close();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //列数
            try
            {
                int count = this.GridView1.HeaderRow.Cells.Count;
                for (int i = 0; i < count; i++)
                {
                    string oldValue = this.GridView1.HeaderRow.Cells[i].Text;
                    if (oldValue == "UNO")
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = "用户号";
                    }
                    else if (oldValue == "shuliang")
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = "数量";
                    }
                    else if (oldValue == "ONO")
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = "订单号";
                    }
                    else if (oldValue == "btime")
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = "购买时间";
                    }
                    else if (oldValue == "jine")
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = "金额";
                    }
                   
                }

            
            }
            catch
            {
                Response.Write("<script>alert('当前没有订单！')</script>");
            }
        }
    }
}