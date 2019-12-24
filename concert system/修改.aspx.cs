using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 修改 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
            TextBox10.Visible = false;
            TextBox11.Visible = false;
            TextBox12.Visible = false;
            TextBox13.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;
            TextBox9.Visible = true;
            TextBox10.Visible = true;
            TextBox11.Visible = true;
            TextBox12.Visible = true;
            TextBox13.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label12.Visible = true;
            String s1 = TextBox1.Text.Trim().ToString();
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            String str1 = "select CNAME from CONCERT1 where CNO = '" + s1 + "'";
            String str2 = "select CTIME from CONCERT1 where CNO = '" + s1 + "'";
            String str3 = "select SADD1 from CONCERT1,STADIUM1 where STADIUM1.SNO = CONCERT1.SNO and CONCERT1.CNO = '" + s1 + "'";
            String str4 = "select VNAME from CONCERT1 where CNO ='" + s1 + "'";
            String str5 = "select VCNAME from CONCERT1,VOCALIST where CONCERT1.VNAME = VOCALIST.VNAME and CONCERT1.CNO = '" + s1 + "'";
            String str6 = "select VCADD from CONCERT1,VOCALIST where CONCERT1.VNAME = VOCALIST.VNAME and CONCERT1.CNO = '" + s1 + "'";
            String str7 = "select VCTEL from CONCERT1,VOCALIST where CONCERT1.VNAME = VOCALIST.VNAME and CONCERT1.CNO = '" + s1 + "'";
            String str8 = "select HNAME from CONCERT1 where CNO ='" + s1 + "'";
            String str9 = "select HCADD from CONCERT1,HOLDER where CONCERT1.HNAME = HOLDER.HNAME and CONCERT1.CNO = '" + s1 + "'";
            SqlCommand sq1 = new SqlCommand(str1, conn);
            SqlCommand sq2 = new SqlCommand(str2, conn);
            SqlCommand sq3 = new SqlCommand(str3, conn);
            SqlCommand sq4 = new SqlCommand(str4, conn);
            SqlCommand sq5 = new SqlCommand(str5, conn);
            SqlCommand sq6 = new SqlCommand(str6, conn);
            SqlCommand sq7 = new SqlCommand(str7, conn);
            SqlCommand sq8 = new SqlCommand(str8, conn);
            SqlCommand sq9 = new SqlCommand(str9, conn);
            object text1 = sq1.ExecuteScalar();
            object text2 = sq2.ExecuteScalar();
            object text3 = sq3.ExecuteScalar();
            object text4 = sq4.ExecuteScalar(); 
            object text5 = sq5.ExecuteScalar();
            object text6 = sq6.ExecuteScalar();
            object text7 = sq7.ExecuteScalar();
            object text8 = sq8.ExecuteScalar();
            object text9 = sq9.ExecuteScalar();
            String x1 = Convert.ToString(text1);
            String x2 = Convert.ToString(text2);
            String x3 = Convert.ToString(text3);
            String x4 = Convert.ToString(text4);
            String x5 = Convert.ToString(text5);
            String x6 = Convert.ToString(text6);
            String x7 = Convert.ToString(text7);
            String x8 = Convert.ToString(text8);
            String x9 = Convert.ToString(text9);
            if (s1 == "")
            {
                TextBox2.Text = "无此演唱会";
            }
            else if (s1 == "1")
            {
                TextBox2.Text = x1;
                TextBox3.Text = x2;
                TextBox4.Text = x3;
                TextBox5.Text = x4;
                TextBox6.Text = x5;
                TextBox7.Text = x6;
                TextBox8.Text = x7;
                TextBox9.Text = x8; 
                TextBox10.Text = x9;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}