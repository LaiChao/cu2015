using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using DataEntity.EntityManager;
using DataEntity.Entity;
using System.Data;
using System.Collections.Specialized;
using System.Web.UI;
/// <summary>
///lyf_UserRolePermission 的摘要说明
/// </summary>
public class lyf_UserRolePermission
{
    private Manager _manager;
    private ISingleTable _entity;//
    private ISingleTable _entityPMS;//
    protected DataTable _dtData;
    private const string PK = "USER_ID";
	public lyf_UserRolePermission()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        _manager = (Manager)(Managers.Members["NewUtilityOra"]);
        _entity = (ISingleTable)(_manager.Entities["USER_ROLE_PMS_VIEW"]);
        _entityPMS = (ISingleTable)(_manager.Entities["PERMISSION_VIEW"]);
	}
    /// <summary>
    /// 根据用户ID，返回对应的权限列表
    /// </summary>
    /// <param name="UserID">用户ID</param>
    /// <returns>权限列表</returns>
    public DataView getPermissionByUser(string UserID)
    {
        //获取权限列表
        HybridDictionary hd = new HybridDictionary();
        hd.Add(PK, UserID);
        _dtData = _entity.ExecuteDataTable2(CommandType.Text, "SelectById", hd);
        DataView dv = new DataView(_dtData);

//        1、通过ASP.NET获取
// 如果测试的url地址是http://www.idc311.com/testweb/default.aspx, 结果如下：
//Request.ApplicationPath:                /testweb
// Request.CurrentExecutionFilePath:       /testweb/default.aspx
// Request.FilePath:                       /testweb/default.aspx
// Request.Path:                           /testweb/default.aspx
// Request.PhysicalApplicationPath:        E:\WWW\testwebRequest.PhysicalPath:                   E:\WWW\testweb\default.aspx
// Request.RawUrl:                         /testweb/default.aspx
// Request.Url.AbsolutePath:               /testweb/default.aspx
// Request.Url.AbsoluteUrl:                http://www.idc311.com/testweb/default.aspx
// Request.Url.Host:                       http://www.idc311.com/
// Request.Url.LocalPath:                  /testweb/default.aspx
        
        //for (int i = 0; i < dv.Count; i++)
        //{
        //    //
        //    //string sT = dv[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
        //    //string sPName = dv[i]["PMS_NAME"].ToString().Trim();//权限名称     
        //    string sUrl = dv[i]["URL"].ToString().Trim();//地址
        //}
        return dv;
    }
    /// <summary>
    /// 返回页面的路径+页面名，如：/testweb/default.aspx
    /// </summary>
    /// <param name="page">页面对象</param>
    /// <returns>路径+页面名</returns>
    public string getPageName(Page page)
    {
        return page.Request.FilePath; 
    }
    /// <summary>
    /// 根据输入的用户ID、页面对象，判断该用户是否有权限访问该页面
    /// </summary>
    /// <param name="userID">用户ID</param>
    /// <param name="page">页面对象</param>
    /// <returns>包含返回true,不包含返回false</returns>
    public bool isPer(string userID, Page page)
    {
        bool result = false;
        DataView dv = getPermissionByUser(userID);
        string PageName=getPageName(page);
        //判断权限列表中是否包含此页面
        for (int i = 0; i < dv.Count; i++)
        {
            //
            //string sT = dv[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
            //string sPName = dv[i]["PMS_NAME"].ToString().Trim();//权限名称     
            string sUrl = dv[i]["URL"].ToString().Trim();//地址
            if (PageName.Contains(sUrl))
            {
                result = true;
                break;
            }
        }
        return result;
    }
    /// <summary>
    /// 判断用户是否登录
    /// </summary>
    /// <param name="page">页面对象</param>
    /// <param name="UserID">用户ID</param>
    public void isLogin(Page page,out string UserID,out string UserName)
    {
        if (page.Session["UserID"] == null)
        {
            UserID = "";
            UserName = "";
            page.Response.Redirect("../Login.aspx");
        }
        else
        {
            UserID = page.Session["UserID"].ToString();
            UserName = page.Session["UserName"].ToString();
        }
    }
}