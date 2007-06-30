using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPrinting;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
namespace Scheduler.BusinessLayer
{
    class DevExpressClassPrinting : Link
    {

        #region Declarations
        #region Alignment Attributes
        int top = 85;
        int leftColumn = 50;
        int rightColumn = 210;
        int topIncrement = 20;
        public Color label1ForeColor = Color.Black;
        PrintingSystem printingSystem;
        #endregion

        #region Data Attributes
        private ArrayList arrLabel;
        private ArrayList arrValue;

        private ArrayList arrLabel1;
        private ArrayList arrValue1;
        private ArrayList arrValue2;
        private ArrayList arrValue3;
        private ArrayList arrValue4;
        #endregion

        private bool sClass = false;

        public int RowCount = 0;  // current count of rows;
        private const int kVerticalCellLeeway = 10;
        public int PageNumber = 1;
        public ArrayList Lines = new ArrayList();
        private int LastIndex = 0;
        private int LastPos = 0;
        bool boolContinue = false;

        #region Page Settings Attributes
        float PageWidth;
        float PageHeight;
        float TopMargin;
        float BottomMargin;
        #endregion
        #endregion

        #region Constructors
        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue): base(ps)
        {
            printingSystem = ps;
            arrLabel = _arrLabel;
            arrValue = _arrValue;

            PageWidth = ps.PageSettings.UsablePageSize.Width;
            PageHeight = ps.PageSettings.UsablePageSize.Height;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;

            CreateDocument(ps);
        }

        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue, ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3) : base(ps)
        {
            printingSystem = ps;
            arrLabel = _arrLabel;
            arrValue = _arrValue;

            arrLabel1 = _arrLabel1;
            arrValue1 = _arrValue1;
            arrValue2 = _arrValue2;
            arrValue3 = _arrValue3;

            PageWidth = ps.PageSettings.UsablePageSize.Width;
            PageHeight = ps.PageSettings.UsablePageSize.Height;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;

            CreateDocument(ps);
        }

        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue, ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3,ArrayList _arrValue4) : base(ps)
        {
            printingSystem = ps;
            arrLabel = _arrLabel;
            arrValue = _arrValue;

            arrLabel1 = _arrLabel1;
            arrValue1 = _arrValue1;
            arrValue2 = _arrValue2;
            arrValue3 = _arrValue3;
            arrValue4 = _arrValue4;

            PageWidth = ps.PageSettings.UsablePageSize.Width;
            PageHeight = ps.PageSettings.UsablePageSize.Height;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;

            CreateDocument(ps);

        }

        #endregion



        public override void CreateDocument(PrintingSystem ps)
        {
            
            if (ps != null)
            {
                base.CreateDocument();
            }

        }

        protected override void CreateDetail(BrickGraphics g)
        {
            base.CreateDetail(g);
            CreateRow(g);
        }

        #region Methods
        protected virtual void CreateRow(BrickGraphics g)
        {
            bool bContinue = false;
            try
            {
                //DrawHeader(g);
                //if (sClass)
                //{
                //    bContinue = DrawClass(g);
                //}
                //else
                //{
                //    bContinue = DrawRows(g);
                //}
                g.DrawString("Test Printing", new RectangleF(new PointF(100, 100), new SizeF(150, 150)));
              //  if (!bContinue) InitializeData();
              //  if (bContinue)
                {
                   // PageNumber++;
                    //sClass = false;

                    //BrickGraphics newBrick = (BrickGraphics)g.PrintingSystem.CreateBrick("Brick");

                    //g.PrintingSystem.Document.Pages.Add((Page)p);
                    //mainFrm.DrawTopLabel(newBrick);
                    // sClass = true;
                    //return DrawDataGrid(newBrick, mainFrm);
                }
               // else
                {
                 //   return bContinue;
                }
                System.Console.WriteLine("Test");
                //return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //return false;
            }

        }

        protected override void CreateInnerPageHeader(BrickGraphics graph)
        {
            base.CreateInnerPageHeader(graph);
            int TopMargin = PrintingSystem.PageSettings.Margins.Top;

            Font _font =
                new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            graph.Font = _font;
            RectangleF rect = new RectangleF(20, 40, 300, 300);
            try
            {
                Color c = label1ForeColor;
                graph.DrawString("Class Information", c, rect, DevExpress.XtraPrinting.BorderSide.None);
            }
            catch (Exception ex)
            {

            }
            
        }
        #region Main Methods
        public bool DrawRows(BrickGraphics g)
        {
            float lastRowBottom = TopMargin;

            try
            {
                #region Declarations
                SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.Black);
                SolidBrush BackBrush = new SolidBrush(System.Drawing.Color.White);
                Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);


                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));

                Font _font_value = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));
                Rectangle iRectangle = new Rectangle(0, 0, 200, 100);

                int X = 85;
                bool IsRichText = false;
                bool LastIsRichText = false;
                #endregion

                if (LastPos <= 0)
                {
                    #region Last Pos Less than or equal zero
                    for (int i = LastIndex; i < arrLabel.Count; i++)
                    {
                        if (arrLabel[i].ToString() == "------")
                        {
                            if (arrValue[i].ToString() == "RICHTEXT") IsRichText = true;
                            DrawHorizontalLines(g, X);
                        }
                        else
                        {

                        }
                        {
                            if (IsRichText)
                            {
                                g.Font = _font_label;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrLabel[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None); // 50, X, new StringFormat());
                                X += 20;

                                string s = arrValue[i].ToString();
                                int CarriageReturnCnt = 0;
                                foreach (char c in s)
                                {
                                    if (c == '\n') CarriageReturnCnt++;
                                }
                                g.Font = _font_value;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrValue[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);

                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += CarriageReturnCnt * 11;
                                IsRichText = false;
                            }
                            else
                            {

                                g.Font = _font_label;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrLabel[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                g.Font = _font_value;
                                iRectangle.X = 210;
                                iRectangle.Y = X;
                                g.DrawString(arrValue[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
                            }

                        }
                        X += 20;

                        if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                        {
                            boolContinue = true;
                            LastPos = 0;
                            LastIndex = i;
                            LastIsRichText = IsRichText;
                            return true;
                        }
                        else LastPos = 1;
                        boolContinue = false;
                    }
                    #endregion
                }

                if (arrValue1 != null)
                {
                    #region arrValue1 Not Equal to 0
                    if (((LastPos == 1) && (boolContinue)) || (!boolContinue))
                    {

                        if (!boolContinue) LastIndex = 0;

                        if (arrValue1.Count > 0)
                        {
                            #region arrValue1 Count is greater than zero
                            for (int i = LastIndex; i < arrLabel1.Count; i++)
                            {
                                if (arrLabel1[i].ToString() == "------")
                                {
                                    DrawHorizontalLines(g, X);
                                    X += 15;
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString("Initial Test Event >>", System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                    //g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString(arrLabel1[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);


                                    g.Font = _font_value;
                                    iRectangle.X = 210;
                                    iRectangle.Y = X;
                                    g.DrawString(arrValue1[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                    //   g.DrawString(arrValue1[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());

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

                                if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                {
                                    boolContinue = true;
                                    LastPos = 1;
                                    LastIndex = i;
                                    LastIsRichText = IsRichText;
                                    return true;
                                }
                                else LastPos = 2;
                                boolContinue = false;
                            }
                            #endregion
                        }
                        else LastPos = 2;
                    }

                    if (arrValue2 != null)
                    {
                        #region arrValue2 IS NOT NULL
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

                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString("MidTerm Test Event >>", System.Drawing.Color.Black, iRectangle, BorderSide.None);

                                        //g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString(arrLabel1[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);


                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        g.Font = _font_value;
                                        iRectangle.X = 210;
                                        iRectangle.Y = X;
                                        g.DrawString(arrValue2[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);

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

                                    if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                    {
                                        boolContinue = true;
                                        LastPos = 2;
                                        LastIndex = i;
                                        LastIsRichText = IsRichText;
                                        return true;
                                    }
                                    else LastPos = 3;
                                    boolContinue = false;
                                }
                            }
                        }
                        else LastPos = 3;
                        #endregion
                    }

                    if (arrValue3 != null)
                    {
                        #region arrValue3 IS NOT NULL
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

                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString("Final Test Event >>", System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString(arrLabel1[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        g.Font = _font_value;
                                        iRectangle.X = 210;
                                        iRectangle.Y = X;
                                        g.DrawString(arrValue3[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);
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

                                    if (X > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                                    {
                                        boolContinue = true;
                                        LastPos = 3;
                                        LastIndex = i;
                                        LastIsRichText = IsRichText;
                                        return true;
                                    }
                                    else LastPos = 3;
                                    boolContinue = false;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        public bool DrawClass(BrickGraphics g)
        {
            float lastRowBottom = TopMargin;

            try
            {
                #region Declarations

                SolidBrush ForeBrush = new SolidBrush(System.Drawing.Color.Black);
                SolidBrush BackBrush = new SolidBrush(System.Drawing.Color.White);
                Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);

                Font _font_label = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
                Font _font_value = new Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                Rectangle iRectangle = new Rectangle(0, 0, 200, 100);

                int X = 85;
                bool IsRichText = false;
                bool LastIsRichText = false;
                #endregion
                if (LastPos <= 0)
                {
                    for (int i = LastIndex; i < arrLabel.Count; i++)
                    {
                        if (arrLabel[i].ToString() == "------")
                        {
                            if (arrValue[i].ToString() == "RICHTEXT") IsRichText = true;
                            DrawHorizontalLines(g, (float)X);
                        }
                        else
                        {
                            if (IsRichText)
                            {
                                g.Font = _font_label;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrLabel[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);

                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += 20;

                                string s = arrValue[i].ToString();
                                int CarriageReturnCnt = 0;
                                foreach (char c in s)
                                {
                                    if (c == '\n') CarriageReturnCnt++;
                                }

                                g.Font = _font_value;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrValue[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                X += CarriageReturnCnt * 11;
                                IsRichText = false;
                            }
                            else
                            {
                                g.Font = _font_label;
                                iRectangle.X = 50;
                                iRectangle.Y = X;
                                g.DrawString(arrLabel[i].ToString() + " : ", System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                //g.DrawString(arrLabel[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                g.Font = _font_value;
                                iRectangle.X = 210;
                                iRectangle.Y = X;
                                g.DrawString(arrValue[i].ToString(), System.Drawing.Color.Black, iRectangle, BorderSide.None);
                                //g.DrawString(arrValue[i].ToString(), _font_value, new SolidBrush(System.Drawing.Color.Black), 210, X, new StringFormat());
                            }

                        }
                        X += 20;

                        if (X > (PageHeight) - (BottomMargin + TopMargin))
                        {
                            boolContinue = true;
                            LastPos = 0;
                            LastIndex = i;
                            LastIsRichText = IsRichText;
                            return true;
                        }
                        else LastPos = 1;
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
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString("Class Event >>", Color.Black, iRectangle, BorderSide.None);
                                    //g.DrawString("Class Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString(arrLabel1[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
                                    //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                    g.Font = _font_value;
                                    iRectangle.X = 210;
                                    iRectangle.Y = X;
                                    g.DrawString(arrValue4[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
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

                                if (X > (PageHeight) - (BottomMargin + TopMargin))
                                {
                                    boolContinue = true;
                                    LastPos = 1;
                                    LastIndex = i;
                                    LastIsRichText = IsRichText;
                                    return true;
                                }
                                else LastPos = 2;
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
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString("Initial Test Event >>", Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString("Initial Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString(arrLabel1[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        g.Font = _font_value;
                                        iRectangle.X = 210;
                                        iRectangle.Y = X;
                                        g.DrawString(arrValue1[i].ToString(), Color.Black, iRectangle, BorderSide.None);
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

                                    if (X > (PageHeight) - (BottomMargin + TopMargin))
                                    {
                                        boolContinue = true;
                                        LastPos = 2;
                                        LastIndex = i;
                                        LastIsRichText = IsRichText;
                                        return true;
                                    }
                                    else LastPos = 3;
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
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString("MidTerm Test Event >>", Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString("MidTerm Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                        X += 10;
                                    }
                                    else
                                    {
                                        g.Font = _font_label;
                                        iRectangle.X = 50;
                                        iRectangle.Y = X;
                                        g.DrawString(arrLabel1[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
                                        //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                        g.Font = _font_value;
                                        iRectangle.X = 210;
                                        iRectangle.Y = X;
                                        g.DrawString(arrValue2[i].ToString(), Color.Black, iRectangle, BorderSide.None);

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

                                    if (X > (PageHeight) - (BottomMargin + TopMargin))
                                    {
                                        boolContinue = true;
                                        LastPos = 3;
                                        LastIndex = i;
                                        LastIsRichText = IsRichText;
                                        return true;
                                    }
                                    else LastPos = 4;
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
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString("Final Test Event >>", Color.Black, iRectangle, BorderSide.None);
                                    //g.DrawString("Final Test Event >>", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());
                                    X += 10;
                                }
                                else
                                {
                                    g.Font = _font_label;
                                    iRectangle.X = 50;
                                    iRectangle.Y = X;
                                    g.DrawString(arrLabel1[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
                                    //g.DrawString(arrLabel1[i].ToString() + " : ", _font_label, new SolidBrush(System.Drawing.Color.Black), 50, X, new StringFormat());

                                    g.Font = _font_value;
                                    iRectangle.X = 210;
                                    iRectangle.Y = X;
                                    g.DrawString(arrValue3[i].ToString() + " : ", Color.Black, iRectangle, BorderSide.None);
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

                                if (X > (PageHeight) - (BottomMargin + TopMargin))
                                {
                                    boolContinue = true;
                                    LastPos = 4;
                                    LastIndex = i;
                                    LastIsRichText = IsRichText;
                                    return true;
                                }
                                else LastPos = 5;
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

        public void InitializeData()
        {
            RowCount = 0;
            PageNumber = 1;
            LastIndex = 0;
            LastPos = 0;
            boolContinue = false;
        }

        void DrawHorizontalLines(BrickGraphics g, float y)
        {
            Pen TheLinePen = new Pen(System.Drawing.Color.Gray, 1);

            //if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
            //	return;

            //for (int i = 0;  i < lines.Count; i++)
            //{
            g.DrawLine(new PointF(20, y), new PointF(PageWidth - 40, y), Color.Gray, 1);

            //}
        }
        #endregion
        #endregion
    }
}
