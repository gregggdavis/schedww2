using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsProgram.
	/// </summary>
	public class Program
	{
		public Program()
		{}

		private DataTable _dtbl=null;
		private int _programid=0;
		private string _name="";
        private string _namephonetic="";
		private string _nameromaji="";
		private string _nickname="";
		private int _deptid=0;
		private string _department="";
		private string _description="";
		private string _specialremarks="";
		private string _reportattendence="";
		private int _testinieventid=0;
		private int _testmideventid=0;
		private int _testfinaleventid=0;
		private string _testiniform="";
		private string _testmidform="";
		private string _testfinalform="";
		private string _evalmidform="";
		private string _evalfinalform="";
		private string _questmidform="";
        private string _questfinalform = "";
        private int _programstatus = 0;

		private int _contact1id=0;
		private int _contact2id=0;

		private string _message="";

        private string _billing = "";

		public DataTable ProgramDataTable
		{
			get{return _dtbl;}
			set{_dtbl=value;}
		}
		public int ProgramID
		{
			get{return _programid;}
			set{_programid=value;}
		}
		public string name
		{
			get{return _name;}
			set{_name=value;}
		}
		public string NamePhonetic
		{
			get{return _namephonetic;}
			set{_namephonetic=value;}
		}
		public string NameRomaji
		{
			get{return _nameromaji;}
			set{_nameromaji=value;}
		}
		public string NickName
		{
			get{return _nickname;}
			set{_nickname=value;}
		}
		public int DepartmentID
		{
			get{return _deptid;}
			set{_deptid=value;}
		}
		public int Contact1ID
		{
			get{return _contact1id;}
			set{_contact1id=value;}
		}
		public int Contact2ID
		{
			get{return _contact2id;}
			set{_contact2id=value;}
		}
		public string Department
		{
			get{return _department;}
			set{_department=value;}
		}
		public string Description
		{
			get{return _description;}
			set{_description=value;}
		}
		public string SpecialRemarks
		{
			get{return _specialremarks;}
			set{_specialremarks=value;}
		}
		
		public string ReportAttendence
		{
			get{return _reportattendence;}
			set{_reportattendence=value;}
		}
		public int TestInitialEventID
		{
			get{return _testinieventid;}
			set{_testinieventid=value;}
		}
		public int TestMidEventID
		{
			get{return _testmideventid;}
			set{_testmideventid=value;}
		}
		public int TestFinalEventID
		{
			get{return _testfinaleventid;}
			set{_testfinaleventid=value;}
		}
		
		public string TestInitialForm
		{
			get{return _testiniform;}
			set{_testiniform=value;}
		}
		public string TestMidtermForm
		{
			get{return _testmidform;}
			set{_testmidform=value;}
		}
		public string TestFinalForm
		{
			get{return _testfinalform;}
			set{_testfinalform=value;}
		}
		public string EvaluationMidtermForm
		{
			get{return _evalmidform;}
			set{_evalmidform=value;}
		}
		public string EvaluationFinalForm
		{
			get{return _evalfinalform;}
			set{_evalfinalform=value;}
		}
		public string QuestionaireMidtermForm
		{
			get{return _questmidform;}
			set{_questmidform=value;}
		}
		public string QuestionaireFinalForm
		{
			get{return _questfinalform;}
			set{_questfinalform=value;}
		}
		public int ProgramStatus
		{
			get{return _programstatus;}
			set{_programstatus=value;}
		}
		public string Message
		{
			get{return _message;}
			set{_message=value;}
		}
        public string Billing
        {
            get { return _billing; }
            set { _billing = value; }
        }
        private void BuildDataTable()
		{
			if(_dtbl==null)
			{
				_dtbl=new DataTable();
			}
			_dtbl.Columns.Clear();
			_dtbl.Columns.Add(new DataColumn("ProgramID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("BrowseName", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NamePhonetic", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NameRomaji", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NickName", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("DepartmentID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("Contact1", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Contact2", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Department", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Client", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("SpecialRemarks", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ReportAttendence", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("TestInitialEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestMidtermEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestFinalEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestInitialForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("TestMidtermForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("TestFinalForm", Type.GetType("System.String")));
            _dtbl.Columns.Add(new DataColumn("EvaluationMidtermForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("EvaluationFinalForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("QuestionaireMidtermForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("QuestionaireFinalForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ProgramStatus", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ClientID", Type.GetType("System.Int32")));
            _dtbl.Columns.Add(new DataColumn("Billing", Type.GetType("System.String")));
        }

		public static int CloneData(int programID)
		{
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try
			{
				strSql = "usp_ProgramClone";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.CommandType = CommandType.StoredProcedure;
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("ProgramID", SqlDbType.Int));
				com.Parameters["ProgramID"].Value = programID;
				com.Parameters.Add(new SqlParameter("creatorID", SqlDbType.Int));
				com.Parameters["creatorID"].Value = Common.LogonID;
				com.Parameters.Add(new SqlParameter("insertedID", SqlDbType.Int));
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
			string strClient="";
			SqlDataReader Reader=null;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				if(_programid<=0)
				{
					strSql =  "Select P.*, CASE ";
					strSql += "WHEN P.NickName IS NULL THEN P.Name ";
					strSql += "WHEN P.NickName = '' THEN P.Name ";
					strSql += "ELSE P.NickName ";
                    strSql += "END AS BrowseName,  ";
					strSql += "D.DepartmentID, CASE ";
					strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
					strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
					strSql += "ELSE C.NickName ";
                    strSql += "END AS Department,  ";
					strSql += "CASE ";
					strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
					strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
					strSql += "ELSE C1.NickName ";
                    strSql += "END AS Client,  ";
					strSql += "D.ClientID, ";
					strSql += "CASE ";
					strSql += "WHEN CC1.NickName IS NULL THEN CC1.LastName + ', ' + CC1.FirstName ";
					strSql += "WHEN CC1.NickName = '' THEN CC1.LastName + ', ' + CC1.FirstName ";
					strSql += "ELSE CC1.NickName ";
                    strSql += "END AS Contact1,  ";
					//strSql += "CC2.LastName + ', ' + CC2.FirstName as Contact2 ";
					strSql += "CASE ";
					strSql += "WHEN CC2.NickName IS NULL THEN CC2.LastName + ', ' + CC2.FirstName ";
					strSql += "WHEN CC2.NickName = '' THEN CC2.LastName + ', ' + CC2.FirstName ";
					strSql += "ELSE CC2.NickName ";
                    strSql += "END AS Contact2  ";
					strSql += "From Program P ";
					strSql += "Left Join Department D on (P.DepartmentID=D.DepartmentID) ";
					strSql += "Left Join Contact C on (D.ContactID=C.ContactID) ";
					strSql += "Left Join Contact C1 on (D.ClientID=C1.ContactID) ";
					strSql += "Left Join Contact CC1 on (P.Contact1ID=CC1.ContactID) ";
					strSql += "Left Join Contact CC2 on (P.Contact2ID=CC2.ContactID) ";
					strSql += "Order By BrowseName                                   ";
				}
				else
				{
					strSql =  "Select P.*, CASE ";
					strSql += "WHEN P.NickName IS NULL THEN P.Name ";
					strSql += "WHEN P.NickName = '' THEN P.Name ";
					strSql += "ELSE P.NickName ";
                    strSql += "END AS BrowseName,  ";
					strSql += "D.DepartmentID, CASE ";
					strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
					strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
					strSql += "ELSE C.NickName ";
                    strSql += "END AS Department,  ";
					//strSql += "C1.CompanyName as Client, D.ClientID, ";
					//strSql += "CC1.LastName + ', ' + CC1.FirstName as Contact1, ";
					//strSql += "CC2.LastName + ', ' + CC2.FirstName as Contact2 ";
					strSql += "CASE ";
					strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
					strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
					strSql += "ELSE C1.NickName ";
					strSql += "END AS Client,  ";
					strSql += "D.ClientID, ";
					strSql += "CASE ";
					strSql += "WHEN CC1.NickName IS NULL THEN CC1.LastName + ', ' + CC1.FirstName ";
					strSql += "WHEN CC1.NickName = '' THEN CC1.LastName + ', ' + CC1.FirstName ";
					strSql += "ELSE CC1.NickName ";
                    strSql += "END AS Contact1,  ";
					//strSql += "CC2.LastName + ', ' + CC2.FirstName as Contact2 ";
					strSql += "CASE ";
					strSql += "WHEN CC2.NickName IS NULL THEN CC2.LastName + ', ' + CC2.FirstName ";
					strSql += "WHEN CC2.NickName = '' THEN CC2.LastName + ', ' + CC2.FirstName ";
					strSql += "ELSE CC2.NickName ";
                    strSql += "END AS Contact2  ";
					strSql += "From Program P ";
					strSql += "Left Join Department D on (P.DepartmentID=D.DepartmentID) ";
					strSql += "Left Join Contact C on (D.ContactID=C.ContactID) ";
					strSql += "Left Join Contact C1 on (D.ClientID=C1.ContactID) ";
					strSql += "Left Join Contact CC1 on (P.Contact1ID=CC1.ContactID) ";
					strSql += "Left Join Contact CC2 on (P.Contact2ID=CC2.ContactID) ";
					strSql += "Where P.ProgramID=" + _programid.ToString() +  " ";
				}
			
				BuildDataTable();
			
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				Reader = com.ExecuteReader();
				
				string strstatus="";
				string contact1="";
				string contact2="";
				while(Reader.Read())
				{
					strstatus="";
					contact1="";
					contact2="";

					if(Convert.ToInt16(Reader["ProgramStatus"].ToString())==0)
					{
						strstatus = "Active";
					}
					else
					{
						strstatus = "Inactive";
					}

					_programid = Convert.ToInt32(Reader["ProgramID"].ToString());
					_name = Reader["Name"].ToString();
					_namephonetic = Reader["NamePhonetic"].ToString();
					_nameromaji = Reader["NameRomaji"].ToString();
					_nickname = Reader["NickName"].ToString();
					if(Reader["DepartmentID"]!=System.DBNull.Value)
					{
						_deptid = Convert.ToInt32(Reader["DepartmentID"].ToString());	
					}
					_department = Reader["Department"].ToString();
					if(Reader["Client"]!=System.DBNull.Value)
						strClient = Reader["Client"].ToString();
                    _description = Reader["Description"].ToString();
					_specialremarks = Reader["SpecialRemarks"].ToString();
                    _reportattendence = Reader["ReportAttendence"].ToString();
					_testinieventid = Convert.ToInt32(Reader["TestInitialEventID"].ToString());
					_testmideventid = Convert.ToInt32(Reader["TestMidtermEventID"].ToString());
					_testfinaleventid = Convert.ToInt32(Reader["TestFinalEventID"].ToString());
					_testiniform = Reader["TestInitialForm"].ToString();
					_testmidform = Reader["TestMidtermForm"].ToString();
					_testfinalform = Reader["TestFinalForm"].ToString();
					_evalmidform = Reader["EvaluationMidtermForm"].ToString();
					_evalfinalform = Reader["EvaluationFinalForm"].ToString();
					_questmidform = Reader["QuestionaireMidtermForm"].ToString();
					_questfinalform = Reader["QuestionaireFinalForm"].ToString();
					_programstatus = Convert.ToInt32(Reader["ProgramStatus"].ToString());
                    _billing = Reader["Billing"].ToString();

					if(Reader["Contact1"]!=null)
					{
						contact1 = Reader["Contact1"].ToString();
					}
					if(Reader["Contact2"]!=null)
					{
						contact2 = Reader["Contact2"].ToString();
					}

					_dtbl.Rows.Add(new object[]
		
					{
						Convert.ToInt32(Reader["ProgramID"].ToString()),
						Reader["BrowseName"].ToString(),
						_name,
						_namephonetic,
						_nameromaji,
						_nickname,
						_deptid,
						contact1,
						contact2,
						_department,
						strClient,
						_description,
						_specialremarks,
						_reportattendence,
						Convert.ToInt32(Reader["TestInitialEventID"].ToString()),
						Convert.ToInt32(Reader["TestMidtermEventID"].ToString()),
						Convert.ToInt32(Reader["TestFinalEventID"].ToString()),
						Reader["TestInitialForm"].ToString(),
						Reader["TestMidtermForm"].ToString(),
						Reader["TestFinalForm"].ToString(),
						Reader["EvaluationMidtermForm"].ToString(),
						Reader["EvaluationFinalForm"].ToString(),
						Reader["QuestionaireMidtermForm"].ToString(),
						Reader["QuestionaireFinalForm"].ToString(),
						strstatus,
						Convert.ToInt32(Reader["ClientID"].ToString()),
						Reader["Billing"].ToString()
					});
				}
				Reader.Close();

				/*int deptid=0;
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
				}*/
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
					if(contact2=="")
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
				strSql =  "Insert Into [Program] " +
					"(" + 
					"Name, " +
					"NamePhonetic, " +
					"NameRomaji, " + 
					"NickName, " + 
					"DepartmentID, " +
					"Contact1ID, " +
					"Contact2ID, " +
					"Description, " +
					"SpecialRemarks, " +
					"ReportAttendence, " +
					"TestInitialEventID, " +
					"TestMidtermEventID, " +
					"TestFinalEventID, " +
					"TestInitialForm, " +
					"TestMidtermForm, " +
					"TestFinalForm, " +
					"EvaluationMidtermForm, " +
					"EvaluationFinalForm, " +
					"QuestionaireMidtermForm, " +
					"QuestionaireFinalForm, " +
					"ProgramStatus, " +
                    "CreatedByUserId, " + 
					"DateCreated, " + 
					"DateLastModified, " + 
					"LastModifiedByUserID, " +
                    "Billing) " +
                    "Values( " +
					"@Name, " + 
					"@NamePhonetic, " +
					"@NameRomaji, " + 
					"@NickName, " + 
					"@DepartmentID, " + 
					"@Contact1ID, " +
					"@Contact2ID, " +
					"@Description, " +
					"@SpecialRemarks, " +
					"@ReportAttendence, " + 
					"@TestInitialEventID, " + 
					"@TestMidtermEventID, " + 
					"@TestFinalEventID, " + 
					"@TestInitialForm, " + 
					"@TestMidtermForm, " + 
					"@TestFinalForm, " + 
					"@EvaluationMidtermForm, " + 
					"@EvaluationFinalForm, " + 
					"@QuestionaireMidtermForm, " + 
					"@QuestionaireFinalForm, " +
					"@ProgramStatus, " +
                    "@CreatedByUserId, " + 
					"@DateCreated, " +
					"@DateLastModified, " +
					"@LastModifiedByUserID, " +
                    "@Billing " +
                    ") ";
				strSql += "SELECT @@IDENTITY";


				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Contact1ID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Contact2ID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@SpecialRemarks", SqlDbType.NVarChar));
                com.Parameters.Add(new SqlParameter("@ReportAttendence", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestInitialEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestMidtermEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestFinalEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@EvaluationMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@EvaluationFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@QuestionaireMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@QuestionaireFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ProgramStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@Billing", SqlDbType.NVarChar));

				com.Parameters["@Name"].Value = _name;
				com.Parameters["@NamePhonetic"].Value = _namephonetic;
                com.Parameters["@NameRomaji"].Value = _nameromaji;
                com.Parameters["@NickName"].Value = _nickname;
				com.Parameters["@DepartmentID"].Value = _deptid;
				com.Parameters["@Contact1ID"].Value = _contact1id;
				com.Parameters["@Contact2ID"].Value = _contact2id;
				com.Parameters["@Description"].Value = _description;
				com.Parameters["@SpecialRemarks"].Value = _specialremarks;
				com.Parameters["@ReportAttendence"].Value = _reportattendence;
				com.Parameters["@TestInitialEventID"].Value = _testinieventid;
				com.Parameters["@TestMidtermEventID"].Value = _testmideventid;
				com.Parameters["@TestFinalEventID"].Value = _testfinaleventid;
				com.Parameters["@TestInitialForm"].Value = _testiniform;
				com.Parameters["@TestMidtermForm"].Value = _testmidform;
				com.Parameters["@TestFinalForm"].Value = _testfinalform;
				com.Parameters["@EvaluationMidtermForm"].Value = _evalmidform;
				com.Parameters["@EvaluationFinalForm"].Value = _evalfinalform;
				com.Parameters["@QuestionaireMidtermForm"].Value = _questmidform;
				com.Parameters["@QuestionaireFinalForm"].Value = _questfinalform;
				com.Parameters["@ProgramStatus"].Value = _programstatus;
                com.Parameters["@CreatedByUserId"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;
                com.Parameters["@Billing"].Value = _billing;

				SqlDataReader Reader = com.ExecuteReader();
				if(Reader.Read())
				{
					ProgramID = Convert.ToInt32(Reader[0].ToString());
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
				strSql =  "Update [Program] Set " +
					"Name=@Name, " + 
					"NamePhonetic=@NamePhonetic, " +
					"NameRomaji=@NameRomaji, " +
					"NickName=@NickName, " +
					"DepartmentID=@DepartmentID, " +
					"Contact1ID=@Contact1ID, " +
					"Contact2ID=@Contact2ID, " +
					"Description=@Description, " +
					"SpecialRemarks=@SpecialRemarks, " +
					"ReportAttendence=@ReportAttendence, " +
					"TestInitialEventID=@TestInitialEventID, " +
					"TestMidtermEventID=@TestMidtermEventID, " +
                    "TestFinalEventID=@TestFinalEventID, " +
					"TestInitialForm=@TestInitialForm, " +
					"TestMidtermForm=@TestMidtermForm, " +
					"TestFinalForm=@TestFinalForm, " +
					"EvaluationMidtermForm=@EvaluationMidtermForm, " +
					"EvaluationFinalForm=@EvaluationFinalForm, " +
					"QuestionaireMidtermForm=@QuestionaireMidtermForm, " +
					"QuestionaireFinalForm=@QuestionaireFinalForm, " + 
					"ProgramStatus=@ProgramStatus, " + 
					"DateLastModified=@DateLastModified, " + 
					"LastModifiedByUserID=@LastModifiedByUserID, " +
                    "Billing=@Billing " +
                    "WHERE ProgramId=@ProgramId ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar));				com.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Contact1ID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Contact2ID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@SpecialRemarks", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ReportAttendence", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestInitialEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestMidtermEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestFinalEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@EvaluationMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@EvaluationFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@QuestionaireMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@QuestionaireFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ProgramStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@Billing", SqlDbType.NVarChar));

				com.Parameters["@ProgramID"].Value = _programid;				
				com.Parameters["@Name"].Value = _name;
				com.Parameters["@NamePhonetic"].Value = _namephonetic;
				com.Parameters["@NameRomaji"].Value = _nameromaji;
                com.Parameters["@NickName"].Value = _nickname;
				com.Parameters["@DepartmentID"].Value = _deptid;
				com.Parameters["@Contact1ID"].Value = _contact1id;
				com.Parameters["@Contact2ID"].Value = _contact2id;
				com.Parameters["@Description"].Value = _description;
				com.Parameters["@SpecialRemarks"].Value = _specialremarks;
				com.Parameters["@ReportAttendence"].Value = _reportattendence;
				com.Parameters["@TestInitialEventID"].Value = _testinieventid;
				com.Parameters["@TestMidtermEventID"].Value = _testmideventid;
				com.Parameters["@TestFinalEventID"].Value = _testfinaleventid;
				com.Parameters["@TestInitialForm"].Value = _testiniform;
				com.Parameters["@TestMidtermForm"].Value = _testmidform;
				com.Parameters["@TestFinalForm"].Value = _testfinalform;
				com.Parameters["@EvaluationMidtermForm"].Value = _evalmidform;
				com.Parameters["@EvaluationFinalForm"].Value = _evalfinalform;
				com.Parameters["@QuestionaireMidtermForm"].Value = _questmidform;
				com.Parameters["@QuestionaireFinalForm"].Value = _questfinalform;
				com.Parameters["@ProgramStatus"].Value = _programstatus;
                com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;
                com.Parameters["@Billing"].Value = _billing;

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
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters["@ProgramID"].Value = _programid;

				//Test Initial Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestInitialEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestInitialEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				//Test MidTerm Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestMidTermEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestMidTermEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				//Test Final Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestFinalEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestFinalEventID From [Program] " +
					"WHERE ProgramID=@ProgramID)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();
				
				
				strSql =  "Delete From [Program] " +
					"WHERE ProgramID=@ProgramID ";
				com.CommandText = strSql;
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
			try
			{
				strSql =  "Select Count(*) From [Program] " +
					"WHERE [Name]=@Name and DepartmentID=@DepartmentID and ProgramID<>" + _programid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _name;
				com.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int));
				com.Parameters["@DepartmentID"].Value = _deptid;

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

		public bool NickNameExists()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Program] " +
					"WHERE [NickName]=@Name and DepartmentID=@DepartmentID and ProgramID<>" + _programid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _nickname;
				com.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int));
				com.Parameters["@DepartmentID"].Value = _deptid;

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

		/*public string getEventText(string eventid, string eType)
		{
			if(eventid=="0") 
			{
				return "None";
			}
			string Result="";
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select StartDateTime From [CalendarEvent] ";
				strSql += "WHERE EventID=@EventID";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters["@EventID"].Value = eventid;

				object o = com.ExecuteScalar();
				if(o==null) return "None";
				Result = Convert.ToDateTime(o).ToShortDateString() + " " + Convert.ToDateTime(o).ToShortTimeString();

				return Result;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return "";
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

		public string getEventText(string eventid, string eType, ref string rectext)
		{
			if(eventid=="0") 
			{
				return "None";
			}
			string Result="";
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			SqlDataReader Reader=null;

			DateTime dtStart=Convert.ToDateTime(null);
			DateTime dtEnd=Convert.ToDateTime(null);

			try
			{
				strSql =  "Select StartDateTime, EndDateTime From [CalendarEvent] ";
				strSql += "WHERE EventID=@EventID";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters["@EventID"].Value = eventid;

				Reader=com.ExecuteReader();
				if(Reader.Read())
				{
					if(Reader["StartDateTime"]==System.DBNull.Value)
					{
						Reader.Close();
						return "None";
					}

					dtStart = Convert.ToDateTime(Reader["StartDateTime"].ToString());
					dtEnd = Convert.ToDateTime(Reader["EndDateTime"].ToString());
				}
				Reader.Close();
				Result = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString();

				Result+= " - " + dtEnd.ToShortDateString() + " " + dtEnd.ToShortTimeString();
				if(Result.IndexOf("(")>0)
				{
					Result = Result.Substring(0, Result.IndexOf("(")+1);
				}

				strSql =  "Select RecurrenceText From [Event] ";
				strSql += "WHERE EventID=@EventID";
				com.CommandText=strSql;
				Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					rectext = Reader["RecurrenceText"].ToString();
				}
				Reader.Close();
				
				return Result;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return "";
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

        /// <summary>
        /// Loads Test Events for a Program.
        /// </summary>
        /// <returns>A DataTable populated with information about each of those test events.</returns>
        public DataTable LoadTestEvents()
        {
            string strSql = "";
            SqlDataReader Reader = null;
            SqlCommand com = null;
            Connection con = null;

            try
            {
                _dtbl = new DataTable();
                con = new Connection();
                con.Connect();
                
                strSql = "Select TestInitialEventId,TestMidtermEventId,TestFinalEventId from [Program] WHERE ProgramId=@ProgramId";
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@ProgramId", SqlDbType.Int));
                com.Parameters["@ProgramId"].Value = _programid;
                Reader = com.ExecuteReader();

                string[] temp = new string[3];
                Reader.Read();
                temp[0] = Reader[0].ToString();
                temp[1] = Reader[1].ToString();
                temp[2] = Reader[2].ToString();
                Reader.Close();

                string temp2 = "";
                if (temp[0] != null && temp[0] != "")
                    temp2 = temp[0];
                if (temp[1] != null && temp[1] != "")
                    temp2 += "," + temp[1];
                if (temp[2] != null && temp[2] != "")
                    temp2 += "," + temp[2];

                strSql = "SELECT * from [CalendarEvent] WHERE EventType LIKE 'Test%' AND EventId IN (" + temp2 + ");";
                com.CommandText = strSql;
                Reader = com.ExecuteReader();

                if (Reader.HasRows)
                    _dtbl.Load(Reader);

                Reader.Close();

                return _dtbl;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return null;
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

        /// <summary>
        /// Checks whether Test Initial, Mid or Final are set for a Program or not.
        /// </summary>
        /// <returns>A boolean array with Test Event Ids or 0 if no events exist.</returns>
        public bool[] CheckTestEvents()
        {
            string strSql = "";
            SqlDataReader Reader = null;
            SqlCommand com = null;
            Connection con = null;

            try
            {
                strSql = "Select TestInitialEventId,TestMidtermEventId,TestFinalEventId from [Program] WHERE ProgramId=@ProgramId;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@ProgramId", SqlDbType.Int));
                com.Parameters["@ProgramId"].Value = _programid;
                Reader = com.ExecuteReader();

                string[] temp = new string[3];
                bool[] boolArray = { false, false, false };
                Reader.Read();
                temp[0] = Reader[0].ToString();
                temp[1] = Reader[1].ToString();
                temp[2] = Reader[2].ToString();
                Reader.Close();

                if (temp[0] != null && temp[0] != "" && temp[0] != "0")
                    boolArray[0] = true;
                if (temp[1] != null && temp[1] != "" && temp[1] != "0")
                    boolArray[1] = true;
                if (temp[2] != null && temp[2] != "" && temp[2] != "0")
                    boolArray[2] = true;

                return boolArray;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return null;
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
