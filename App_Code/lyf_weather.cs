using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
/// <summary>
///lyf_weather 的摘要说明
/// </summary>
/// 
[Table(Name="weather")]
public class lyf_weather
{
    //日期
    [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
    public DateTime Date { get; set; }
    //白天温度
    [Column()]
    public int DayTemper { get; set; }
    //夜间温度
    [Column()]
    public int NeightTemper { get; set; }
    //更新时间
    [Column()]
    public DateTime UpdataDate { get; set; }
    //Id
    [Column()]
    public int Id { get; set; }
    public static List<lyf_weather> GetList(List<lyf_weather> list)
    {
        return list;
    }
	public lyf_weather()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

}

public class FileInfos 
{
    public string FileName { get; set; }
    public  static string UpLoadFilePath = "~/others/Uploads/";
    public static string UpLoadHeTongPath = "~/others/HeTong/";
    static FileInfos()
    {
        getFileInfoList =new List<FileInfo>();
    }
    public  static List<FileInfos> getFileList()
    {
        List<FileInfos> list = new List<FileInfos>();
        return list;
    }
    public static List<FileInfo> getFileInfoList
    {
        get;
        set;
    }
}

