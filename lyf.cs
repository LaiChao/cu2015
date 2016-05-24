using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

//使用数据访问层添加的必备引用
using System.Text.RegularExpressions;
using System.Configuration;//
using System.Data.Odbc;
using System.Data;//DataView
using System.Collections.Specialized;
using System.Drawing;//Color
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;//Chart
//using System.Web.UI.Page;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Data.OracleClient;


namespace LyfHelper
{
    public static class lyf
    {
        public static bool IsPass()
        {
            return true;
            //bool b = false;
            ////今天日期
            //DateTime  sToday = DateTime.Now.Date;
            ////过期日期
            //string sEndDay = "2014-4-1";
            //DateTime dt = DateTime.Parse(sEndDay);
            ////判断是否过期
            //if (sToday < dt)
            //{ b = true; }

            //return b;
        }

        /// <summary>
        /// 判断是否为超级管理员
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Pwd"></param>
        /// <returns>返回true，则为超级管理员；false,则为否</returns>
        public static bool IsSupperMan(string ID, string Pwd)
        {
            //初始化标记
            bool b = false;
            //获取超级管理员的ID和PWD
            string sSupperID = System.Configuration.ConfigurationManager.AppSettings["SupperID"];
            string sSupperPwd = System.Configuration.ConfigurationManager.AppSettings["SupperPWD"];
            //判断超级管理员的ID和PWD是否为空。是，则返回false；否，则继续。
            if (string.IsNullOrEmpty(sSupperID) || string.IsNullOrEmpty(sSupperPwd))
            {
                return b;
            }
            //判断是否为超级管理员的ID和PWD。是，则返回true;否，则返回false
            if (sSupperID == ID && sSupperPwd == Pwd)
            {
                b = true;
            }
            return b;
        }

        public static void CreatTicket(string userID, string userData, Page page)
        {
            //构造身份验证票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userID, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
            //加密
            string value = FormsAuthentication.Encrypt(ticket);
            string name = FormsAuthentication.FormsCookieName; //.Auth
            //存入cookie
            HttpCookie cook = new HttpCookie(name, value);
            page.Response.Cookies.Add(cook);

            string url = page.Request.QueryString["ReturnUrl"];//ReturnUrl：跳转过来的网页都自动生成
            if (!string.IsNullOrEmpty(url)) //被动登录
            {
                page.Response.Redirect(url, true); //转到目标页面
            }
            else
            {
                page.Response.Redirect(FormsAuthentication.DefaultUrl, true);
            }
        }
        /// <summary>
        /// 创建用户验证票
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPwd">密码</param>
        /// <param name="userName">昵称</param>
        /// <param name="userRole">角色</param>
        /// <param name="page">所在网页</param>
        public static void CreatTicket(string userID, string userPwd, string userName, string userRole, Page page)
        {
            string userData = userID + "|" + userPwd + "|" + userName + "|" + userRole;
            //构造身份验证票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userID, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
            //加密
            string value = FormsAuthentication.Encrypt(ticket);
            string name = FormsAuthentication.FormsCookieName; //.Auth
            //存入cookie
            HttpCookie cook = new HttpCookie(name, value);
            page.Response.Cookies.Add(cook);

            string url = page.Request.QueryString["ReturnUrl"];//ReturnUrl：跳转过来的网页都自动生成
            if (!string.IsNullOrEmpty(url)) //被动登录
            {
                page.Response.Redirect(url, true); //转到目标页面
            }
            else
            {
                url = FormsAuthentication.DefaultUrl;
                page.Response.Redirect(url, true);
            }
        }
        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <param name="p">网页的实体</param>
        /// <param name="ctr">需要导出的内容</param>
        public static bool expExcle(Page p, HtmlGenericControl ctr)
        {
            bool b = false;
            if (!LyfHelper.lyf.IsPass())
            {
                return b ;
            }
            p.Response.Clear();//清除缓冲区流中的所有内容输出
            //name:要添加 value 的 HTTP 头名称。
            //value:要添加到头中的字符串。
            //p.Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            p.Response.AddHeader("content-disposition", "inline;filename=FileName.xls");

            //中文正常
            //p.Response.Charset = "utf-8";//获取或设置输出流的 HTTP 字符集
            p.Response.ContentEncoding = System.Text.Encoding.UTF8;//获取或设置输出流的 HTTP 字符集

            //中文为乱码
            //p.Response.Charset = "GB2312";//获取或设置输出流的 HTTP 字符集        
            //p.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//获取或设置输出流的 HTTP 字符集

            p.Response.ContentType = "application/ms-excel";// 输出流的 HTTP MIME 类型。默认值为“text/html”

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            ctr.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
            b = true;
            return b;
        }
        public static bool expExcle(Page p, HtmlGenericControl ctr,string FileName)
        {
            bool b = false;
            if (!LyfHelper.lyf.IsPass())
            {
                return b;
            }
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = "fileName";
            }
            string s = "attachment;filename=" + HttpUtility.UrlEncode(FileName) + ".xls";
            p.Response.Clear();//清除缓冲区流中的所有内容输出
            //name:要添加 value 的 HTTP 头名称。
            //value:要添加到头中的字符串。
            p.Response.AddHeader("content-disposition", s);

            //中文正常
            //p.Response.Charset = "utf-8";//获取或设置输出流的 HTTP 字符集
            p.Response.ContentEncoding = System.Text.Encoding.UTF8;//获取或设置输出流的 HTTP 字符集

            //中文为乱码
            //p.Response.Charset = "GB2312";//获取或设置输出流的 HTTP 字符集        
            //p.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//获取或设置输出流的 HTTP 字符集

            //------------未验证,来自百度百科
            //相对于Office2003是这样的:
            //Response.ContentType = "application/vnd.ms-excel"
            //Office2007对应的值:(for .xlsx files)
            //"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" 
            //--------------
            //".xls",先4种IE10下效果一样
            //"application/-excel"、"application/ms-excel"、"application/vnd.ms-excel"、"application/x-xls"

            p.Response.ContentType = "application/ms-excel";// 输出流的 HTTP MIME 类型。默认值为“text/html”

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            ctr.RenderControl(htmlWrite);
            p.Response.Write(stringWrite.ToString());
            p.Response.End();
            b = true;
            return b;
        }
        #region 单条数据
        /// <summary>
        /// 设置图形控件（单条线）
        /// </summary>
        /// <param name="chart">控件</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="XValue">X轴绑定在数据/字段</param>
        /// <param name="YValue">Y轴绑定在数据/字段</param>
        /// <param name="ChartType">图表样式：1为折线图，2为柱状图，3为饼状图</param>
        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string YValue, string ChartType)
        {
            int Width = 1200;//控件的宽度：单位是像素
            int Height = 700;//控件的高度：单位是像素
            getChart(chart, dataSource, XValue, YValue, ChartType, Width, Height);   
        }
        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string YValue, string ChartType,int width,int height)
        {

            //DataView dv = dv2 as DataView;
            chart.DataSource = dataSource;//数据源   
            if (width > 0)
            {
                chart.Width = width;//控件的宽度：单位是像素
            }
            else
            {
                chart.Width = 1200;
            }
            if (width > 0)
            {
                chart.Height = height;//控件的高度：单位是像素
            }
            else
            {
                chart.Height = 700;
            }    
            chart.RenderType = RenderType.ImageTag; //以图片的方式展示在网页（默认值）
            /*此属性决定MSChart生成的图形以何种方式送到客户端，有三种：   
            ImageTag，图形在服务端保存为临时文件，并将临时文件的URL作为HTML中<IMG>标签的SRC属性值。而此临时文件的URL规则及临时文件如何生成可由ImageLocation属性确定。   
            BinaryStreaming，不在服务端生成图形文件，<IMG>标签的SRC属性值将指向另一个负责生成图形的.aspx页面   
            ImageMap，不显示实际的图形，仅创建图片热区（image map）。   
            默认值是ImageTag，就是会在服务端生成临时文件。 */
            //数据绑定方法一：
            //chart.Series[0].Points.DataBindXY(dv, "DATA_DATE", dv, "IN_PUT2");
            //数据绑定方法二：
            chart.Series.Clear();
            chart.Series.Add("1");
            chart.Series[0].XValueMember = XValue;//X轴对应的字段
            chart.Series[0].YValueMembers = YValue;//Y轴对应的字段
            //chart.Series[0].Legend = "legend";//图例名

            chart.Series[0].IsValueShownAsLabel = true;//是否在标签上显示数据点的值
            chart.Series[0].IsVisibleInLegend = true;
            chart.Series[0].MarkerSize = 8;
            chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart.Series[0].MarkerColor = Color.DarkRed;
            chart.Series[0].ShadowOffset = 2;//阴影宽
            chart.Legends.Clear();
            chart.Legends.Add("legend");//添加一个图例
            chart.Legends[0].Title = "图例";//图例标题文本
            Title title = new Title();
            chart.Titles.Clear();
            title.Name = "title_lyf";
            chart.Titles.Add(title);


            //chart.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            // chart.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
            // chart.ChartAreas[0].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            // chart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
            switch (ChartType)
            {
                case "1":
                    chart.Series[0].ChartType = SeriesChartType.Line;//折线图
                    getChartArea(chart);
                    chart.Series[0].BorderWidth = 4;//拆线线宽
                    chart.Legends[0].Enabled = false;//不显示图例
                    chart.Titles[0].Text = "折线图";//标题显示的文本

                    break;
                case "2":
                    chart.Series[0].ChartType = SeriesChartType.Column;//柱状图
                    getChartArea(chart);
                    chart.Series[0]["PointWidth"] = "0.5";//柱宽                

                    chart.Series[0]["BarLabelStyle"] = "Center"; //数字显示在条柱中间                 
                    chart.Legends[0].Enabled = false;
                    chart.Titles[0].Text = "柱状图";

                    break;
                case "3":
                    chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chart.Series[0].PostBackValue = "#INDEX";
                    chart.Series[0].LegendPostBackValue = "#INDEX";
                    chart.Series[0].ChartType = SeriesChartType.Pie;//饼状图
                    chart.Series[0].LegendText = "#PERCENT:#VALX";//开启图例 序号：百分比：值（序号从0开始）
                    chart.Series[0].Label = "#VALX";//序号：百分比
                    //chart.Series[0]["PieLabelStyle"] = "Outside";//标签位置：外部（外部时才有连线）
                    //chart.Series[0]["PieLineColor"] = "Black";//连线颜色：黑
                    //chart.Series[0].IsXValueIndexed = false;
                    //chart.Series[0].IsValueShownAsLabel = false; 
                    //chart.Series[0].ToolTip = "#VALX";//显示提示用语
                    chart.Legends[0].Enabled = true;//显示图例

                    chart.Titles[0].Text = "饼状图";
                    break;
            }
            chart.DataBind();
        }

        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string YValue, string ChartType,int Num)
        {
            int Width = 1200;//控件的宽度：单位是像素
            int Height = 700;//控件的高度：单位是像素
            getChart(chart, dataSource, XValue, YValue, ChartType, Width, Height,Num);
        }
        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string YValue, string ChartType, int width, int height,int num)
        {

            //DataView dv = dv2 as DataView;
            chart.DataSource = dataSource;//数据源   
            if (width > 0)
            {
                chart.Width = width;//控件的宽度：单位是像素
            }
            else
            {
                chart.Width = 1200;
            }
            if (width > 0)
            {
                chart.Height = height;//控件的高度：单位是像素
            }
            else
            {
                chart.Height = 700;
            }
            chart.RenderType = RenderType.ImageTag; //以图片的方式展示在网页（默认值）
            /*此属性决定MSChart生成的图形以何种方式送到客户端，有三种：   
            ImageTag，图形在服务端保存为临时文件，并将临时文件的URL作为HTML中<IMG>标签的SRC属性值。而此临时文件的URL规则及临时文件如何生成可由ImageLocation属性确定。   
            BinaryStreaming，不在服务端生成图形文件，<IMG>标签的SRC属性值将指向另一个负责生成图形的.aspx页面   
            ImageMap，不显示实际的图形，仅创建图片热区（image map）。   
            默认值是ImageTag，就是会在服务端生成临时文件。 */
            //数据绑定方法一：
            //chart.Series[0].Points.DataBindXY(dv, "DATA_DATE", dv, "IN_PUT2");
            //数据绑定方法二：
            chart.Series.Clear();
            chart.Series.Add("1");
            chart.Series[0].XValueMember = XValue;//X轴对应的字段
            chart.Series[0].YValueMembers = YValue;//Y轴对应的字段
            //chart.Series[0].Legend = "legend";//图例名

            chart.Series[0].IsValueShownAsLabel = true;//是否在标签上显示数据点的值
            chart.Series[0].IsVisibleInLegend = true;
            chart.Series[0].MarkerSize = 8;
            chart.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart.Series[0].MarkerColor = Color.DarkRed;
            chart.Series[0].ShadowOffset = 2;//阴影宽
            chart.Legends.Clear();
            chart.Legends.Add("legend");//添加一个图例
            chart.Legends[0].Title = "图例";//图例标题文本
            Title title = new Title();
            chart.Titles.Clear();
            title.Name = "title_lyf";
            chart.Titles.Add(title);


            //chart.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
            // chart.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
            // chart.ChartAreas[0].Area3DStyle.Inclination = 30;//倾斜度(0～90)
            // chart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
            switch (ChartType)
            {
                case "1":
                    chart.Series[0].ChartType = SeriesChartType.Line;//折线图
                    getChartArea(chart);
                    chart.Series[0].BorderWidth = 4;//拆线线宽
                    chart.Legends[0].Enabled = false;//不显示图例
                    chart.Titles[0].Text = "折线图";//标题显示的文本

                    break;
                case "2":
                    chart.Series[0].ChartType = SeriesChartType.Column;//柱状图
                    getChartArea(chart);
                    chart.Series[0]["PointWidth"] = "0.5";//柱宽                

                    chart.Series[0]["BarLabelStyle"] = "Center"; //数字显示在条柱中间                 
                    chart.Legends[0].Enabled = false;
                    chart.Titles[0].Text = "柱状图";

                    break;
                case "3":
                    chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chart.Series[0].PostBackValue = "#INDEX";
                    chart.Series[0].LegendPostBackValue = "#INDEX";
                    chart.Series[0].ChartType = SeriesChartType.Pie;//饼状图
                    chart.Series[0].LegendText = "#PERCENT:#VALX";//开启图例 序号：百分比：值（序号从0开始）
                    chart.Series[0].Label = "#VALX";//序号：百分比
                    //chart.Series[0]["PieLabelStyle"] = "Outside";//标签位置：外部（外部时才有连线）
                    //chart.Series[0]["PieLineColor"] = "Black";//连线颜色：黑
                    //chart.Series[0].IsXValueIndexed = false;
                    //chart.Series[0].IsValueShownAsLabel = false; 
                    //chart.Series[0].ToolTip = "#VALX";//显示提示用语
                    chart.Legends[0].Enabled = true;//显示图例

                    chart.Titles[0].Text = "饼状图";
                    break;
            }
            chart.DataBind();
        }

        #endregion
        /// <summary>
        /// 获取坐标系
        /// </summary>
        /// <param name="chart">对应的控件</param>
        private static void getChartArea(Chart chart)
        {
            //chart.ChartAreas[0].AxisY.Title = "能耗量";//X轴标题，饼状图无效
            //chart.ChartAreas[0].AxisX.Title = "日期";//Y轴标题，饼状图无效                
            chart.ChartAreas[0].AxisX.Interval = 1;//X轴间隔，1为每个都显示

            chart.ChartAreas[0].AxisX.LineColor = Color.Black;//X轴颜色
            chart.ChartAreas[0].AxisX.LineWidth = 2;//X轴宽度
            chart.ChartAreas[0].AxisY.LineColor = Color.Black;//Y轴颜色
            chart.ChartAreas[0].AxisY.LineWidth = 2;//Y轴宽度

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.BlueViolet;//Y轴网格线
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.BlueViolet;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
        }

        #region 多条数据
        /// <summary>
        /// 设置图形控件（多条线）
        /// </summary>
        /// <param name="chart">控件</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="XValue">X轴绑定在数据/字段</param>
        /// <param name="YValues">Y轴绑定在数据/字段</param>
        /// <param name="ChartType">图表样式：1为折线图，2为柱状图，3为饼状图</param>
        /// 
        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string[] YValues, string ChartType, string[] Names)
        {
            int count = YValues.Length;
            chart.DataSource = dataSource;//数据源
            chart.Width = 1200;//控件的宽度：单位是像素
            chart.Height = 700;//控件的高度：单位是像素
            chart.RenderType = RenderType.ImageTag; //以图片的方式展示在网页（默认值）
            /*此属性决定MSChart生成的图形以何种方式送到客户端，有三种：   
            ImageTag，图形在服务端保存为临时文件，并将临时文件的URL作为HTML中<IMG>标签的SRC属性值。而此临时文件的URL规则及临时文件如何生成可由ImageLocation属性确定。   
            BinaryStreaming，不在服务端生成图形文件，<IMG>标签的SRC属性值将指向另一个负责生成图形的.aspx页面   
            ImageMap，不显示实际的图形，仅创建图片热区（image map）。   
            默认值是ImageTag，就是会在服务端生成临时文件。 */
            //数据绑定方法一：
            //DataView dv = dv2 as DataView;
            chart.Series.Clear();
            for (int i = 0; i < count; i++)
            {
                chart.Series.Add(i.ToString());
                chart.Series[i].Points.DataBindXY(dataSource, XValue, dataSource, YValues[i]);
                chart.Series[i].IsValueShownAsLabel = true;//是否在标签上显示数据点的值
                chart.Series[i].IsVisibleInLegend = true;
                chart.Series[i].MarkerSize = 8;
                chart.Series[i].MarkerStyle = MarkerStyle.Diamond;
                chart.Series[i].MarkerColor = Color.DarkRed;
                chart.Series[i].ShadowOffset = 2;//阴影宽 
                chart.Series[i].Name = Names[i].ToString();
            }
            chart.Legends.Clear();
            chart.Legends.Add("legend");//添加一个图例
            chart.Legends[0].Title = "图例";//图例标题文本
            Title title = new Title();
            title.Name = "title_lyf";
            chart.Titles.Clear();
            chart.Titles.Add(title);

            switch (ChartType)
            {
                case "1":
                    for (int i = 0; i < count; i++)
                    {
                        chart.Series[i].ChartType = SeriesChartType.Line;//折线图
                        chart.Series[i].BorderWidth = 4;//拆线线宽
                    }
                    getChartArea(chart);
                    chart.Legends[0].Enabled = true;//不显示图例          
                    chart.Titles[0].Text = "折线图";//标题显示的文本
                    break;
                case "2":
                    for (int i = 0; i < count; i++)
                    {
                        chart.Series[i].ChartType = SeriesChartType.Column;//柱状图
                        chart.Series[i]["PointWidth"] = "0.5";//柱宽                 
                        chart.Series[i]["BarLabelStyle"] = "Center"; //数字显示在条柱中间   
                    }
                    getChartArea(chart);
                    chart.Legends[0].Enabled = true;
                    chart.Titles[0].Text = "柱状图";
                    break;
                //case "3":
                //    chart.Series[0].ChartType = SeriesChartType.Pie;//饼状图
                //    chart.Series[0].LegendText = "#INDEX:#PERCENT:#VALX";//开启图例 序号：百分比：值（序号从0开始）
                //    chart.Series[0].Label = "#INDEX:#PERCENT";//序号：百分比
                //    chart.Series[0]["PieLabelStyle"] = "Outside";//标签位置：外部（外部时才有连线）
                //    chart.Series[0]["PieLineColor"] = "Black";//连线颜色：黑
                //    //chart.Series[0].IsXValueIndexed = false;
                //    //chart.Series[0].IsValueShownAsLabel = false; 
                //    //chart.Series[0].ToolTip = "#VALX";//显示提示用语
                //    chart.Legends[0].Enabled = true;//显示图例
                //    break;
            }
            chart.DataBind();
        }

        public static void getChart(Chart chart, IEnumerable dataSource, string XValue, string[] YValues, string ChartType)
        {
            int count = YValues.Length;
            chart.DataSource = dataSource;//数据源
            chart.Width = 1200;//控件的宽度：单位是像素
            chart.Height = 700;//控件的高度：单位是像素
            chart.RenderType = RenderType.ImageTag; //以图片的方式展示在网页（默认值）
            /*此属性决定MSChart生成的图形以何种方式送到客户端，有三种：   
            ImageTag，图形在服务端保存为临时文件，并将临时文件的URL作为HTML中<IMG>标签的SRC属性值。而此临时文件的URL规则及临时文件如何生成可由ImageLocation属性确定。   
            BinaryStreaming，不在服务端生成图形文件，<IMG>标签的SRC属性值将指向另一个负责生成图形的.aspx页面   
            ImageMap，不显示实际的图形，仅创建图片热区（image map）。   
            默认值是ImageTag，就是会在服务端生成临时文件。 */
            //数据绑定方法一：
            //DataView dv = dv2 as DataView;
            chart.Series.Clear();
            for (int i = 0; i < count; i++)
            {
                chart.Series.Add(i.ToString());
                chart.Series[i].Points.DataBindXY(dataSource, XValue, dataSource, YValues[i]);
                chart.Series[i].IsValueShownAsLabel = true;//是否在标签上显示数据点的值
                chart.Series[i].IsVisibleInLegend = true;
                chart.Series[i].MarkerSize = 8;
                chart.Series[i].MarkerStyle = MarkerStyle.Diamond;
                chart.Series[i].MarkerColor = Color.DarkRed;
                chart.Series[i].ShadowOffset = 2;//阴影宽 
            }
            chart.Legends.Clear();
            chart.Legends.Add("legend");//添加一个图例
            chart.Legends[0].Title = "图例";//图例标题文本
            Title title = new Title();
            title.Name = "title_lyf";
            chart.Titles.Clear();
            chart.Titles.Add(title);

            switch (ChartType)
            {
                case "1":
                    for (int i = 0; i < count; i++)
                    {
                        chart.Series[i].ChartType = SeriesChartType.Line;//折线图
                        chart.Series[i].BorderWidth = 4;//拆线线宽
                    }
                    getChartArea(chart);
                    chart.Legends[0].Enabled = true;//不显示图例
                    chart.Titles[0].Text = "折线图";//标题显示的文本
                    break;
                case "2":
                    for (int i = 0; i < count; i++)
                    {
                        chart.Series[i].ChartType = SeriesChartType.Column;//柱状图
                        chart.Series[i]["PointWidth"] = "0.5";//柱宽                 
                        chart.Series[i]["BarLabelStyle"] = "Center"; //数字显示在条柱中间   
                    }
                    getChartArea(chart);
                    chart.Legends[0].Enabled = true;
                    chart.Titles[0].Text = "柱状图";
                    break;
                //case "3":
                //    chart.Series[0].ChartType = SeriesChartType.Pie;//饼状图
                //    chart.Series[0].LegendText = "#INDEX:#PERCENT:#VALX";//开启图例 序号：百分比：值（序号从0开始）
                //    chart.Series[0].Label = "#INDEX:#PERCENT";//序号：百分比
                //    chart.Series[0]["PieLabelStyle"] = "Outside";//标签位置：外部（外部时才有连线）
                //    chart.Series[0]["PieLineColor"] = "Black";//连线颜色：黑
                //    //chart.Series[0].IsXValueIndexed = false;
                //    //chart.Series[0].IsValueShownAsLabel = false; 
                //    //chart.Series[0].ToolTip = "#VALX";//显示提示用语
                //    chart.Legends[0].Enabled = true;//显示图例
                //    break;
            }
            chart.DataBind();
        }
        #endregion
    }
}