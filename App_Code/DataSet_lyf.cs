using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntity;

/// <summary>
///DataSet_lyf 的摘要说明
/// </summary>
public class DataSet_lyf
{


	public DataSet_lyf()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

	}
    public static List<METER_DATA_INPUT_VIEW> GetList(List<METER_DATA_INPUT_VIEW> list)
    {
        return list;
    }

}

public class METER_DATA_INPUT_VIEW
{
    public string meter_id { get; set; }
    public string meter_name { get; set; }
    public string input_region_id { get; set; }
    public DateTime data_date { get; set; }
    public int lastday_input_data { get; set; }
    public int today_input_data { get; set; }
    public int input_data { get; set; }
    public int meter_value { get; set; }
    public int balance_value { get; set; }
    public DateTime maintain_time { get; set; }
    public string memo { get; set; }
    public string source_id { get; set; }
    public string task_id { get; set; }
}