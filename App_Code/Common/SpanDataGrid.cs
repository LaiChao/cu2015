using System;
using System.Web.UI.WebControls;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// SpanDataGrid 的摘要说明。
	/// </summary>
	public class SpanDataGrid
	{
		public static void SpanGrid(DataGrid dg ,string a,int k)
		{ 
			int i; 
			int j; 
			int intspan; 
			string temp; 
			for(i=0;i<dg.Items.Count;i++) 
			{ 
				DataGridItem _item = dg.Items[i]; 
				intspan = 1; 
				temp =((Label)dg.Items[i].Cells[k].FindControl(a)).Text;
				for(j=i+1;j<dg.Items.Count;j++) 
				{ 
					if(String.Compare(temp,((Label)dg.Items[j].Cells[k].FindControl(a)).Text)== 0) 
						//if(dg.Items[j].Cells[0].Text.CompareTo())
					{ 
						intspan++; 
						dg.Items[i].Cells[k].RowSpan = intspan; 
						dg.Items[j].Cells[k].Visible = false; 
					} 
					else 
					{ 
						break; 
					} 
				} 
				i=j-1; 
			} 
		}
		//合并Grid
		//Input: a- 需要合并的列名
		//		 k- a所在的列的索引
		//       m- 同a进行合并的列的索引
		public static void SpanGrid(DataGrid dg ,string name,int index, int[] other)
		{ 
			int i; 
			int j; 
			int k;
			int intspan; 
			string temp; 
			for(i=0;i<dg.Items.Count;i++) 
			{ 
				DataGridItem _item = dg.Items[i]; 
				intspan = 1; 
				temp =((Label)dg.Items[i].Cells[index].FindControl(name)).Text;
				for(j=i+1;j<dg.Items.Count;j++) 
				{ 
					if(String.Compare(temp,((Label)dg.Items[j].Cells[index].FindControl(name)).Text)== 0) 
						//if(dg.Items[j].Cells[0].Text.CompareTo())
					{ 
						intspan++; 
						dg.Items[i].Cells[index].RowSpan = intspan; 
						dg.Items[j].Cells[index].Visible = false; 

						for(k=0;k < other.Length;k++)
						{
							dg.Items[i].Cells[other[k]].RowSpan = intspan; 
							dg.Items[j].Cells[other[k]].Visible = false; 
						}
					} 
					else 
					{ 
						break; 
					} 
				} 
				i=j-1; 
			} 
		}
	}
}
