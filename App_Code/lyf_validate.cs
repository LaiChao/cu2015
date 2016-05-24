using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace luyunfei
{
    /// <summary>
    ///用于验证的类
    /// </summary>
    public static class lyf_validate
    {
        
        /// <summary>
        /// 验证用户名，密码；只能包含字母、数字、下划线，且不能以数字开头，5~16位
        /// </summary>
        /// <param name="ID">用户名或密码</param>
        /// <returns></returns>
        public static bool isIDorPwd(string ID)
        {
            string pattern = @"^[a-zA-Z_][a-zA-Z0-9_]{4,15}$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = regex.IsMatch(ID);
            return isMatch;
        }
        /// <summary>
        /// 验证是否只包含字母a-z,A-Z、数字0-9、下划线_，且不能以数字开头
        /// </summary>
        /// <param name="ID">字符串</param>
        /// <param name="Min">最小长度，最小1</param>
        /// <param name="Max">最大长度,最高1000</param>
        /// <returns>正确返回true,否则返回false</returns>
        public static bool isAZaz09_(string ID,int Min,int Max)
        {
            if (Min < 1)
            { Min = 1; }
            if (Max > 1000)
            {
                Max = 1000;
            }
            string pattern = @"^[a-zA-Z_][a-zA-Z0-9_]{"+(Min-1).ToString()+","+(Max-1).ToString()+"}$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = regex.IsMatch(ID);
            return isMatch;
        }
        /// <summary>
        /// 验证是否只包含字母a-z,A-Z、数字0-9、下划线_，且不能以数字开头
        /// </summary>
        /// <param name="str">要验证的字符串</param>
        /// <param name="Min">最小长度，最小1</param>
        /// <param name="Max">最大长度,最高1000</param>
        /// <param name="Message">正确返回空，否则返回错误信息</param>
        /// <returns>正确返回true,否则返回false</returns>
        public static bool isAZaz09_(string str, int Min, int Max,out string Message)
        {
            if (Min < 1)
            { Min = 1; }
            if (Max > 1000)
            {
                Max = 1000;
            }
            string pattern = @"^[a-zA-Z_][a-zA-Z0-9_]{" + (Min-1).ToString() + "," + (Max-1).ToString() + "}$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = regex.IsMatch(str);
            if (isMatch)
            {
                Message = "";
            }
            else
            {
                Message = "只能包含字母、数字、下划线，且不能以数字开头，长度大于等于"+Min.ToString()+"小于等于"+Max.ToString();
            }
            return isMatch;
        }

        public static bool is09AZaz_(string str, int Min, int Max, out string Message)
        {
            if (Min < 1)
            { Min = 1; }
            if (Max > 1000)
            {
                Max = 1000;
            }
            string pattern = @"^[a-zA-Z0-9_]{" + Min.ToString() + "," + Max.ToString() + "}$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);           
            bool isMatch = regex.IsMatch(str);
            if (isMatch)
            {
                Message = "";
            }
            else
            {
                Message = "只能包含字母、数字、下划线，长度大于等于" + Min.ToString() + "小于等于" + Max.ToString();
            }
            return isMatch;
        }
        /// <summary>
        /// 验证是否只包含字母a-z,A-Z、数字0-9、下划线_，中文
        /// </summary>
        /// <param name="str">要验证的字符串</param>
        /// <param name="Min">最小长度，最小1</param>
        /// <param name="Max">最大长度,最高1000</param>
        /// <param name="Message">正确返回空，否则返回错误信息</param>
        /// <returns>正确返回true,否则返回false</returns>
        public static bool isAZaz09_Ch(string str, int Min, int Max, out string Message)
        {
            if (Min < 0)
            { Min = 0; }
            if (Max > 1000)
            {
                Max = 1000;
            }
            string pattern = @"^[\w\s]{" + Min.ToString() + "," + Max.ToString() + "}$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = regex.IsMatch(str);
            if (isMatch)
            {
                Message = "";
            }
            else
            {
                Message = "只能包含字母、数字、下划线、中文，长度大于等于" + Min.ToString() + "小于等于" + Max.ToString();
            }
            return isMatch;
        }
        /// <summary>
        /// 校验长度在min,max之间的正整数
        /// </summary>
        /// <param name="str">要检验字符串</param>
        /// <param name="Min">最小长度</param>
        /// <param name="Max">最大长度</param>
        /// <param name="Message">返回信息，正常为空，否则为提示信息</param>
        /// <param name="Result">返回转换后的数</param>
        /// <returns>正确为true,否则为false</returns>
        public static bool isInt(string str,int Min,int Max,out string Message,out int Result)
        {
            Result=0;
            Message = "";
            if (string.IsNullOrEmpty(str))
            {
                Message = "输入不能为空！";
                return false;
            }
            if (Min < 1)
            { Min = 1; }
            if (Max > 20)
            { Max = 20; }
            if(str.Length<Min || str.Length>Max)
            {
                Message = "输入的长度不在正确的范围内！输入的长度应该在"+Min.ToString()+"与"+Max.ToString()+"之间!";
                return false;
            }
            if (!int.TryParse(str, out Result))
            {
                Message = "输入的不是整数！";
                return false;
            }
            if (Result <= 0)
            {
                Message = "输入的不是正整数！";
                return false;
            }
            return true;
        
        }
        /// <summary>
        /// 校验长度在min,max之间的正数
        /// </summary>
        /// <param name="str">要检验字符串</param>
        /// <param name="Min">最小长度</param>
        /// <param name="Max">最大长度</param>
        /// <param name="Message">返回信息，正常为空，否则为提示信息</param>
        /// <param name="Result">返回转换后的数</param>
        /// <returns>正确为true,否则为false</returns>
        public static bool isDouble(string str, int Min, int Max, out string Message, out double Result)
        {
            Result = 0;
            Message = "";
            if (string.IsNullOrEmpty(str))
            {
                Message = "输入不能为空！";
                return false;
            }
            if (Min < 1)
            { Min = 1; }
            if (Max > 20)
            { Max = 20; }
            if (str.Length < Min || str.Length > Max)
            {
                Message = "输入的长度不在正确的范围内！输入的长度应该在" + Min.ToString() + "与" + Max.ToString() + "之间!";
                return false;
            }
            if (!double.TryParse(str, out Result))
            {
                Message = "输入的不是整数！";
                return false;
            }
            if (Result <= 0)
            {
                Message = "输入的不是正整数！";
                return false;
            }
            return true;

        }
        /// <summary>
        /// 判断是否是数值型：正整数，正小数
        /// </summary>
        /// <param name="Decimal"></param>
        /// <returns></returns>
        public static bool isDecimal(string Decimal)
        {
            string pattern = @"^\d*[\.]?\d*$"; //正则表达式字符串
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = regex.IsMatch(Decimal);
            return isMatch;
        }
    }
}