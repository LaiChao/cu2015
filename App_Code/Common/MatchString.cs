using System;
using System.Web.UI.WebControls;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// MatchString 的摘要说明。
	/// </summary>
	public sealed class MatchString
	{
		public MatchString()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetByBool(DropDownList ddlUseIdentifier)
		{
			string strFilter;
			switch (ddlUseIdentifier.SelectedValue.ToString().Trim())
			{
				case "0":	
					strFilter = "";
					break;
				case "1":	
					strFilter = "USE_IDENTIFIER <> 0";
					break;
				case "2":   
					strFilter = "USE_IDENTIFIER = 0";
					break;
				default :	
					strFilter = "";
					break;
			};
			return strFilter;
		}
		public static string GetByBool(string strSelect, DropDownList ddlUseIdentifier)
		{
			string strFilter;
			switch (ddlUseIdentifier.SelectedValue.ToString().Trim())
			{
				case "0":	
					strFilter = strSelect;
					break;
				case "1":
					if (strSelect == "")
					{
						strFilter = "USE_IDENTIFIER <> 0";
					}
					else
					{
						strFilter = strSelect + "AND USE_IDENTIFIER <> 0";
					}
					break;
				case "2":   
					if (strSelect == "")
					{
						strFilter = "USE_IDENTIFIER = 0";
					}
					else
					{
						strFilter = strSelect + "AND USE_IDENTIFIER = 0";
					}
					break;
				default :	
					strFilter = strSelect;
					break;
			};
			return strFilter;
		}
		public static string GetByText(DropDownList ddlMatchField, string strMatch)
		{
			if (strMatch.Trim() == "") return null;
			 
            string strMatchField = ddlMatchField.SelectedValue.ToString().Trim();
			return strMatchField + " like '*" + strMatch.Trim() + "*'";
		}
		public static string GetByText(string strSelect, DropDownList ddlMatchField, string strMatch)
		{
			if (strMatch.Trim() == "") return strSelect;

			string strMatchField = ddlMatchField.SelectedValue.ToString().Trim();
			if (strSelect == "")
			{
				return strMatchField + " like '*" + strMatch.Trim() + "*'";
			}
			else
			{
				return strSelect + " and " + strMatchField + " like '*" + strMatch.Trim() + "*'";
			}
			
		}
	}
}
