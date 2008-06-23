using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Scheduler.BusinessLayer;
using System.Data;

namespace Scheduler.Reports
{
    public partial class FinalProgramInformation : DevExpress.XtraReports.UI.XtraReport
    {
        public FinalProgramInformation()
        {
            InitializeComponent();
        }

        public void LoadData(string programName)
        {
            lblProgramNameValue.Text = programName;
        }

        public void LoadData(int programID)
        {
            this.programID = programID; 
            dataSet11.ViewProgramReport.Clear();
            dataSet11.ViewProgramReport.Load(DAC.SelectStatement("Select * From ViewProgramReport Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);
            dataSet11.viewProgramReportClassDetails.Load(DAC.SelectStatement("Select * From viewProgramReportClassDetails Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);
            dataSet11.viewPivotCourseDetails.Load(BusinessLayer.DAC.SelectStatement("Select * From viewPivotCourseDetails Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);
            DataTable dt = Pivot(dataSet11.viewPivotCourseDetails.CreateDataReader(), "Name", "DAYNAME", "InstructorName");
            foreach (DataRow row in dt.Rows)
            {
                BusinessLayer.DataSet1.PivotReportRow prow = dataSet11.PivotReport.NewPivotReportRow();
                prow.Name = row["Name"].ToString();

                if (dt.Columns.Contains("Sun"))
                    prow.Sun = row["Sun"].ToString();
                if (dt.Columns.Contains("Mon"))
                    prow.Mon = row["Mon"].ToString();
                if (dt.Columns.Contains("Tue"))
                    prow.Tue = row["Tue"].ToString();
                if (dt.Columns.Contains("Wed"))
                    prow.Wed = row["Wed"].ToString();
                if (dt.Columns.Contains("Thu"))
                    prow.Thu = row["Thu"].ToString();
                if (dt.Columns.Contains("Fri"))
                    prow.Fri = row["Fri"].ToString();
                if (dt.Columns.Contains("Sat"))
                    prow.Sat = row["Sat"].ToString();
                prow.ProgramID = programID;
                dataSet11.PivotReport.AddPivotReportRow(prow);
            }
        }
        public void LoadData(int programID,string courses)
        {
            this.programID = programID;
            dataSet11.ViewProgramReport.Clear();
            dataSet11.ViewProgramReport.Load(DAC.SelectStatement("Select * From ViewProgramReport Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);
            dataSet11.viewProgramReportClassDetails.Load(DAC.SelectStatement("Select * From viewProgramReportClassDetails Where ProgramID = " + programID + " AND CourseID IN (" + courses + ")"), System.Data.LoadOption.OverwriteChanges);
            dataSet11.viewPivotCourseDetails.Load(BusinessLayer.DAC.SelectStatement("Select * From viewPivotCourseDetails Where ProgramID = " + programID + " AND CourseID IN (" + courses + ")"), System.Data.LoadOption.OverwriteChanges);
            DataTable dt = Pivot(dataSet11.viewPivotCourseDetails.CreateDataReader(), "Name", "DAYNAME", "InstructorName");
            foreach (DataRow row in dt.Rows)
            {
                BusinessLayer.DataSet1.PivotReportRow prow = dataSet11.PivotReport.NewPivotReportRow();
                prow.Name = row["Name"].ToString();

                if (dt.Columns.Contains("Sun"))
                    prow.Sun = row["Sun"].ToString();
                if (dt.Columns.Contains("Mon"))
                    prow.Mon = row["Mon"].ToString();
                if (dt.Columns.Contains("Tue"))
                    prow.Tue = row["Tue"].ToString();
                if (dt.Columns.Contains("Wed"))
                    prow.Wed = row["Wed"].ToString();
                if (dt.Columns.Contains("Thu"))
                    prow.Thu = row["Thu"].ToString();
                if (dt.Columns.Contains("Fri"))
                    prow.Fri = row["Fri"].ToString();
                if (dt.Columns.Contains("Sat"))
                    prow.Sat = row["Sat"].ToString();
                prow.ProgramID = programID;
                dataSet11.PivotReport.AddPivotReportRow(prow);
            }
        }
        int programID;
        public static DataTable Pivot(IDataReader dataValues, string keyColumn, string pivotNameColumn, string pivotValueColumn)
        {

            DataTable tmp = new DataTable();

            DataRow r;

            string LastKey = "//dummy//";

            int i, pValIndex, pNameIndex;

            string s;

            bool FirstRow = true;



            // Add non-pivot columns to the data table:



            pValIndex = dataValues.GetOrdinal(pivotValueColumn);

            pNameIndex = dataValues.GetOrdinal(pivotNameColumn);



            for (i = 0; i <= dataValues.FieldCount - 1; i++)

                if (i != pValIndex && i != pNameIndex)

                    tmp.Columns.Add(dataValues.GetName(i), dataValues.GetFieldType(i));



            r = tmp.NewRow();



            // now, fill up the table with the data:

            while (dataValues.Read())
            {

                // see if we need to start a new row

                if (dataValues[keyColumn].ToString() != LastKey)
                {

                    // if this isn't the very first row, we need to add the last one to the table

                    if (!FirstRow)

                        tmp.Rows.Add(r);

                    r = tmp.NewRow();

                    FirstRow = false;

                    // Add all non-pivot column values to the new row:

                    for (i = 0; i <= dataValues.FieldCount - 3; i++)

                        r[i] = dataValues[tmp.Columns[i].ColumnName];

                    LastKey = dataValues[keyColumn].ToString();

                }

                // assign the pivot values to the proper column; add new columns if needed:

                s = dataValues[pNameIndex].ToString();

                if (!tmp.Columns.Contains(s))

                    tmp.Columns.Add(s, dataValues.GetFieldType(pValIndex));

                r[s] = dataValues[pValIndex];

            }




            // add that final row to the datatable:

            tmp.Rows.Add(r);


            // Close the DataReader

            dataValues.Close();


            // and that's it!

            return tmp;

        }
        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // finalProgramSubReport1.LoadData(programID);
        }

    }
}
