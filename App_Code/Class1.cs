using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Class1 的摘要说明
/// </summary>
using System;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace hya.Control
{
    /**/
    /// <summary>
    ///    柱状图控件
    ///    需要传入列表项名，值，超级连接地址
    /// </summary>
    [ToolboxData("<{0}:Columniation runat=server></{0}:Columniation>")]
    public class Columniation : System.Web.UI.WebControls.WebControl
    {
        private const int _colorLimit = 12;  //颜色列表
        private Color[] _color = 
   { 
    Color.Chocolate,
    Color.YellowGreen,
    Color.Olive,
    Color.DarkKhaki,
    Color.Sienna,
    Color.PaleGoldenrod,
    Color.Peru,
    Color.Tan,
    Color.Khaki,
    Color.DarkGoldenrod,
    Color.Maroon,
    Color.OliveDrab
   };

        private DataTable items;//列表项名称和值
        private string text = "数据";
        private string datastd = "标准值";
        private string data = "实时数据";

        int kds = 10; //刻度数
        float kddw = 100;  //没刻度大小

        int zmheight = 500; //真个图区高
        int zmwidth = 740;  //真个图区宽

        int height = 400;//呈现区高
        int width = 730;
        int cxtop = 30;//呈现区距顶距离
        int cxleft = 30;//呈现区左边距离

        Color bzlink = Color.Black;//标准线颜色

        int Chart_Flag = 1;
        Bitmap bm;
        int Displacement = 0; //获取负坐标刻度数

        [Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        [Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string DataStdName
        {
            get
            {
                return datastd;
            }

            set
            {
                datastd = value;
            }
        }

        [Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string DataName
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        /**/
        /// <summary>
        /// 需要呈现的数据
        /// </summary>
        public DataTable Items
        {
            set
            { items = value; }
        }

        /**/
        /// <summary>
        /// 需要显示的刻度量
        /// </summary>
        public int Kdcount
        {
            set { kds = value; }
        }

        /**/
        /// <summary>
        /// 刻度大小
        /// </summary>

        public float Kddw
        { set { kddw = value; } }

        public int ChatStyle
        { set { this.Chart_Flag = value; } }

        /**/
        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param text="output"> 要写出到的 HTML 代码 </param>
        protected override void Render(HtmlTextWriter output)
        {
            //if(dt==null)
            //{
            // return "没有数据";
            //}
            //设计样式
            kd(items);
            output.Write(makeimage(items, "c:/"));

        }

        private string makeimage(DataTable dt, string imagefile)
        {


            string url = "";

            switch (Chart_Flag)
            {
                case 1:
                    {

                        this.Draw_X_Y_Bar(dt);
                        url = this.Drar_Bar(dt);

                        break;
                    }
                case 2:
                    {


                        this.Draw_X_Y(dt);
                        url = this.Drow_Lin(dt);

                        break;
                    }
                case 3:
                    {

                        url = this.Draw_Pie(dt);
                        break;
                    }

            }

            return url;


        }
        /**/
        /// <summary>
        /// 换算成实际值
        /// </summary>
        /// <param text="kd">提供的值</param>
        /// <returns>返回换算后的实际值</returns>
        private float bl(float kd)
        {
            float bls = 1;
            bls = (float)height / ((float)kds * (float)kddw);
            return (float)kd * bls;
        }

        //通过数据计算刻度,和负坐标数#region //通过数据计算刻度,和负坐标数

        private void kd(DataTable dt)
        {
            float mintest = float.MaxValue;
            float maxtest = float.MinValue;

            float maxnegative = 0f;


            for (int j = 1; j < dt.Columns.Count; j++)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float test = System.Convert.ToSingle(dt.Rows[i][j]);
                    //求最小值
                    if (test < 0 && test < maxnegative)
                    {
                        maxnegative = test;
                    }
                    //求最大值
                    if (test > maxtest)
                    {
                        maxtest = test;
                    }
                }
            }

            maxtest = maxtest + Math.Abs(maxnegative);

            // this.Page .Response .Write (maxtest);

            kddw = maxtest / kds;





            double exp = Convert.ToDouble(Math.Floor(Math.Log10(maxtest)));

            // this.Page .Response .Write ("exp"+exp.ToString ()+"<br>");
            float tempMax = Convert.ToSingle(Math.Ceiling(maxtest / Math.Pow(10, exp)) * Math.Pow(10, exp));

            // this.Page .Response .Write ("temp_Max"+exp.ToString ()+"<br>");


            kddw = tempMax / kds;
            double expTick = Convert.ToDouble(Math.Floor(Math.Log10(kddw)));
            kddw = Convert.ToSingle(Math.Ceiling(kddw / Math.Pow(10, expTick)) * Math.Pow(10, expTick));
            this.Displacement = Math.Abs((int)Math.Floor(maxnegative / kddw));
            // this.Page .Response.Write (this.Displacement);


        }

        //绘制折线图#region  绘制折线图

        private string Drow_Lin(DataTable dt)
        {


            //通过循环画出曲线图   
            int x = -1;
            int bzy = -1;



            Graphics bp = Graphics.FromImage(bm);
            for (int j = 1; j < dt.Columns.Count; j++)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //标准刻度



                    float bzkd = bl(System.Convert.ToSingle(dt.Rows[i].ItemArray[j]));
                    //实际刻度
                    // float sjkd=bl(System.Convert.ToSingle(dt.Rows[i].ItemArray[2]));

                    int bztop = cxtop + height - (int)bzkd - 3 - (int)(bl(this.Displacement * kddw));
                    //填充标准柱(画刷，起点Ｘ，起点Ｙ，宽，高）



                    bp.FillRectangle(new SolidBrush(_color[j - 1]), (i * 40) + cxleft + 20 - 3, bztop, 6, 6);
                    // int sstop=zmheight-(int)sjkd-(zmheight-cxtop-height)-3;
                    //填充实时点(画刷，起点Ｘ，起点Ｙ，宽，高）
                    // bp.FillRectangle(new SolidBrush(ss),(i*30)+cxleft,sstop,6,6);

                    //绘制点到点连接线
                    if (x != -1)
                    {
                        //绘制标准点连接线

                        bp.DrawLine(new Pen(_color[j - 1], 1.6F), new Point(x, bzy), new Point((i * 40) + cxleft + 20, bztop));
                        //绘制实时点连接线
                        // bp.DrawLine(new Pen(ss,1.6F),new Point(x+3,ssy+4),new Point((i*30)+cxleft+10,sstop+4));
                    }
                    x = (i * 40) + cxleft + 20;
                    bzy = bztop;
                    // ssy=sstop;
                    //  bp.DrawString(dt.Rows[i].ItemArray[0].ToString (),new Font("宋体",9),new SolidBrush(Color.Black),new PointF((i*40)+cxleft+10,height+cxtop+1));


                }

                x = -1;
            }
            FileStream fs = new FileStream(Page.Server.MapPath(Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg")), FileMode.Create);
            bm.Save(fs, ImageFormat.Jpeg);

            bm.Dispose();
            bp.Dispose();
            fs.Close();
            return "<img src=" + Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg") + " ></img>";

        }

        //画住状图　画住状图#region 画住状图

        private string Drar_Bar(DataTable dt)
        {
            Graphics bp = Graphics.FromImage(bm);

            int flag = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    float sjkd = bl(System.Convert.ToSingle(dt.Rows[i].ItemArray[j]));

                    float top = cxtop + height - (int)sjkd - (int)(bl(this.Displacement * kddw));
                    if (sjkd < 0)
                    {
                        top = top + sjkd;
                        sjkd = Math.Abs(sjkd);
                    }

                    bp.FillRectangle(new SolidBrush(this._color[j]), (flag * 40) + cxleft + 20, top, 20, sjkd);

                    //    this.Page .Response .Write ("<br>"+  (flag*40+cxleft+20) );

                    flag++;


                }
            }

            FileStream fs = new FileStream(Page.Server.MapPath(Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg")), FileMode.Create);
            bm.Save(fs, ImageFormat.Jpeg);

            bm.Dispose();
            bp.Dispose();
            fs.Close();
            return "<img src=" + Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg") + " ></img>";


        }

        //画　X,Y 轴 线和刻度#region  画　X,Y 轴 线和刻度

        private void Draw_X_Y(DataTable dt)
        {

            //调整宽度
            width = 45 * dt.Rows.Count + 30;

            zmwidth = width + cxleft + 80;
            //创建一个画布

            bm = new Bitmap(zmwidth, zmheight);
            //在新建的画布上画一个图
            Graphics bp = Graphics.FromImage(bm);

            bp.Clear(Color.AliceBlue);
            //填充图表呈现区背景(画刷,起点x，起点Y，高，宽)
            bp.FillRectangle(new SolidBrush(Color.WhiteSmoke), cxleft, cxtop, width, height);
            //描绘呈现区边框
            bp.DrawRectangle(Pens.Black, cxleft, cxtop, width, height);

            //绘制图表名称
            bp.DrawString(text, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(zmwidth / 2, 10));


            //绘制图表说明
            bp.DrawRectangle(Pens.Black, cxleft + width + 10, zmheight / 2, 60, 15 * dt.Columns.Count - 1);
            for (int j = 0; j < dt.Columns.Count - 1; j++)
            {
                bp.FillRectangle(new SolidBrush(this._color[j]), cxleft + width + 10 + 2, zmheight / 2 + 6 + 16 * j, 8, 8);
                //文字说明
                bp.DrawString(dt.Columns[j + 1].ColumnName, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(cxleft + width + 10 + 2 + 8, zmheight / 2 + 4 + j * 12));
            }




            //通过循环绘制标准线
            for (int i = 0; i <= kds; i++)
            {


                string Cur_Kd;
                if (i - this.Displacement != 0)
                {
                    Cur_Kd = ((i - this.Displacement) * (kddw)).ToString("#,###.##");
                    // this.Page .Response .Write ("<br>abc"+Cur_Kd.ToString ());
                }
                else
                {
                    Cur_Kd = "0";
                }

                bp.DrawString(Cur_Kd, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(2, zmheight - (bl(i * kddw) + (zmheight - cxtop - height) + 4)));
                //填充标准线(画刷，起点Ｘ，起点Ｙ，宽，高）
                int top = cxtop + height - (int)(bl(i * kddw));

                bp.DrawLine(new Pen(bzlink), new Point(cxleft - 4, top), new Point(cxleft + width, top));

            }

            for (int j = 1; j < dt.Rows.Count + 1; j++)
            {

                bp.DrawLine(new Pen(bzlink), new Point(cxleft + j * 40, (int)(cxtop + height - bl(this.Displacement * kddw))), new Point(cxleft + j * 40, (int)(cxtop + height - bl(this.Displacement * kddw)) + 4));

                bp.DrawString(dt.Rows[j - 1].ItemArray[0].ToString(), new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(((j - 1) * 40) + cxleft + 10, (int)(cxtop + height - bl(this.Displacement * kddw)) + 1));

            }
        }

        //画　柱状 x,y 　刻度#region 画　柱状 x,y 　刻度

        private void Draw_X_Y_Bar(DataTable dt)
        {
            //调整宽度
            width = 45 * dt.Rows.Count * (dt.Columns.Count - 1) + 10;

            zmwidth = width + cxleft + 80;
            //创建一个画布

            bm = new Bitmap(zmwidth, zmheight);
            //在新建的画布上画一个图
            Graphics bp = Graphics.FromImage(bm);

            bp.Clear(Color.AliceBlue);
            //填充图表呈现区背景(画刷,起点x，起点Y，高，宽)
            bp.FillRectangle(new SolidBrush(Color.WhiteSmoke), cxleft, cxtop, width, height);
            //描绘呈现区边框
            bp.DrawRectangle(Pens.Black, cxleft, cxtop, width, height);

            //绘制图表名称
            bp.DrawString(text, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(zmwidth / 2, 10));


            //绘制图表说明
            bp.DrawRectangle(Pens.Black, cxleft + width + 10, zmheight / 2, 60, 15 * dt.Columns.Count - 1);
            for (int j = 1; j < dt.Columns.Count; j++)
            {
                bp.FillRectangle(new SolidBrush(this._color[j]), cxleft + width + 10 + 2, zmheight / 2 + 6 + 16 * (j - 1), 8, 8);
                //文字说明
                bp.DrawString(dt.Columns[j].ColumnName, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(cxleft + width + 10 + 2 + 8, zmheight / 2 + 6 + 16 * (j - 1)));
            }




            //通过循环绘制标准线
            for (int i = 0; i <= kds; i++)
            {


                string Cur_Kd;
                if (i - this.Displacement != 0)
                {
                    Cur_Kd = ((i - this.Displacement) * (kddw)).ToString("#,###.##");
                    // 
                }
                else
                {
                    Cur_Kd = "0";
                }

                bp.DrawString(Cur_Kd, new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(2, zmheight - (bl(i * kddw) + (zmheight - cxtop - height) + 4)));
                //填充标准线(画刷，起点Ｘ，起点Ｙ，宽，高）
                int top = cxtop + height - (int)(bl(i * kddw));

                bp.DrawLine(new Pen(bzlink), new Point(cxleft - 4, top), new Point(cxleft + width, top));
                //   this.Page .Response .Write ("<br>abc"+Cur_Kd.ToString ()); 
            }
            if (dt.Columns.Count == 2)
            { }
            else
            {

                for (int j = 1; j < dt.Rows.Count + 1; j++)
                {

                    bp.DrawLine(new Pen(bzlink), new Point(cxleft + (dt.Columns.Count - 1) * j * 40, (int)(cxtop + height - bl(this.Displacement * kddw))), new Point(cxleft + (dt.Columns.Count - 1) * j * 40, (int)(cxtop + height - bl(this.Displacement * kddw)) + 12));

                    bp.DrawString(dt.Rows[j - 1].ItemArray[0].ToString(), new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(((dt.Columns.Count - 1) * (j - 1) * 40) + cxleft + 40, (int)(cxtop + height - bl(this.Displacement * kddw)) + 1));

                }
            }

        }

        // 饼状图#region  饼状图

        private string Draw_Pie(DataTable dt)
        {

            int width = 240;
            const int page_top_margin = 15;

            float total = 0.0F, tmp;
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                tmp = Convert.ToSingle(dt.Rows[i][1]);
                total += tmp;
            }

            Font fontLegend = new Font("Verdana", 10);

            Font fontTitle = new Font("Verdana", 12, FontStyle.Bold);
            int titleHeight = fontTitle.Height + page_top_margin;

            int row_gap = 6;
            int start_of_rect = 8;
            int rect_width = 14;
            int rect_height = 16;

            int row_height;
            if (rect_height > fontLegend.Height) row_height = rect_height; else row_height = fontLegend.Height;
            row_height += row_gap;

            int legendHeight = row_height * (dt.Rows.Count + 1);
            int height = width + legendHeight + titleHeight + page_top_margin;
            int pieHeight = width;
            Rectangle pieRect = new Rectangle(0, titleHeight, width, pieHeight);

            float currentDegree = 0.0F;

            Bitmap bm = new Bitmap(width, height);
            Graphics objGraphics = Graphics.FromImage(bm);

            SolidBrush blackBrush = new SolidBrush(Color.Black);

            objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                objGraphics.FillPie(
                  new SolidBrush(this._color[i]),
                 pieRect,
                 currentDegree,
                 Convert.ToSingle(dt.Rows[i][1]) / total * 360);

                currentDegree += Convert.ToSingle(dt.Rows[i][1]) / total * 360;
            }

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            objGraphics.DrawString(this.datastd, fontTitle, blackBrush,
             new Rectangle(0, 0, width, titleHeight), stringFormat);

            objGraphics.DrawRectangle(
             new Pen(Color.Gray, 1),
             0,
             height - legendHeight,
             width - 4,
             legendHeight - 1);

            int y = height - legendHeight + row_gap;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                objGraphics.FillRectangle(
                 new SolidBrush(this._color[i]),
                 start_of_rect,  // x
                 y,
                 rect_width,
                 rect_height);

                objGraphics.DrawString(
                 Convert.ToString(dt.Rows[i][0])
                 + " - " +
                 Convert.ToString(dt.Rows[i][1]),
                 fontLegend,
                 blackBrush,
                 start_of_rect + rect_width + 4,
                 y);

                y += rect_height + row_gap;

            }

            FileStream fs = new FileStream(Page.Server.MapPath(Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg")), FileMode.Create);
            bm.Save(fs, ImageFormat.Jpeg);

            bm.Dispose();
            objGraphics.Dispose();
            fs.Close();
            return "<img src=" + Page.Request.Url.AbsolutePath.Replace(".aspx", ".jpg") + " ></img>";
        }
    }
}
