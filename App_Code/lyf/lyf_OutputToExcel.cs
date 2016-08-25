using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
///lyf_OutputToExcel 的摘要说明
/// </summary>
public static class lyf_OutputToExcel
{
    public static void expExcle(Page p, HtmlGenericControl ctr, string FileName)
    {
        if (string.IsNullOrEmpty(FileName))
        {
            FileName = "fileName";
        }
        FileName += ".xls";
        string outputFilename = null;
        string s = "inline;filename=" + HttpUtility.UrlEncode(FileName);
        p.Response.Clear();//清除缓冲区流中的所有内容输出
        //name:要添加 value 的 HTTP 头名称。
        //value:要添加到头中的字符串。

        string browser = HttpContext.Current.Request.UserAgent.ToUpper();
        if (browser.Contains("MS") == true && browser.Contains("IE") == true)
        {
            outputFilename = s;
        }
        else if (browser.Contains("FIREFOX") == true)
        {
            outputFilename = "inline;filename=\"" + FileName+"\"";
        }
        else
        {
            outputFilename = s;
        }

        p.Response.AddHeader("Content-Disposition", outputFilename);

        //p.Response.AddHeader("content-disposition", s);

        ////中文正常
        //p.Response.Charset = "utf-8";//获取或设置输出流的 HTTP 字符集
        p.Response.ContentEncoding = System.Text.Encoding.UTF8;//获取或设置输出流的 HTTP 字符集
        //p.Response.HeaderEncoding = System.Text.Encoding.UTF8; 

        //中文为乱码
        //p.Response.Charset = "GB2312";//获取或设置输出流的 HTTP 字符集        
        //p.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//获取或设置输出流的 HTTP 字符集
        //p.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("GB2312");

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
        string sMeta = "<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=utf-8\" />";
        p.Response.Write(sMeta);//待测试
        p.Response.Write(stringWrite.ToString());
        p.Response.End();
    }
    public static bool expExcle2(Page p, HtmlGenericControl ctr, string FileName)
    {
        bool b = false;
        //if (!LyfHelper.lyf.IsPass())
        //{
        //    return b;
        //}
        p.Response.Clear();//清除缓冲区流中的所有内容输出
        //name:要添加 value 的 HTTP 头名称。
        //value:要添加到头中的字符串。
        if (string.IsNullOrEmpty(FileName))
        {
            FileName = "fileName";
        }
        //
        // FileNamew为中文时：
        //HttpUtility.UrlEncode(FileName)：IE10正常，火狐乱码
        string s = "attachment;filename=" + HttpUtility.UrlEncode(FileName) + ".xls";
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


        p.Response.ContentType = "application/x-xls";// 输出流的 HTTP MIME 类型。默认值为“text/html”

        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        ctr.RenderControl(htmlWrite);
        p.Response.Write(stringWrite.ToString());
        p.Response.End();
        b = true;
        return b;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="p">页面名称，本业就用this</param>
    /// <param name="ctr">要导出的控件，我们这里是divPrint,导出后的文件名（不用加后缀名）</param>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public static void expWord(Page p, HtmlGenericControl ctr, string FileName)
    {
        if (string.IsNullOrEmpty(FileName))
        {
            FileName = "fileName";
        }
        //inline
        string s = "attachment;filename=" + HttpUtility.UrlEncode(FileName) + ".doc";
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

        p.Response.ContentType = "application/ms-word";// 输出流的 HTTP MIME 类型。默认值为“text/html”

        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        ctr.RenderControl(htmlWrite);
        p.Response.Write(stringWrite.ToString());
        p.Response.End();
    }
}