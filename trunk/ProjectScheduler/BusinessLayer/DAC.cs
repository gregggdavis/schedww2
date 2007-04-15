using System;
using System.Configuration;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using SQLHelper.SqlHelpers;
using System.Data.SqlClient;
namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for DAC.
	/// </summary>
	public class DAC
	{
     
        
		public DAC()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private static string myconnection = "";
		public static string MyConnection
		{
			set 
			{
				myconnection = value;
			}
			get
			{
				return ConnectionString;
			}
		}
		//"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
		private static string databaseName = "";
		public static string DatabaseName
		{
			set { databaseName = value;}
			get {return databaseName;}
		}


        
        
		private static string connectionString = "";
		public static string ConnectionString
		{
			get
			{
				try
				{
                    return connectionString;
				}
				catch(Exception ex)
				{	
					throw ex;
				}
			}
			set
			{
				try
				{
                    connectionString = value;
                    connection = new SqlConnection(connectionString);
				}
				catch(Exception ex)
				{	
					throw ex;
				}
			}
		}

        public static void TestConnection(ref string msg,ref bool connected)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                msg = "Database Connected Successfully";
                connected = true;
            }
            catch (Exception ex)
            {
                msg = "The Following Error Has Occured During Connecting to the Database " + ex.Message;
                connected = false;
            }
        }
		private static System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString);


		public static SqlConnection Connection
		{
			get
			{
                if (connection == null)
                    connection = new SqlConnection(ConnectionString);
				return connection;
			}
            

		}
		public static void Main()
		{

		}

		public static int GetAutoNumberID()
		{
			try
			{
				//string query
				SqlCommand command = SqlHelper.CreateCommand(DAC.Connection, "SELECT @@IDENTITY");
				
				if(DAC.Connection.State == ConnectionState.Closed)
				{
					DAC.Connection.Open();
				}

				int ID = Convert.ToInt32(command.ExecuteScalar());

				if(DAC.Connection.State == ConnectionState.Open)
				{
					DAC.Connection.Close();
				}

				return ID;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
        public static System.Data.SqlClient.SqlDataReader SelectStatement(string query)
        {
            if (DAC.Connection.State != ConnectionState.Open)
                DAC.Connection.Open();
            System.Data.SqlClient.SqlDataReader dr = SqlHelper.ExecuteReader(DAC.ConnectionString, CommandType.Text, query);
            if (DAC.Connection.State != ConnectionState.Closed)
                DAC.Connection.Close();
            return dr;
        }
        public static void EXQuery(string query)
        {
            if (DAC.Connection.State != ConnectionState.Open)
                DAC.Connection.Open();
            SqlHelper.ExecuteNonQuery(DAC.ConnectionString, CommandType.Text, query);
            if (DAC.Connection.State != ConnectionState.Closed)
                DAC.Connection.Close();
        }
		public static int GetAutoNumberID(string tableName,string pkName)
		{
			try
			{
				string query = "SELECT MAX(" + pkName + ") from " + tableName;
				//OleDbCommand command = SqlHelper.ExecuteScalar((DAC.Connection, query);
						
				if(DAC.Connection.State == ConnectionState.Closed)
				{
					DAC.Connection.Open();
				}

				int ID = Convert.ToInt32(SqlHelper.ExecuteScalar(DAC.Connection,CommandType.Text ,query));

					//Convert.ToInt32(command.ExecuteScalar());

				if(DAC.Connection.State == ConnectionState.Open)
				{
					DAC.Connection.Close();
				}

				return ID;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
