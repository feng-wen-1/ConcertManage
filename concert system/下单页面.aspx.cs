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
    public partial class 下单页面 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["a"]="0";
                TextBox2.Attributes.Add("OnClick", "this.value = '';");
            }

            Label19.Visible = false;
            Label20.Visible = false;
            Label21.Visible = false;

            quehuo();
            Label17.Text = Session["cno"].ToString();
            Label18.Visible = false;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            string str1 = "select sadd1 from CONCERT1,STADIUM1 where cname='" + Session["CNAME"].ToString() + "' and CONCERT1.SNO=STADIUM1.SNO";
            //string cno = "select cno from CONCERT1 where CNO='"+Session["CNAME"].ToString() + "'";
            
            string shijian = "select ctime from CONCERT1 where cname='" + Session["CNAME"].ToString() + "'";

            SqlConnection conn = new SqlConnection(strconn);
            
           // SqlCommand sqlcmd = new SqlCommand(shuliang, conn);
            SqlCommand sqlcmd1 = new SqlCommand(str1,conn);
            SqlCommand sqlcmd2 = new SqlCommand(shijian ,conn);
            conn.Open();
            
            //object tempcount = sqlcmd.ExecuteScalar();
            object temp = sqlcmd1.ExecuteScalar();
            object temp1 = sqlcmd2.ExecuteScalar();
            Label13.Text = Convert.ToString(Session["CNAME"].ToString());
            Label14.Text = Convert.ToString(temp);
            Label15.Text = Convert.ToString(temp1);

            
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
            conn.Close();
        }

        //缺货则相应票价显示缺货
       void quehuo()
        {
            //连接数据库，如果票量小于等于零，则按键显示缺货
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 1  and uno is null and cno='" + Session["cno"].ToString() + "' ";
            SqlCommand sqlcmd = new SqlCommand(shuliang, conn);
            object tempcount = sqlcmd.ExecuteScalar();
            int bb = Convert.ToInt32(tempcount);
            if (bb == 0)
            {
                Button1.Text = "188元（缺货）";
                Button1.Enabled = false;
            }

            string shuliang2 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 2  and uno is null and cno='" + Session["cno"].ToString() + "' ";
            SqlCommand sqlcmd2 = new SqlCommand(shuliang2, conn);
            object tempcount2 = sqlcmd2.ExecuteScalar();
            int bb2 = Convert.ToInt32(tempcount2);
            if (bb2 == 0)
            {
                Button2.Text = "388元（缺货）";
                Button2.Enabled = false;
            }

            string shuliang3 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 3  and uno is null and cno='" + Session["cno"].ToString() + "' ";
            SqlCommand sqlcmd3 = new SqlCommand(shuliang3, conn);
            object tempcount3 = sqlcmd3.ExecuteScalar();
            int bb3 = Convert.ToInt32(tempcount3);
            if (bb3 == 0)
            {
                Button3.Text = "588元（缺货）";
                Button3.Enabled = false;
            }

            string shuliang4 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 4  and uno is null and cno='" + Session["cno"].ToString() + "' ";
            SqlCommand sqlcmd4 = new SqlCommand(shuliang4, conn);
            object tempcount4 = sqlcmd4.ExecuteScalar();
            int bb4 = Convert.ToInt32(tempcount4);
            if (bb4 == 0)
            {
                Button4.Text = "688元（缺货）";
                Button4.Enabled = false;
            }

            string shuliang5 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 5  and uno is null and cno='" + Session["cno"].ToString() + "' ";
            SqlCommand sqlcmd5 = new SqlCommand(shuliang5, conn);
            object tempcount5 = sqlcmd5.ExecuteScalar();
            int bb5 = Convert.ToInt32(tempcount5);
            if (bb5 == 0)
            {
                Button5.Text = "988元（缺货）";
                Button5.Enabled = false;
            }
            conn.Close();
            Label16.Visible = false;

            
        }
        void noShowShuliang()
        {
            Label1.Visible = false;
            Button10.Visible = false;
            Button9.Visible = false;
            Label9.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            
        }
        void ShowShuliang()
        {
            Label1.Visible = true;
            Button10.Visible = true;
            Button9.Visible = true;
            Label9.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
        }
        //选择188元档时，改变金额数，其他按件的值置为false
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 1 and uno is null and cno='" + Session["cno"] + "'";
            SqlCommand sqlcmd = new SqlCommand(shuliang, conn);
            object tempcount = sqlcmd.ExecuteScalar();
            int bb = Convert.ToInt32(tempcount);
            int a = 188;
            string c = Label9.Text.Trim();
            int d = a * Convert.ToInt32(c);
            string b = Convert.ToString(d);
            Label8.Text = b;
            if (Convert.ToInt32(c) >= 3)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
               Label9.Text = "3";
            }
            else
            {
                Button10.Enabled = true;
                Label6.Visible = false;
            }
            if (Convert.ToInt32(c) >= bb)
            {
                Label9.Text = Convert.ToString(bb);
                Label8.Text = Convert.ToString(bb * 188);
                Label16.Text = "库存不足！！";
                Button10.Enabled = false;
                Label9.Text = Convert.ToString(bb);
            }
                
            if (Convert.ToInt32(c) == bb)
                Button10.Enabled = false;
            if (Convert.ToInt32(c) < bb)
                if (Convert.ToInt32(c) < 3)
                    Button10.Enabled = true;
            Session["a"] = 1;
            conn.Close();
        }
        //选择388元档时，改变金额数，其他按件的值置为false
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang2 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 2 and uno is null and cno='" + Session["cno"] + "'";
            SqlCommand sqlcmd2 = new SqlCommand(shuliang2, conn);
            object tempcount2 = sqlcmd2.ExecuteScalar();
            int bb2 = Convert.ToInt32(tempcount2);
            int a = 388;
            string c = Label9.Text.Trim();
            int d = a * Convert.ToInt32(c);
            string b = Convert.ToString(d);
            Label8.Text = b;
            if (Convert.ToInt32(c) >= 3)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
                Label9.Text = "3";
            }
            else
            {
                Button10.Enabled = true;
                Label6.Visible = false;
            }
            if (Convert.ToInt32(c) >= bb2)
            {
                Label9.Text = Convert.ToString(bb2);
                Label8.Text = Convert.ToString(bb2* 388);
            }
            if (Convert.ToInt32(c) == bb2)
                Button10.Enabled = false;
            if (Convert.ToInt32(c) < bb2)
                if(Convert.ToInt32(c)<3)
                    Button10.Enabled = true;
            Session["a"] = 2;
            conn.Close();
        }
        //选择588元档时，改变金额数，其他按件的值置为false
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang3 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 3 and uno is null and cno='" + Session["cno"] + "'";
            SqlCommand sqlcmd3 = new SqlCommand(shuliang3, conn);
            object tempcount3 = sqlcmd3.ExecuteScalar();
            int bb3 = Convert.ToInt32(tempcount3);
            int a = 588;
            string c = Label9.Text.Trim();
            int d = a * Convert.ToInt32(c);
            string b = Convert.ToString(d);
            if (Convert.ToInt32(c) >= 3)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
               Label9.Text = "3";
            }
            else
            {
                Button10.Enabled = true;
                Label6.Visible = false;
            }
            Label8.Text = b;
            if (Convert.ToInt32(c) >= bb3)
            {
                Label9.Text = Convert.ToString(bb3);
                Label8.Text = Convert.ToString(bb3 * 588);
            }
            if (Convert.ToInt32(c) == bb3)
            {
                Button10.Enabled = false;
            }
            if (Convert.ToInt32(c) < bb3)
                if (Convert.ToInt32(c) < 3)
                    Button10.Enabled = true;
            Session["a"] = 3;
            conn.Close();
        }
        //选择688元档时，改变金额数，其他按件的值置为false
        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang4 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 4 and uno is null and cno='" + Session["cno"] + "'";
            SqlCommand sqlcmd4 = new SqlCommand(shuliang4, conn);
            object tempcount4 = sqlcmd4.ExecuteScalar();
            int bb4 = Convert.ToInt32(tempcount4);
            int a = 688;
            string c = Label9.Text.Trim();
            int d = a * Convert.ToInt32(c);
            string b = Convert.ToString(d);
            Label8.Text = b;
            if (Convert.ToInt32(c) >= 3)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
                Label9.Text = "3";
            }
            else
            {
                Button10.Enabled = true;
                Label6.Visible = false;
            }
            if (Convert.ToInt32(c) >= bb4)
            {
                Label9.Text = Convert.ToString(bb4);
                Label8.Text = Convert.ToString(bb4 * 688);
            }
            if (Convert.ToInt32(c) == bb4)
            {
                Button10.Enabled = false;
            }
            if (Convert.ToInt32(c) < bb4)
                if (Convert.ToInt32(c) < 3)
                    Button10.Enabled = true; ;
            Session["a"] = 4;
            conn.Close();
        }
        //选择988元档时，改变金额数，其他按件的值置为false
        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang5 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 5 and uno is null and cno='"+ Session["cno"] + "'";
            SqlCommand sqlcmd5 = new SqlCommand(shuliang5, conn);
            object tempcount5 = sqlcmd5.ExecuteScalar();
            int bb5 = Convert.ToInt32(tempcount5);
            int a = 988;
            string c = Label9.Text.Trim();
            int d = a * Convert.ToInt32(c);
            string b = Convert.ToString(d);
            Label8.Text = b;
            if (Convert.ToInt32(c) >= 3)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
                Label9.Text = "3";
            }
            else
            {
                Button10.Enabled = true;
                Label6.Visible = false;
            }
            if (Convert.ToInt32(c) >= bb5)
            {
                Label9.Text = Convert.ToString(bb5);
                Label8.Text = Convert.ToString(bb5 * 988);
            }
            if (Convert.ToInt32(c) == bb5)
            {
                Button10.Enabled = false;
            }
            if (Convert.ToInt32(c) < bb5)
                if (Convert.ToInt32(c) < 3)
                    Button10.Enabled = true; ;
            Session["a"] = 5;
            conn.Close();
        }

       
        //当用户选定省份之后后面一个dropdownlist变为相应的省份
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDownList1.SelectedItem.Text;
            if (a == "山东")
            {DropDownList2.Items.Clear();
                string[] city = { "请选择", "济南","青岛","淄博","枣庄","东营","烟台","潍坊","济宁","泰安","威海","日照","莱芜","临沂","德州","聊城","菏泽","滨州" };
                for (int i = 0; i < city.Length; i++)
                {
                    
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
             if (a == "新疆")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "乌鲁木齐", "克拉玛依", "石河子", "阿拉尔市", "图木舒克", "五家渠", "哈密", "吐鲁番", "阿克苏", "喀什", "伊宁", "塔城", "阿勒泰", "奎屯", "奎屯", "昌吉", "阜康","库尔勒", "阿图什", "乌苏" };
                for (int i = 0; i < city.Length; i++)
                {
                   
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "西藏")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "阿里地区","都昌市","拉萨市","林芝市","那曲市","日喀则市","山南市"};
                for (int i = 0; i < city.Length; i++)
                {

                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "宁夏")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "银川市", "石嘴山市", "林芝市", "那曲市", "日喀则市", "山南市" };
                for (int i = 0; i < city.Length; i++)
                {

                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "内蒙古")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "呼和浩特市", "包头市", "乌海市", "赤峰市", "通辽市", "鄂尔多斯市", "呼伦贝尔市","巴彦淖尔市","乌兰察布市"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "北京")
            {
                DropDownList2.Items.Clear();
                string[] city = { "北京市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "天津")
            {
                DropDownList2.Items.Clear();
                string[] city = { "天津市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "上海")
            {
                DropDownList2.Items.Clear();
                string[] city = { "上海市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "重庆")
            {
                DropDownList2.Items.Clear();
                string[] city = { "重庆市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "广西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "南宁市", "柳州市", "桂林市", "梧州市", "北海市", "崇左市", "来宾市", "贺州市", "玉林市","百色市","河池市","钦州市","防城港市","贵港市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "黑龙江")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "哈尔滨市", "大庆市", "齐齐哈尔市", "佳木斯市", "鸡西市", "鹤岗市", "双鸭山市", "牡丹江市", "伊春市", "七台河市", "黑河市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "吉林")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "长春市", "吉林市", "四平市", "辽源市", "通化市", "白山市", "松原市", "白城市"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "辽宁")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "沈阳市", "大连市", "鞍山市", "抚顺市", "本溪市", "丹东市", "锦州市", "营口市", "阜新市", "辽阳市", "盘锦市", "铁岭市", "朝阳市", "葫芦岛市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "河北")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "石家庄市", "唐山市", "邯郸市", "秦皇岛市", "保定市", "张家口市", "承德市", "廊坊市", "沧州市", "衡水市", "邢台市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "江苏")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "南京市", "镇江市", "常州市", "无锡市", "苏州市", "徐州市", "来宾市", "连云港市", "淮安市", "盐城市", "扬州市", "泰州市", "南通市", "宿迁市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "安徽")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "合肥市", "蚌埠市", "芜湖市", "淮南市", "亳州市", "阜阳市", "淮北市", "宿州市", "滁州市", "安庆市", "巢湖市", "马鞍山市", "宣城市", "黄山市","池州市","铜陵市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "浙江")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "杭州市", "嘉兴市", "湖州市", "宁波市", "金华市", "温州市", "丽水市", "绍兴市", "衢州市", "舟山市", "台州市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "福建")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "福州市", "厦门市", "泉州市", "三明市", "南平市", "漳州市", "莆田市", "宁德市", "龙岩市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "海南")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "海口市", "三亚市", "琼海市", "文昌市", "万宁市", "五指山市", "儋州市", "东方市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "云南")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "昆明市", "曲靖市", "玉溪市", "保山市", "昭通市", "丽江市", "普洱市", "临沧市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "贵州")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "贵阳市", "安顺市", "六盘水市", "毕节市", "遵义市", "铜仁市", "黔东南苗族自治州", "黔南布依族苗族自治州", "黔西南布依族自治州" };
                for (int i = 0; i < city.Length; i++)
                {  
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "四川")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "成都市", "绵阳市", "德阳市", "广元市", "自贡市", "攀枝花市", "乐山市", "南充市", "内江市", "遂宁市", "广安市", "泸州市", "达州市", "眉山市","宜宾市","雅安市","资阳市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "湖南")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "长沙市", "株洲市", "湘潭市", "衡阳市", "郴州市", "永州市", "邵阳市", "怀化市", "常德市", "益阳市", "张家界市", "娄底市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "湖北")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "武汉市", "襄樊市", "宜昌市", "黄石市", "鄂州市", "随州市", "荆州市", "荆门市", "十堰市", "孝感市", "黄冈市", "咸宁市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "河南")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "郑州市", "洛阳市", "开封市", "漯河市", "安阳市", "新乡市", "周口市", "三门峡市", "焦作市", "平顶山", "信阳市", "南阳市", "鹤壁市", "濮阳市","许昌市","商丘市","驻马店市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "山西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "太原市", "大同市", "忻州市", "阳泉市", "长治市", "晋城市", "运城市", "朔州市", "晋中市", "运城市", "临汾市", "吕梁市"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "山西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "西安市", "咸阳市", "铜川市", "延安市", "宝鸡市", "渭南市", "汉中市", "安康市", "商洛市", "榆林市"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "甘肃")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "兰州市", "天水市", "平凉市", "酒泉市", "嘉峪关市", "金昌市", "白银市", "武威市", "张掖市", "庆阳市", "定西市", "陇南市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "青海")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "果洛藏族自治州", "海北藏族自治州", "海东市", "海南藏族自治州", "海西蒙古族自治州", "黄南藏族自治州", "西宁市", "玉树藏族自治州" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "江西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "南昌市", "九江市", "赣州市", "吉安市", "鹰潭市", "上饶市", "萍乡市", "景德镇市", "新余市", "宜春市", "抚州市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "台湾")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择","台北市", "台中市", "基隆市", "高雄市", "台南市", "新竹市", "嘉义市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "香港")
            {
                DropDownList2.Items.Clear();
                string[] city = { "九龙", "香港岛", "新界"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "澳门")
            {
                DropDownList2.Items.Clear();
                string[] city = { "澳门半岛", "离岛"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if(a=="广东")
            {
                DropDownList2.Items.Clear();
                string[] city = { "广州市", "深圳市","珠海市","汕头市","佛山市","韶关市","湛江市","肇庆市","江门市","茂名市","惠州市","梅州市","汕尾市","河源市","阳江市","清远市","东莞市" ,"中山市","潮州市","揭阳市","云浮市"};
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
        }
        //如果用户点击“-”按钮，减少票的数量
        protected void Button9_Click(object sender, EventArgs e)
        {
            
            string x = Label9.Text.Trim();//获取票的张数
            
            int y = Convert.ToInt32(x);
             if (y > 1)
                y--;
            if (Convert.ToInt32(y )< 3)
                Button10.Enabled=true;
            x = Convert.ToString(y);
            Label9.Text = x;//将修改后的张数传递到前台
            if (Convert .ToInt32(Session["a"])==1)//根据选定的票档改变金额
            {
                y = 188 * y;
                Label8.Text = Convert.ToString(y);
            }
            else if (Convert.ToInt32(Session["a"]) == 2)//根据选定的票档改变金额
            {
                y = 388 * y;
                Label8.Text = Convert.ToString(y);
            }
            else if (Convert.ToInt32(Session["a"]) == 3)//根据选定的票档改变金额
            {
                y = 588 * y;
                Label8.Text = Convert.ToString(y);
            }
           else if (Convert.ToInt32(Session["a"]) == 4)//根据选定的票档改变金额
            {
                y = 688 * y;
                Label8.Text = Convert.ToString(y);
            }
            else if (Convert.ToInt32(Session["a"]) == 5)//根据选定的票档改变金额
            {
                y = 988 * y;
                Label8.Text = Convert.ToString(y);
            }
        }
        //如果用户点击“+”按钮，增加票的张数
        protected void Button10_Click(object sender, EventArgs e)
        {
            string xx = Label9.Text.Trim();//获取票的张数
            if (Convert.ToInt32(xx) >=3)
                Button10.Enabled = false;
            //查询剩下的每种种类的票的数量
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string shuliang = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 1 and uno is null and cno='" + Session["cno"].ToString() + "'";
            SqlCommand sqlcmd = new SqlCommand(shuliang, conn);
            object tempcount = sqlcmd.ExecuteScalar();
            int bb = Convert.ToInt32(tempcount);
            
            string shuliang2 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 2  and uno is null and cno='" + Session["cno"].ToString() + "'";
            SqlCommand sqlcmd2 = new SqlCommand(shuliang2, conn);
            object tempcount2 = sqlcmd2.ExecuteScalar();
            int bb2 = Convert.ToInt32(tempcount2);

            string shuliang3 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 3  and uno is null and cno='" + Session["cno"].ToString() + "'";
            SqlCommand sqlcmd3 = new SqlCommand(shuliang3, conn);
            object tempcount3 = sqlcmd3.ExecuteScalar();
            int bb3 = Convert.ToInt32(tempcount3);

            string shuliang4 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 4  and uno is null and cno='" + Session["cno"].ToString() + "'";
            SqlCommand sqlcmd4 = new SqlCommand(shuliang4, conn);
            object tempcount4 = sqlcmd4.ExecuteScalar();
            int bb4 = Convert.ToInt32(tempcount4);

            string shuliang5 = "select COUNT(TNO)as shuliang from TICKET where TKINDS = 5  and uno is null and cno='" + Session["cno"].ToString() + "'";
            SqlCommand sqlcmd5 = new SqlCommand(shuliang5, conn);
            object tempcount5 = sqlcmd5.ExecuteScalar();
            int bb5 = Convert.ToInt32(tempcount5);
            
            conn.Close();

            string x = Label9.Text.Trim();//获取票的张数
            int y = Convert.ToInt32(x);
            

            //限购三张票
            if (y > 1)
            {
                Button10.Enabled = false;
                Label16.Visible = true;
                Label16.Text = "每个用户限购三张";
            }
            if (Convert.ToInt32(Session["a"]) == 1)//根据选定的票档改变金额
            {
                if (bb == Convert.ToInt32(Label9.Text.Trim()))
                {
                    Label18.Visible = true;
                    Label18.Text = "库存不足！！";
                    Button10.Enabled = false;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                }
                else
                {
                    y++;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                    Button10.Enabled = true;
                    y = 188 * y;
                    Label8.Text = Convert.ToString(y);
                }
            }
            else if (Convert.ToInt32(Session["a"]) == 2)//根据选定的票档改变金额
            {
                if (bb2 == Convert.ToInt32(Label9.Text.Trim()))
                {
                    Label18.Visible = true;
                    Label18.Text = "库存不足！！";
                    Button10.Enabled = false;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                }
                else
                {
                    y++;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                   
                    y = 388 * y;
                    Label8.Text = Convert.ToString(y);
                }
            }
            else if (Convert.ToInt32(Session["a"]) == 3)//根据选定的票档改变金额
            {
                if (bb3 == Convert.ToInt32(Label9.Text.Trim()))
                {
                    Label18.Visible = true;
                    Label18.Text = "库存不足！！";
                    Button10.Enabled = false;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                }
                else
                {
                    y++;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                    y = 588 * y;
                    Label8.Text = Convert.ToString(y);
                }

            }
            else if (Convert.ToInt32(Session["a"]) == 4)//根据选定的票档改变金额
            {
                if (bb4 == Convert.ToInt32(Label9.Text.Trim()))
                {
                    Label18.Visible = true;
                    Label18.Text = "库存不足！！";
                    Button10.Enabled = false;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                }
                else
                {
                    y++;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                    y = 688 * y;
                    Label8.Text = Convert.ToString(y);
                }
            }
            else if (Convert.ToInt32(Session["a"]) == 5)//根据选定的票档改变金额
            {
                if (bb5 == Convert.ToInt32(Label9.Text.Trim()))
                {
                    Label18.Visible = true;
                    Label18.Text = "库存不足！！";
                    Button10.Enabled = false;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                }
                else
                {
                    y++;
                    Label9.Text = Convert.ToString(y);//将修改后的张数传递到前台
                    y = 988 * y;
                    Label8.Text = Convert.ToString(y);
                }
            }
        }

        //点击立即购买后弹出确认对话框，点击确认后跳转至下单成功界面
        protected void Button11_Click(object sender, EventArgs e)
        {
            string a = DropDownList1.SelectedItem.Text.Trim().ToString();
            string b = DropDownList2.SelectedItem.Text.Trim().ToString();
            string c = a + b + TextBox2.Text.ToString();
            
            if (Session["a"].ToString() == "0")
            {
                Label21.Visible = true;
                Label21.Text = "请选择票档!";
            }
            else if(DropDownList1.SelectedItem.Text.Trim().ToString()=="请选择")
            {
                Label21.Visible = true;
                Label21.Text = "请选择地区!";
            }
            else if (TextBox2.Text.Trim().ToString() == "" || TextBox2.Text.Trim().ToString() == "详细地址")
            {
                Label19.Visible = true;
                Label19.Text = "请输入详细地址！";
            }
            else if (TextBox3.Text.Trim().ToString() == "")
            {
                Label20.Visible = true;
                Label20.Text = "请输入联系方式!";
            }
            else
            {
                Label19.Visible = false;
                Label20.Visible = false;
                Label21.Visible = false;
                Button11.Enabled = true;

                //连接数据库,生成订单
                string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(strconn);
                conn.Open();
                string str1 = "select MAX(ONO) from BUY ";
                SqlCommand sqlcmd = new SqlCommand(str1, conn);
                object tempcount = sqlcmd.ExecuteScalar();
                string n = tempcount.ToString();
                int max;
                if (tempcount.ToString() == "")
                    max = 20000001;
                else
                {
                    max = Convert.ToInt32(tempcount);
                    max++;
                }//新生成的订单号
                Session["dingdanNO"] = Convert.ToString(max);

                string str3 = "select MIN(tno) from TICKET where uno is null and TKINDS='" + Session["a"].ToString() + "'and cno='" + Session["cno"] + "' ";
                SqlCommand sqlcmd1 = new SqlCommand(str3, conn);
                object temp = sqlcmd1.ExecuteScalar();
                string y1 = Convert.ToString(temp);
                string y2 = Session["a"].ToString();
                string q2 = "0";
                if (y1 == "")
                {
                    string c1 = "select min(tno) from ticket where TKINDS='" + Session["a"].ToString() + "'and cno='" + Session["cno"] + "'";
                    SqlCommand q = new SqlCommand(c1, conn);
                    object q1 = q.ExecuteScalar();
                    q2 = q1.ToString();
                }
                else
                    q2 = y1;
                int min = Convert.ToInt32(q2);

                //标记已被购买的票
                string str6 = " update TICKET set UNO='" + Session["yonghuNO"].ToString() + "' where TKINDS='" + Session["a"].ToString() + "' and TNO='" + Convert.ToString(min) + "' and cno='"+ Session["cno"] + "'";
                string x1 = "update ticket set ono='" + Convert.ToString(max) + "'where tno= '" + Convert.ToString(min) + "'";
                SqlCommand s2 = new SqlCommand(str6, conn);
                SqlCommand s3 = new SqlCommand(x1, conn);
                object m = s3.ExecuteScalar();
                object t9 = s2.ExecuteScalar();
                //票的张数大于一
                if (Convert.ToInt32(Label9.Text.Trim().ToString()) > 1)
                {
                    //张数为2
                    int min2 = min + 1;
                    string strr2 = "update TICKET set UNO='" + Session["yonghuNO"].ToString() + "' where TKINDS='" + Session["a"].ToString() + "' and TNO='" + Convert.ToString(min2) + "' and cno='" + Session["cno"] + "'";
                    string x2 = "update ticket set ono='" + Convert.ToString(max) + "'where tno= '" + Convert.ToString(min2) + "' and cno='" + Session["cno"] + "'";
                    SqlCommand ss2 = new SqlCommand(strr2, conn);
                    SqlCommand x22 = new SqlCommand(x2, conn);
                    object tt3 = ss2.ExecuteScalar();
                    object xx2 = x22.ExecuteScalar();
                    if (Convert.ToInt32(Label9.Text.Trim().ToString()) > 2)
                    {
                        int min3 = min2 + 1;
                        string strr3 = "update TICKET set UNO='" + Session["yonghuNO"].ToString() + "' where TKINDS='" + Session["a"].ToString() + "' and TNO='" + Convert.ToString(min3) + "' and cno='" + Session["cno"] + "'";
                        string x3 = "update ticket set ono='" + Convert.ToString(max) + "'where tno= '" + Convert.ToString(min3) + "' and cno='" + Session["cno"] + "'";
                        SqlCommand ss3 = new SqlCommand(strr3, conn);
                        SqlCommand x33 = new SqlCommand(x3, conn);
                        object xx3 = x33.ExecuteScalar();
                        object tt4 = ss3.ExecuteScalar();
                    }
                }
                string time = DateTime.Now.ToString();//获得下单时的时间
                                                      //生成订单
                string str2 = "insert into BUY(UNO,ONO,btime,jine,shuliang) values('" + Session["yonghuNO"].ToString() + "','" + Convert.ToString(max) + "','" + time + "','" +Label8.Text.ToString() + "','" + Label9.Text.ToString() + "')";
                SqlCommand sqlcmd2 = new SqlCommand(str2, conn);
                object temp1 = sqlcmd2.ExecuteScalar();
                Session["oNO"] = Convert.ToString(max);

                //生成物流单
                string str4 = " select MAX(eno) from ED";
                SqlCommand s1 = new SqlCommand(str4, conn);
                object t1 = s1.ExecuteScalar();
                string t = Convert.ToString(t1);
                int x = 0;
                if (t == "")
                    x = 10000001;
                else
                {
                    x = Convert.ToInt32(t1);
                    x = x + 1;

                }//获得新生成的快递单号
                Session["kuaidiNO"] = Convert.ToString(x);//存下快递单号
                string strx = "insert into ED(ENO,ONO,CSTATUS,TEL,EDIZHI) values('" + Session["kuaidiNO"].ToString() + "','" + Convert.ToString(max) + "','" + Convert.ToString(1) + "','" + TextBox3.Text.ToString() + "','" + c.ToString() + "')";
                SqlCommand sqlcmdx = new SqlCommand(strx, conn);
                object tempx = sqlcmdx.ExecuteScalar();

                conn.Close();

                Response.Redirect("下单成功界面.aspx");
            }



        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim().ToString() != "" || TextBox2.Text.Trim().ToString() != "请选择")
                Button11.Enabled = true;
           // Response.AddHeader("Refresh", "0");
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
           Response.Redirect("Hompage.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("选座购买.aspx");
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().ToString() != "")
                Button11.Enabled = true;
            //Response.AddHeader("Refresh", "0");
        }
    }
}