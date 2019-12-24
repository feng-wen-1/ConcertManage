using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concert_system
{
    public partial class 选座购买 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {Label3.Visible = false;
            TextBox2.Attributes.Add("OnClick", "this.value = '';");
            Label2.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            }
        }

        protected void TNO_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void TNO_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
        {
            
        }

        //已经购买的的座位表示为不可选
        protected void CheckBoxList1_DataBound(object sender, EventArgs e)
        {
            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            string zshu = "select count(tno) from ticket where cno=1";
            SqlCommand shu = new SqlCommand(zshu, conn);
            object count = shu.ExecuteScalar();
            int co = Convert.ToInt32(count);
            if (co > 0)
                for (int i = 0; i < co; i++)
                {
                    String str = "select uno from ticket where tno='" + Convert.ToString(i) + "'and cno= '" + Session["cno"] + "'";
                    SqlCommand sqlcmd = new SqlCommand(str, conn);
                    object temp = sqlcmd.ExecuteScalar();
                    string k1 = Convert.ToString(temp);
                    if (k1 != "")
                        CheckBoxList1.Items[i].Enabled = false;
                    
                }
            conn.Close();
        }
       
        //点击购买
        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = DropDownList1.SelectedItem.Text.Trim().ToString();
            string b = DropDownList2.SelectedItem.Text.Trim().ToString();
            string c = a + b + TextBox2.Text.ToString();//地址

            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            int count = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    count++;
                }
            }


            if(Label3.Text.Trim().ToString()=="")
            {
                Label6.Visible = true;
                Label6.Text = "请选择座位!";
            }
            else if (DropDownList1.SelectedItem.Text.Trim().ToString() == "请选择" || DropDownList2.SelectedItem.Text.Trim().ToString()=="请选择")
            {
                Label6.Visible = true;
                Label6.Text = "请选择地区!";
            }
            else if (TextBox2.Text.Trim().ToString() == "" || TextBox2.Text.Trim().ToString() == "详细地址")
            {
                Label6.Visible = true;
                Label6.Text = "请输入详细地址！";
            }
            else if (TextBox3.Text.Trim().ToString() == "")
            {
                Label6.Visible = true;
                Label6.Text = "请输入联系方式!";
            }
            else
            {
                Label6.Visible = false;
                //生成订单
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
                string time = DateTime.Now.ToString();//获得下单时的时间
                string str2 = "insert into BUY(UNO,ONO,btime,jine,shuliang) values('" + Session["yonghuNO"].ToString() + "','" + Convert.ToString(max) + "','" + time + "','" + Label5.Text.ToString() + "','" + Convert.ToString(count) + "')";
                SqlCommand sqlcmd2 = new SqlCommand(str2, conn);
                object temp1 = sqlcmd2.ExecuteScalar();
                Session["oNO"] = Convert.ToString(max);

                //生成发货单
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
                string strx = "insert into ED(ENO,ONO,CSTATUS,TEL,EDIZHI) values('" + Session["kuaidiNO"].ToString() + "','" + Convert.ToString(max) + "','" + Convert.ToString(1) + "','" + TextBox3.Text.Trim().ToString() + "','" + c.ToString() + "')";
                SqlCommand sqlcmdx = new SqlCommand(strx, conn);
                object tempx = sqlcmdx.ExecuteScalar();

                //标记已卖出的票
                string f = Label3.Text.Trim().ToString();
                string[] sarray = f.Split(' ');
                for (int i = 0; i < sarray.Length; i++)
                {
                    if (sarray[i] != " ")
                    {
                        string h = CheckBoxList1.Items[i].ToString();
                        string xx = "update ticket set uno='" + Session["yonghuNO"].ToString() + "' where cno= '" + Session["cno"] + "' and tno='" + sarray[i] + "'";
                        string xxx = "update ticket set ono='" + Convert.ToString(max) + "' where  cno= '" + Session["cno"] + "' and tno='" + sarray[i] + "'";
                        SqlCommand xx1 = new SqlCommand(xx, conn);
                        SqlCommand xxx1 = new SqlCommand(xxx, conn);
                        object xx2 = xx1.ExecuteScalar();
                        object xxx2 = xxx1.ExecuteScalar();
                    }
                }
                conn.Close();
                Response.Redirect("下单成功界面.aspx");
            }
            
        }

        
        //选择省份后下一个dropdownlist的值随之改变
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDownList1.SelectedItem.Text;
            if (a == "山东")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "济南", "青岛", "淄博", "枣庄", "东营", "烟台", "潍坊", "济宁", "泰安", "威海", "日照", "莱芜", "临沂", "德州", "聊城", "菏泽", "滨州" };
                for (int i = 0; i < city.Length; i++)
                {

                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "新疆")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "乌鲁木齐", "克拉玛依", "石河子", "阿拉尔市", "图木舒克", "五家渠", "哈密", "吐鲁番", "阿克苏", "喀什", "伊宁", "塔城", "阿勒泰", "奎屯", "奎屯", "昌吉", "阜康", "库尔勒", "阿图什", "乌苏" };
                for (int i = 0; i < city.Length; i++)
                {

                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "西藏")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "阿里地区", "都昌市", "拉萨市", "林芝市", "那曲市", "日喀则市", "山南市" };
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
                string[] city = { "请选择", "呼和浩特市", "包头市", "乌海市", "赤峰市", "通辽市", "鄂尔多斯市", "呼伦贝尔市", "巴彦淖尔市", "乌兰察布市" };
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
                string[] city = { "请选择", "南宁市", "柳州市", "桂林市", "梧州市", "北海市", "崇左市", "来宾市", "贺州市", "玉林市", "百色市", "河池市", "钦州市", "防城港市", "贵港市" };
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
                string[] city = { "请选择", "长春市", "吉林市", "四平市", "辽源市", "通化市", "白山市", "松原市", "白城市" };
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
                string[] city = { "请选择", "合肥市", "蚌埠市", "芜湖市", "淮南市", "亳州市", "阜阳市", "淮北市", "宿州市", "滁州市", "安庆市", "巢湖市", "马鞍山市", "宣城市", "黄山市", "池州市", "铜陵市" };
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
                string[] city = { "请选择", "成都市", "绵阳市", "德阳市", "广元市", "自贡市", "攀枝花市", "乐山市", "南充市", "内江市", "遂宁市", "广安市", "泸州市", "达州市", "眉山市", "宜宾市", "雅安市", "资阳市" };
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
                string[] city = { "请选择", "郑州市", "洛阳市", "开封市", "漯河市", "安阳市", "新乡市", "周口市", "三门峡市", "焦作市", "平顶山", "信阳市", "南阳市", "鹤壁市", "濮阳市", "许昌市", "商丘市", "驻马店市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "山西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "太原市", "大同市", "忻州市", "阳泉市", "长治市", "晋城市", "运城市", "朔州市", "晋中市", "运城市", "临汾市", "吕梁市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "山西")
            {
                DropDownList2.Items.Clear();
                string[] city = { "请选择", "西安市", "咸阳市", "铜川市", "延安市", "宝鸡市", "渭南市", "汉中市", "安康市", "商洛市", "榆林市" };
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
                string[] city = { "请选择", "台北市", "台中市", "基隆市", "高雄市", "台南市", "新竹市", "嘉义市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "香港")
            {
                DropDownList2.Items.Clear();
                string[] city = { "九龙", "香港岛", "新界" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "澳门")
            {
                DropDownList2.Items.Clear();
                string[] city = { "澳门半岛", "离岛" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
            if (a == "广东")
            {
                DropDownList2.Items.Clear();
                string[] city = { "广州市", "深圳市", "珠海市", "汕头市", "佛山市", "韶关市", "湛江市", "肇庆市", "江门市", "茂名市", "惠州市", "梅州市", "汕尾市", "河源市", "阳江市", "清远市", "东莞市", "中山市", "潮州市", "揭阳市", "云浮市" };
                for (int i = 0; i < city.Length; i++)
                {
                    DropDownList2.Items.Insert(i, city[i]);
                    DropDownList2.Items[i].Value = i.ToString();
                }
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Label2.Visible = true;

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //点击确定后更新金额的相关问题
        protected void Button2_Click(object sender, EventArgs e)
        {
            string a = DropDownList1.SelectedItem.Text.Trim().ToString();
            string b = DropDownList2.SelectedItem.Text.Trim().ToString();
            string c = a + b + TextBox2.Text.ToString();//地址

            string strconn = "Data Source=.;Initial Catalog=YCH1;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            int count = 0;
            int jine = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    string str = "select tkinds from ticket where cno= '" + Session["cno"] + "' and tno='" + CheckBoxList1.Items[i] + "'";
                    SqlCommand sqlcmdd = new SqlCommand(str, conn);
                    object temp = sqlcmdd.ExecuteScalar();
                    Label5.Visible = true;
                    int k = Convert.ToInt32(temp.ToString());
                    if (k == 1)
                        jine = jine + 188;
                    else if (k == 2)
                        jine = jine + 388;
                    else if (k == 3)
                        jine = jine + 588;
                    else if (k == 4)
                        jine = jine + 688;
                    else if (k == 5)
                        jine = jine + 988;
                    Label5.Text = Convert.ToString(jine);
                    count++;
                }
                Label4.Visible = true;
                Label4.Text = Convert.ToString(count);
            }
            if (count > 3)
            {
                Label2.Visible = true;
                Label2.Text = "每笔订单限购三张!";
                Label4.Visible = false;
                Label5.Visible = false;
            }
            else
            {
                Label2.Visible = false;
                string selval = "";
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        Label3.Visible = true;
                        selval += CheckBoxList1.Items[i].Value.ToString();
                        Label3.Text = selval;
                    }
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("下单页面.aspx");
        }
    }
}
