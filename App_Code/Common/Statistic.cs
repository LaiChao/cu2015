using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataEntity.EntityManager;
using DataEntity.Entity;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// Statistic 的摘要说明。
	/// </summary>
	public class Statistic
	{
		public Statistic()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region "自定义属性"
		public static Manager oraUtilityManager = Managers.Members["UtilityOra"] as Manager;

		public static ISingleTable statisticTable = oraUtilityManager.Entities["STATISTIC"] as ISingleTable;
		public static ISingleTable statisticItemTable = oraUtilityManager.Entities["STATISTIC_ITEM"] as ISingleTable;
		public static ISingleTable statisticStaitemCombTable = oraUtilityManager.Entities["STATISTIC_STAITEM_COMB"] as ISingleTable;
		public static ISingleView staitemCombUseView = oraUtilityManager.Entities["STAITEM_COMB_USE_VIEW"] as ISingleView;

		#endregion

		public StringCollection GetInputStatistics(string inputRegionId, string sourceId, int dataWayId)
		{
			//取出该录入区域和来源的所有统计项
			HybridDictionary myHd4 = new HybridDictionary();
			myHd4.Add("INPUT_REGION_ID", inputRegionId);
			myHd4.Add("SOURCE_ID", sourceId);
			myHd4.Add("DATA_WAY_ID", dataWayId);
			DataTable tableInputStaitem = statisticItemTable.ExecuteDataTable2(CommandType.Text, "SelectUseStaitemByReginputSource", myHd4);
			StringCollection colInputSaitem = new StringCollection();
			foreach(DataRow dr in tableInputStaitem.Rows)
			{
				colInputSaitem.Add(dr["STATISTIC_ITEM_ID"].ToString());
			}

			//取出该来源的所有统计
			HybridDictionary myHd = new HybridDictionary();
			myHd.Add("SOURCE_ID", sourceId);
			DataTable tableStatistic = statisticTable.ExecuteDataTable2(CommandType.Text, "SelectIdNameBySourceId", myHd);
			DataView dvStatistic = new DataView(tableStatistic, "use_identifier <> 0", null, DataViewRowState.CurrentRows);

			SortedList listStatistic = new SortedList();
			
			//获取每个统计对应的统计项
			foreach(DataRowView drv in dvStatistic)
			{
				HybridDictionary hdStaitem = new HybridDictionary();

				listStatistic.Add(drv["STATISTIC_ID"], null);

				HybridDictionary myHd2 = new HybridDictionary();
				myHd2.Add("STATISTIC_ID", drv["STATISTIC_ID"]);
				DataTable tableTopStaitem = statisticStaitemCombTable.ExecuteDataTable2(CommandType.Text, "SelectbyID", myHd2);
				DataView dvTopStaitem = new DataView(tableTopStaitem, "use_identifier <> 0", null, DataViewRowState.CurrentRows);

				foreach(DataRowView drvTop in dvTopStaitem)
				{
					hdStaitem.Add(drvTop["STATISTIC_ITEM_ID"], drvTop["STATISTIC_ITEM_ID"]);

					HybridDictionary myHd3 = new HybridDictionary();
					myHd3.Add("PARENT_STAITEM_ID", drvTop["STATISTIC_ITEM_ID"]);
					DataTable tableStaitem = staitemCombUseView.ExecuteDataTable(CommandType.Text, "SelectByTopId", myHd3);
					DataView dvStaitem = new DataView(tableStaitem, null, null, DataViewRowState.CurrentRows);

					foreach(DataRowView drvStaitem in dvStaitem)
					{
						if (!(hdStaitem.Contains(drvStaitem["CHILD_STAITEM_ID"])))
						{
							hdStaitem.Add(drvStaitem["CHILD_STAITEM_ID"], drvStaitem["CHILD_STAITEM_ID"]);
						}
					}
				}
				listStatistic[drv["STATISTIC_ID"]] = hdStaitem;
			}

			//检查需要录入的统计项是否在各统计中是否存在
			StringCollection colInputStatistic = new StringCollection();
			for (int i = 0; i < listStatistic.Count ; i++)
			{
				bool isExist = false;
				string key = listStatistic.GetKey(i).ToString();

				foreach(string staitemId in colInputSaitem)
				{
					if (((HybridDictionary)(listStatistic.GetByIndex(i))).Contains(staitemId))
					{
						isExist = true;
						break;
					}
				}
				if (isExist)
				{
					colInputStatistic.Add(key);
				}

			}
			return colInputStatistic;

		}
		

	}
}
