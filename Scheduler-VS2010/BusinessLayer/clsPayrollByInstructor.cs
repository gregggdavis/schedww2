using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SQLHelper.SqlHelpers;
namespace Scheduler.BusinessLayer
{
    public class PayrollByInstructor
    {
        public System.Data.SqlClient.SqlDataReader GetPayrollByInstructor(DateTime startdate, DateTime enddate,bool isnull,DataSet1 ds)
        {
            try
            {


                System.Data.SqlClient.SqlCommand command = SqlHelper.CreateCommand(DAC.Connection, "GetPayrollByInstructor");
                command.CommandType = CommandType.StoredProcedure;
                
                //command.CommandText = sqlhelper.CreateMyCommand(DAC.ConnectionString, "InsertNewBanks", null);
                
                {
                    System.Data.SqlClient.SqlParameter pStartDateTime = new System.Data.SqlClient.SqlParameter("@StartDateTime", System.Data.SqlDbType.DateTime);
                    pStartDateTime.Direction = ParameterDirection.Input;
                    if (!isnull)
                        pStartDateTime.Value = startdate;
                    else
                        pStartDateTime.Value = null;
                    command.Parameters.Add(pStartDateTime);

                    System.Data.SqlClient.SqlParameter pEndDateTime = new System.Data.SqlClient.SqlParameter("@EndDateTime", System.Data.SqlDbType.DateTime);
                    pEndDateTime.Direction = ParameterDirection.Input;
                    if (!isnull)
                        pEndDateTime.Value = enddate;
                    else
                        pEndDateTime.Value = null;
                    command.Parameters.Add(pEndDateTime);
                }
                if (DAC.Connection.State == ConnectionState.Closed)
                {
                    DAC.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
                if (DAC.Connection.State == ConnectionState.Open)
                {
                    DAC.Connection.Close();
                }
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetData(DateTime startdate, DateTime enddate, bool isnull,DataSet1 ds)
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;
            try
            {
                strSql = "GetPayrollByInstructor";

                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con.SQLCon;
                com.CommandText = strSql;

                com.Parameters.Add(new SqlParameter("StartDateTime", SqlDbType.DateTime));
                if (isnull)
                    com.Parameters["StartDateTime"].Value = DBNull.Value;
                else
                    com.Parameters["StartDateTime"].Value = startdate;
                com.Parameters.Add(new SqlParameter("EndDateTime", SqlDbType.DateTime));
                if (isnull)
                    com.Parameters["EndDateTime"].Value = DBNull.Value;
                else
                    com.Parameters["EndDateTime"].Value = enddate;
                SqlDataReader reader = com.ExecuteReader();
                ds.GetPayrollByInstructor.Clear();
                ds.GetPayrollByInstructor.Load(reader, LoadOption.OverwriteChanges);
                DataSet1.GetPayrollByInstructorDataTable table = new DataSet1.GetPayrollByInstructorDataTable();
                foreach (DataSet1.GetPayrollByInstructorRow row in ds.GetPayrollByInstructor.Rows)
                {
                    #region Adding to temptable
                    System.Data.DataRow[] olddr = ds.GetPayrollByInstructor.Select("TeacherID = " + row.TeacherID);
                    System.Data.DataRow[] newdr = table.Select("TeacherID = " + row.TeacherID);
                    if (olddr.Length != 4)
                    {
                        int total = newdr.Length + olddr.Length;
                        if(total != 4)
                        {
                            bool evefound = false, morfound = false, dayfound = false, satfound = false;
                            foreach (DataSet1.GetPayrollByInstructorRow srow in olddr)
                            {
                                switch (srow.DayType)
                                {
                                    case "4-Evening":
                                        evefound = true;
                                        break;
                                    case "3-Morning":
                                        morfound = true;
                                        break;
                                    case "2-Saturday":
                                        satfound = true;
                                        break;
                                    case "1-Daytime":
                                        dayfound = true;
                                        break;
                                }
                                
                            }
                            foreach (DataSet1.GetPayrollByInstructorRow srow in newdr)
                            {
                                switch (srow.DayType)
                                {
                                    case "4-Evening":
                                        evefound = true;
                                        break;
                                    case "3-Morning":
                                        morfound = true;
                                        break;
                                    case "2-Saturday":
                                        satfound = true;
                                        break;
                                    case "1-Daytime":
                                        dayfound = true;
                                        break;
                                }
                            }
                            if (!dayfound)
                                table.AddGetPayrollByInstructorRow(row.TeacherID, row.InstructorName, Convert.ToDecimal(0.00), Convert.ToDecimal(1.0), row.BasePayField, Convert.ToDecimal(0.00), "1-Daytime", row.TimeStatus);
                            if (!satfound)
                                table.AddGetPayrollByInstructorRow(row.TeacherID, row.InstructorName, Convert.ToDecimal(0.00), Convert.ToDecimal(1.2), row.BasePayField, Convert.ToDecimal(0.00), "2-Saturday", row.TimeStatus);
                            if (!morfound)
                                table.AddGetPayrollByInstructorRow(row.TeacherID, row.InstructorName, Convert.ToDecimal(0.00), Convert.ToDecimal(1.1), row.BasePayField, Convert.ToDecimal(0.00), "3-Morning", row.TimeStatus);
                            if (!evefound)
                                table.AddGetPayrollByInstructorRow(row.TeacherID, row.InstructorName, Convert.ToDecimal(0.00), Convert.ToDecimal(1.2), row.BasePayField, Convert.ToDecimal(0.00), "4-Evening", row.TimeStatus);
                            
                            
                            
                        }
                    }
                    #endregion
                }
                foreach (DataSet1.GetPayrollByInstructorRow row in table)
                {
                    ds.GetPayrollByInstructor.AddGetPayrollByInstructorRow(row.TeacherID, row.InstructorName, row.TotalHours, row.HourlyRate, row.BasePayField, row.Total, row.DayType, row.TimeStatus);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                    con.DisConnect();
                }
            }
        }

    }
}
