using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basic201512_uploadDownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  // 页面首次加载
        {
            // 返回指定目录的所有文件的名称
            string[] AllFile = Directory.GetFiles(Server.MapPath("File"));
            foreach (string Name in AllFile)
            {
                // 返回指定路径的文件的名称
                ListBox1.Items.Add(Path.GetFileName(Name));
            }
        }

    }

    // 上传文件类
    public static void UpLoadFile(FileUpload FU, string NewFileName)
    {
        if (FU.HasFile)  // 判断是否有文件上传
        {
            // 原来的扩展名（取得的扩展名包括“.”）
            string OldExtensionName = Path.GetExtension(FU.FileName).ToLower();
            // 保存文件的虚拟路径
            string Url = "File\\" + NewFileName + OldExtensionName;
            // 保存文件的物理路径
            string FullPath = HttpContext.Current.Server.MapPath(Url);
            try
            {
                // 检查文件是否存在
                if (File.Exists(FullPath))
                {
                    HttpContext.Current.Response.Write("<script>alert('文件已存在，请重新上传。');</script>");
                }
                else
                {
                    FU.SaveAs(FullPath);
                    HttpContext.Current.Response.Write("<script>alert('文件已成功上传。');</script>");
                }
            }
            catch { }
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('请选择上传的文件');</script>");
        }
    }
 
     // “上传文件”按钮事件
     protected void Button3_Click(object sender, EventArgs e)
     {
         // 原来的文件名
         string OldFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
         UpLoadFile(FileUpload1, OldFileName);
         //Response.Redirect(Request.Url.PathAndQuery.ToString());

     }
 
     protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
         Session["SelectedFile"] = ListBox1.SelectedValue.ToString();
     }

     //  下载文件类
     public void DownLoadFile(string FullFileName)
     {
         // 保存文件的虚拟路径
         string Url = "File\\" + FullFileName;
         // 保存文件的物理路径
         string FullPath = HttpContext.Current.Server.MapPath(Url);
         // 初始化FileInfo类的实例，作为文件路径的包装
         FileInfo FI = new FileInfo(FullPath);
         // 判断文件是否存在
         if (FI.Exists)
         {
             // 将文件保存到本机
             Response.Clear();
             Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(FI.Name));
             Response.AddHeader("Content-Length", FI.Length.ToString());
             Response.ContentType = "application/octet-stream";
             Response.Filter.Close();
             Response.WriteFile(FI.FullName);
             Response.End();
         }
     }

     // “下载文件”按钮事件
     protected void Button4_Click(object sender, EventArgs e)
     {
         // 判断是否选择了文件名
         if (ListBox1.SelectedValue != "")
         {
             if (Session["SelectedFile"] != "")
             {
                 string FullFileName = Session["SelectedFile"].ToString();
                 DownLoadFile(FullFileName);

             }
         }
         else
         {
             Response.Write("<script>alert('请先选择要下载的文件');</script>");
         }
     }

     // 删除文件类
     public void DeleteFile(string FullFileName)
     {
         // 保存文件的虚拟路径
         string Url = "File\\" + FullFileName;
         // 保存文件的物理路径
         string FullPath = HttpContext.Current.Server.MapPath(Url);
         // 去除文件的只读属性
         File.SetAttributes(FullPath, FileAttributes.Normal);
         // 初始化FileInfo类的实例，作为文件路径的包装
         FileInfo FI = new FileInfo(FullPath);
         // 判断文件是否存在
         if (FI.Exists)
         {
             FI.Delete();
         }
     }

     // “删除文件”按钮事件
     protected void Button5_Click(object sender, EventArgs e)
     {
         // 判断是否选择了文件名
         if (ListBox1.SelectedValue != "")
         {
             if (Session["SelectedFile"] != "")
             {
                 string FullFileName = Session["SelectedFile"].ToString();
                 DeleteFile(FullFileName);
                 Response.Redirect(Request.Url.PathAndQuery.ToString());
             }
         }
         else
         {
             Response.Write("<script>alert('请先选择要删除的文件');</script>");
         }
     }
     protected void Button6_Click(object sender, EventArgs e)
     {
         Response.Redirect(Request.Url.PathAndQuery.ToString());
     }
}