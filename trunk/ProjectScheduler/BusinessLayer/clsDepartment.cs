using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsUser.
	/// </summary>
	public class Department
	{
		public Department()
		{
		}

		private DataTable _dtbl=null;
		private int _deptid=0;
		private int _contactid=0;
		private string _contactname="";
		private int _clientid=0;
		private string _clientname="";
		private int _statusid=0;
		private string _message="";

		public DataTable DeptDataTable
		{
			get{return _dtbl;}
			set{_dtbl=value;}
		}
		public int DeptID
		{
			get{return _deptid;}
			set{_deptid=value;}
		}
		public int ContactID
		{
			get{return _contactid;}
			set{_contactid=value;}
		}
		public string ContactName
		{
			get{return _contactname;}
			set{_contactname=value;}
		}
		public int ClientID
		{
			get{return _clientid;}
			set{_clientid=value;}
		}
		public string ClientName
		{
			get{return _clientname;}
			set{_clientname=value;}
		}
		public int StatusID
		{
			get{return _statusid;}
			set{_statusid=value;}
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
			_dtbl.Columns.Add(new DataColumn("DepartmentID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ContactID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("Contact", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ClientID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("Client", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Contact1", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Contact2", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("DepartmentStatus", Type.GetType("System.String")));
		}

		public static int[] CloneData(int departmentID)
		{
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try
			{
				strSql = "usp_DepartmentClone";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.CommandType = CommandType.StoredProcedure;
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("DepartmentID", SqlDbType.Int));
				com.Parameters["DepartmentID"].Value = departmentID;
				com.Parameters.Add(new SqlParameter("creatorID", SqlDbType.Int));
				com.Parameters["creatorID"].Value = Common.LogonID;
				com.Parameters.Add(new SqlParameter("insertedID", SqlDbType.Int));
				com.Parameters["insertedID"].Direction = ParameterDirection.Output;
                com.Parameters.Add(new SqlParameter("out_newcontactID", SqlDbType.Int));
                com.Parameters["out_newcontactID"].Direction = ParameterDirection.Output;

				com.ExecuteNonQuery();
                int[] array = new int[2];
				array[0]=(int)com.Parameters["insertedID"].Value;
                array[1] = (int)com.Parameters["out_newcontactID"].Value;

                return array;
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
				if(_deptid<=0)
				{
					strSql = "select D.*, ";
					strSql += "C.NickName, C.ContactID As ContactID, C.LastName + ', ' + C.FirstName As Contact, ";
					strSql += "C.TitleForName, CompanyName = CASE ";
					strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
					strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
					strSql += "ELSE C.NickName ";
					strSql += "END,  ";
					strSql += "C1.ContactID As ClientID, Client = CASE ";
					strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
					strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
					strSql += "ELSE C1.NickName ";
					strSql += "END  ";
					strSql += "From Department D ";
					strSql += "Left Join Contact C on(D.ContactID=C.ContactID) ";
					strSql += "Left Join Contact C1 on(D.ClientID=C1.ContactID) ";
					strSql += "Order By D.DepartmentID ";
				}
				else
				{
					strSql = "select D.*, ";
					strSql += "C.NickName, C.ContactID As ContactID, C.LastName + ', ' + C.FirstName As Contact, ";
					strSql += "C.TitleForName, CompanyName = CASE ";
					strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
					strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
					strSql += "ELSE C.NickName ";
					strSql += "END,  ";
					strSql += "C1.ContactID As ClientID, Client = CASE ";
					strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
					strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
					strSql += "ELSE C1.NickName ";
					strSql += "END  ";
					strSql += "From Department D ";
					strSql += "Left Join Contact C on(D.ContactID=C.ContactID) ";
					strSql += "Left Join Contact C1 on(D.ClientID=C1.ContactID) ";
					strSql += "Where D.DepartmentID=" + _deptid.ToString() + " ";
				}
			
				BuildDataTable();
			
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				Reader = com.ExecuteReader();
				
				string strstatus;
				string strcompname;
				while(Reader.Read())
				{
					strstatus="";
					strcompname="";

					//company
					if(Reader["NickName"].ToString()!="")
					{
						strcompname = Reader["NickName"].ToString() + " ";
					}
					else
					{
						if(Reader["TitleForName"].ToString()!="")
							strcompname = Reader["TitleForName"].ToString() + " ";
						if(Reader["CompanyName"].ToString()!="")
							strcompname += Reader["CompanyName"].ToString();
					}

					strcompname=strcompname.Trim();

					//status
					if(Convert.ToInt16(Reader["DepartmentStatus"].ToString())==0)
					{
						strstatus = "Active";
					}
					else
					{
						strstatus = "Inactive";
					}

					_deptid = Convert.ToInt32(Reader["DepartmentID"].ToString());
					_contactid = Convert.ToInt32(Reader["ContactID"].ToString());
					_contactname = Reader["Contact"].ToString();
					_clientid = Convert.ToInt32(Reader["ClientID"].ToString());
					_clientname = Reader["Client"].ToString();
					_statusid = Convert.ToInt16(Reader["DepartmentStatus"].ToString());

					_dtbl.Rows.Add(new object[]
									{
										_deptid,
										strcompname,
										_contactid,
										_contactname,
										_clientid,
										_clientname,
										"",
										"",
										strstatus
									});
				}
				Reader.Close();

				//Get the contacts
				int deptid=0;
				string contact1="";
				string contact2="";
				foreach(DataRow dr in _dtbl.Rows)
				{
					deptid=0;
					contact1="";
					contact2="";
					deptid=Convert.ToInt32(dr["DepartmentID"].ToString());				
					GetContact(deptid, ref contact1, ref contact2);
					dr["Contact1"] = contact1;
					dr["Contact2"] = contact2;
					dr.AcceptChanges();
				}
				
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

		private bool GetContact(int mdeptid, ref string contact1, ref string contact2)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Top 2 LastName + ', ' + FirstName As ContactName From Contact Where ContactType=5 AND RefID=" + mdeptid.ToString() + " Order by ContactID";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				SqlDataReader Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					if(contact1=="")
						contact1 = Reader["ContactName"].ToString();
					else
						contact2 = Reader["ContactName"].ToString();
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
				strSql =  "Insert Into [Department] " +
					"(" + 
					"ContactID, " +
                    "ClientID, " +
					"DepartmentStatus, " + 
					"CreatedByUserId, " + 
					"DateCreated, " + 
					"DateLastModified, " + 
					"LastModifiedByUserID) " + 
					"Values( " +
					"@contactid, " + 
					"@clientid, " +
					"@DepartmentStatus, " + 
					"@CreatedByUserId, " + 
					"@DateCreated, " +
					"@DateLastModified, " +
					"@LastModifiedByUserID " +
					") SELECT @@IDENTITY";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DepartmentStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@ContactId"].Value = _contactid;
				com.Parameters["@ClientId"].Value = _clientid;
				com.Parameters["@DepartmentStatus"].Value = _statusid;
				com.Parameters["@CreatedByUserId"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;

				SqlDataReader Reader = com.ExecuteReader();
				if(Reader.Read())
				{
					_deptid = Convert.ToInt32(Reader[0].ToString());
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
				strSql =  "Update [Department] Set " +
					"ContactId=@ContactId, " + 
					"ClientId=@ClientId, " +
                    "DepartmentStatus=@DepartmentStatus, " + 
					"DateLastModified=@DateLastModified, " + 
					"LastModifiedByUserID=@LastModifiedByUserID " + 
					"WHERE DepartmentId=@DepartmentId ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DepartmentStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@DepartmentId"].Value = _deptid;
				com.Parameters["@ContactId"].Value = _contactid;
				com.Parameters["@ClientId"].Value = _clientid;
				com.Parameters["@DepartmentStatus"].Value = _statusid;
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
				strSql =  "Delete From [Department] " +
					"WHERE DepartmentID=@DepartmentID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int));
				com.Parameters["@DepartmentID"].Value = _deptid;
				com.ExecuteNonQuery();

				strSql = "Delete from contact where RefID=@DepartmentID AND ContactType=5";
				com.Parameters["@DepartmentID"].Value = _deptid;
				com.CommandText=strSql;
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

		/*public bool Exists()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Department] " +
					"WHERE [Name]=@Name ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _deptname;

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
		}*/
		
	}

}
