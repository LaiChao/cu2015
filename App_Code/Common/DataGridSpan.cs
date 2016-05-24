//��web datagrid�ϲ���Ԫ�񣬲����ݺϲ��Ľ�������ͳ��ֵ
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace CL_Utility.Common
{
	/// <summary>
	/// DataGridSpan ��ժҪ˵��
	/// ʵ��web datagrid��
	/// ��Ԫ��ϲ�
	/// ����һ�кϲ��Ľ�������ĳ�е�ͳ��ֵ
	/// ����һ�еĺϲ�������ϲ�������
	/// </summary>
	public class DataGridSpan
	{
		private  DataGrid dgData;//ʹ�õ�datagrid
		private  int[] m_SpanResult;//��Ԫ��ϲ���Ľ������
		private  int m_SpanCell;//datagrid����Ҫ�ϲ�����
		private  int m_SumCell;//datagrid����Ҫ�������
		private  int m_SpanControl;//datagrid����Ҫ�ϲ��Ŀؼ�
		private  int m_SumControl;//datagrid����Ҫ����Ŀؼ�


		#region "����"
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
		/// ��ʼ��
		/// </summary>
		/// <param name="dgData">
		///dgData:��Ҫ���кϲ�������datagrid
		/// </param>
		public DataGridSpan(DataGrid m_dgData)
		{
			dgData = m_dgData;
			m_SpanCell = 0; //����һ��web datagrid�У������еļ����Ǵ�0��ʼ��
			           //�������ǲ���ʾ�����ġ�ͨ��cell�Կɷ��ʣ�����˳����cell�ľ���˳�򣬲���cell����ʾ˳��
			m_SumCell = 0; 
			m_SpanControl = 1;//����һ��web datagrid,����ÿһ��column�У��ؼ��ı���ǰ���
						  //TemplateColumn
						  //HeaderTemplate
						  //ItemTemplate
						  //EditItemTemplate
						  //FooterTemplate
						  //˳���д�ġ�
			              //���������������ֻ��ItemTemplate����һ��Label�ؼ�����ô����ؼ����Ϊ1
						  //��������Ĭ�ϸ�ֵΪ1
			m_SumControl = 1;
     	}
		/// <summary>
		/// ����dgData����Ĭ�ϵĺϲ���������ֵ
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
		/// ��dgData���кϲ�������һ������
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
