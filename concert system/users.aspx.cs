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
    public partial class users : System.Web.UI.Page
    {
        public static string SqlStr = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
        SqlConnection sqlcon = new SqlConnection(SqlStr); //创建SqlConnectin对象
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }
        //显示数据库中的数据
        protected void Bind()
        {
            //string sql = "select *from YONGHU where UNO='18205021200'";
            string sql = "select *from YONGHU where UNO='" + Request.Params["uno"].ToString() + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter();  //创建SqlDataAdapter对象
            //给SqlDataAdapter的SelectCommand赋值
            sqlda.SelectCommand = new SqlCommand(sql, sqlcon);
            DataSet ds = new DataSet();  //创建DataSet对象
            sqlda.Fill(ds, "user");  //填充数据集
            DataTable dt = ds.Tables[0].DefaultView.ToTable();
            lblnk.Text = dt.Rows[0][2].ToString();
            lbluno.Text = dt.Rows[0][0].ToString();
            umail.Text = dt.Rows[0][3].ToString();
            hide();
        }
        protected void show()
        {
            Label1.Visible = true;
           
            Label3.Visible = true;
            Button2.Visible = true;
            TextBox1.Visible = true;
            
            TextBox3.Visible = true;
        }
        protected void hide()
        {
            Label1.Visible = false;
            
            Label3.Visible = false;
            Button2.Visible = false;
            TextBox1.Visible = false;
            
            TextBox3.Visible = false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            show();
            //lblnk.Text = TextBox1.Text;
            //umail.Text = TextBox3.Text;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "update YONGHU set UN='" + TextBox1.Text + "',UMAIL='" + TextBox3.Text + "' where UNO='" + lbluno.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            if (sqlcon.State == ConnectionState.Closed)//如果数据库状态是关闭则打开链接
                sqlcon.Open();
            int update=cmd.ExecuteNonQuery();

            if (update != 0 && update != -1)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                
                Bind();
            }
            else
                Response.Write("<script language=javascript>alert('修改失败！')</script>");

            sqlcon.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hompage.aspx");
        }
    }
}