using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;
using DevExpress.XtraPrinting;


namespace Scheduler
{
    public class DevNormalPrinting : Link
    {
        #region Declarations
        //private PrintDocument ThePrintDocument;
        private ArrayList arrLabel;
        private ArrayList arrValue;

        private ArrayList arrLabel1;
        private ArrayList arrValue1;
        private ArrayList arrValue2;
        private ArrayList arrValue3;
        private ArrayList arrValue4;

        private bool sClass = false;

        public int RowCount = 0;  // current count of rows;
        private const int kVerticalCellLeeway = 10;
        public int PageNumber = 1;
        public ArrayList Lines = new ArrayList();
        private int LastIndex = 0;
        private int LastPos = 0;
        bool boolContinue = false;

        int PageWidth;
        int PageHeight;
        int TopMargin;
        int BottomMargin;

        int TextWidth = 200;
        int TextHeight = 100;
        public Color Label1ForeColor = Color.Black;
        public string RTitle = "";
        #endregion

        #region Constructors
        public DevNormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, PrintingSystem aPrintDocument)
		{
			//
			// TODO: Add constructor logic here
			//
			arrLabel = _arrLabel;
			arrValue = _arrValue;
			this.ps = aPrintDocument;
            
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;
            PageWidth = ps.PageBounds.Width - ps.PageMargins.Right - ps.PageMargins.Left;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Width);
            PageHeight = ps.PageBounds.Height - TopMargin - BottomMargin;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Height);
            
		}

		public DevNormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, 
			ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3,
			PrintingSystem aPrintDocument)
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
			
			this.ps = aPrintDocument;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;
            PageWidth = ps.PageBounds.Width - ps.PageMargins.Right - ps.PageMargins.Left;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Width);
            PageHeight = ps.PageBounds.Height - TopMargin - BottomMargin;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Height);
            //PageWidth = Convert.ToInt32(ps.PageSettings.UsablePageSize.Width);
            //PageHeight = Convert.ToInt32(ps.PageSettings.UsablePageSize.Height);
            //TopMargin = ps.PageMargins.Top;
            //BottomMargin = ps.PageMargins.Bottom;
		}

        public DevNormalPrinting(ArrayList _arrLabel, ArrayList _arrValue, 
			ArrayList _arrLabel1, ArrayList _arrValue1, 
			ArrayList _arrValue2, 
			ArrayList _arrValue3,
			ArrayList _arrValue4,
			PrintingSystem aPrintDocument)
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
			
			this.ps = aPrintDocument;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;
            PageWidth = ps.PageBounds.Width - ps.PageMargins.Right - ps.PageMargins.Left;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Width);
            PageHeight = ps.PageBounds.Height - TopMargin - BottomMargin;//Convert.ToInt32(ps.PageSettings.UsablePageSize.Height);
            //PageWidth = Convert.ToInt32(ps.PageSettings.UsablePageSize.Width);
            //PageHeight = Convert.ToInt32(ps.PageSettings.UsablePageSize.Height);
            //TopMargin = ps.PageMargins.Top;
            //BottomMargin = ps.PageMargins.Bottom;
		}

        #endregion

        #region MainMethods
        public bool DrawRows(BrickGraphics g)
        {
            int lastRowBottom = TopMargin;

            try
            {
                //SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.Black);
                Color ForeBrush = System.Drawing.Color.Black;
                Color BackBrush = System.Drawing.Color.White;
                Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                BrickStringFormat brickCellFormat = new BrickStringFormat(cellformat);

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);


                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
                Font _font_value = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));
                // int X = 10;
                bool IsRichText = false;
                bool LastIsRichText = false;

                if (LastPos <= 0)
                {
                    for (int i = LastIndex; i < arrLabel.Count; i++)
                    {
                        if (arrLabel[i].ToString() == "------")
                        {
                            if (arrValue[i].ToString() == "RICHTEXT") IsRichText = true;
                            DrawHorizontalLines(g, X);
                        }
                        else
                        {
                            if (IsRichText)
                            {
                                
                                

                                this.DrawString(arrLabel[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight,new StringFormat(), g);
                                
                                
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += 20;

                                string s = arrValue[i].ToString();
                                int CarriageReturnCnt = 0;
                                foreach (char c in s)
                                {
                                    if (c == '\n') CarriageReturnCnt++;
                                }
                                this.DrawString(arrValue[i].ToString(), _font_value, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += CarriageReturnCnt * 11;
                                IsRichText = false;
                            }
                            else
                            {
                                this.DrawString(arrLabel[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                this.DrawString(arrValue[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
                            }

                        }
                        X += 20;

                        //if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                        //{
                        //    boolContinue = true;
                        //    LastPos = 0;
                        //    LastIndex = i;
                        //    LastIsRichText = IsRichText;
                        //    return true;
                        //}
                        //else 
                        LastPos = 1;
                        boolContinue = false;
                    }
                }

                if (arrValue1 != null)
                {
                    if (((LastPos == 1) && (boolContinue)) || (!boolContinue))
                    {
                        if (!boolContinue) LastIndex = 0;

                        if (arrValue1.Count > 0)
                        {
                            for (int i = LastIndex; i < arrLabel1.Count; i++)
                            {
                                if (arrLabel1[i].ToString() == "------")
                                {
                                    DrawHorizontalLines(g, X);
                                    X += 15;
                                    this.DrawString("Initial Test Event >>",_font_label,Color.Black,50,X,TextWidth,TextHeight,new StringFormat(), g);
                                    //g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    this.DrawString(arrLabel1[i].ToString(), _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    this.DrawString(arrValue1[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrValue1[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                }

                                if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                    (arrLabel1[i].ToString() == "Exception Reason") ||
                                    (arrLabel1[i].ToString() == "Description") ||
                                    (arrLabel1[i].ToString() == "Note"))
                                {
                                    X += 30;
                                }
                                else
                                {
                                    X += 20;
                                }

                                //if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                //{
                                //    boolContinue = true;
                                //    LastPos = 1;
                                //    LastIndex = i;
                                //    LastIsRichText = IsRichText;
                                //    return true;
                                //}
                                //else 
                                LastPos = 2;
                                boolContinue = false;
                            }
                        }
                        else LastPos = 2;
                    }

                    if (arrValue2 != null)
                    {
                        if (((LastPos == 2) && (boolContinue)) || (!boolContinue))
                        {
                            if (!boolContinue) LastIndex = 0;

                            if (arrValue2.Count > 0)
                            {
                                for (int i = LastIndex; i < arrLabel1.Count; i++)
                                {
                                    if (arrLabel1[i].ToString() == "------")
                                    {
                                        DrawHorizontalLines(g, X);
                                        X += 15;
                                        this.DrawString("MidTerm Test Event >>", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        this.DrawString(arrValue2[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrValue2[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                    }
                                    if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                        (arrLabel1[i].ToString() == "Exception Reason") ||
                                        (arrLabel1[i].ToString() == "Description") ||
                                        (arrLabel1[i].ToString() == "Note"))
                                    {
                                        X += 30;
                                    }
                                    else
                                    {
                                        X += 20;
                                    }

                                    //if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                    //{
                                    //    boolContinue = true;
                                    //    LastPos = 2;
                                    //    LastIndex = i;
                                    //    LastIsRichText = IsRichText;
                                    //    return true;
                                    //}
                                    //else 
                                    LastPos = 3;
                                    boolContinue = false;
                                }
                            }
                        }
                        else LastPos = 3;
                    }

                    if (arrValue3 != null)
                    {
                        if (((LastPos == 3) && (boolContinue)) || (!boolContinue))
                        {
                            if (!boolContinue) LastIndex = 0;
                            if (arrValue3.Count > 0)
                            {
                                for (int i = LastIndex; i < arrLabel1.Count; i++)
                                {
                                    if (arrLabel1[i].ToString() == "------")
                                    {
                                        DrawHorizontalLines(g, X);
                                        X += 15;
                                        this.DrawString("Final Test Event >>", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);                                        
                                        //g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        this.DrawString(arrValue3[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrValue3[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                    }
                                    if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                        (arrLabel1[i].ToString() == "Exception Reason") ||
                                        (arrLabel1[i].ToString() == "Description") ||
                                        (arrLabel1[i].ToString() == "Note"))
                                    {
                                        X += 30;
                                    }
                                    else
                                    {
                                        X += 20;
                                    }

                                    //if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                    //{
                                    //    boolContinue = true;
                                    //    LastPos = 3;
                                    //    LastIndex = i;
                                    //    LastIsRichText = IsRichText;
                                    //    return true;
                                    //}
                                    //else 
                                    LastPos = 3;
                                    boolContinue = false;
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
        int X = 10;
        public bool DrawClass(BrickGraphics g)
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

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);

                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
                Font _font_value = new Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
               
                bool IsRichText = false;
                bool LastIsRichText = false;

                if (LastPos <= 0)
                {
                    for (int i = LastIndex; i < arrLabel.Count; i++)
                    {
                        if (arrLabel[i].ToString() == "------")
                        {
                            if (arrValue[i].ToString() == "RICHTEXT") IsRichText = true;
                            DrawHorizontalLines(g, X);
                        }
                        else
                        {
                            if (IsRichText)
                            {
                                this.DrawString(arrLabel[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += 20;

                                string s = arrValue[i].ToString();
                                int CarriageReturnCnt = 0;
                                foreach (char c in s)
                                {
                                    if (c == '\n') CarriageReturnCnt++;
                                }
                                this.DrawString(arrValue[i].ToString(), _font_value, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                               // g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += CarriageReturnCnt * 11;
                                IsRichText = false;
                            }
                            else
                            {
                                this.DrawString(arrLabel[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                this.DrawString(arrValue[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
                            }

                        }
                        X += 20;

                        //if (X > (PageHeight) - (BottomMargin + TopMargin))
                        //{
                        //    boolContinue = true;
                        //    LastPos = 0;
                        //    LastIndex = i;
                        //    LastIsRichText = IsRichText;
                        //    return true;
                        //}
                        //else 
                        LastPos = 1;
                        boolContinue = false;
                    }
                }

                if (arrValue4 != null)
                {
                    if (((LastPos == 1) && (boolContinue)) || (!boolContinue))
                    {
                        if (!boolContinue) LastIndex = 0;

                        if (arrValue4.Count > 0)
                        {
                            for (int i = LastIndex; i < arrLabel1.Count; i++)
                            {
                                if (arrLabel1[i].ToString() == "------")
                                {
                                    DrawHorizontalLines(g, X);
                                    X += 15;
                                    this.DrawString("Class Event >>", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString("Class Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                    this.DrawString(arrValue4[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrValue4[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                }

                                if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                    (arrLabel1[i].ToString() == "Exception Reason") ||
                                    (arrLabel1[i].ToString() == "Description") ||
                                    (arrLabel1[i].ToString() == "Note"))
                                {
                                    X += 30;
                                }
                                else
                                {
                                    X += 20;
                                }

                                //if (X > (PageHeight))// - (BottomMargin + TopMargin))
                                //{
                                //    X += 20;
                                //    //boolContinue = true;
                                //    //LastPos = 1;
                                //    //LastIndex = i;
                                //    //LastIsRichText = IsRichText;
                                //    //return true;
                                //}
                                //else 
                                LastPos = 2;
                                boolContinue = false;
                            }
                        }
                        else LastPos = 2;
                    }

                    if (arrValue1 != null)
                    {
                        if (((LastPos == 2) && (boolContinue)) || (!boolContinue))
                        {
                            if (!boolContinue) LastIndex = 0;

                            if (arrValue1.Count > 0)
                            {
                                for (int i = LastIndex; i < arrLabel1.Count; i++)
                                {
                                    if (arrLabel1[i].ToString() == "------")
                                    {
                                        DrawHorizontalLines(g, X);
                                        X += 15;
                                        this.DrawString("Initial Test Event >>",_font_label,Color.Black,50,X,TextWidth,TextHeight,new StringFormat(), g);
                                        //g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        this.DrawString(arrValue1[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrValue1[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                    }
                                    if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                        (arrLabel1[i].ToString() == "Exception Reason") ||
                                        (arrLabel1[i].ToString() == "Description") ||
                                        (arrLabel1[i].ToString() == "Note"))
                                    {
                                        X += 30;
                                    }
                                    else
                                    {
                                        X += 20;
                                    }

                                    //if (X > (PageHeight) - (BottomMargin + TopMargin))
                                    //{
                                    //    boolContinue = true;
                                    //    LastPos = 2;
                                    //    LastIndex = i;
                                    //    LastIsRichText = IsRichText;
                                    //    return true;
                                    //}
                                    //else 
                                    LastPos = 3;
                                    boolContinue = false;
                                }
                            }
                        }
                        else LastPos = 3;
                    }

                    if (arrValue2 != null)
                    {
                        if (((LastPos == 3) && (boolContinue)) || (!boolContinue))
                        {
                            if (!boolContinue) LastIndex = 0;
                            if (arrValue2.Count > 0)
                            {
                                for (int i = LastIndex; i < arrLabel1.Count; i++)
                                {
                                    if (arrLabel1[i].ToString() == "------")
                                    {
                                        DrawHorizontalLines(g, X);
                                        X += 15;
                                        this.DrawString("MidTerm Test Event >>", _font_label,Color.Black,50,X,TextWidth,TextHeight,new StringFormat(), g);
                                        //g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        this.DrawString(arrValue2[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                        //g.DrawString(arrValue2[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                    }
                                    if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                        (arrLabel1[i].ToString() == "Exception Reason") ||
                                        (arrLabel1[i].ToString() == "Description") ||
                                        (arrLabel1[i].ToString() == "Note"))
                                    {
                                        X += 30;
                                    }
                                    else
                                    {
                                        X += 20;
                                    }

                                    //if (X > (PageHeight) - (BottomMargin + TopMargin))
                                    //{
                                    //    boolContinue = true;
                                    //    LastPos = 3;
                                    //    LastIndex = i;
                                    //    LastIsRichText = IsRichText;
                                    //    return true;
                                    //}
                                    //else 
                                    LastPos = 4;
                                    boolContinue = false;
                                }
                            }
                        }
                        else LastPos = 4;
                    }

                }

                if (arrValue3 != null)
                {
                    if (((LastPos == 4) && (boolContinue)) || (!boolContinue))
                    {
                        if (!boolContinue) LastIndex = 0;
                        if (arrValue3.Count > 0)
                        {
                            for (int i = LastIndex; i < arrLabel1.Count; i++)
                            {
                                if (arrLabel1[i].ToString() == "------")
                                {
                                    DrawHorizontalLines(g, X);
                                    X += 15;
                                    this.DrawString("Final Test Event >>", _font_label,Color.Black,50,X,TextWidth,TextHeight,new StringFormat(), g);
                                    //g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    this.DrawString(arrLabel1[i].ToString() + " : ", _font_label, Color.Black, 50, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    this.DrawString(arrValue3[i].ToString(), _font_value, Color.Black, 210, X, TextWidth, TextHeight, new StringFormat(), g);
                                    //g.DrawString(arrValue3[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

                                }
                                if ((arrLabel1[i].ToString() == "Instructor Change Reason") ||
                                    (arrLabel1[i].ToString() == "Exception Reason") ||
                                    (arrLabel1[i].ToString() == "Description") ||
                                    (arrLabel1[i].ToString() == "Note"))
                                {
                                    X += 30;
                                }
                                else
                                {
                                    X += 20;
                                }

                                //if (X > (PageHeight) - (BottomMargin + TopMargin))
                                //{
                                //    boolContinue = true;
                                //    LastPos = 4;
                                //    LastIndex = i;
                                //    LastIsRichText = IsRichText;
                                //    return true;
                                //}
                                //else 
                                LastPos = 5;
                                boolContinue = false;
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

        void DrawHorizontalLines(BrickGraphics g, int y)
        {
            Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);

            //if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
            //	return;

            //for (int i = 0;  i < lines.Count; i++)
            //{
            g.DrawLine(new PointF(20, y), new PointF(PageWidth - 40, y), TheLinePen.Color, TheLinePen.Width);
            //g.DrawLine(TheLinePen, 20, y, PageWidth - 40, y);
            //}
        }

        void DrawVerticalGridLines(BrickGraphics g, Pen TheLinePen, int columnwidth, int bottom)
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


        public bool DrawDataGrid(BrickGraphics g)
        {
            bool bContinue = false;
            try
            {
                //DrawHeader(g);
                if (sClass)
                {
                    bContinue = DrawClass(g);
                }
                else
                {
                    bContinue = DrawRows(g);
                }

                if (!boolContinue) InitializeData();
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
            LastIndex = 0;
            LastPos = 0;
            boolContinue = false;
        }



        public void DrawString(string s, Font printFont, Color brush, Single x, Single y, Single w, Single h, BrickGraphics _G)
        {
            DrawString(s, printFont, brush, x, y, w, h, new StringFormat(),_G);
        }

        public void DrawString(string s, Font printFont, Color brush, Single x, Single y, Single w, Single h, StringFormat sf, BrickGraphics _G)
        {
                
                RectangleF r = new RectangleF();
                r.X = x;
                r.Y = y;
                r.Width = w;
                r.Height = h;
                _G.Font = printFont;
                BrickStringFormat xformat = new BrickStringFormat(sf);
                _G.StringFormat = xformat;
                _G.ForeColor = brush;
                _G.DrawString(s, brush, r, BorderSide.None);
        }

        #endregion

        #region OverLoadedMethods
        //protected override void CreateInnerPageHeader(BrickGraphics graph)
        //{
        //    base.CreateInnerPageHeader(graph);
        //    int TopMargin = ps.PageSettings.Margins.Top;

        //    Font _font =
        //        new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
        //    //g.DrawString("Class Information", _font, new SolidBrush(label1.ForeColor), 20, 40, new StringFormat());
        //    this.DrawString("Class Information", _font, Label1ForeColor, 20, 40, TextWidth, TextHeight, new StringFormat(), graph);
        //    //Graphics g = e.Graphics;
        //    //DrawTopLabel(g);
        //    //bool more = nm.DrawDataGrid(g);
        //    //if (more == true)
        //    //{
        //    //    e.HasMorePages = true;
        //    //    nm.PageNumber++;
        //    //}
        //}
        protected override void CreateMarginalHeader(BrickGraphics graph)
        {
            base.CreateMarginalHeader(graph);
            int TopMargin = ps.PageSettings.Margins.Top;

            Font _font =
                new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            //g.DrawString("Class Information", _font, new SolidBrush(label1.ForeColor), 20, 40, new StringFormat());
            graph.Font = _font;
            SizeF size = graph.MeasureString(RTitle);
            int x = PageWidth / 2;
            x = x - Convert.ToInt32(size.Width / 2);
            this.DrawString(RTitle, _font, Label1ForeColor, x, 40, TextWidth, TextHeight, new StringFormat(), graph);
        }
        public override void CreateDocument()
        {
            if (ps != null)
            {
                base.CreateDocument();
            }
        }

        protected override void CreateDetail(BrickGraphics graph)
        {
            base.CreateDetail(graph);
            bool more = DrawDataGrid(graph);
            if (more == true)
            {
                //e.HasMorePages = true;
                PageNumber++;
            }
        }
        #endregion
    }

}
