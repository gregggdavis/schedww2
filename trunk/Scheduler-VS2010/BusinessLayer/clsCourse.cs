using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsUser.
	/// </summary>
	public class Course
	{
		public Course()
		{
        }
        #region Declarations

        private DataTable _dtbl=null;
		private int _courseid=0;
		private string _name="";
		private string _namephonetic="";
		private string _nameromaji="";
		private string _nickname="";
		private int _programid=0;
		private string _program="";
		private string _description="";
		private string _specialremarks="";
		private string _coursetype="";
		private string _curriculam="";
		private int _numberstudents=0;
		private int _homeworkminutes=0;
		private int _eventid=0;
		private int _testinieventid=0;
		private int _testmideventid=0;
		private int _testfinaleventid=0;
		private string _testiniform="";
		private string _testmidform="";
		private string _testfinalform="";
		private int _coursestatus=0;
		private string _message="";
        #endregion

        #region Properties
        public DataTable CourseDataTable
		{
			get{return _dtbl;}
			set{_dtbl=value;}
		}
        public int CourseId
		{
			get{return _courseid;}
			set{_courseid=value;}
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
		public int ProgramID
		{
			get{return _programid;}
			set{_programid=value;}
		}
		public string Program
		{
			get{return _program;}
			set{_program=value;}
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
		public string CourseType
		{
			get{return _coursetype;}
			set{_coursetype=value;}
		}
		public string Curriculam
		{
			get{return _curriculam;}
			set{_curriculam=value;}
		}
		public int NumberStudents
		{
			get{return _numberstudents;}
			set{_numberstudents=value;}
		}
		public int HomeWorkMinutes
		{
			get{return _homeworkminutes;}
			set{_homeworkminutes=value;}
		}
		public int EventID
		{
			get{return _eventid;}
			set{_eventid=value;}
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
		public int CourseStatus
		{
			get{return _coursestatus;}
			set{_coursestatus=value;}
		}
		public string Message
		{
			get{return _message;}
			set{_message=value;}
        }

        #endregion
        private void BuildDataTable()
		{
			if(_dtbl==null)
			{
				_dtbl=new DataTable();
			}
			_dtbl.Columns.Clear();
            _dtbl.Columns.Add(new DataColumn("CourseId", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("BrowseName", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NamePhonetic", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NameRomaji", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NickName", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("ProgramID", Type.GetType("System.Int32")));			
			_dtbl.Columns.Add(new DataColumn("Program", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Client", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Department", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("CourseType", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("SpecialRemarks", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Curriculam", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NumberStudents", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("HomeWorkMinutes", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("EventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestInitialEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestMidtermEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestFinalEventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("TestInitialForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("TestMidtermForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("TestFinalForm", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("CourseStatus", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("EventStartDateTime", Type.GetType("System.DateTime")));
            _dtbl.Columns.Add(new DataColumn("EventEndDateTime", Type.GetType("System.DateTime")));
            _dtbl.Columns.Add(new DataColumn("OccurrenceCount", Type.GetType("System.String")));
            _dtbl.Columns.Add(new DataColumn("ScheduledInstructor", Type.GetType("System.String")));
		}

        public static int CloneData(int CourseId)
		{
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try
			{
				strSql = "usp_CourseClone";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.CommandType = CommandType.StoredProcedure;
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

                com.Parameters.Add(new SqlParameter("CourseId", SqlDbType.Int));
                com.Parameters["CourseId"].Value = CourseId;
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
			SqlDataReader Reader=null;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				if(_courseid<=0)
				{
					strSql += "Select C.*, BrowseName = CASE " +
						"WHEN C.NickName IS NULL THEN C.Name " +
						"WHEN C.NickName = '' THEN C.Name " +
						"ELSE C.NickName " +
						"END,  " +
						"P.ProgramID, " +
						"Program = CASE " +
						"WHEN P.NickName IS NULL THEN P.Name " +
						"WHEN P.NickName = '' THEN P.Name " +
						"ELSE P.NickName " +
						"END,  " +
						"Department = CASE " +
						"WHEN CO.NickName IS NULL THEN CO.CompanyName " +
						"WHEN CO.NickName = '' THEN CO.CompanyName " +
						"ELSE CO.NickName " +
						"END,  " +
						"Client = CASE " + 
						"WHEN CO1.NickName IS NULL THEN CO1.CompanyName " +
						"WHEN CO1.NickName = '' THEN CO1.CompanyName " +
						"ELSE CO1.NickName " +
						"END  " +
						"from Course C " +
						"Left Join Program P on (C.ProgramID=P.ProgramID) " +
						"Left Join Department D on (P.DepartmentID=D.DepartmentID) " +
						"Left Join Contact CO on (D.ContactID=CO.ContactID) " +
						"Left Join Contact CO1 on (D.ClientID=CO1.ContactID) " +
                        "Order By C.BrowseName ";
				}
				else
				{
					strSql += "Select C.*, BrowseName = CASE " +
						"WHEN C.NickName IS NULL THEN C.Name " +
						"WHEN C.NickName = '' THEN C.Name " +
						"ELSE C.NickName " +
						"END,  " +
						"P.ProgramID, " +
						"P.NickName, Program = CASE " +
						"WHEN P.NickName IS NULL THEN P.Name " +
						"WHEN P.NickName = '' THEN P.Name " +
						"ELSE P.NickName " +
						"END,  " +
						"Department = CASE " +
						"WHEN CO.NickName IS NULL THEN CO.CompanyName " +
						"WHEN CO.NickName = '' THEN CO.CompanyName " +
						"ELSE CO.NickName " +
						"END,  " +
						"Client = CASE " + 
						"WHEN CO1.NickName IS NULL THEN CO1.CompanyName " +
						"WHEN CO1.NickName = '' THEN CO1.CompanyName " +
						"ELSE CO1.NickName " +
						"END  " +
						"from Course C " +
						"Left Join Program P on (C.ProgramID=P.ProgramID) " +
						"Left Join Department D on (P.DepartmentID=D.DepartmentID) " +
						"Left Join Contact CO on (D.ContactID=CO.ContactID) " +
						"Left Join Contact CO1 on (D.ClientID=CO1.ContactID) " +
                        "Where C.CourseId=" + _courseid.ToString() + " ";
				}
			
				BuildDataTable();
			
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;
				Reader = com.ExecuteReader();
				
				string strstatus="";
				while(Reader.Read())
				{
					strstatus="";

					if(Convert.ToInt16(Reader["CourseStatus"].ToString())==0)
					{
						strstatus = "Active";
					}
					else
					{
						strstatus = "Inactive";
					}

                    _courseid = Convert.ToInt32(Reader["CourseId"].ToString());
					_name = Reader["Name"].ToString();
					_namephonetic = Reader["NamePhonetic"].ToString();
					_nameromaji = Reader["NameRomaji"].ToString();
					if(Reader["ProgramID"]!=System.DBNull.Value)
					{
						_programid = Convert.ToInt32(Reader["ProgramID"].ToString());	
					}
					_program = Reader["Program"].ToString();
					_nickname = Reader["NickName"].ToString();
					_description = Reader["Description"].ToString();
					_coursetype = Reader["CourseType"].ToString();
					_specialremarks = Reader["SpecialRemarks"].ToString();
					_curriculam = Reader["Curriculam"].ToString();
					_numberstudents = Convert.ToInt32(Reader["NumberStudents"].ToString());
					_homeworkminutes = Convert.ToInt32(Reader["HomeWorkMinutes"].ToString());
					_eventid = Convert.ToInt32(Reader["EventID"].ToString());
					_testinieventid = Convert.ToInt32(Reader["TestInitialEventID"].ToString());
					_testmideventid = Convert.ToInt32(Reader["TestMidtermEventID"].ToString());
					_testfinaleventid = Convert.ToInt32(Reader["TestFinalEventID"].ToString());
					_testiniform = Reader["TestInitialForm"].ToString();
					_testmidform = Reader["TestMidtermForm"].ToString();
					_testfinalform = Reader["TestFinalForm"].ToString();
					_coursestatus = Convert.ToInt32(Reader["CourseStatus"].ToString());

					_dtbl.Rows.Add(new object[]
		
					{
						_courseid,
						Reader["BrowseName"].ToString(),
						_name,
						_namephonetic,
						_nameromaji,
						_nickname,
						_programid,
						_program,
						Reader["Client"].ToString(),
						Reader["Department"].ToString(),
						_description,
						_coursetype,
						_specialremarks,
						_curriculam,
						_numberstudents,
						_homeworkminutes,
						_eventid,
						_testinieventid,
						_testmideventid,
						_testfinaleventid,
						Reader["TestInitialForm"].ToString(),
						Reader["TestMidtermForm"].ToString(),
						Reader["TestFinalForm"].ToString(),
						strstatus
					});
				}
				Reader.Close();

				int intEID=0;
				string startdate="", enddate="";
                string instructorName = "";
				foreach(DataRow dr in _dtbl.Rows)
				{
					intEID = Convert.ToInt32(dr["EventID"].ToString()); 

					//getEventText(intEID, ref startdate, ref enddate);
					startdate = getEventText(intEID, true,true,ref instructorName);
					enddate = getEventText(intEID, false);

					dr["EventStartDateTime"] = startdate;
					dr["EventEndDateTime"] = enddate;
                    dr["OccurrenceCount"] = getOccurrenceCount(intEID);
                    dr["ScheduledInstructor"] = instructorName;
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
        //ViewClassEventsN
        public bool LoadDataN()
        {
            string strSql = "select * From ViewClassEventsN ";
            SqlDataReader Reader = null;
            SqlCommand com = null;
            Connection con = null;
            try
            {
                /*
                if (_courseid <= 0)
                {
                    strSql +=  " Order By BrowseName ";
                }
                else
                {
                    strSql += String.Format(" Where C.CourseId= {0} ", _courseid);
                }
                */

                BuildDataTable();

                /*
                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = strSql;
                Reader = com.ExecuteReader();
                */
///*
                strSql = "SpClassEventsN";

                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con.SQLCon;
                com.CommandText = strSql;
                Reader = com.ExecuteReader();
//*/





                _dtbl.Load(Reader, LoadOption.OverwriteChanges);
                return true;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return false;
            }
            finally
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                    con.DisConnect();
                }
            }
        }
        //Loads Other Events (Events with 'EventType' fields set to anything but ZERO.
        /* Event Type Field Values:
         * 'Class' =  Repeating or Single Occurence
         * 'Test Initial', 'Test Mid', 'Test Final', 'Extra Class'
         */
        public DataTable LoadOtherEvents(bool IsRecurring)
        {
            string strSql = "";
            SqlDataReader Reader = null;
            SqlCommand com = null;
            Connection con = null;

            try
            {
                //Here we need to make sure that we use different commands for selecting Tests and Extra Classes
                //because extra classes only exist for repeating class events and NOT single occuring class events!

                //Loading Positive Exceptions first
                _dtbl = new DataTable();
                /*
                strSql = "Select Count(*) from Event WHERE RecurrenceText IS NOT NULL AND EventId=" + _eventid + ";";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                int result = (int)com.ExecuteScalar();
                */
                con = new Connection();
                con.Connect();
                //Means the class event exists and class reocurrs alright
                if (_eventid > 0 && IsRecurring)
                {
                    strSql = "Select * from [CalendarEvent] WHERE EventId=" + _eventid + " AND EventType='Extra Class';";
                    com = new SqlCommand(strSql, con.SQLCon);
                    Reader = com.ExecuteReader();
                    if (Reader.HasRows)
                        _dtbl.Load(Reader);
                    Reader.Close();
                }

                //Now, Loading the Test Events (if any)
                strSql = "Select TestInitialEventId,TestMidtermEventId,TestFinalEventId from [Course] WHERE CourseId=@CourseId";
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
                com.Parameters["@CourseId"].Value = _courseid;
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
                //com = new SqlCommand(strSql, con.SQLCon);
                com.CommandText = strSql;
                Reader = com.ExecuteReader();

                if (Reader.HasRows)
                {
                    if (_dtbl.Rows.Count==0) _dtbl.Load(Reader);
                    else
                    {
                        DataTable _temp = new DataTable();
                        _temp.Load(Reader);
                        _dtbl.Merge(_temp);
                    }
                }

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

		public bool InsertData()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Insert Into [Course] " +
					"(" + 
					"Name, " +
					"NamePhonetic, " +
					"NameRomaji, " + 
					"NickName, " + 
					"ProgramID, " +
					"EventID, " +
					"Description, " +
					"SpecialRemarks, " +
					"CourseType, " +
					"Curriculam, " +
					"NumberStudents, " +
					"HomeWorkMinutes, " +
					"TestInitialEventID, " +
					"TestMidtermEventID, " +
					"TestFinalEventID, " +
					"TestInitialForm, " +
					"TestMidtermForm, " +
					"TestFinalForm, " +
					"CourseStatus, " +
					"CreatedByUserId, " + 
					"DateCreated, " + 
					"DateLastModified, " + 
					"LastModifiedByUserID) " + 
					"Values( " +
					"@Name, " + 
					"@NamePhonetic, " +
					"@NameRomaji, " + 
					"@NickName, " + 
					"@ProgramID, " + 
					"@EventID, " +
					"@Description, " +
					"@SpecialRemarks, " +
					"@CourseType, " +
					"@Curriculam, " +
					"@NumberStudents, " +
					"@HomeWorkMinutes, " +
					"@TestInitialEventID, " + 
					"@TestMidtermEventID, " + 
					"@TestFinalEventID, " + 
					"@TestInitialForm, " + 
					"@TestMidtermForm, " + 
					"@TestFinalForm, " + 
					"@CourseStatus, " +
					"@CreatedByUserId, " + 
					"@DateCreated, " +
					"@DateLastModified, " +
					"@LastModifiedByUserID " +
					")";
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
				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@SpecialRemarks", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CourseType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Curriculam", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NumberStudents", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@HomeWorkMinutes", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestMidtermEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestFinalEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CourseStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@Name"].Value = _name;
				com.Parameters["@NamePhonetic"].Value = _namephonetic;
				com.Parameters["@NameRomaji"].Value = _nameromaji;
				com.Parameters["@NickName"].Value = _nickname;
				com.Parameters["@ProgramID"].Value = _programid;
				com.Parameters["@EventID"].Value = _eventid;
				com.Parameters["@Description"].Value = _description;
				com.Parameters["@SpecialRemarks"].Value = _specialremarks;
				com.Parameters["@CourseType"].Value = _coursetype;
				com.Parameters["@Curriculam"].Value = _curriculam;
				com.Parameters["@NumberStudents"].Value = _numberstudents;
				com.Parameters["@HomeWorkMinutes"].Value = _homeworkminutes;
				com.Parameters["@TestInitialEventID"].Value = _testinieventid;
				com.Parameters["@TestMidtermEventID"].Value = _testmideventid;
				com.Parameters["@TestFinalEventID"].Value = _testfinaleventid;
				com.Parameters["@TestInitialForm"].Value = _testiniform;
				com.Parameters["@TestMidtermForm"].Value = _testmidform;
				com.Parameters["@TestFinalForm"].Value = _testfinalform;
				com.Parameters["@CourseStatus"].Value = _coursestatus;
				com.Parameters["@CreatedByUserId"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;

				SqlDataReader Reader = com.ExecuteReader();
				if(Reader.Read())
				{
                    CourseId = Convert.ToInt32(Reader[0].ToString());
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
				strSql =  "Update [Course] Set " +
					"Name=@Name, " + 
					"NamePhonetic=@NamePhonetic, " +
					"NameRomaji=@NameRomaji, " +
					"NickName=@NickName, " +
					"ProgramID=@ProgramID, " +
					"EventID=@EventID, " +
					"Description=@Description, " +
					"SpecialRemarks=@SpecialRemarks, " +
					"CourseType=@CourseType, " +
					"Curriculam=@Curriculam, " +
					"NumberStudents=@NumberStudents, " +
					"HomeWorkMinutes=@HomeWorkMinutes, " +
					"TestInitialEventID=@TestInitialEventID, " +
					"TestMidtermEventID=@TestMidtermEventID, " +
					"TestFinalEventID=@TestFinalEventID, " +
					"TestInitialForm=@TestInitialForm, " +
					"TestMidtermForm=@TestMidtermForm, " +
					"TestFinalForm=@TestFinalForm, " +
					"CourseStatus=@CourseStatus, " + 
					"DateLastModified=@DateLastModified, " + 
					"LastModifiedByUserID=@LastModifiedByUserID " +
                    "WHERE CourseId=@CourseId ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

                com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));				
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@SpecialRemarks", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CourseType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Curriculam", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NumberStudents", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@HomeWorkMinutes", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestMidtermEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestFinalEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@TestInitialForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestMidtermForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TestFinalForm", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CourseStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

                com.Parameters["@CourseId"].Value = _courseid;				
				com.Parameters["@Name"].Value = _name;
				com.Parameters["@NamePhonetic"].Value = _namephonetic;
				com.Parameters["@NameRomaji"].Value = _nameromaji;
				com.Parameters["@NickName"].Value = _nickname;
				com.Parameters["@ProgramID"].Value = _programid;
				com.Parameters["@EventID"].Value = _eventid;
				com.Parameters["@Description"].Value = _description;
				com.Parameters["@SpecialRemarks"].Value = _specialremarks;
				com.Parameters["@CourseType"].Value = _coursetype;
				com.Parameters["@Curriculam"].Value = _curriculam;
				com.Parameters["@NumberStudents"].Value = _numberstudents;
				com.Parameters["@HomeWorkMinutes"].Value = _homeworkminutes;
				com.Parameters["@TestInitialEventID"].Value = _testinieventid;
				com.Parameters["@TestMidtermEventID"].Value = _testmideventid;
				com.Parameters["@TestFinalEventID"].Value = _testfinaleventid;
				com.Parameters["@TestInitialForm"].Value = _testiniform;
				com.Parameters["@TestMidtermForm"].Value = _testmidform;
				com.Parameters["@TestFinalForm"].Value = _testfinalform;
				com.Parameters["@CourseStatus"].Value = _coursestatus;
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

                com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
                com.Parameters["@CourseId"].Value = _courseid;


				//Test Initial Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestInitialEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestInitialEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				//Test MidTerm Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestMidTermEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestMidTermEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				//Test Final Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select TestFinalEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select TestFinalEventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				//Event ID
				strSql =  "Delete From [Event] " +
					"WHERE EventID IN (Select EventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [CalendarEvent] " +
					"WHERE EventID IN (Select EventID From [Course] " +
                    "WHERE CourseId=@CourseId)  ";
				com.CommandText=strSql;
				com.ExecuteNonQuery();

				strSql =  "Delete From [Course] " +
                    "WHERE CourseId=@CourseId ";
				com.CommandText=strSql;
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
				strSql =  "Select Count(*) From [Course] " +
                    "WHERE [Name]=@Name and ProgramID=@ProgramID and CourseId<>" + _courseid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _name;
				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters["@ProgramID"].Value = _programid;

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
				strSql =  "Select Count(*) From [Course] " +
                    "WHERE [NickName]=@Name and ProgramID=@ProgramID and CourseId<>" + _courseid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters["@Name"].Value = _nickname;
				com.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int));
				com.Parameters["@ProgramID"].Value = _programid;

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

		public string getEventText(string eventid, string eType, ref string rectext)
		{
			if(eventid=="0") 
				return "None";

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
				bool IsRecord=false;
				if(Reader.Read())
				{
					IsRecord=true;
					if(Reader["StartDateTime"]==System.DBNull.Value)
					{
						Reader.Close();
						return "None";
					}

					dtStart = Convert.ToDateTime(Reader["StartDateTime"].ToString());
					dtEnd = Convert.ToDateTime(Reader["EndDateTime"].ToString());
				}
				Reader.Close();

				if(IsRecord)
				{
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
				}
				else Result="None";
				
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
		
		public string getEventText(int eventid, bool Start)
		{
			string startdate="", enddate="";
			string Result="";
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			SqlDataReader Reader=null;

			DateTime dtStart=Convert.ToDateTime(null);
			DateTime dtEnd=Convert.ToDateTime(null);

			if(Start)
				dtStart=Convert.ToDateTime(null);
			else
				dtEnd=Convert.ToDateTime(null);

			try
			{
				if(Start)
				{
					strSql =  "Select Top 1 StartDateTime,ScheduledTeacherID From [CalendarEvent] ";
					strSql += "WHERE EventID=@EventID Order By CalendarEventID";
				}
				else
				{
					strSql =  "Select Top 1 EndDateTime From [CalendarEvent] ";
					strSql += "WHERE EventID=@EventID Order by CalendarEventID DESC";
				}

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters["@EventID"].Value = eventid;

				Reader=com.ExecuteReader();
				bool IsRecord=false;
				if(Reader.Read())
				{
					IsRecord=true;
					if(Start)
					{
						if(Reader["StartDateTime"]!=System.DBNull.Value)
						{
							dtStart = Convert.ToDateTime(Reader["StartDateTime"].ToString());
						}
					}
					else
					{
						if(Reader["EndDateTime"]!=System.DBNull.Value)
						{
							dtEnd = Convert.ToDateTime(Reader["EndDateTime"].ToString());
						}
					}
				}
				Reader.Close();
				if(IsRecord) 
				{
					if(Start)
					{
						if(dtStart!=Convert.ToDateTime(null))
						{
							Result = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString();
							if(Result.IndexOf("(")>0)
							{
								Result = Result.Substring(0, Result.IndexOf("(")+1);
							}
							startdate = Result;
						}
					}
					else
					{
						if(dtEnd!=Convert.ToDateTime(null))
						{
							Result = dtEnd.ToShortDateString() + " " + dtEnd.ToShortTimeString();
							if(Result.IndexOf("(")>0)
							{
								Result = Result.Substring(0, Result.IndexOf("(")+1);
							}
							enddate = Result;
						}
					}
				}
				else Result="None";

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

        public string getEventText(int eventid, bool Start,bool getInstructor,ref string instructorName)
        {
            string startdate = "", enddate = "";
            string Result = "";
            string strSql = "";
            
            SqlCommand com = null;
            Connection con = null;
            SqlDataReader Reader = null;
            SqlCommand com1 = null;
            DateTime dtStart = Convert.ToDateTime(null);
            DateTime dtEnd = Convert.ToDateTime(null);

            if (Start)
                dtStart = Convert.ToDateTime(null);
            else
                dtEnd = Convert.ToDateTime(null);

            try
            {
                if (Start)
                {
                    strSql = "Select Top 1 StartDateTime,ScheduledTeacherID From [CalendarEvent] ";
                    strSql += "WHERE EventID=@EventID Order By CalendarEventID";
                }
                else
                {
                    strSql = "Select Top 1 EndDateTime From [CalendarEvent] ";
                    strSql += "WHERE EventID=@EventID Order by CalendarEventID DESC";
                }

                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = strSql;

                com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
                com.Parameters["@EventID"].Value = eventid;

                Reader = com.ExecuteReader();
                string id = "";
                bool IsRecord = false;
                if (Reader.Read())
                {
                    IsRecord = true;
                    if (Start)
                    {
                        if (Reader["StartDateTime"] != System.DBNull.Value)
                        {
                            dtStart = Convert.ToDateTime(Reader["StartDateTime"].ToString());
                        }
                    }
                    else
                    {
                        if (Reader["EndDateTime"] != System.DBNull.Value)
                        {
                            dtEnd = Convert.ToDateTime(Reader["EndDateTime"].ToString());
                        }
                    }
                    if(getInstructor)
                    {
                        if (Reader["ScheduledTeacherID"] != System.DBNull.Value)
                        {
                            id = Convert.ToString(Reader["ScheduledTeacherID"]);
                            //instructorName = getInstructorName(id);
                        }
                        else
                        {
                            instructorName = "None";
                        }
                    }
                    if (id == "0")
                        instructorName = "None";
                }
                Reader.Close();
                if (IsRecord)
                {
                    if (Start)
                    {
                        if (dtStart != Convert.ToDateTime(null))
                        {
                            Result = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString();
                            if (Result.IndexOf("(") > 0)
                            {
                                Result = Result.Substring(0, Result.IndexOf("(") + 1);
                            }
                            startdate = Result;
                        }
                    }
                    else
                    {
                        if (dtEnd != Convert.ToDateTime(null))
                        {
                            Result = dtEnd.ToShortDateString() + " " + dtEnd.ToShortTimeString();
                            if (Result.IndexOf("(") > 0)
                            {
                                Result = Result.Substring(0, Result.IndexOf("(") + 1);
                            }
                            enddate = Result;
                        }
                    }

                    if (id != "None" && id != "0")
                    {
                        instructorName = getInstructorName(id,con);
                    }
                    else
                        instructorName = "None";
                }
                else
                { Result = "None"; instructorName = "None"; }

                return Result;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return "";
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

        public string getInstructorName(string id,Connection con)
        {
            string Result = "";
            string strSql = "";

            SqlCommand com = null;
            //Connection con = null;
            SqlDataReader Reader = null;
            SqlCommand com1 = null;
            //con = new Connection();
            //con.Connect();
            strSql = "Select LastName,FirstName from Contact Where ContactID = " + id;
            com1 = new SqlCommand();
            com1.Connection = con.SQLCon;
            com1.CommandText = strSql;

            try
            {
                Reader = com1.ExecuteReader();
                if (Reader.Read())
                {
                    Result = Reader["LastName"].ToString() + ", " + Reader["FirstName"].ToString();
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

                if (com1 != null)
                {
                    com1.Dispose();
                    com = null;
                    //con.DisConnect();
                }
            }
            return Result;

        }

		public string getEventText(int eventid, ref string startdate, ref string enddate)
		{
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
				bool IsRecord=false;
				if(Reader.Read())
				{
					IsRecord=true;
					if(Reader["StartDateTime"]!=System.DBNull.Value)
					{
						dtStart = Convert.ToDateTime(Reader["StartDateTime"].ToString());
					}
					if(Reader["EndDateTime"]!=System.DBNull.Value)
					{
						dtEnd = Convert.ToDateTime(Reader["EndDateTime"].ToString());
					}
				}
				Reader.Close();
				if(IsRecord) 
				{
					if(dtStart!=Convert.ToDateTime(null))
					{
						Result = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString();
						if(Result.IndexOf("(")>0)
						{
							Result = Result.Substring(0, Result.IndexOf("(")+1);
						}
						startdate = Result;
					}

					if(dtEnd!=Convert.ToDateTime(null))
					{
						Result = dtEnd.ToShortDateString() + " " + dtEnd.ToShortTimeString();
						if(Result.IndexOf("(")>0)
						{
							Result = Result.Substring(0, Result.IndexOf("(")+1);
						}
						enddate = Result;
					}
				}
				else Result="None";

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

		public bool IsEventExists(int evtid)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(EventID) From [Event] " +
					"WHERE EventID=" + evtid.ToString() + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

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

        /// <summary>
        /// Determines whether the class is a single event or a series of repeating events.
        /// </summary>
        /// <returns>A boolean indicating if a class repeats or not.</returns>
        public bool IsRecurring()
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;

            try
            {
                strSql = "Select Count(*) from [Event] WHERE RecurrenceText IS NOT NULL AND RecurrenceText<>'' AND EventId=" + _eventid + ";";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                int result = (int)com.ExecuteScalar();

                //Means the class reocurrs alright
                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return false;
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
        /// Checks whether Test Initial, Mid or Final are set for a Class or not.
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
                strSql = "Select TestInitialEventId,TestMidtermEventId,TestFinalEventId from [Course] WHERE CourseId=@CourseId;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
                com.Parameters["@CourseId"].Value = _courseid;
                Reader = com.ExecuteReader();

                string[] temp = new string[3];
                bool[] boolArray = { false, false, false };
                Reader.Read();
                temp[0] = Reader[0].ToString();
                temp[1] = Reader[1].ToString();
                temp[2] = Reader[2].ToString();
                Reader.Close();
                IDataReader readerTemp = null;
                if (temp[0] != null && temp[0] != "" && temp[0] != "0")
                {
                    readerTemp = DAC.SelectStatement("Select * From Event Where EventID = " + temp[0]);
                    if (readerTemp.Read())
                    {
                        boolArray[0] = true;
                    }
                    else
                    {
                        DAC.EXQuery("Update [Course] Set TestInitialEventId = 0 Where CourseId = " + _courseid);
                        boolArray[0] = false;
                    }
                }
                if (temp[1] != null && temp[1] != "" && temp[1] != "0")
                {
                    readerTemp = DAC.SelectStatement("Select * From Event Where EventID = " + temp[1]);
                    if (readerTemp.Read())
                    {
                        boolArray[1] = true;
                    }
                    else
                    {

                        DAC.EXQuery("Update [Course] Set TestMidtermEventId = 0 Where CourseId = " + _courseid);
                        boolArray[1] = false;
                    }
                }
                if (temp[2] != null && temp[2] != "" && temp[2] != "0")
                {
                    readerTemp = DAC.SelectStatement("Select * From Event Where EventID = " + temp[2]);
                    if (readerTemp.Read())
                    {
                        boolArray[2] = true;
                    }
                    else
                    {
                        DAC.EXQuery("Update [Course] Set TestFinalEventId = 0 Where CourseId = " + _courseid);
                        boolArray[2] = false;
                    }
                }

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

        public string getOccurrenceCount(int eventid)
        {
            SqlCommand com = null;
            Connection con = null;
            SqlDataReader Reader = null;
            string strSQL = string.Empty;
            string strResult = string.Empty;
            int result1;
            int result2;
            int temp;
            try
            {
                strSQL = "Select Count(*) from [CalendarEvent] WHERE EventId=@EventId AND StartDateTime < GetDate() AND CalendarEventStatus = 0;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSQL, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@EventId", SqlDbType.Int));
                com.Parameters["@EventId"].Value = eventid;
                result1 = (int)com.ExecuteScalar();

                //strSQL = "Select Count(*) from [CalendarEvent] WHERE EventId=@EventId AND EndDateTime >= GetDate() AND CalendarEventStatus = 0;";
                strSQL = "Select Count(*) from [CalendarEvent] WHERE EventId=@EventId AND CalendarEventStatus = 0;";
                com.CommandText = strSQL;
                //com.Parameters["@EventId"].Value = eventid;
                result2 = (int)com.ExecuteScalar();

                //strResult = result1.ToString() + " / " + (result1 + result2).ToString();
                strResult = result1.ToString() + " / " + (result2).ToString();

                return strResult;
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return "Error!";
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