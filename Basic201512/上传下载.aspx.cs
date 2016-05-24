using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basic201512_上传下载 : System.Web.UI.Page
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
    // 为上传的文件命名新的名字
    //public static string NameFile()
    //{
    //    DateTime DT = DateTime.Now;
    //    string NewName = DT.Year.ToString();
    //    NewName += DT.Month.ToString().PadLeft(2, '0');
    //    NewName += DT.Day.ToString().PadLeft(2, '0');
    //    NewName += DT.Hour.ToString().PadLeft(2, '0');
    //    NewName += DT.Minute.ToString().PadLeft(2, '0');
    //    NewName += DT.Second.ToString().PadLeft(2, '0');
    //    NewName += DT.Millisecond.ToString().PadLeft(3, '0');
    //    return NewName;
    //}

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
                    //HttpContext.Current.Response.Write("<script>alert('文件已存在，请重新上传。');</script>");
                    
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
 
     // “检查文件”按钮的事件类
     //protected void Button1_Click(object sender, EventArgs e)
     //{
     //    if (FileUpload1.HasFile)  // 判断是否有文件上传
     //    {
     //        // 上传过来的路径（包括文件名和扩展名）
     //        string OldFullPath = FileUpload1.PostedFile.FileName;
     //        // 原来的文件全名（包括文件名和扩展名）
     //        string OldFullFileName = Path.GetFileName(FileUpload1.FileName);
     //        // 原来的文件名
     //        string OldFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
     //        // 原来的扩展名（取得的扩展名包括“.”）
     //        string OldExtensionName = Path.GetExtension(FileUpload1.FileName).ToLower();
     //        // 原来的文件大小
     //        int OLdSize = FileUpload1.PostedFile.ContentLength;
     //        // 原来的文件类型
     //        string OldType = FileUpload1.PostedFile.ContentType;
     //        // 显示信息
     //        Label1.Text = "上传过来的路径：" + OldFullPath + "<br />";
     //        Label1.Text += "原来的文件全名：" + OldFullFileName + "<br />";
     //        Label1.Text += "原来的文件名：" + OldFileName + "<br />";
     //        Label1.Text += "原来的扩展名：" + OldExtensionName + "<br />";
     //        Label1.Text += "原来的文件大小：" + OLdSize + "<br />";
     //        Label1.Text += "原来的文件类型：" + OldType + "<br />";
     //    }
     //    else
     //    {
     //        Response.Write("<script>alert('请选择上传需要检查的文件');</script>");
     //    }
     //}
 
     //// 改名字后上传文件的事件类
     //protected void Button2_Click(object sender, EventArgs e)
     //{
     //    // 新的文件名
     //    string NewFileName = NameFile();
     //    UpLoadFile(FileUpload1, NewFileName);
     //}
 
     // 不改名字上传文件的事件类
     protected void Button3_Click(object sender, EventArgs e)
     {
         // 原来的文件名
         string OldFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
         UpLoadFile(FileUpload1, OldFileName);
         Response.Redirect(Request.Url.PathAndQuery.ToString());

     }
 
     protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
         Session["SelectedFile"] = ListBox1.SelectedValue.ToString();
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
}