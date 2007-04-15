using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
namespace Scheduler.BusinessLayer
{

	/// <summary>
	/// Summary description for DataGridPrinter.
	/// </summary>
	public class GridViewPrinter
	{

		private PrintDocument ThePrintDocument;
		private GridView TheTable;
		private GridControl  TheDataGrid;
        

		public int RowCount = 0;  // current count of rows;
		private const int kVerticalCellLeeway = 10;
		public int PageNumber = 1;
		public ArrayList Lines = new ArrayList();

		int PageWidth;
		int PageHeight;
		int TopMargin;
		int BottomMargin;
		
		int LeftMargin;
		int RightMargin;



		public GridViewPrinter(GridControl aGrid, PrintDocument aPrintDocument, GridView aTable)
		{
			TheDataGrid = aGrid;
			ThePrintDocument = aPrintDocument;
			TheTable = aTable;

			if (aPrintDocument.DefaultPageSettings.Landscape)
			{
				PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
				PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;

				TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;
				BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
				LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
				RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
			}
			else
			{
				PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
				PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;

				TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
				BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
			}

		}

		public void DrawHeader(Graphics g)
		{
			SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.White);
			SolidBrush BackBrush = new SolidBrush(System.Drawing.Color.Gray);
			Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
			StringFormat cellformat = new StringFormat();
			cellformat.Trimming = StringTrimming.EllipsisCharacter;
			cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;



			int columnwidth = (PageWidth - LeftMargin - RightMargin)/TheTable.VisibleColumns.Count;   //Columns.Count;

			int initialRowCount = RowCount;

			// draw the table header
			float startxposition = TheDataGrid.Location.X + LeftMargin;
			RectangleF nextcellbounds = new RectangleF(0,0, 0, 0);

			RectangleF HeaderBounds  = new RectangleF(0, 0, 0, 0);

			HeaderBounds.X = TheDataGrid.Location.X + LeftMargin;
			HeaderBounds.Y = TheDataGrid.Location.Y + TopMargin + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints  + kVerticalCellLeeway);
			HeaderBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
			HeaderBounds.Width = (PageWidth - LeftMargin - RightMargin);

			g.FillRectangle(BackBrush, HeaderBounds);

			for (int k = 0; k < TheTable.Columns.Count; k++)
			{
				if(TheTable.Columns[k].VisibleIndex<0) continue;
				string nextcolumn = TheTable.Columns[k].Caption;
				RectangleF cellbounds = new RectangleF(startxposition, TheDataGrid.Location.Y + TopMargin + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints  + kVerticalCellLeeway),
					columnwidth, 9 + kVerticalCellLeeway);
				//TheDataGrid.HeaderFont.SizeInPoints + kVerticalCellLeeway);
				nextcellbounds = cellbounds;

				if (startxposition + columnwidth <= PageWidth)
				{
					g.DrawString(nextcolumn, TheDataGrid.Font, ForeBrush, cellbounds, cellformat);
				}

				startxposition = startxposition + columnwidth;

			}
	
			//if (TheDataGrid.GridLineStyle != DataGridLineStyle.None)
			g.DrawLine(TheLinePen, TheDataGrid.Location.X + LeftMargin, nextcellbounds.Bottom, PageWidth - RightMargin, nextcellbounds.Bottom);
		}

		public bool DrawRows(Graphics g)
		{
			int lastRowBottom = TopMargin;

			try
			{   
				SolidBrush ForeBrush = new SolidBrush(TheDataGrid.ForeColor);
				SolidBrush BackBrush = new SolidBrush(TheDataGrid.BackColor);
				SolidBrush AlternatingBackBrush = new SolidBrush(TheDataGrid.BackColor);
				Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
                
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                int columnwidth = (PageWidth - LeftMargin - RightMargin) /TheTable.VisibleColumns.Count;
                /*
                int initialRowCount = RowCount;
                
				RectangleF RowBounds  = new RectangleF(0, 0, 0, 0);
                */
                int startxposition = 0;
                string temp = string.Empty;
                for (int i = 0; i < TheTable.RowCount; i++)
                {
                    startxposition = TheDataGrid.Location.X + LeftMargin;
                    /*
                    RowBounds.X = TheDataGrid.Location.X + LeftMargin;
                    RowBounds.Y = TheDataGrid.Location.Y + TopMargin + ((RowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
                    RowBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
                    RowBounds.Width = (PageWidth - LeftMargin - RightMargin);
                    Lines.Add(RowBounds.Bottom);*/
                    

                    for (int j = 0; j < TheTable.Columns.Count; j++)
                    {
                        //g.DrawString("Razzita", new Font("Arial", 5), new SolidBrush(Color.Black), (1 + i) * 30, (1 + j) * 30);
                        if (TheTable.Columns[j].VisibleIndex < 0) continue;
                        RectangleF cellbounds = new RectangleF(startxposition,
                            TheDataGrid.Location.Y + TopMargin + ((RowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                            columnwidth,
                            TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);

                        if (startxposition + columnwidth <= PageWidth)
                        {
                            temp = TheTable.GetRowCellValue(i, TheTable.Columns[j]).ToString();
                            g.DrawString(temp, TheDataGrid.Font, ForeBrush, cellbounds, new StringFormat());
                            lastRowBottom = (int)cellbounds.Bottom;
                        }

                        startxposition = startxposition + columnwidth;                        
                        
                    }

                    RowCount++;
                    /*
                    // draw the rows of the table
                    for (int i = initialRowCount; i < TheTable.RowCount; i++)
                    {
                        //DataRow dr = TheTable.Rows[i];
                        int startxposition = TheDataGrid.Location.X + LeftMargin;

                        RowBounds.X = TheDataGrid.Location.X + LeftMargin;
                        RowBounds.Y = TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount)+1) * (TheDataGrid.Font.SizeInPoints  + kVerticalCellLeeway);
                        RowBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
                        RowBounds.Width = (PageWidth - LeftMargin - RightMargin);
                        Lines.Add(RowBounds.Bottom);

                        //if (i%2 == 0)
                        //{
                            //g.FillRectangle(BackBrush, RowBounds);
                        //}
                        //else
                        //{
                        //	g.FillRectangle(AlternatingBackBrush, RowBounds);
                        //}


                        for (int j = 0; j < TheTable.Columns.Count; j++)
                        {
                            if(TheTable.Columns[j].VisibleIndex<0) continue;
                            RectangleF cellbounds = new RectangleF(startxposition, 
                                TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints  + kVerticalCellLeeway),
                                columnwidth, 
                                TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);

                            if (startxposition + columnwidth <= PageWidth)
                            {
                                string s = TheTable.GetRowCellValue(i, TheTable.Columns[j]).ToString();
                                g.DrawString(s, TheDataGrid.Font, ForeBrush, cellbounds, cellformat);
                                lastRowBottom = (int)cellbounds.Bottom;
                            }

                            startxposition = startxposition + columnwidth;
                        }

                        RowCount++;
                    
                        /*
                        if (RowCount * (TheDataGrid.Font.SizeInPoints  + kVerticalCellLeeway) > (PageHeight * PageNumber) - (BottomMargin+TopMargin))
                        {
                            DrawHorizontalLines(g, Lines);
                            DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                            return true;
                        }*/
                    //}*/

                    //DrawHorizontalLines(g, Lines);
                    //DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                    
                }
                return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return false;
			}

		}

		void DrawHorizontalLines(Graphics g, ArrayList lines)
		{/*
			Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);

			//if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
			//	return;

			for (int i = 0;  i < lines.Count; i++)
			{
				g.DrawLine(TheLinePen, TheDataGrid.Location.X + LeftMargin, (float)lines[i], (PageWidth - RightMargin), (float)lines[i]);
			}*/
		}

		void DrawVerticalGridLines(Graphics g, Pen TheLinePen, int columnwidth, int bottom)
		{
			//if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
			//	return;
            /*
			for (int k = 0; k < TheTable.Columns.Count; k++)
			{
				g.DrawLine(TheLinePen, TheDataGrid.Location.X + LeftMargin + k*columnwidth, 
					TheDataGrid.Location.Y + TopMargin,
					TheDataGrid.Location.X + LeftMargin + k*columnwidth,
					bottom);
			}*/
		}

		public bool DrawDataGrid(Graphics g)
		{

			try
			{
				DrawHeader(g);
				bool bContinue = DrawRows(g);
				return bContinue;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return false;
			}

		}

	}
}