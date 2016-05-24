using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.OracleClient;
using System.Data;
/// <summary>
///lyf_oracle 的摘要说明
/// </summary>
public static class lyf_oracle
{
    //更新节点数据
   public static void updateNodeDate(DateTime dataTime)
    {
       //
        exeProcedure("p_UPDATE_T_NODE_DATA", dataTime);
       //更新节点数据，一定要更新核算单元数据
        updateUnitDate(dataTime);
    }
    //更新单元数据
   public static void updateUnitDate(DateTime dataTime)
   {
       exeProcedure("p_UPDATE_T_UNIT_DATA_AUTO", dataTime);
   }
    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="procedureName">存储过程名</param>
    /// <param name="dataTime">日期</param>
   private static void exeProcedure(string procedureName, DateTime dataTime)
   {
       //创建连接
       string strCon = "Data Source=orcl;User ID=NEWUTILITY;Password=mes";//Persist Security Info=True;
       OracleConnection con = new OracleConnection(strCon);
       //创建命令
       OracleCommand cmd = new OracleCommand();
       cmd.CommandText = procedureName;//存储过程名称 p_UPDATE_T_UNIT_DATA_AUTO
       cmd.CommandType = CommandType.StoredProcedure;//命令类型设置为存储过程
       cmd.Connection = con;
       cmd.Parameters.Add("inDate", OracleType.DateTime).Value = dataTime;//参数
       //打开连接
       con.Open();
       //执行存储过程
       int i = cmd.ExecuteNonQuery();
       //关闭连接
       con.Close();      
   }
}