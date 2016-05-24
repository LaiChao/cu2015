using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// UserInterface 的摘要说明。
	/// </summary>
	public class UserInterface
	{
		public UserInterface()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

		}
		public static void  Status(System.Web.UI.Page page,string strMessage)
		{
			string strScript="<SCRIPT language='javascript'>window.status='"+strMessage+"';</SCRIPT>";
			page.Response.Write(strScript);
			page.Response.Flush();
			PlayMsg(page,strMessage);
			return;
		}	
		public static void  Title(System.Web.UI.Page page,string strMessage)
		{
			string strScript="<SCRIPT language='javascript'>window.parent.parent.document.title ='"+strMessage+"';</SCRIPT>";
			page.Response.Write(strScript);
			page.Response.Flush();
			return;
		}	
		public static void PopupMsg(System.Web.UI.Page page,string strDescription)
		{
			string strScript = "<script language=\"javascript\">";
			if(strDescription != "")
			{
				strScript += "document.write(\"<div id='popmsg' style='position:absolute;right:0px;bottom:0px;width:260px;height:165px;z-index:1;padding:20px 20px 20px 20px;word-break:break-all;text-align:left;background-image: url(images/popmsgbg.gif);'>"+strDescription+"</div>\");";

				strScript += "j=3;"+
					"function popClose() {"+
					" j -= 1;"+
					" if (j > 0){setTimeout(\"popClose()\",1000);}"+
					" else{popmsg.style.display=\"none\";}"+
					"}";

				strScript += "popClose();";

			}
			strScript += "</script>";

			page.Response.Write ( strScript);
			page.Response.Flush();
		}
		public static void PlayMsg(System.Web.UI.Page page,string strMsg)
		{
			string strPlay="<OBJECT id='yuzi' classid='CLSID:D45FD31B-5C6E-11D1-9EC1-00C04FD7081F' VIEWASTEXT> "+
						   "</OBJECT> "+
							"<SCRIPT> "+
							" var MerlinID; "+
							" var MerlinACS; "+
							" yuzi.Connected = true; "+
							" MerlinLoaded = LoadLocalAgent(MerlinID, MerlinACS); "+
							" Merlin = yuzi.Characters.Character(MerlinID); "+
							" Merlin.Show(); "+
//							" Merlin.PlaySequence('GetAttention');"+
							" Merlin.Play('Surprised'); "+
							" Merlin.Speak('"+strMsg+"'); "+
							" function LoadLocalAgent(CharID, CharACS) "+
							" {	 LoadReq = yuzi.Characters.Load(CharID, CharACS);"+
							" return(true);} "+
							"</SCRIPT> ";
			page.Response.Write (strPlay);
			page.Response.Flush();
		}

		public string ExceptionMsg(Exception ex)
		{	
			string strEx = ex.Message;
			string strMsg = "";
			switch (strEx.Substring(4,5))
			{
				case "00001":
					strMsg = ": 已经存在相关记录";
					break;
				case "02292":
					strMsg = ": 存在相应子记录信息";
					break;
				case "02291":
					strMsg = ": 未找到相应父记录信息";
					break;
				default:
					int start = strEx.IndexOf("(",0);
					int end = strEx.IndexOf(")",0);
					int length = end - start + 1;
					if ( start <0 || end <0 )
					{
						strMsg = strEx;
					}
					else
					{
						strMsg = strEx.Remove(start,length);
						strMsg = strMsg.Remove(0,9);
					}
					break;
			}
			return strMsg;
		}

			
	}	
}
