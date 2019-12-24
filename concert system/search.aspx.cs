using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }
        static string SqlStr = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(SqlStr); //创建SqlConnectin对象
        private void BindGridView()
        {
            try
            {
                string sqlstr = "select CNAME,HNAME ,VNAME,CTIME,CNO,SADD1 from CONCERT1,STADIUM1 WHERE CONCERT1.SNO=STADIUM1.SNO AND CNAME LIKE '%" + Session["name"].ToString() + "%'";
                // string sqlstr = "select * from CONCERT1 ";
                if (con.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                    con.Open();
                DataSet ds1 = new DataSet();//建立数据集对象
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);//建立适配器对象,并初始化，执行sql语句，得到查询数据
                da.Fill(ds1, "concert");//将查询数据填充到数据集的表中
                GridView1.DataSource = ds1.Tables["concert"];//将datagridview与数据源绑定
                DataTable dt1 = ds1.Tables[0].DefaultView.ToTable();
                GridView1.DataKeyNames = new string[] { "CNO" };
                GridView1.DataBind();
                //GridView1.Rows[0].Cells[0].Text= dt1.Rows[0][5].ToString();
                con.Close();
            }
            catch
            {
                Response.Write("<script>alert('数据库连接失败，请重试！’)</script>");
                con.Close();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //获取当前行所在的索引
            int i = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

            Response.Redirect("Ticketinfor.aspx?name=" + GridView1.Rows[i].Cells[5].Text);
        }
        //获取当前所选择的行
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (!e.Item.Text.ToString().Equals("全部"))
            {
                string sqlstr1 = "select CNAME,HNAME ,VNAME,CTIME,CNO,SADD1 from CONCERT1,STADIUM1 WHERE CONCERT1.SNO=STADIUM1.SNO AND sadd1 LIKE '%" + e.Item.Text.ToString() + "%'";
                // string sqlstr = "select * from CONCERT1 ";
                if (con.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                    con.Open();
                DataSet ds1 = new DataSet();//建立数据集对象
                SqlDataAdapter da = new SqlDataAdapter(sqlstr1, con);//建立适配器对象,并初始化，执行sql语句，得到查询数据
                da.Fill(ds1, "CONCERT");//将查询数据填充到数据集的表中
                GridView1.DataSource = ds1.Tables["concert"];//将datagridview与数据源绑定
                DataTable dt1 = ds1.Tables[0].DefaultView.ToTable();
                GridView1.DataKeyNames = new string[] { "CNO" };
                GridView1.DataBind();
                if (dt1.Rows.Count == 0)
                {
                    Label1.Text = "没有找到符合条件的商品。您可以减少筛选条件重新搜索。";
                    Label1.Visible = true;
                }
                con.Close();
            }
            else
                BindGridView();



        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int count = this.GridView1.HeaderRow.Cells.Count;
            for (int i = 0; i < count; i++)
            {
                string oldValue = this.GridView1.HeaderRow.Cells[i].Text;
                if (oldValue == "VNAME")
                {
                    this.GridView1.HeaderRow.Cells[i].Text = "歌手";
                }
                else if (oldValue == "HNAME")
                {
                    this.GridView1.HeaderRow.Cells[i].Text = "举办方";
                }
                else if (oldValue == "CNAME")
                {
                    this.GridView1.HeaderRow.Cells[i].Text = "演唱会名字";
                }
                else if (oldValue == "CTIME")
                {
                    this.GridView1.HeaderRow.Cells[i].Text = "演唱会时间";
                }
                else if (oldValue == "SADD1")
                {
                    this.GridView1.HeaderRow.Cells[i].Text = "金额";
                }
                else if (oldValue == "CNO")
                    this.GridView1.HeaderRow.Cells[i].Text = "演唱会编号";
            }
        }
    }
}