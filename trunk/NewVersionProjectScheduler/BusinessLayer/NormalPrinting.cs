using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;

namespace Scheduler.BusinessLayer
{

	/// <summary>
	/// Class for printing Details' Views
	/// </summary>
	public class NormalPrinting
	{

		private PrintDocument ThePrintDocument;
		private ArrayList  arrLabel;
		private ArrayList  arrValue;

		private ArrayList  arrLabel1;
		private ArrayList  arrValue1;
		private ArrayList  arrValue2;
		private ArrayList  arrValue3;
		private ArrayList  arrValue4;

		private bool sClass=false;

		public int RowCount = 0;  // current count of rows;
		private const int kVerticalCellLeeway = 10;
		public int PageNumber = 1;
		public ArrayList Lines = new ArrayList();
		private int LastIndex=0;
		private int LastPos=0;
		bool boolContinue=false;

		int PageWidth;
		int PageHeight;
		int TopMargin;
		int BottomMargin;



		public NormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, PrintDocument aPrintDocument)
		{
			//
			// TODO: Add constructor logic here
			//
			arrLabel = _arrLabel;
			arrValue = _arrValue;
			ThePrintDocument = aPrintDocument;

			PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
			PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
			TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
			BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
		}

		public NormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, 
			ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3,
			PrintDocument aPrintDocument)
		{
			//
			// TODO: Add constructor logic here
			//
			arrLabel = _arrLabel;
			arrValue = _arrValue;

			arrLabel1 = _arrLabel1;
			arrValue1 = _arrValue1;
			arrValue2 = _arrValue2;
			arrValue3 = _arrValue3;
			
			ThePrintDocument = aPrintDocument;

			PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
			PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
			TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
			BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
		}

		public NormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, 
			ArrayList _arrLabel1, ArrayList _arrValue1, 
			ArrayList _arrValue2, 
			ArrayList _arrValue3,
			ArrayList _arrValue4,
			PrintDocument aPrintDocument)
		{
			//
			// TODO: Add constructor logic here
			//
			sClass=true;
			
			arrLabel = _arrLabel;
			arrValue = _arrValue;

			arrLabel1 = _arrLabel1;
			arrValue1 = _arrValue1;
			arrValue2 = _arrValue2;
			arrValue3 = _arrValue3;
			arrValue4 = _arrValue4;
			
			ThePrintDocument = aPrintDocument;

			PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
			PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
			TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
			BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
		}

		public bool DrawRows(Graphics g)
		{
			int lastRowBottom = TopMargin;

			try
			{
				SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.Black);
				SolidBrush BackBrush = new SolidBrush(System.Drawing.Color.White);
				Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
				StringFormat cellformat = new StringFormat();
				cellformat.Trimming = StringTrimming.EllipsisCharacter;
				cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

				RectangleF RowBounds  = new RectangleF(0, 0, 0, 0);


                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
                Font _font_value = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));
				int X=85;
				bool IsRichText=false;
				bool LastIsRichText=false;

				if(LastPos<=0)
				{
					for(int i=LastIndex; i<arrLabel.Count; i++)
					{
						if(arrLabel[i].ToString()=="------")
						{
							if(arrValue[i].ToString()=="RICHTEXT") IsRichText=true;
							DrawHorizontalLines(g, X);
						}
						else
						{
							if(IsRichText)
							{
								g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
								X+=20;

								string s = arrValue[i].ToString();
								int CarriageReturnCnt=0;
								foreach(char c in s)
								{
									if(c=='\n') CarriageReturnCnt++;
								}
								g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
								X+=CarriageReturnCnt*11;
								IsRichText=false;
							}
							else
							{
								g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
								g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
							}

						}
						X+=20;

						if(X>(PageHeight * PageNumber) - (BottomMargin+TopMargin))
						{
							boolContinue=true;
							LastPos=0;
							LastIndex=i;
							LastIsRichText=IsRichText;
							return true;
						}
						else LastPos=1;
						boolContinue=false;
					}
				}

				if(arrValue1!=null)
				{
					if(((LastPos==1) && (boolContinue)) || (!boolContinue))
					{
						if(!boolContinue)  LastIndex=0;

						if(arrValue1.Count>0)
						{
							for(int i=LastIndex; i<arrLabel1.Count; i++)
							{
								if(arrLabel1[i].ToString()=="------")
								{
									DrawHorizontalLines(g, X);
									X+=15;
									g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
									X+=10;
								}
								else
								{
									g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    g.DrawString(arrValue1[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

								}

								if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
									(arrLabel1[i].ToString()=="Exception Reason") ||
									(arrLabel1[i].ToString()=="Description") ||
									(arrLabel1[i].ToString()=="Note"))
								{
									X+=30;
								}
								else
								{
									X+=20;
								}

								if(X>(PageHeight * PageNumber) - (BottomMargin+TopMargin))
								{
									boolContinue=true;
									LastPos=1;
									LastIndex=i;
									LastIsRichText=IsRichText;
									return true;
								}
								else LastPos=2;
								boolContinue=false;
							}
						}
						else LastPos=2;
					}
				
					if(arrValue2!=null)
					{
						if(((LastPos==2) && (boolContinue)) || (!boolContinue))
						{
							if(!boolContinue)  LastIndex=0;

							if(arrValue2.Count>0)
							{
								for(int i=LastIndex; i<arrLabel1.Count; i++)
								{
									if(arrLabel1[i].ToString()=="------")
									{
										DrawHorizontalLines(g, X);
										X+=15;
                                        g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
										X+=10;
									}
									else
									{
                                        g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        g.DrawString(arrValue2[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

									}
									if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
										(arrLabel1[i].ToString()=="Exception Reason") ||
										(arrLabel1[i].ToString()=="Description") ||
										(arrLabel1[i].ToString()=="Note"))
									{
										X+=30;
									}
									else
									{
										X+=20;
									}

									if(X>(PageHeight * PageNumber) - (BottomMargin+TopMargin))
									{
										boolContinue=true;
										LastPos=2;
										LastIndex=i;
										LastIsRichText=IsRichText;
										return true;
									}
									else LastPos=3;
									boolContinue=false;
								}
							}
						}
						else LastPos=3;
					}

					if(arrValue3!=null)
					{
						if(((LastPos==3) && (boolContinue)) || (!boolContinue))
						{
							if(!boolContinue)  LastIndex=0;
							if(arrValue3.Count>0)
							{
								for(int i=LastIndex; i<arrLabel1.Count; i++)
								{
									if(arrLabel1[i].ToString()=="------")
									{
										DrawHorizontalLines(g, X);
										X+=15;
                                        g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
										X+=10;
									}
									else
									{
                                        g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        g.DrawString(arrValue3[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

									}
									if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
										(arrLabel1[i].ToString()=="Exception Reason") ||
										(arrLabel1[i].ToString()=="Description") ||
										(arrLabel1[i].ToString()=="Note"))
									{
										X+=30;
									}
									else
									{
										X+=20;
									}

									if(X>(PageHeight * PageNumber) - (BottomMargin+TopMargin))
									{
										boolContinue=true;
										LastPos=3;
										LastIndex=i;
										LastIsRichText=IsRichText;
										return true;
									}
									else LastPos=3;
									boolContinue=false;
								}
							}
						}
					}
				}

				return false;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return false;
			}

		}

		public bool DrawClass(Graphics g)
		{
			int lastRowBottom = TopMargin;

			try
			{
				SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.Black);
				SolidBrush BackBrush = new SolidBrush(System.Drawing.Color.White);
				Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
				StringFormat cellformat = new StringFormat();
				cellformat.Trimming = StringTrimming.EllipsisCharacter;
				cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

				RectangleF RowBounds  = new RectangleF(0, 0, 0, 0);

                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
				Font _font_value = new Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				int X=85;
				bool IsRichText=false;
				bool LastIsRichText=false;

				if(LastPos<=0)
				{
					for(int i=LastIndex; i<arrLabel.Count; i++)
					{
						if(arrLabel[i].ToString()=="------")
						{
							if(arrValue[i].ToString()=="RICHTEXT") IsRichText=true;
							DrawHorizontalLines(g, X);
						}
						else
						{
							if(IsRichText)
							{
                                g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
								X+=20;

								string s = arrValue[i].ToString();
								int CarriageReturnCnt=0;
								foreach(char c in s)
								{
									if(c=='\n') CarriageReturnCnt++;
								}
                                g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
								X+=CarriageReturnCnt*11;
								IsRichText=false;
							}
							else
							{
                                g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
							}

						}
						X+=20;

						if(X>(PageHeight) - (BottomMargin+TopMargin))
						{
							boolContinue=true;
							LastPos=0;
							LastIndex=i;
							LastIsRichText=IsRichText;
							return true;
						}
						else LastPos=1;
						boolContinue=false;
					}
				}

				if(arrValue4!=null)
				{
					if(((LastPos==1) && (boolContinue)) || (!boolContinue))
					{
						if(!boolContinue)  LastIndex=0;

						if(arrValue4.Count>0)
						{
							for(int i=LastIndex; i<arrLabel1.Count; i++)
							{
								if(arrLabel1[i].ToString()=="------")
								{
									DrawHorizontalLines(g, X);
									X+=15;
                                    g.DrawString("Class Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
									X+=10;
								}
								else
								{
                                    g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    g.DrawString(arrValue4[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

								}

								if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
									(arrLabel1[i].ToString()=="Exception Reason") ||
									(arrLabel1[i].ToString()=="Description") ||
									(arrLabel1[i].ToString()=="Note"))
								{
									X+=30;
								}
								else
								{
									X+=20;
								}

								if(X>(PageHeight) - (BottomMargin+TopMargin))
								{
									boolContinue=true;
									LastPos=1;
									LastIndex=i;
									LastIsRichText=IsRichText;
									return true;
								}
								else LastPos=2;
								boolContinue=false;
							}
						}
						else LastPos=2;
					}
				
					if(arrValue1!=null)
					{
						if(((LastPos==2) && (boolContinue)) || (!boolContinue))
						{
							if(!boolContinue)  LastIndex=0;

							if(arrValue1.Count>0)
							{
								for(int i=LastIndex; i<arrLabel1.Count; i++)
								{
									if(arrLabel1[i].ToString()=="------")
									{
										DrawHorizontalLines(g, X);
										X+=15;
                                        g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
										X+=10;
									}
									else
									{
                                        g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        g.DrawString(arrValue1[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

									}
									if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
										(arrLabel1[i].ToString()=="Exception Reason") ||
										(arrLabel1[i].ToString()=="Description") ||
										(arrLabel1[i].ToString()=="Note"))
									{
										X+=30;
									}
									else
									{
										X+=20;
									}

									if(X>(PageHeight) - (BottomMargin+TopMargin))
									{
										boolContinue=true;
										LastPos=2;
										LastIndex=i;
										LastIsRichText=IsRichText;
										return true;
									}
									else LastPos=3;
									boolContinue=false;
								}
							}
						}
						else LastPos=3;
					}

					if(arrValue2!=null)
					{
						if(((LastPos==3) && (boolContinue)) || (!boolContinue))
						{
							if(!boolContinue)  LastIndex=0;
							if(arrValue2.Count>0)
							{
								for(int i=LastIndex; i<arrLabel1.Count; i++)
								{
									if(arrLabel1[i].ToString()=="------")
									{
										DrawHorizontalLines(g, X);
										X+=15;
                                        g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
										X+=10;
									}
									else
									{
                                        g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        g.DrawString(arrValue2[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

									}
									if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
										(arrLabel1[i].ToString()=="Exception Reason") ||
										(arrLabel1[i].ToString()=="Description") ||
										(arrLabel1[i].ToString()=="Note"))
									{
										X+=30;
									}
									else
									{
										X+=20;
									}

									if(X>(PageHeight) - (BottomMargin+TopMargin))
									{
										boolContinue=true;
										LastPos=3;
										LastIndex=i;
										LastIsRichText=IsRichText;
										return true;
									}
									else LastPos=4;
									boolContinue=false;
								}
							}
						}
						else LastPos=4;
					}

				}

				if(arrValue3!=null)
				{
					if(((LastPos==4) && (boolContinue)) || (!boolContinue))
					{
						if(!boolContinue)  LastIndex=0;
						if(arrValue3.Count>0)
						{
							for(int i=LastIndex; i<arrLabel1.Count; i++)
							{
								if(arrLabel1[i].ToString()=="------")
								{
									DrawHorizontalLines(g, X);
									X+=15;
                                    g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
									X+=10;
								}
								else
								{
                                    g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    g.DrawString(arrValue3[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

								}
								if((arrLabel1[i].ToString()=="Instructor Change Reason") ||
									(arrLabel1[i].ToString()=="Exception Reason") ||
									(arrLabel1[i].ToString()=="Description") ||
									(arrLabel1[i].ToString()=="Note"))
								{
									X+=30;
								}
								else
								{
									X+=20;
								}

								if(X>(PageHeight) - (BottomMargin+TopMargin))
								{
									boolContinue=true;
									LastPos=4;
									LastIndex=i;
									LastIsRichText=IsRichText;
									return true;
								}
								else LastPos=5;
								boolContinue=false;
							}
						}
					}
				}


				return false;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return false;
			}

		}
		
		void DrawHorizontalLines(Graphics g, int y)
		{
			Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);

			//if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
			//	return;

			//for (int i = 0;  i < lines.Count; i++)
			//{
				g.DrawLine(TheLinePen, 20, y, PageWidth-40, y);
			//}
		}

		void DrawVerticalGridLines(Graphics g, Pen TheLinePen, int columnwidth, int bottom)
		{
			//if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
			//	return;

			//for (int k = 0; k < TheTable.Columns.Count; k++)
			//{
			//	g.DrawLine(TheLinePen, TheDataGrid.Location.X + k*columnwidth, 
			//		TheDataGrid.Location.Y + TopMargin,
			//		TheDataGrid.Location.X + k*columnwidth,
			//		bottom);
			//}
		}


		public bool DrawDataGrid(Graphics g)
		{
			bool bContinue=false;
			try
			{
				//DrawHeader(g);
				if(sClass)
				{
					bContinue = DrawClass(g);
				}
				else
				{
					bContinue = DrawRows(g);
				}

				if(!boolContinue) InitializeData();
				return bContinue;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return false;
			}

		}

		public void InitializeData()
		{
			RowCount = 0;
			PageNumber = 1;
			LastIndex=0;
			LastPos=0;
			boolContinue=false;
		}

	}
}

