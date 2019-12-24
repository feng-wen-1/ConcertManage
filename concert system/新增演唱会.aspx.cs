using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 新增演唱会 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string str = "select max(cno) from concert1";
            SqlCommand sqlcmd = new SqlCommand(str, conn);
            object temp = sqlcmd.ExecuteScalar();
            string max = Convert.ToString(temp);
            int newcno = Convert.ToInt32(max) + 1;
            Label1.Text = Convert.ToString(newcno);
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            if (TextBox1.Text.Trim().ToString() == "" || TextBox2.Text.Trim().ToString() == "" || TextBox14.Text.Trim().ToString() == "" || TextBox15.Text.Trim().ToString() == "" || TextBox16.Text.Trim().ToString() == "" || TextBox17.Text.Trim().ToString() == "" || TextBox18.Text.Trim().ToString() == "")
            {
                Label2.Visible = true;
                Label2.Text = "请完整填写信息！！";
            }
            else
            {
                Label2.Visible = false;
                string str1 = "insert into concert1(vname,sno,hname,cname,ctime,cno) values('"+DropDownList1.SelectedItem.ToString()+"','"+DropDownList2.SelectedItem.ToString()+"','"+DropDownList3.SelectedItem.ToString()+"','"+TextBox1.Text.Trim().ToString()+"','"+TextBox2.Text.Trim().ToString()+"','"+Label1.Text.Trim().ToString()+"')";
                SqlCommand c = new SqlCommand(str1,conn);
                object tem = c.ExecuteScalar();
                string d11 = TextBox14.Text.Trim().ToString();//188下限
                string d12 = TextBox19.Text.Trim().ToString();
                string d21 = TextBox15.Text.Trim().ToString();//388
                string d22 = TextBox20.Text.Trim().ToString();
                string d31 = TextBox16.Text.Trim().ToString();//588
                string d32 = TextBox21.Text.Trim().ToString();
                string d41 = TextBox17.Text.Trim().ToString();//688
                string d42 = TextBox22.Text.Trim().ToString();
                string d51 = TextBox18.Text.Trim().ToString();//988
                string d52 = TextBox23.Text.Trim().ToString();
                
                //插入188的票
                for(int i=Convert.ToInt32(d11);i<=Convert.ToInt32(d12);i++)
                {
                    string str = "insert into ticket(tno,tkinds,cno) values('"+i+ "',1,'" + Label1.Text.Trim().ToString() + "')";
                    SqlCommand scd = new SqlCommand(str, conn);
                    object te = scd.ExecuteScalar();
                }

                //插入388的票
                for (int i = Convert.ToInt32(d21); i <= Convert.ToInt32(d22); i++)
                {
                    string str = "insert into ticket(tno,tkinds,cno) values('" + i + "',2,'" + Label1.Text.Trim().ToString() + "')";
                    SqlCommand scd = new SqlCommand(str, conn);
                    object te = scd.ExecuteScalar();
                }

                //插入588的票
                for (int i = Convert.ToInt32(d31); i <= Convert.ToInt32(d32); i++)
                {
                    string str = "insert into ticket(tno,tkinds,cno) values('" + i + "',3,'" + Label1.Text.Trim().ToString() + "')";
                    SqlCommand scd = new SqlCommand(str, conn);
                    object te = scd.ExecuteScalar();
                }

                //插入688的票
                for (int i = Convert.ToInt32(d41); i <= Convert.ToInt32(d42); i++)
                {
                    string str = "insert into ticket(tno,tkinds,cno) values('" + i + "',4,'" + Label1.Text.Trim().ToString() + "')";
                    SqlCommand scd = new SqlCommand(str, conn);
                    object te = scd.ExecuteScalar();
                }

                //插入988的票
                for (int i = Convert.ToInt32(d51); i <= Convert.ToInt32(d52); i++)
                {
                    string str = "insert into ticket(tno,tkinds,cno) values('" + i + "',5,'" + Label1.Text.Trim().ToString() + "')";
                    SqlCommand scd = new SqlCommand(str, conn);
                    object te = scd.ExecuteScalar();
                }
                Session["b"] = "1";
                Response.Redirect("成功.aspx");
            }
                conn.Close();
        }
    }
}