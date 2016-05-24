//对web datagrid合并单元格，并根据合并的结果计算出统计值
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace CL_Utility.Common
{
	/// <summary>
	/// DataGridSpan 的摘要说明
	/// 实现web datagrid中
	/// 单元格合并
	/// 根据一列合并的结果计算出某列的统计值
	/// 根据一列的合并结果，合并其他列
	/// </summary>
	public class DataGridSpan
	{
		private  DataGrid dgData;//使用的datagrid
		private  int[] m_SpanResult;//单元格合并后的结果数组
		private  int m_SpanCell;//datagrid中需要合并的列
		private  int m_SumCell;//datagrid中需要计算的列
		private  int m_SpanControl;//datagrid中需要合并的控件
		private  int m_SumControl;//datagrid中需要计算的控件


		#region "参数"
		public DataGrid  dataGrid
		{
			get 
			{
				return dgData;
			}
			set 
			{
				dgData = value;
			}
		}
		public int[] SpanResult 
		{
			get 
			{
				return m_SpanResult;
			}
			set 
			{
				m_SpanResult = value;
			}
		}
		public int SpanCell 
		{
			get
			{
				return m_SpanCell;
			}
			set
			{
				m_SpanCell = value;
			}
		}
		public int SumCell 
		{
			get
			{
				return m_SumCell;
			}
			set
			{
				m_SumCell = value;
			}
		}
	
		public int SpanControl 
		{
			get 
			{
				return m_SpanControl;
			}
			set
			{
				m_SpanControl = value;
			}
		
		}
		public int SumControl 
		{
			get 
			{
				return m_SumControl;
			}
			set
			{
				m_SumControl = value;
			}
		
		}
		#endregion 

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="dgData">
		///dgData:需要进行合并操作的datagrid
		/// </param>
		public DataGridSpan(DataGrid m_dgData)
		{
			dgData = m_dgData;
			m_SpanCell = 0; //对于一个web datagrid中，对于列的计数是从0开始，
			           //若该列是不显示出来的。通过cell仍可访问，访问顺序是cell的绝对顺序，不是cell的显示顺序
			m_SumCell = 0; 
			m_SpanControl = 1;//对于一个web datagrid,对于每一个column中，控件的编号是按照
						  //TemplateColumn
						  //HeaderTemplate
						  //ItemTemplate
						  //EditItemTemplate
						  //FooterTemplate
						  //顺序编写的。
			              //如果本列有列名，只在ItemTemplate中有一个Label控件，那么这个控件编号为1
						  //本程序中默认该值为1
			m_SumControl = 1;
     	}
		/// <summary>
		/// 对于dgData进行默认的合并，不返回值
		/// </summary>
		public  void SpanGrid0()
		{
			int intSpan;
			string strTemp,str;
			int i,j,k,n;
			n = 0;
			for( i = 0;i<dgData.Items.Count ;i++)
			{
				intSpan = 1;
				strTemp = ((Label)dgData.Items[i].Cells[m_SpanCell].Controls[m_SpanControl]).Text.Trim();
				k = i+1;
				for( j = i+1 ;j<dgData.Items.Count ; j++)
				{
					str = ((Label)dgData.Items[j].Cells[m_SpanCell].Controls[m_SpanControl]).Text.Trim();
					if (str.CompareTo(strTemp) == 0)
					{
						intSpan += 1;
						k += 1;
						dgData.Items[i].Cells[m_SpanCell].RowSpan = intSpan;
						dgData.Items[j].Cells[m_SpanCell].Visible = false;
					}
					else 
					{
						j = dgData.Items.Count-1;
					}
				}
				i = k-1;
				n = n+1;
			}
		}

		/// <summary>
		/// 对dgData进行合并，返回一个数组
		/// </summary>
		/// <returns></returns>
		public  int[] SpanGrid()
		{
			int[] result = new int[1000];
			int intSpan;
			string strTemp,str;
			int i,j,k,n;
			n = 0;
			for( i = 0;i<dgData.Items.Count ;i++)
			{
				intSpan = 1;
				strTemp = ((Label)dgData.Items[i].Cells[m_SpanCell].Controls[m_SpanControl]).Text;
				k = i+1;
				for( j = i+1 ;j<dgData.Items.Count ; j++)
				{
					str = ((Label)dgData.Items[j].Cells[m_SpanCell].Controls[m_SpanControl]).Text;
					if (str.CompareTo(strTemp) == 0)
					{
						intSpan += 1;
						k += 1;
						dgData.Items[i].Cells[m_SpanCell].RowSpan = intSpan;
						dgData.Items[j].Cells[m_SpanCell].Visible = false;
					}
					else 
					{
						j = dgData.Items.Count-1;
					}
				}
				i = k-1;
				n = n+1;	
				result[n] = i;
				n = n+1;
				result[n] = k;
			}
			m_SpanResult = result ;
			return result ;
		}
		/// <summary>
		/// /
		/// </summary>
		public  void sumGrid ()
		{ 
			int i;
			int j ;
			double temp = 0;
			string str;
			for (i = 0 ;i<m_SpanResult.Length/2 ;i++)
			{
				if ((m_SpanResult[2*i +1] == 0) && (i!=0)) 
					return ;
				dgData.Items[m_SpanResult[2*i]].Cells[m_SumCell].RowSpan = m_SpanResult[2*i+1] -m_SpanResult[2*i]+1 ;
				str = ((Label)dgData.Items[m_SpanResult[2*i]].Cells[m_SumCell].Controls[m_SumControl]).Text;
				temp = Convert.ToDouble(str);
				for ( j = m_SpanResult[2*i]+1; j<m_SpanResult[2*i+1]+1;j++)
				{
					dgData.Items[j].Cells[m_SumCell].Visible = false;
					str = ((Label)dgData.Items[j].Cells[m_SumCell].Controls[m_SumControl]).Text;
					temp  += Convert.ToDouble(str);
				}
				((Label)dgData.Items[m_SpanResult[2*i]].Cells[m_SumCell].Controls[m_SumControl]).Text = temp.ToString();
			}
		}
		

	}
}
