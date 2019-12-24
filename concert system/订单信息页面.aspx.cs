using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class 付款页面 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            unxiugai();

            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();


            Label15.Text = Session["oNO"].ToString();//显示订单编号
            //显示演唱会信息
            Label17.Text = Session["cno"].ToString();//演唱会编号

            string str1 = "select cname from concert1 where cno='" + Session["cno"].ToString() + "' ";//显示名称
            SqlCommand sqlcmd = new SqlCommand(str1, conn);
            object tempcount = sqlcmd.ExecuteScalar();
            Label2.Text = Convert.ToString(tempcount);
            //显示图片
            string str0 = "select CPICTURE from concert1 where cno='" + Session["cno"].ToString() + "' ";

            DataSet ds = new DataSet();  //创建DataSet对象
            SqlDataAdapter sqlda = new SqlDataAdapter();  //创建SqlDataAdapter对象
            sqlda.SelectCommand = new SqlCommand(str0, conn);
            sqlda.Fill(ds, "concert1");  //填充数据集
            DataTable dt = ds.Tables[0].DefaultView.ToTable();

            MemoryStream MStream1 = new MemoryStream((byte[])dt.Rows[0][0]);
            string base64 = Convert.ToBase64String(MStream1.ToArray());
            Image1.ImageUrl = "data:image/png;base64," + base64;

            string str = "select ctime from concert1 where cno='" + Session["cno"].ToString() + "' ";//显示演唱会时间
            SqlCommand sqlcmd1 = new SqlCommand(str, conn);
            object temp = sqlcmd1.ExecuteScalar();
            Label4.Text = Convert.ToString(temp);

            string str2 = "select sadd1 from concert1,stadium1 where concert1.sno=stadium1.sno and cno='" + Session["cno"].ToString() + "'";//显示演唱会举办地址
            SqlCommand sqlcmd2 = new SqlCommand(str2,conn);
            object temp1 = sqlcmd2.ExecuteScalar();
            Label6.Text = Convert.ToString(temp1);

            string str4 = "select shuliang from buy where ono='"+Session["oNO"].ToString()+"'";//数量
            SqlCommand sqlcmd4 = new SqlCommand(str4, conn);
            object temp3 = sqlcmd4.ExecuteScalar();
            Label13.Text = Convert.ToString(temp3);

            string str17 = "select btime from buy where ono='" + Session["oNO"].ToString() + "'";//下单时间
            SqlCommand sqlcmd17 = new SqlCommand(str17, conn);
            object temp17 = sqlcmd17.ExecuteScalar();
            Label18.Text = Convert.ToString(temp17);

            string str3 = "select tno from ticket where ono='" + Session["oNO"].ToString() + "'";//显示座位号
            SqlCommand sqlcmd3 = new SqlCommand(str3, conn);
            object temp2 = sqlcmd3.ExecuteScalar();
            Label8.Text = Convert.ToString(temp2);//只有一张票
            string w = temp3.ToString();
            if (Convert.ToInt32(w) >1)
            {
                //两张票
                SqlDataAdapter sda = new SqlDataAdapter(str3,conn);
                DataSet dss = new DataSet();
                sda.Fill(dss);
                string a = Convert.ToString(dss.Tables[0].Rows[1][0]);
                Label8.Text = Label8.Text.Trim() + ","+a;
                //三张票
                if (Convert.ToInt32(w) == 3)
                {
                    string b = Convert.ToString(dss.Tables[0].Rows[2][0]);
                    Label8.Text = Label8.Text.Trim() + "," + b;
                }
            }
            

            string str5= "select jine from buy where ono='" + Session["oNO"].ToString() + "'";//金额
            SqlCommand sqlcmd5 = new SqlCommand(str5, conn);
            object temp4 = sqlcmd5.ExecuteScalar();
            Label14.Text = Convert.ToString(temp4);

            string str6 = "select eno from buy,ed where buy.ono=ed.ono and ed.ono='" + Session["oNO"].ToString() + "'";//物流单号
            SqlCommand sqlcmd6 = new SqlCommand(str6, conn);
            object temp5 = sqlcmd6.ExecuteScalar();
            Label16.Text = Convert.ToString(temp5);

            string str7= "select cstatus from ed where ono='" + Session["oNO"].ToString() + "'";//物流状态
            SqlCommand sqlcmd7 = new SqlCommand(str7, conn);
            object temp6 = sqlcmd7.ExecuteScalar();
            string t = Convert.ToString(temp6);
            if (Convert.ToInt32(t) == 1)
                Label11.Text = "未发货";
            else if (Convert.ToInt32(t) == 2)
            {
                Button1.Visible = false;
                Button3.Visible = false;
                Label11.Text = "已发货";
            }

            string str8= "select edizhi from ed where ono='" + Session["oNO"].ToString() + "'";//地址
            SqlCommand sqlcmd8 = new SqlCommand(str8, conn);
            object temp7 = sqlcmd8.ExecuteScalar();
            Label9.Text = Convert.ToString(temp7);

            string str9 = "select tel from ed where ono='" + Session["oNO"].ToString() + "'";//联系电话
            SqlCommand sqlcmd9 = new SqlCommand(str9, conn);
            object temp8 = sqlcmd9.ExecuteScalar();
            Label10.Text = Convert.ToString(temp8);

            string str10 = "select em from ed where ono='" + Session["oNO"].ToString() + "'";//物流信息
            SqlCommand sqlcmd10 = new SqlCommand(str10, conn);
            object temp9= sqlcmd10.ExecuteScalar();
            Label12.Text = Convert.ToString(temp9);

            string strr = "select cstatus from ed where ono='" + Session["oNO"] + "'";
            SqlCommand sqlcmdd = new SqlCommand(strr, conn);
            object tempp = sqlcmdd.ExecuteScalar();
            if (tempp.ToString() == "2")
            {
                Button2.Visible = false;
                Button1.Visible = false;
                Button4.Visible = false;
            }
            conn.Close();
        }
        void unxiugai()
        {
            Button4.Visible = false;
            Label10.Visible = true;
            Label9.Visible = true;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button1.Visible = true;
        }
        void xiugai()
        {
            Button4.Visible = true;
            Button1.Visible = false;
            Label10.Visible = false;
            Label9.Visible = false;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Button2.Visible = true;
        }
        //修改联系方式，收货地址
        protected void Button1_Click(object sender, EventArgs e)
        {
            xiugai();
            TextBox1.Text = Label9.Text.Trim();
            TextBox2.Text = Label10.Text.Trim();
        }
        //保存修改后的信息
        protected void Button2_Click(object sender, EventArgs e)
        {
            unxiugai();
            
            string a=TextBox1.Text.Trim();//地址
            string b = TextBox2.Text.Trim();//联系方式
            Label9.Text = a;
            Label10.Text = b;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string str1 = "update ed set tel='"+TextBox1.Text.ToString ()+ "' where ono='" + Session["oNO"] + "'";
            string str2= "update ed lset edizhi='" + TextBox2.Text.ToString() + "'where ono='" + Session["oNO"] + "'";

            SqlCommand sqlcmd1 = new SqlCommand(str1, conn);
            object temp1 = sqlcmd1.ExecuteScalar();
            Label9.Text = TextBox1.Text.ToString();

            SqlCommand sqlcmd2 = new SqlCommand(str2, conn);
            object temp2 = sqlcmd2.ExecuteScalar();
            

            conn.Close();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            unxiugai();
        }
        //退票
        protected void Button3_Click1(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            //删除订单信息
            string str1 = "delete from buy where uno='" + Session["yonghuNO"].ToString() + "'and ono='"+ Session["oNO"].ToString() + "'";
            SqlCommand sqlcmd = new SqlCommand(str1, conn);
            object temp = sqlcmd.ExecuteScalar();
            //删除物流信息
            string str2 = "delete from ed where eno='" + Session["kuaidiNO"].ToString() + "'";
            SqlCommand sqlcmd1 = new SqlCommand(str2, conn);
            object temp1 = sqlcmd1.ExecuteScalar();
            //删除退的票的标记
            string str3 = "update TICKET set UNO=null where ono='"+ Session["dingdanNO"].ToString() + "'";
            SqlCommand sqlcmd2 = new SqlCommand(str3, conn);
            object temp2 = sqlcmd2.ExecuteScalar();
            string str4 = "update ticket set ono=null where ono='"+ Session["dingdanNO"].ToString() + "'";
            SqlCommand sqlcmd3 = new SqlCommand(str4, conn);
            object temp3 = sqlcmd3.ExecuteScalar();

            conn.Close();
            Response.Redirect("退票成功.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hompage.aspx");
        }
    }
}