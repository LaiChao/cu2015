using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// mysqlconn 的摘要说明
/// </summary>
public class mysqlconn
{
	public mysqlconn()
	{
		
	}
    #region  建立MySql数据库连接
    /// <summary>
    /// 建立数据库连接.
    /// </summary>
    /// <returns>返回MySqlConnection对象</returns>
    public  MySqlConnection getmysqlcon(){
    
        //http://sosoft.cnblogs.com/
        string M_str_sqlcon = "server=localhost;user id=root;password=123456;database=mscsdb;charset=gbk;Max Pool Size = 2048;"; //根据自己的设置
        MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
        return myCon;
    }
    #endregion

    #region  执行MySqlCommand命令
    /// <summary>
    /// 执行MySqlCommand
    /// </summary>
    /// <param name="M_str_sqlstr">SQL语句</param>
    public int getmysqlcom(string M_str_sqlstr)
    {
        MySqlConnection mysqlcon = this.getmysqlcon();
        mysqlcon.Open();
        MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
        int result=   mysqlcom.ExecuteNonQuery();
        mysqlcom.Dispose();     
        mysqlcon.Close();
        mysqlcom.Dispose();
        return result;
        
    }
    #endregion

    #region  创建MySqlDataReader对象
    /// <summary>
    /// 创建一个MySqlDataReader对象
    /// </summary>
    /// <param name="M_str_sqlstr">SQL语句</param>
    /// <returns>返回MySqlDataReader对象</returns>
    public MySqlDataReader getmysqlread(string M_str_sqlstr)
    {
        MySqlConnection mysqlcon = this.getmysqlcon();
        MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
        mysqlcon.Open();
        MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);      
        return mysqlread;  
     
    }
    #endregion

}