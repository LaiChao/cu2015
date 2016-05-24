using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
namespace CL.Utility.Web.Common
{
	/// <summary>
	/// CleanString 的摘要说明。
	/// </summary>
    public sealed class CleanString
    {
		private static Regex _isNonnegativeInteger = new Regex("^[0-9]+$");
		private static Regex _isInteger = new Regex("^[+-]?[0-9]+$");

        private static Regex _isNumber = new Regex("^[0-9]+$");
		private static Regex _isSym = new Regex("^[+-]?[0-1]$");
		private static Regex _isData = new Regex("^[+-]?[0-9]+(.[0-9]+)?$");
		private static Regex _isDate = new Regex("^[1-9][0-9][0-9][0-9][-][1-2][0-9][-][0-3][1-9]$");
		private static Regex _isEnsh = new Regex("^[A-Za-z]+$");
		private static Regex _isOp = new Regex("^[-()*/+]");
        // return a digit string based on input data
        // look first in the QueryString collection, then in Form
        // return string.Empty if not found or if non-digit
        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string retVal = string.Empty;

            if(inputKey != null && inputKey != string.Empty)
            {
                retVal = req.QueryString[inputKey];
                if(null == retVal)
                    retVal = req.Form[inputKey];

                if(null != retVal)
                {
                    retVal = CleanString.SqlText(retVal, maxLen);
                    if(!IsNumber(retVal))
                        retVal = string.Empty;
                }
            }

            if(retVal == null)
                retVal = string.Empty;

            return retVal;
        }
		public static bool IsNonnegativeInteger(string inputData)
		{
			Match m = _isNonnegativeInteger.Match(inputData);
			return m.Success;
		}
		public static bool IsInteger(string inputData)
		{
			Match m = _isInteger.Match(inputData);
			return m.Success;
		}
		public static bool IsData(string inputData)
		{
			Match m = _isData.Match(inputData);
			return m.Success;
		}
		public static bool IsOp(string inputData)
		{
			Match m = _isOp.Match(inputData);
			return m.Success;
		}
		public static bool IsSym(string inputData)
		{
			Match m = _isSym.Match(inputData);
			return m.Success;
		}
		public static bool IsDate(string inputData)
		{
			Match m = _isDate.Match(inputData);
			return m.Success;
		}
        public static bool IsNumber(string inputData)
        {
            Match m = _isNumber.Match(inputData);
            return m.Success;
        }

		public static bool IsEnshStr(string inputData)
		{
			Match m = _isEnsh.Match(inputData);
			return m.Success;
		}
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }


        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);
        }

        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }

        /// <remarks>
        /// This was doing HtmlEncoding going into the DB
        /// we prefer to encode data appropriately where used, so
        /// only the length validation logic is left
        /// </remarks>
        public static string SqlText(string sqlInput, int maxLength)
        {
            // check incoming parameters for null or blank string
            if(sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();

                //chop the string in case the client-side max length
                //fields are bypassed to prevent buffer overruns
                if(sqlInput.Length > maxLength)
                    sqlInput = sqlInput.Substring(0, maxLength);
            }

            return sqlInput;
        }
    }
}
