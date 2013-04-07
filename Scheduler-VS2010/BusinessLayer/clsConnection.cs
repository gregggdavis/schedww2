using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsConnection.
	/// </summary>
	public class Connection
	{
		public Connection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private SqlConnection sqlCon=null;

		public SqlConnection SQLCon
		{
			get{return sqlCon;}
			set{sqlCon = value;}
		}

		public bool Connect()
		{
			try
			{
				sqlCon = new SqlConnection();
				sqlCon.ConnectionString = Common.ConnString;
				if(sqlCon.State==ConnectionState.Closed)
				{
					sqlCon.Open();
				}
				return true;
			}
			catch(SqlException ex)
			{
				Message.ShowException("Unable to Connect Database", ex.Message);
				return false;
			}
		}

		public void DisConnect()
		{
			if(sqlCon.State == ConnectionState.Open) 
			{
				sqlCon.Close();
			}
			sqlCon.Dispose();
			sqlCon=null;
		}
	}
}
