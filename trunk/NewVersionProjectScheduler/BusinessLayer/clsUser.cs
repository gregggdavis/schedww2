using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsUser.
	/// </summary>
	public class User
	{
		public User()
		{
		}

		private DataTable _dtbl=null;
		private int _userid=0;
		private string _name="";
		private string _pwd="";
		private int _contactid=0;
		private int _typeid=0;
		private int _statusid=0;
		private string _message="";
		private bool _passwordchanged=false;

		public DataTable UserDataTable
		{
			get{return _dtbl;}
			set{_dtbl=value;}
		}
		public int UserID
		{
			get{return _userid;}
			set{_userid=value;}
		}
		public string Name
		{
			get{return _name;}
			set{_name=value;}
		}
		public string Pwd
		{
			get{return _pwd;}
			set{_pwd=value;}
		}
		public int ContactID
		{
			get{return _contactid;}
			set{_contactid=value;}
		}
		public int TypeID
		{
			get{return _typeid;}
			set{_typeid=value;}
		}
		public int StatusID
		{
			get{return _statusid;}
			set{_statusid=value;}
		}
		public bool PasswordChanged
		{
			get{return _passwordchanged;}
			set{_passwordchanged=value;}
		}
		public string Message
		{
			get{return _message;}
			set{_message=value;}
		}

		private void BuildDataTable()
		{
			if(_dtbl==null)
			{
				_dtbl=new DataTable();
			}
			_dtbl.Columns.Clear();
			_dtbl.Columns.Add(new DataColumn("UserID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("UserName", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Password", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ContactID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("UserType", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("UserStatus", Type.GetType("System.String")));
		}

		public static int Clone(int userID)
		{
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try
			{
                /*
				strSql = "usp_ContactClone";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.CommandType = CommandType.StoredProcedure;
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("ContactID", SqlDbType.Int));
				com.Parameters["ContactID"].Value = userID;
				com.Parameters.Add(new SqlParameter("creatorID", SqlDbType.Int));
				com.Parameters["creatorID"].Value = Common.LogonID;
				com.Parameters.Add(new SqlParameter("insertedID", SqlDbType.Int));
				com.Parameters["insertedID"].Direction = ParameterDirection.Output;

				com.ExecuteNonQuery();
                */
                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con.SQLCon;
                com.CommandText = "usp_UserClone";

                com.Parameters.Add(new SqlParameter("userID", SqlDbType.Int));
                com.Parameters["userID"].Value = userID;
                com.Parameters.Add(new SqlParameter("creatorID", SqlDbType.Int));
                com.Parameters["creatorID"].Value = Common.LogonID;
                com.Parameters.Add(new SqlParameter("insertedID", SqlDbType.Int));
                //com.Parameters["insertedID"].Value = DBNull.Value;
                com.Parameters["insertedID"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                return (int)com.Parameters["insertedID"].Value;
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

		public bool LoadData()
		{
			string strSql="";
			SqlDataReader Reader=null;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				if(_userid<=0)
				{
					strSql = "Select * from [User] Order By UserName, UserID";
				}
				else
				{
					strSql = "Select * from [User] Where UserID=" + _userid.ToString() + " ";
				}
			
				BuildDataTable();
			
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				Reader = com.ExecuteReader();
				
				string strtype, strstatus;
				while(Reader.Read())
				{
					strtype="";
					strstatus="";

					if(Convert.ToInt16(Reader["UserType"].ToString())==0)
					{
						strtype = "User";
					}
                    else if (Convert.ToInt16(Reader["UserType"].ToString()) == 1)
                    {
                        strtype = "Admin";
                    }
                    else
                    {
                        strtype = "Read-only";
                    }
					if(Convert.ToInt16(Reader["UserStatus"].ToString())==0)
					{
						strstatus = "Active";
					}
					else
					{
						strstatus = "Inactive";
					}

					_userid = Convert.ToInt32(Reader["UserID"].ToString());
					_name = Reader["UserName"].ToString();
					_pwd = Reader["Password"].ToString();
					_contactid = Convert.ToInt32(Reader["ContactID"].ToString());
					_typeid = Convert.ToInt16(Reader["UserType"].ToString());
					_statusid = Convert.ToInt16(Reader["UserStatus"].ToString());

					_dtbl.Rows.Add(new object[]
									{
										_userid,
										_name,
										_pwd,
										_contactid,
										strtype,
										strstatus
									});
				}
				Reader.Close();

				return true;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

		public bool InsertData()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Insert Into [User] " +
						  "(" + 
							"UserName, " + 
							"Password, " + 
							"UserType, " +
							"UserStatus, " + 
							"ContactID, " + 
							"CreatedByUserId, " +
							"DateLastLogin, " + 
							"DateCreated, " + 
							"DateLastModified, " + 
							"LastModifiedByUserID) " + 
						  "Values( " +
							"@UserName, " + 
							"@Password, " + 
							"@UserType, " +
							"@UserStatus, " + 
							"@ContactID," +
							"@CreatedByUserId, " +
							"@DateLastLogin, " + 
							"@DateCreated, " +
							"@DateLastModified, " +
							"@LastModifiedByUserID " +
						   ")";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 15));
				com.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@UserType", SqlDbType.Bit));
				com.Parameters.Add(new SqlParameter("@UserStatus", SqlDbType.Bit));
				com.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateLastLogin", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@UserName"].Value = _name;
				com.Parameters["@Password"].Value = _pwd;
				com.Parameters["@UserType"].Value = _typeid;
				com.Parameters["@UserStatus"].Value = _statusid;
				com.Parameters["@ContactID"].Value = _contactid;
				com.Parameters["@CreatedByUserId"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@DateLastLogin"].Value = Scheduler.BusinessLayer.Common.LogonDate;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;

				com.ExecuteNonQuery();

				return true;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

		public bool UpdateData()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Update [User] Set " +
						  "UserName=@UserName, ";
				if(_passwordchanged)
				{
					strSql += "Password=@Password, ";
				}
				strSql += "UserType=@UserType, " +
						  "UserStatus=@UserStatus, " + 
						  "DateLastLogin=@DatelastLogin, " + 
						  "DateLastModified=@DateLastModified, " + 
						  "LastModifiedByUserID=@LastModifiedByUserID " + 
						  "WHERE UserID=@UserID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 15));
				if(_passwordchanged)
				{
					com.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
				}
				com.Parameters.Add(new SqlParameter("@UserType", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@UserStatus", SqlDbType.Bit));
				com.Parameters.Add(new SqlParameter("@DateLastLogin", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@UserID"].Value = _userid;
				com.Parameters["@UserName"].Value = _name;
				if(_passwordchanged)
				{
					com.Parameters["@Password"].Value = _pwd;
				}
				com.Parameters["@UserType"].Value = _typeid;
				com.Parameters["@UserStatus"].Value = _statusid;
				com.Parameters["@DateLastLogin"].Value = Scheduler.BusinessLayer.Common.LogonDate;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;

				com.ExecuteNonQuery();

				return true;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

		public bool DeleteData()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Delete From [User] " +
					"WHERE UserID=@UserID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int));
				com.Parameters["@UserID"].Value = _userid;
				com.ExecuteNonQuery();

				com.CommandText = "Delete from [Contact] Where ContactID=@ContactID";
				com.Parameters.Clear();
				com.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int));
				com.Parameters["@ContactID"].Value = _contactid;
				com.ExecuteNonQuery();

				return true;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

		public bool Exists()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			SqlDataReader Reader=null;
			try
			{
				strSql =  "Select UserID, UserType, UserStatus, Password From [User] " +
						  "Where UserName=@UserName ";
					      //"And Password=@Password ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 15));
				com.Parameters["@UserName"].Value = _name;
				//com.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 15));
				//com.Parameters["@Password"].Value = _pwd;

				Reader = com.ExecuteReader();
				if(Reader.HasRows)
				{
					string pwdencrypted;
					while(Reader.Read())
					{
						pwdencrypted="";
						pwdencrypted = Reader["Password"].ToString();
						if(SimpleHash.Verify(_pwd, pwdencrypted))
						{
							_userid = Convert.ToInt32(Reader["UserID"].ToString());
							_typeid = Convert.ToInt32(Reader["UserType"].ToString());
							_statusid = Convert.ToInt32(Reader["UserStatus"].ToString());

							return true;
						}
					}
				}

				return false;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

		public bool UserExists()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [User] " +
					"WHERE [UserName]=@Name and UserID<>" + _userid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _name;

				object o = com.ExecuteScalar();
				if(Convert.ToInt32(o)>0)
				{
					return true;
				}

				return false;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return false;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
				}
			}
		}

	}

}
