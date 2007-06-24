using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPrinting;
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
        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue)
        {
            arrLabel = _arrLabel;
            arrValue = _arrValue;

            PageWidth = ps.PageSettings.UsablePageSize.Width;
            PageHeight = ps.PageSettings.UsablePageSize.Height;
            TopMargin = ps.PageMargins.Top;
            BottomMargin = ps.PageMargins.Bottom;

            CreateDocument(ps);
        }

        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue, ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3)
        {
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

        public DevExpressClassPrinting(PrintingSystem ps, ArrayList _arrLabel, ArrayList _arrValue, ArrayList _arrLabel1, ArrayList _arrValue1, ArrayList _arrValue2, ArrayList _arrValue3,ArrayList _arrValue4)
        {
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

        }

        #region Methods
        protected virtual void CreateRow(BrickGraphics g)
        {

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
    }
}
