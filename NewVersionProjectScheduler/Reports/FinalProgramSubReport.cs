using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Scheduler.Reports
{
    public partial class FinalProgramSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        public FinalProgramSubReport()
        {
            InitializeComponent();
        }
        public void LoadData(int programID)
        {
            dataSet1.Clear();
            dataSet1.viewPivotCourseDetails.Load(BusinessLayer.DAC.SelectStatement("Select * From viewPivotCourseDetails Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);
            DataTable dt = Pivot(dataSet1.viewPivotCourseDetails.CreateDataReader(), "Name", "DAYNAME", "InstructorName");
            foreach (DataRow row in dt.Rows)
            {
                BusinessLayer.DataSet1.PivotReportRow prow = dataSet1.PivotReport.NewPivotReportRow();
                prow.Name = row["Name"].ToString();
                prow.Sun = row["Sun"].ToString();
                prow.Mon = row["Mon"].ToString();
                prow.Tue = row["Tue"].ToString();
                prow.Wed = row["Wed"].ToString();
                prow.Thu = row["Thu"].ToString();
                prow.Fri = row["Fri"].ToString();
                prow.Sat = row["Sat"].ToString();
                dataSet1.PivotReport.AddPivotReportRow(prow);
            }
        }
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
    }
}
