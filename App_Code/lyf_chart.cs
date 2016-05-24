using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;//DataView
using System.Web.UI.DataVisualization.Charting;//Chart
using System.Drawing;//Color
using System.Web.UI.WebControls;
using System.Collections;
//using System.Web.UI.Page;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.IO;
/// <summary>
///需要一个chart控件，并且包含一个series,一个chartAreas
/// 
/// </summary>
public static class lyf_chart
{

    /// <summary>
    /// 获取下拉菜单：年份
    /// </summary>
    /// <param name="ddlYear">对应年份的下拉菜单控件</param>
    public static void getddlYear(DropDownList ddlYear)
    {
        ddlYear.Items.Clear();

        string strYear = DateTime.Today.Year.ToString();
        int intYear = int.Parse(strYear);
        for (int i = 2012; i <= intYear; i++)
        {
            ListItem li = new ListItem(i.ToString() + "年", i.ToString());
            ddlYear.Items.Add(li);
        }
    }
    /// <summary>
    /// 获取下拉菜单：月份
    /// </summary>
    /// <param name="ddlMonth">对应月份的下拉菜单控件</param>
    public static void getddlMonth(DropDownList ddlMonth)
    {
        ddlMonth.Items.Clear();
        for (int i = 1; i < 13; i++)
        {
            //方法一。
            //ListItem li = new ListItem();
            //li.Text = i.ToString() + "月";
            //li.Value = i.ToString();
            //方法二。
            ListItem li = new ListItem(i.ToString() + "月", i.ToString());
            ddlMonth.Items.Add(li);
        }
    }
    /// <summary>
    /// 获取下拉菜单：报表类型（年，月，日）
    /// </summary>
    /// <param name="ddlClass">对应的下拉菜单控件</param>
    public static void getddlClass(DropDownList ddlClass)
    {
        ddlClass.Items.Clear();
        ListItem li = new ListItem("日", "Day");
        ListItem li2 = new ListItem("月", "Month");
        ListItem li3 = new ListItem("年", "Year");
        ddlClass.Items.Add(li);
        ddlClass.Items.Add(li2);
        ddlClass.Items.Add(li3);
    }

    /// <summary>
    /// 测试数据
    /// </summary>
    /// <returns></returns>
    public static List<zhuanHuan> getZhuanHuan()
    {
        List<zhuanHuan> list = new List<zhuanHuan>()
            {
                new zhuanHuan(){ UnitName="变配电系统", WaterValue=600,  DianValue=1080, MeiValue=800},
                new zhuanHuan(){ UnitName="锅炉房系统", WaterValue=700,  DianValue=1000, MeiValue=800},
                new zhuanHuan(){ UnitName="供暖系统", WaterValue=660,  DianValue=1080, MeiValue=600},
                new zhuanHuan(){ UnitName="生活热水供应系统", WaterValue=600,  DianValue=1180, MeiValue=800},
                new zhuanHuan(){ UnitName="中央空调系统", WaterValue=500,  DianValue=1080, MeiValue=900},
                new zhuanHuan(){ UnitName="分体空调系统", WaterValue=600,  DianValue=1000, MeiValue=800},
                new zhuanHuan(){ UnitName="供水系统冷水", WaterValue=680,  DianValue=1180, MeiValue=870},
                new zhuanHuan(){ UnitName="供水系统热水", WaterValue=600,  DianValue=1080, MeiValue=800},          
            };
        return list;
    }
    public static List<ReportMain> getReportMain()
    {
        List<ReportMain> list = new List<ReportMain>() {
        new ReportMain() { ENERGY_NAME="水", VALUE=5000,VALUE2=5000,VALUE3=5000 },
        new ReportMain() { ENERGY_NAME="电", VALUE=20000,VALUE2=9000,VALUE3=9000 },
        new ReportMain() { ENERGY_NAME="煤", VALUE=4000,VALUE2=3900,VALUE3=3900 } 
        };
        return list;
    }
    public static List<Transform> getTransform()
    {
        List<Transform> list = new List<Transform>() {
        new Transform{ UnitName="A锅炉", InputEnergyName="电", InputEnergyValue=2000, InputSCCValue=800,OutputEnergyName="热", OutputEnergyValue=900, OutputSCCValue=700},
        new Transform{ UnitName="B锅炉", InputEnergyName="电", InputEnergyValue=2000, InputSCCValue=800,OutputEnergyName="热", OutputEnergyValue=900, OutputSCCValue=700},
        new Transform{ UnitName="A空调", InputEnergyName="电", InputEnergyValue=1200, InputSCCValue=500,OutputEnergyName="热", OutputEnergyValue=500, OutputSCCValue=400},
        };
        return list;
    }
    public static List<EnergyNet> getEnergyNet()
    {
        List<EnergyNet> list = new List<EnergyNet>() {
        new EnergyNet{  UnitName="一", InputEnergyName="1日", InputEnergyValue=4000, InputSCCValue=2000},
        new EnergyNet{ UnitName="1", InputEnergyName="2日", InputEnergyValue=2000, InputSCCValue=1200},
        new EnergyNet{UnitName="2", InputEnergyName="3日", InputEnergyValue=3000, InputSCCValue=300},
        new EnergyNet{  UnitName="二", InputEnergyName="4日", InputEnergyValue=3400, InputSCCValue=1000},
        new EnergyNet{ UnitName="1", InputEnergyName="5日", InputEnergyValue=1500, InputSCCValue=600},
        new EnergyNet{UnitName="2", InputEnergyName="6日", InputEnergyValue=2500, InputSCCValue=1000},
        new EnergyNet{  UnitName="三", InputEnergyName="7日", InputEnergyValue=1000, InputSCCValue=400},
        new EnergyNet{ UnitName="1", InputEnergyName="8日", InputEnergyValue=500, InputSCCValue=200},
        new EnergyNet{UnitName="2", InputEnergyName="9日", InputEnergyValue=400, InputSCCValue=230},
        };
        return list;
    }
}
public class zhuanHuan
{
    public string UnitName { get; set; }
    public string EnergyWater { get; set; }
    public decimal WaterValue { get; set; }
    public string EnergyDian { get; set; }
    public decimal DianValue { get; set; }
    public string EnergyMei { get; set; }
    public decimal MeiValue { get; set; }
}
public class ReportMain
{
    public string ENERGY_ID { get; set; }
    public string ENERGY_NAME { get; set; }
    public decimal VALUE { get; set; }
    public decimal VALUE2 { get; set; }
    public decimal VALUE3 { get; set; }
    public decimal ZheBiaoXishu { get; set; }
    public decimal ZheBiaoMei { get; set; }
}
public class Transform
{
    public string UnitName { get; set; }
    public string InputEnergyName { get; set; }
    public decimal InputEnergyValue { get; set; }
    public decimal InputSCCValue { get; set; }
    public string OutputEnergyName { get; set; }
    public decimal OutputEnergyValue { get; set; }
    public decimal OutputSCCValue { get; set; }
    public decimal ConverserRate { get { return (this.OutputSCCValue / this.InputSCCValue); }  }
}
public class EnergyNet
{
    public string UnitName { get; set; }
    public string InputEnergyName { get; set; }
    public decimal InputEnergyValue { get; set; }
    public decimal InputSCCValue { get; set; }
}