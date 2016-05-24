using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

public class Global : System.Web.HttpApplication
{

    protected void Application_Start(object sender, EventArgs e)
    {
        Application["user_sessions"] = 0;
    }

    protected void Session_Start(object sender, EventArgs e)
    {
        Application.Lock();
        Application["user_sessions"] = (int)Application["user_sessions"] + 1;
        Application.UnLock();
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {

    }

    //验证请求事件
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        HttpContext ctx = this.Context;
        if (ctx.Request.IsAuthenticated) //已经通过了验证
        {
            //获取当前用户的标识
            IIdentity id = ctx.User.Identity;
            //转化成表单验证的用户标识
            FormsIdentity fid = (FormsIdentity)id;
            //获取身份验证票
            FormsAuthenticationTicket ticket = fid.Ticket;
            //获取验证票中携带的角色字符串信息
            string userData = ticket.UserData;
            //转换成字符串数组
            string[] roles = userData.Split('|');
            //根据身份标识与角色数组构造一个一般用户
            GenericPrincipal gp = new GenericPrincipal(fid, roles);
            //将当前请求中的用户设置为gp,
            //当前请求中的用户也就具有了gp的身份标识与角色信息
            ctx.User = gp;
        }
    }

    protected void Application_Error(object sender, EventArgs e)
    {

    }

    protected void Session_End(object sender, EventArgs e)
    {
        Application.Lock();
        Application["user_sessions"] = (int)Application["user_sessions"] - 1;
        Application.UnLock();
        string sUserName;
        if (Session["UserName"] != null)
        {
            sUserName = Session["UserName"].ToString();

            List<string> list = new List<string>();
            if (Application["Users"] != null)
            {
                list = (List<string>)Application["Users"];
                list.Remove(sUserName);
                Application.Add("Users", list);
            }
        }
    }

    protected void Application_End(object sender, EventArgs e)
    {

    }
}
