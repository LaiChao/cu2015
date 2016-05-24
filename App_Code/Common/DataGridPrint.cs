//在cs中打印datagrid 的通用类


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
//using System.Web.UI.WebControls;

using System.Windows.Forms;

namespace CL_Utility.Common
{
	public class DataGridPrinter
	{
		private  DataGrid dataGrid;
		private PrintDocument printDocument;
		private PageSetupDialog pageSetupDialog;
		private PrintPreviewDialog printPreviewDialog;

		public DataGridPrinter(DataGrid dataGrid)
		{ 
			this.dataGrid = dataGrid; 
			printDocument = new PrintDocument();
			printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
		} 

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int rowCount = 0;
			int colCount = 0;
			int x = 0;
			int y = 0;
			int rowGap = 20;
			int colGap = 5;
			int leftMargin = 50;
			Font font = new Font("Arial", 10);
			Font headingFont = new Font("Arial", 11, FontStyle.Underline);
			Font captionFont = new Font("Arial", 10, FontStyle.Bold); 
			Brush brush = new SolidBrush(Color.Black);
			string cellValue = "";

			if(dataGrid.DataSource.GetType().ToString() == "System.Data.DataTable")
			{
				rowCount = ((DataTable)dataGrid.DataSource).Rows.Count;
			}
			else if(dataGrid.DataSource.GetType().ToString() == "System.Collections.ArrayList")
			{
				rowCount = ((ArrayList)dataGrid.DataSource).Count;
			}

			
			colCount = dataGrid.TableStyles[0].GridColumnStyles.Count;
//			colCount = dataGrid.Columns.Count;


			//print caption
//			if(dataGrid.CaptionVisible)
//			{
//				y += rowGap;
//				x = leftMargin;
//				e.Graphics.DrawString(dataGrid.CaptionText, captionFont, brush, x, y);
//			}
		
			
//			//print headings 
//			y += rowGap;
//			x = leftMargin;
//			for(int j = 0; j < colCount; j++)
//			{
//				if(dataGrid.TableStyles[0].GridColumnStyles[j].Width > 0)
//				{
//					cellValue = dataGrid.TableStyles[0].GridColumnStyles[j].HeaderText; 
//					e.Graphics.DrawString(cellValue, headingFont, brush, x, y);
//					x += dataGrid.TableStyles[0].GridColumnStyles[j].Width + colGap; 
//				}
//			} 
			//print headings 
			
			y += rowGap;
			x = leftMargin;
			for(int j = 0; j < colCount; j++)
			{
				if(dataGrid.TableStyles[0].GridColumnStyles[j].Width > 0)
				{
					cellValue = dataGrid.TableStyles[0].GridColumnStyles[j].HeaderText; 
					e.Graphics.DrawString(cellValue, headingFont, brush, x, y);
					x += dataGrid.TableStyles[0].GridColumnStyles[j].Width + colGap; 
				}
				if(dataGrid.TableStyles[0].GridColumnStyles[j].Width > 0)
				{
					cellValue = dataGrid.TableStyles[0].GridColumnStyles[j].HeaderText; 
					e.Graphics.DrawString(cellValue, headingFont, brush, x, y);
					x += dataGrid.TableStyles[0].GridColumnStyles[j].Width + colGap; 
				}
			} 



			//print all rows
			for(int i = 0; i < rowCount; i++)
			{
				y += rowGap;
				x = leftMargin;
				for(int j = 0; j < colCount; j++)
				{
					if(dataGrid.TableStyles[0].GridColumnStyles[j].Width > 0)
					{
						cellValue = dataGrid[i,j].ToString(); 
						e.Graphics.DrawString(cellValue, font, brush, x, y);
						x += dataGrid.TableStyles[0].GridColumnStyles[j].Width + colGap;
						y = y + rowGap * (cellValue.Split(new char[] {'\r', '\n'}).Length - 1); 
					}
				} 
			}
			string s = cellValue;
			string f3 = cellValue;
		}

		public PrintDocument GetPrintDocument()
		{
			return printDocument;
		}

		public void Print()
		{
			try
			{
				pageSetupDialog = new PageSetupDialog();
				pageSetupDialog.Document = printDocument;
				pageSetupDialog.ShowDialog();
				printPreviewDialog = new PrintPreviewDialog();
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.Height = 600;
				printPreviewDialog.Width = 800;
				printPreviewDialog.ShowDialog();
			}
			catch(Exception e)
			{
				throw new Exception("Printer error." + e.Message);
			}

		}
	} 
} 

