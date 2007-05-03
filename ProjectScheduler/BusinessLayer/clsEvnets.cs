using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer {
	/// <summary>
	/// Summary description for clsUser.
	/// </summary>
	public class Events {
		public Events() {}

		private DataTable _dtbl = new DataTable();
        private string temp;
        private string temp2;
        private string temp3;
        private string temp4;

		public int EventID = 0;
		public int CalendarEventID = 0;
		public string RepeatRule;
		public string NegativeException;
		public string RecurrenceText;
		//public int RecurrenceFlag;

		public string Name;
		public string NamePhonetic;
		public string NameRomaji;

		public string Description;
		//public int EventType;
        public string EventType;
		public string Location;
		public string BlockCode;
		public string RoomNo;
		public string ExceptionReason;
		public string Notes;

		public DateTime StartDate;
		public DateTime EndDate;
		public DateTime DateCompleted;

		public int SchedulerTeacherID = 0;
		public int RealTeacherID = 0;
		public int IsHoliday = 0;
		public string ChangeReason = "";

		public int CalendarEventStatus;
		public int EventStatus = 0;
		private string _message = "";

		public DataTable EventDataTable {
			get { return _dtbl; }
			set { _dtbl = value; }
		}
		public string Message {
			get { return _message; }
			set { _message = value; }
		}

		private void BuildDataTable() {
			_dtbl.Columns.Clear();
			_dtbl.Columns.Add(new DataColumn("EventID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NamePhonetic", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("NameRomaji", Type.GetType("System.String")));
			//_dtbl.Columns.Add(new DataColumn("EventType", Type.GetType("System.Int32")));
            _dtbl.Columns.Add(new DataColumn("EventType", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Location", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("BlockCode", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("RoomNo", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("Notes", Type.GetType("System.String")));
			_dtbl.Columns.Add(new DataColumn("StartDate", Type.GetType("System.DateTime")));
			_dtbl.Columns.Add(new DataColumn("EndDate", Type.GetType("System.DateTime")));
			_dtbl.Columns.Add(new DataColumn("DateCompleted", Type.GetType("System.DateTime")));
			_dtbl.Columns.Add(new DataColumn("ScheduledTeacherID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("RealTeacherID", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("IsHoliday", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("EventStatus", Type.GetType("System.Int32")));
			_dtbl.Columns.Add(new DataColumn("ExceptionReason", Type.GetType("System.String")));
		}

		public DataTable LoadData() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			SqlDataAdapter adpt = null;

			if (_dtbl == null) {
				_dtbl = new DataTable();
			}
			try {
				if (EventID <= 0) {
					strSql = "Select Event.EventID, CalendarEvent.CalendarEventID, Event.RepeatRule, Event.NegetiveException, CalendarEvent.Note, " +
						"Event.RecurrenceText, Event.Description, " +
						"EventStatus = " +
						"CASE CalendarEvent.CalendarEventStatus " +
						"When '0' Then 'Active' " +
						"When '1' Then 'Inactive' " +
						"END, " +
						"CalendarEvent.StartDateTime, CalendarEvent.EndDateTime, " +
						"CalendarEvent.DateCompleted, CalendarEvent.[Name], CalendarEvent.[NamePhonetic], CalendarEvent.[NameRomaji], " +
						"CalendarEvent.Location, CalendarEvent.BlockCode, CalendarEvent.RoomNumber, CalendarEvent.ScheduledTeacherID, " +
						"CalendarEvent.RealTeacherID, CalendarEvent.ChangeReason, CalendarEvent.IsHoliday, CalendarEvent.EventType, " +
						"CalendarEvent.ExceptionReason, CC1.LastName + ', ' + CC1.FirstName as ScheduledTeacher, " +
						"CC2.LastName + ', ' + CC2.FirstName as RealTeacher, " +
						"Course.CourseID, Course.[Name] as Class, Program.ProgramID, Program.[Name] as Program " +
						"From Event " +
						"Inner Join CalendarEvent ON(Event.EventID=CalendarEvent.EventID) " +
						"Left Join Contact CC1 ON(CC1.ContactID=CalendarEvent.ScheduledTeacherID) " +
						"Left Join Contact CC2 ON(CC2.ContactID=CalendarEvent.RealTeacherID) " +
						"Left Join Course ON(" +
						"Event.EventID=Course.EventID OR " +
						"Event.EventID=Course.TestInitialEventID OR " +
						"Event.EventID=Course.TestMidTermEventID OR " +
						"Event.EventID=Course.TestFinalEventID) " +
						"Left Join Program ON( " +
						"Event.EventID=Program.TestInitialEventID OR " +
						"Event.EventID=Program.TestMidTermEventID OR " +
						"Event.EventID=Program.TestFinalEventID) " +
						"Order By Course.[Name] ";
				} else {
					strSql = "Select Event.EventID, CalendarEvent.CalendarEventID, Event.RepeatRule, Event.NegetiveException, CalendarEvent.Note, " +
						"Event.RecurrenceText, Event.Description, " +
						"CalendarEvent.CalendarEventStatus as EventStatus, " +
						"CalendarEvent.StartDateTime, CalendarEvent.EndDateTime, " +
						"CalendarEvent.DateCompleted, CalendarEvent.[Name], CalendarEvent.[NamePhonetic], CalendarEvent.[NameRomaji], " +
						"CalendarEvent.Location, CalendarEvent.BlockCode, CalendarEvent.RoomNumber, CalendarEvent.ScheduledTeacherID, " +
						"CalendarEvent.RealTeacherID, CalendarEvent.ChangeReason, CalendarEvent.IsHoliday, CalendarEvent.EventType, " +
						"CalendarEvent.ExceptionReason, Contact1.LastName + ', ' + Contact1.FirstName as ScheduledTeacher, Contact2.LastName + ', ' + Contact2.FirstName as RealTeacher, " +
						"Course.CourseID, Course.[Name] as Class, Program.ProgramID, Program.[Name] as Program, " +
						"Course.EventID as CEvent1, Course.TestInitialEventID as CEvent2, Course.TestMidtermEventID as CEvent3, Course.TestFinalEventID as CEvent4, " +
						"Program.TestInitialEventID as PEvent1, Program.TestMidtermEventID as PEvent2, Program.TestFinalEventID as PEvent3 " +
						"From Event " +
						"Inner Join CalendarEvent ON(Event.EventID=CalendarEvent.EventID) " +
						"Left Join Contact Contact1 ON(Contact1.ContactID=CalendarEvent.ScheduledTeacherID) " +
						"Left Join Contact Contact2 ON(Contact2.ContactID=CalendarEvent.RealTeacherID) " +
						"Left Join Course ON(" +
						"Event.EventID=Course.EventID OR " +
						"Event.EventID=Course.TestInitialEventID OR " +
						"Event.EventID=Course.TestMidTermEventID OR " +
						"Event.EventID=Course.TestFinalEventID) " +
						"Left Join Program ON( " +
						"Event.EventID=Program.TestInitialEventID OR " +
						"Event.EventID=Program.TestMidTermEventID OR " +
						"Event.EventID=Program.TestFinalEventID) " +
                        "Where Event.EventID=" + EventID.ToString() + " ";
					if (CalendarEventID > 0)
						strSql += "and CalendarEvent.CalendarEventID=" + CalendarEventID.ToString();
                    else
                        strSql+="and CalendarEvent.EventType<>'Extra Class' AND CalendarEvent.EventType<>'Test Initial' AND CalendarEvent.EventType <>'Test Midterm' AND CalendarEvent.EventType<>'Test Final' ";
				}

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				adpt = new SqlDataAdapter();
				adpt.SelectCommand = com;
				adpt.Fill(_dtbl);

				bool boolCourse = false;
				bool boolProgram = false;

				_dtbl.Columns.Add("Department", Type.GetType("System.String"));
				_dtbl.Columns.Add("Client", Type.GetType("System.String"));
				_dtbl.Columns.Add("TestEvent", Type.GetType("System.String"));
				_dtbl.Columns.Add("Instructor", Type.GetType("System.String"));

				SqlDataReader Reader = null;
				//if(EventID<=0)
				//{
				foreach (DataRow dr in _dtbl.Rows) {
					if (dr["ScheduledTeacher"] != null) {
						if (dr["ScheduledTeacher"].ToString().Trim() == ",")
							dr["ScheduledTeacher"] = "";
					} else dr["ScheduledTeacher"] = "";
					if (dr["RealTeacher"] != null) {
						if (dr["RealTeacher"].ToString().Trim() == ",")
							dr["RealTeacher"] = "";
					} else dr["RealTeacher"] = "";

					if (dr["RealTeacher"] != "") dr["Instructor"] = dr["RealTeacher"].ToString();
					else if (dr["ScheduledTeacher"] != "") dr["Instructor"] = dr["ScheduledTeacher"].ToString();
					dr.AcceptChanges();

					if (dr["CourseID"] != DBNull.Value) {
						if (Convert.ToInt32(dr["CourseID"]) > 0) boolCourse = true;
						if (EventID > 0) {
							if (dr["CEvent1"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent1"].ToString()) > 0) dr["TestEvent"] = "Class Event";
							}
							if (dr["CEvent2"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
							}
							if (dr["CEvent3"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
							}
							if (dr["CEvent4"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent4"].ToString()) > 0) dr["TestEvent"] = "Test Final";
							}
							dr.AcceptChanges();
						}
					}
					if (!boolCourse) {
						if (dr["ProgramID"] != DBNull.Value) {
							if (Convert.ToInt32(dr["ProgramID"]) > 0) boolProgram = true;
							if (EventID > 0) {
								if (dr["PEvent1"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent1"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
								}
								if (dr["PEvent2"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
								}
								if (dr["PEvent3"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Final";
								}
								dr.AcceptChanges();
							}
						}
					}

					if (boolCourse) {
						strSql = "Select " +
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
							"From Course C " +
							"Left Join Program P on (C.ProgramID=P.ProgramID) " +
							"Left Join Department D on (P.DepartmentID=D.DepartmentID) " +
							"Left Join Contact CO on (D.ContactID=CO.ContactID) " +
							"Left Join Contact CO1 on (D.ClientID=CO1.ContactID) " +
							"Where C.CourseID=" + dr["CourseID"].ToString() + " ";

						com.CommandText = strSql;
						Reader = com.ExecuteReader();

						while (Reader.Read()) {
							dr["Program"] = Reader["Program"].ToString();
							dr["Department"] = Reader["Department"].ToString();
							dr["Client"] = Reader["Client"].ToString();

							dr.AcceptChanges();
						}
						Reader.Close();
					} else if (boolProgram) {
						strSql = "Select ";
						strSql += "Program = CASE ";
						strSql += "WHEN P.NickName IS NULL THEN P.Name ";
						strSql += "WHEN P.NickName = '' THEN P.Name ";
						strSql += "ELSE P.NickName ";
						strSql += "END,  ";
						strSql += "Department = CASE ";
						strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
						strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
						strSql += "ELSE C.NickName ";
						strSql += "END,  ";
						strSql += "Client = CASE ";
						strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
						strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
						strSql += "ELSE C1.NickName ";
						strSql += "END  ";
						strSql += "From Program P ";
						strSql += "Left Join Department D on (P.DepartmentID=D.DepartmentID) ";
						strSql += "Left Join Contact C on (D.ContactID=C.ContactID) ";
						strSql += "Left Join Contact C1 on (D.ClientID=C1.ContactID) ";
						strSql += "Where ProgramID=" + dr["ProgramID"].ToString() + " ";

						com.CommandText = strSql;
						Reader = com.ExecuteReader();

						while (Reader.Read()) {
							dr["Program"] = Reader["Program"].ToString();
							dr["Department"] = Reader["Department"].ToString();
							dr["Client"] = Reader["Client"].ToString();
							//if(dr["ScheduledTeacher"].ToString().Trim()==",")
							//	dr["ScheduledTeacher"]="";
							//if(dr["RealTeacher"].ToString().Trim()==",")
							//	dr["RealTeacher"]="";
							dr.AcceptChanges();
						}
						Reader.Close();
					}
					boolCourse = false;
					boolProgram = false;
				}
				//}
				return _dtbl;
			} catch (SqlException ex) {
				Message = ex.Message;
				return null;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
					adpt.Dispose();
					adpt = null;
				}
			}
		}

		public DataTable LoadData(DateTime dt1, DateTime dt2,
			string sClient, string sInstructor,
			string sProgram, string sClass) {
			string strSql = "";
			bool IsDate = false;
			SqlCommand com = null;
			Connection con = null;
			SqlDataAdapter adpt = null;

			if ((dt1 == Convert.ToDateTime(null)) && (dt2 == Convert.ToDateTime(null))) {
				IsDate = false;
			} else {
				IsDate = true;
			}

			if (_dtbl == null) {
				_dtbl = new DataTable();
			}
			try {
				if (EventID <= 0) {
                    strSql = "Select Event.EventID, CalendarEvent.CalendarEventID, Event.RepeatRule, Event.NegetiveException, CalendarEvent.Note, " +
						"Event.RecurrenceText, Event.Description, " +
						"EventStatus = " +
						"CASE CalendarEvent.CalendarEventStatus " +
						"When '0' Then 'Active' " +
						"When '1' Then 'Inactive' " +
						"END, " +
                        "CalendarEvent.StartDateTime, CalendarEvent.EndDateTime, DateName(dw,CalendarEvent.StartDateTime) as 'DayOfWeek', " +
						"CalendarEvent.DateCompleted, CalendarEvent.[Name], CalendarEvent.[NamePhonetic], CalendarEvent.[NameRomaji], " +
						"CalendarEvent.Location, CalendarEvent.BlockCode, CalendarEvent.RoomNumber, CalendarEvent.ScheduledTeacherID, " +
						"CalendarEvent.RealTeacherID, CalendarEvent.ChangeReason, CalendarEvent.IsHoliday, CalendarEvent.EventType, " +
						"CalendarEvent.ExceptionReason, CC1.LastName + ', ' + CC1.FirstName as ScheduledTeacher, " +
						"CC2.LastName + ', ' + CC2.FirstName as RealTeacher, " +
						"Course.CourseID, Course.[Name] as Class, Program.ProgramID, Program.[Name] as Program " +
						"From Event " +
						"Inner Join CalendarEvent ON(Event.EventID=CalendarEvent.EventID) " +
						"Left Join Contact CC1 ON(CC1.ContactID=CalendarEvent.ScheduledTeacherID) " +
						"Left Join Contact CC2 ON(CC2.ContactID=CalendarEvent.RealTeacherID) " +
						"Left Join Course ON(" +
						"Event.EventID=Course.EventID OR " +
						"Event.EventID=Course.TestInitialEventID OR " +
						"Event.EventID=Course.TestMidTermEventID OR " +
						"Event.EventID=Course.TestFinalEventID) " +
						"Left Join Program ON( " +
						"Event.EventID=Program.TestInitialEventID OR " +
						"Event.EventID=Program.TestMidTermEventID OR " +
						"Event.EventID=Program.TestFinalEventID) ";
                    /*
                    strSql = "Select Course.*,Program.* from Course Left Join Program on " +
                    "Course.ProgramId = Program.ProgramId Left Join " +
                    "Event On(Event.EventID=Course.EventID OR Event.EventID=Course.TestInitialEventID " +
                    "OR Event.EventID=Course.TestMidTermEventID OR Event.EventID=Course.TestFinalEventID " +
                    "OR Event.EventID=Program.TestInitialEventID OR Event.EventID=Program.TestMidTermEventID " +
                    "OR Event.EventID=Program.TestFinalEventID) " +
                    "Inner Join CalendarEvent on Event.EventId=CalendarEvent.EventId ";
					*/
                    string strWhereClause = "";
					if (IsDate) {
						strWhereClause += "and CalendarEvent.StartDateTime>=@date1 and CalendarEvent.StartDateTime<=@date2 ";
					}
					if (sProgram != "") {
						//strWhereClause += "and (Program.[Name] = '" + sProgram + "') ";
					}
					if (sClass != "") {
						//strWhereClause += "and (Course.[Name] = '" + sClass + "') ";
					}
					if (sInstructor != "") {
						strWhereClause += "and (CC1.LastName + ', ' + CC1.FirstName = '" + sInstructor + "' OR CC2.LastName + ', ' + CC2.FirstName = '" + sInstructor + "') ";
					}

					strWhereClause = strWhereClause.Trim();
					if (strWhereClause.Length > 3) {
						if (strWhereClause.Substring(0, 3).ToUpper() == "AND") {
							strWhereClause = strWhereClause.Substring(3, strWhereClause.Length - 3);
						}

						strWhereClause = " Where " + strWhereClause;
					}

					strSql += strWhereClause + " ";
					strSql += "Order By Event.EventID";

					//	"Order By Course.[Name] ";
				} else {
					strSql = "Select Event.EventID, CalendarEvent.CalendarEventID, Event.RepeatRule, Event.NegetiveException, CalendarEvent.Note, " +
						"Event.RecurrenceText, Event.Description, " +
						"CalendarEvent.CalendarEventStatus as EventStatus, " +
                        "CalendarEvent.StartDateTime, CalendarEvent.EndDateTime, DateName(dw,CalendarEvent.StartDateTime) as 'DayOfWeek', " +
						"CalendarEvent.DateCompleted, CalendarEvent.[Name], CalendarEvent.[NamePhonetic], CalendarEvent.[NameRomaji], " +
						"CalendarEvent.Location, CalendarEvent.BlockCode, CalendarEvent.RoomNumber, CalendarEvent.ScheduledTeacherID, " +
						"CalendarEvent.RealTeacherID, CalendarEvent.ChangeReason, CalendarEvent.IsHoliday, CalendarEvent.EventType, " +
						"CalendarEvent.ExceptionReason, Contact1.LastName + ', ' + Contact1.FirstName as ScheduledTeacher, Contact2.LastName + ', ' + Contact2.FirstName as RealTeacher, " +
						"Course.CourseID, Course.[Name] as Class, Program.ProgramID, Program.[Name] as Program, " +
						"Course.EventID as CEvent1, Course.TestInitialEventID as CEvent2, Course.TestMidtermEventID as CEvent3, Course.TestFinalEventID as CEvent4, " +
						"Program.TestInitialEventID as PEvent1, Program.TestMidtermEventID as PEvent2, Program.TestFinalEventID as PEvent3 " +
						"From Event " +
						"Inner Join CalendarEvent ON(Event.EventID=CalendarEvent.EventID) " +
						"Left Join Contact Contact1 ON(Contact1.ContactID=CalendarEvent.ScheduledTeacherID) " +
						"Left Join Contact Contact2 ON(Contact2.ContactID=CalendarEvent.RealTeacherID) " +
						"Left Join Course ON(" +
						"Event.EventID=Course.EventID OR " +
						"Event.EventID=Course.TestInitialEventID OR " +
						"Event.EventID=Course.TestMidTermEventID OR " +
						"Event.EventID=Course.TestFinalEventID) " +
						"Left Join Program ON( " +
						"Event.EventID=Program.TestInitialEventID OR " +
						"Event.EventID=Program.TestMidTermEventID OR " +
						"Event.EventID=Program.TestFinalEventID) " +
						"Where Event.EventID=" + EventID.ToString() + " ";
					if (CalendarEventID > 0) {
						strSql += "and CalendarEvent.CalendarEventID=" + CalendarEventID.ToString();
					}
				}

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				if (IsDate) {
					com.Parameters.Clear();
					com.Parameters.Add("@date1", SqlDbType.DateTime);
					com.Parameters.Add("@date2", SqlDbType.DateTime);
					com.Parameters["@date1"].Value = dt1;
					com.Parameters["@date2"].Value = dt2;
				}

				adpt = new SqlDataAdapter();
				adpt.SelectCommand = com;
				adpt.Fill(_dtbl);

				bool boolCourse = false;
				bool boolProgram = false;

                _dtbl.Columns.Add("ProgramName", Type.GetType("System.String"));
                _dtbl.Columns.Add("Department", Type.GetType("System.String"));
                _dtbl.Columns.Add("DeptName", Type.GetType("System.String"));
				_dtbl.Columns.Add("Client", Type.GetType("System.String"));
                _dtbl.Columns.Add("ClientName", Type.GetType("System.String"));
				_dtbl.Columns.Add("TestEvent", Type.GetType("System.String"));
				_dtbl.Columns.Add("Instructor", Type.GetType("System.String"));

				SqlDataReader Reader = null;
				//if(EventID<=0)
				//{
				foreach (DataRow dr in _dtbl.Rows) {
					if (dr["ScheduledTeacher"] != null) {
						if (dr["ScheduledTeacher"].ToString().Trim() == ",")
							dr["ScheduledTeacher"] = "";
					} else dr["ScheduledTeacher"] = "";
					if (dr["RealTeacher"] != null) {
						if (dr["RealTeacher"].ToString().Trim() == ",")
							dr["RealTeacher"] = "";
					} else dr["RealTeacher"] = "";

					if (dr["RealTeacher"] != "")
						dr["Instructor"] = dr["RealTeacher"].ToString();
					else
						if (dr["ScheduledTeacher"] != "")
							dr["Instructor"] = dr["ScheduledTeacher"].ToString();
					dr.AcceptChanges();

					if (dr["CourseID"] != DBNull.Value) {
						if (Convert.ToInt32(dr["CourseID"]) > 0) boolCourse = true;
						if (EventID > 0) {
							if (dr["CEvent1"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent1"].ToString()) > 0) dr["TestEvent"] = "Class Event";
							}
							if (dr["CEvent2"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
							}
							if (dr["CEvent3"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
							}
							if (dr["CEvent4"] != DBNull.Value) {
								if (Convert.ToInt32(dr["CEvent4"].ToString()) > 0) dr["TestEvent"] = "Test Final";
							}
							dr.AcceptChanges();
						}
					}
					if (!boolCourse) {
						if (dr["ProgramID"] != DBNull.Value) {
							if (Convert.ToInt32(dr["ProgramID"]) > 0) boolProgram = true;
							if (EventID > 0) {
								if (dr["PEvent1"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent1"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
								}
								if (dr["PEvent2"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
								}
								if (dr["PEvent3"] != DBNull.Value) {
									if (Convert.ToInt32(dr["PEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Final";
								}
								dr.AcceptChanges();
							}
						}
					}

					if (boolCourse) {
						strSql = "Select " +
							"P.[Name] as ProgramName, Program = CASE " +
							"WHEN P.NickName IS NULL THEN P.Name " +
							"WHEN P.NickName = '' THEN P.Name " +
							"ELSE P.NickName " +
							"END,  " +
							"CO.CompanyName as DeptName, Department = CASE " +
							"WHEN CO.NickName IS NULL THEN CO.CompanyName " +
							"WHEN CO.NickName = '' THEN CO.CompanyName " +
							"ELSE CO.NickName " +
							"END,  " +
							"CO1.CompanyName as ClientName, Client = CASE " +
							"WHEN CO1.NickName IS NULL THEN CO1.CompanyName " +
							"WHEN CO1.NickName = '' THEN CO1.CompanyName " +
							"ELSE CO1.NickName " +
							"END  " +
							"From Course C " +
							"Left Join Program P on (C.ProgramID=P.ProgramID) " +
							"Left Join Department D on (P.DepartmentID=D.DepartmentID) " +
							"Left Join Contact CO on (D.ContactID=CO.ContactID) " +
							"Left Join Contact CO1 on (D.ClientID=CO1.ContactID) " +
							"Where C.CourseID=" + dr["CourseID"].ToString() + " ";

						com.CommandText = strSql;
						Reader = com.ExecuteReader();

						while (Reader.Read()) {
							dr["Program"] = Reader["Program"].ToString();
                            dr["ProgramName"] = Reader["ProgramName"].ToString();
							dr["Department"] = Reader["Department"].ToString();
                            dr["DeptName"] = Reader["DeptName"].ToString();
							dr["Client"] = Reader["Client"].ToString();
                            dr["ClientName"] = Reader["ClientName"].ToString();
							dr.AcceptChanges();

							//if( Reader["Client"].ToString()==sClient)
							//{
							//	_dtbl.Rows.Remove(dr);															
							//}

						}
						Reader.Close();
					} 
                    else if (boolProgram) {
                        strSql = "Select ";
                        strSql += "P.[Name] as ProgramName, Program = CASE ";
						strSql += "WHEN P.NickName IS NULL THEN P.Name ";
						strSql += "WHEN P.NickName = '' THEN P.Name ";
						strSql += "ELSE P.NickName ";
						strSql += "END,  ";
						strSql += "C.CompanyName as DeptName, Department = CASE ";
						strSql += "WHEN C.NickName IS NULL THEN C.CompanyName ";
						strSql += "WHEN C.NickName = '' THEN C.CompanyName ";
						strSql += "ELSE C.NickName ";
						strSql += "END,  ";
						strSql += "C1.CompanyName as ClientName, Client = CASE ";
						strSql += "WHEN C1.NickName IS NULL THEN C1.CompanyName ";
						strSql += "WHEN C1.NickName = '' THEN C1.CompanyName ";
						strSql += "ELSE C1.NickName ";
						strSql += "END  ";
						strSql += "From Program P ";
						strSql += "Left Join Department D on (P.DepartmentID=D.DepartmentID) ";
						strSql += "Left Join Contact C on (D.ContactID=C.ContactID) ";
						strSql += "Left Join Contact C1 on (D.ClientID=C1.ContactID) ";
						strSql += "Where ProgramID=" + dr["ProgramID"].ToString() + " ";
                        
						com.CommandText = strSql;
						Reader = com.ExecuteReader();

						while (Reader.Read()) {
							dr["Program"] = Reader["Program"].ToString();
                            dr["ProgramName"] = Reader["ProgramName"].ToString();
                            dr["Department"] = Reader["Department"].ToString();
                            dr["DeptName"] = Reader["DeptName"].ToString();
                            dr["Client"] = Reader["Client"].ToString();
                            dr["ClientName"] = Reader["ClientName"].ToString();
							dr.AcceptChanges();
						}
						Reader.Close();
					}
					boolCourse = false;
					boolProgram = false;
				}

				DataTable dtblTemp; // = new DataTable();
				dtblTemp = _dtbl.Clone();
				dtblTemp.Rows.Clear();
				foreach (DataRow dr1 in _dtbl.Rows)
                {
					if (sClient != "") {
                        if (dr1["ClientName"] != DBNull.Value)
                        {if (dr1["ClientName"].ToString() != sClient) continue;
						} else continue;
					}

					if (sProgram != "") {
                        if (dr1["ProgramName"] != DBNull.Value)
                        { if (dr1["ProgramName"].ToString() != sProgram) continue;
						} else continue;
					}
					if (sClass != "") {
						if (dr1["Class"] != DBNull.Value) {
							if (dr1["Class"].ToString() != sClass) continue;
						} else continue;
					}

					DataRow drNew = dtblTemp.NewRow();
					foreach (DataColumn dc in _dtbl.Columns) {
						drNew[dc.ColumnName] = dr1[dc];
					}
					dtblTemp.Rows.Add(drNew);
				}

				return dtblTemp;

				return _dtbl;
			} catch (SqlException ex) {
				Message = ex.Message;
				return null;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
					adpt.Dispose();
					adpt = null;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <param name="clientName"></param>
		/// <param name="instructorName"></param>
		/// <param name="programName"></param>
		/// <param name="className"></param>
		/// <returns></returns>
		/// 
		public DataTable LoadCalendarData(DateTime startDate, DateTime endDate,
										  string clientName, string instructorName, string programName, string className) {
			string eventsSql;
			SqlCommand sqlCommand = new SqlCommand();
			Connection connection=null;
			SqlDataAdapter sqlDataAdapter=null;
			try {
				eventsSql = @"
				SELECT     Event.EventId, CalendarEvent.CalendarEventId, Event.Description, CalendarEvent.Name AS EventName, 
				CalendarEvent.StartDateTime, CASE When CalendarEvent.CalendarEventStatus = 0 Then 'Active' Else 'InActive' End as Status,
                      CalendarEvent.EndDateTime, CalendarEvent.ScheduledTeacherId, CalendarEvent.RealTeacherId,
                      CC1.LastName + ', ' + CC1.FirstName AS ScheduledTeacher, CC2.LastName + ', ' + CC2.FirstName AS RealTeacher,
                      Course.CourseId, 
                      Course.Name AS Class, Program.ProgramId, Program.Name AS Program
				FROM         Event INNER JOIN
                      CalendarEvent ON Event.EventId = CalendarEvent.EventId LEFT OUTER JOIN
                      Contact CC1 ON CC1.ContactId = CalendarEvent.ScheduledTeacherId LEFT OUTER JOIN
                      Contact CC2 ON CC2.ContactId = CalendarEvent.RealTeacherId LEFT OUTER JOIN
                      Course ON Event.EventId = Course.EventId OR Event.EventId = Course.TestInitialEventId 
                      OR Event.EventId = Course.TestMidtermEventId OR 
                      Event.EventId = Course.TestFinalEventId LEFT OUTER JOIN
                      Program ON Event.EventId = Program.TestInitialEventId OR Event.EventId = Program.TestMidtermEventId 
                      OR Event.EventId = Program.TestFinalEventId 
                 WHERE 1=1
				 ";
				if (startDate!=DateTime.MinValue)
				{
					eventsSql += " AND CalendarEvent.StartDateTime>=@startDate ";
					sqlCommand.Parameters.Add(new SqlParameter("@startDate", startDate));
				}
				if (endDate != DateTime.MaxValue) {
					eventsSql += " AND CalendarEvent.EndDateTime<=@endDate ";
					sqlCommand.Parameters.Add(new SqlParameter("@endDate", endDate));
				}
				//sqlCommand.Parameters.AddWithValue("startDate", startDate);
				//sqlCommand.Parameters.AddWithValue("endDate", endDate);
				if (programName!=string.Empty) {
					eventsSql += @"
					AND 
					((Program.[Name] = @programName) OR (Program.NickName = @programName)) 
					OR (Course.ProgramID=(Select ProgramID From Program Where ((Program.[Name] = @programName) 
					OR (Program.NickName = @programName))))";
					sqlCommand.Parameters.Add(new SqlParameter("@programName", programName));
					//sqlCommand.Parameters.AddWithValue("programName", programName);
				}
				if (className != string.Empty) {
					eventsSql += "and  ((Course.[Name] = @className) OR (Course.NickName =  @className)) ";
					sqlCommand.Parameters.Add(new SqlParameter("@className", className));
					//sqlCommand.Parameters.AddWithValue("className", className);
				}
				eventsSql += "Order By Event.EventID";

				connection = new Connection();
				connection.Connect();
				sqlCommand.Connection = connection.SQLCon;

				sqlCommand.CommandText = eventsSql;

				sqlDataAdapter = new SqlDataAdapter();
				sqlDataAdapter.SelectCommand = sqlCommand;
				sqlDataAdapter.Fill(_dtbl);
				_dtbl.Columns.Add("Department", Type.GetType("System.String"));
				_dtbl.Columns.Add("Client", Type.GetType("System.String"));
				_dtbl.Columns.Add("TestEvent", Type.GetType("System.String"));
				_dtbl.Columns.Add("DeptNickName", Type.GetType("System.String"));
				_dtbl.Columns.Add("ClientNickName", Type.GetType("System.String"));
				//we fix values in data table
				FixDataTable(connection);
				
				DataTable dtbl = new DataTable();
				dtbl.Columns.Add("CEID", Type.GetType("System.String"));
				dtbl.Columns.Add("STARTDATETIME", Type.GetType("System.DateTime"));
				dtbl.Columns.Add("ENDDATETIME", Type.GetType("System.DateTime"));
				dtbl.Columns.Add("TASKDESC", Type.GetType("System.String"));
                dtbl.Columns.Add("Status", Type.GetType("System.String"));
				foreach (DataRow dr in _dtbl.Rows) {
					string strfinalstring = "";
					string strDept = "";
					string strDescription = "";
					string strTeacher = "";
					string strClient = "";
                    string status = "";
					if (dr["EventName"].ToString().Trim().Length > 0)
					{
						strDescription = dr["EventName"].ToString();
					}
					DateTime dtStart = Convert.ToDateTime(null);
					if (dr["StartDateTime"].ToString().Length > 0)
					{
						dtStart = Convert.ToDateTime(dr["StartDateTime"].ToString());
					}

					DateTime dtEnd = DateTime.MinValue;
					if (dr["EndDateTime"].GetType().IsAssignableFrom(typeof(DateTime)))
					{
						dtEnd = (DateTime)dr["EndDateTime"];
					}
					
					if (dr["RealTeacher"].ToString().Trim().Length > 0) {
						strTeacher = dr["RealTeacher"].ToString().Trim();
						if (instructorName != "") {
							if (instructorName != strTeacher) continue;
						}
					} else if (dr["ScheduledTeacher"].ToString().Trim().Length > 0) {
						strTeacher = dr["ScheduledTeacher"].ToString().Trim();
						if (instructorName != "") {
							if (instructorName != strTeacher) continue;
						}
					} else if (instructorName != null && instructorName.Length > 0) {
						continue;
					}

					if (dr["Department"].ToString().Trim().Length > 0)
					{
						strDept = dr["Department"].ToString().Trim();
					}
					if (dr["Client"].ToString().Trim().Length > 0) {
						strClient = dr["Client"].ToString().Trim();
						if (clientName!=string.Empty && clientName != strClient) {
								continue;
						}
					}
                    if (dr["Status"] != DBNull.Value) status = dr["Status"].ToString();
					//strfinalstring = strTime.Trim();
					/*if(strDept!="")
					{
						if(dr["DeptNickName"].ToString()=="")
							strfinalstring += strDept;
						else
							strfinalstring += dr["DeptNickName"].ToString();
					}*/
					if (strClient != "") {
						if (dr["ClientNickName"].ToString() == "")
							strfinalstring += strClient;
						else
							strfinalstring += dr["ClientNickName"].ToString();
					}

					//was removed in corresponding
					//						if(strTeacher!="")
					//						{
					//							strfinalstring += ", " + strTeacher;
					//						}
					if (strDescription != "") {
						strfinalstring += ", " + strDescription;
					}

					strfinalstring = strfinalstring.Trim();
					if (strfinalstring.Length > 0) {
						if (strfinalstring.IndexOf(",", 0, strfinalstring.Length) == 0) {
							strfinalstring = strfinalstring.Substring(1, strfinalstring.Length - 1);
						}
					}

					dtbl.Rows.Add(new object[]{
														  dr["CalendarEventID"].ToString(),
														  dtStart,
														  dtEnd,
														  strfinalstring,status
													  });
				}
				return dtbl;
			} catch (SqlException ex) {
				Message = ex.Message;
				return null;
			} finally {
				if (sqlCommand != null) {
					sqlCommand.Dispose();
					if (connection!=null)
					{
						connection.DisConnect();
					}
					if (sqlDataAdapter!=null)
					{
						sqlDataAdapter.Dispose();
					}
				}
			}
		}

		private void FixDataTable(Connection connection) {
			SqlCommand sqlCommand;
			foreach (DataRow dr in _dtbl.Rows) {
				bool boolCourse = false;
				bool boolProgram = false;
				if (dr["ScheduledTeacher"] != DBNull.Value) {
					if (dr["ScheduledTeacher"].ToString().Trim() == ",")
					{
						dr["ScheduledTeacher"] = "";
					}
				}
				if (dr["RealTeacher"] != DBNull.Value) {
					if (dr["RealTeacher"].ToString().Trim() == ",")
					{
						dr["RealTeacher"] = "";
					}
				}

				if (dr["CourseID"] != DBNull.Value) {
					if (Convert.ToInt32(dr["CourseID"]) > 0) {
						boolCourse = true;
					}
					if (EventID > 0) {
						if (dr["CEvent1"] != DBNull.Value) {
							if (Convert.ToInt32(dr["CEvent1"].ToString()) > 0) dr["TestEvent"] = "Class Event";
						}
						if (dr["CEvent2"] != DBNull.Value) {
							if (Convert.ToInt32(dr["CEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
						}
						if (dr["CEvent3"] != DBNull.Value) {
							if (Convert.ToInt32(dr["CEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
						}
						if (dr["CEvent4"] != DBNull.Value) {
							if (Convert.ToInt32(dr["CEvent4"].ToString()) > 0) dr["TestEvent"] = "Test Final";
						}
						dr.AcceptChanges();
					}
				}
				if (!boolCourse) {
					if (dr["ProgramID"] != DBNull.Value) {
						if (Convert.ToInt32(dr["ProgramID"]) > 0) boolProgram = true;
						if (EventID > 0) {
							if (dr["PEvent1"] != DBNull.Value) {
								if (Convert.ToInt32(dr["PEvent1"].ToString()) > 0) dr["TestEvent"] = "Test Initial";
							}
							if (dr["PEvent2"] != DBNull.Value) {
								if (Convert.ToInt32(dr["PEvent2"].ToString()) > 0) dr["TestEvent"] = "Test Midterm";
							}
							if (dr["PEvent3"] != DBNull.Value) {
								if (Convert.ToInt32(dr["PEvent3"].ToString()) > 0) dr["TestEvent"] = "Test Final";
							}
							dr.AcceptChanges();
						}
					}
				}

				if (boolCourse) {
					string courseSql = @"Select P.Name As Program, CO.CompanyName as Department, CO.NickName as DeptNickName, 
						CO1.CompanyName as Client, CO1.NickName as ClientNickName
							from Course C 
							Left Join Program P on (C.ProgramID=P.ProgramID)
							Left Join Department D on (P.DepartmentID=D.DepartmentID) 
							Left Join Contact CO on (D.ContactID=CO.ContactID) 
							Left Join Contact CO1 on (D.ClientID=CO1.ContactID)
							Where C.CourseID=@courseId";
					sqlCommand = new SqlCommand(courseSql, connection.SQLCon);
					//sqlCommand.Parameters.AddWithValue("courseId", dr["CourseID"]);
					sqlCommand.Parameters.Add(new SqlParameter("@courseId", dr["CourseID"]));
					SqlDataReader reader = sqlCommand.ExecuteReader();
					while (reader.Read()) {
						dr["Program"] = reader["Program"].ToString();
						dr["Department"] = reader["Department"].ToString();
						dr["Client"] = reader["Client"].ToString();
						dr["DeptNickName"] = reader["DeptNickName"].ToString();
						dr["ClientNickName"] = reader["ClientNickName"].ToString();
						dr.AcceptChanges();
					}
					reader.Close();
					//reader.Dispose();
				} else if (boolProgram) {
					string programSql = @"Select P.Name as Program, C.CompanyName As Department, 
						C.NickName as DeptNickName, C1.CompanyName as Client, C1.NickName as ClientNickName 
						from Program P 
						Left Join Department D on (P.DepartmentID=D.DepartmentID) 
						Left Join Contact C on (D.ContactID=C.ContactID) 
						Left Join Contact C1 on (D.ClientID=C1.ContactID) 
						Where ProgramID=@programId";
					sqlCommand = new SqlCommand(programSql, connection.SQLCon);
					sqlCommand.CommandText = programSql;
					//sqlCommand.Parameters.AddWithValue("programId", dr["ProgramID"]);
					sqlCommand.Parameters.Add(new SqlParameter("@programId", dr["ProgramID"]));
					SqlDataReader reader = sqlCommand.ExecuteReader();
					while (reader.Read()) {
						dr["Program"] = reader["Program"].ToString();
						dr["Department"] = reader["Department"].ToString();
						dr["Client"] = reader["Client"].ToString();
						dr["DeptNickName"] = reader["DeptNickName"].ToString();
						dr["ClientNickName"] = reader["ClientNickName"].ToString();
						dr.AcceptChanges();
					}
					reader.Close();
				}
			}
		}

		/// <summary>
		/// Inserts a new record into the 'Event' table.
		/// </summary>
		/// <returns>A boolean indicating whether the record was successfully inserted or not.</returns>
        public bool InsertData() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			SqlDataReader Reader = null;
			try {
				strSql = "Insert Into [Event] " +
					"(" +
					"Description, " +
					"RepeatRule, " +
					"NegetiveException, " +
					"RecurrenceText, " +
					//"RecurrenceFlag, " +
					"EventStatus, " +
					"CreatedByUserId, " +
					"DateCreated, " +
					"DateLastModified, " +
					"LastModifiedByUserID) " +
					"Values(" +
					"@Description, " +
					"@RepeatRule, " +
					"@NegetiveException, " +
					"@RecurrenceText, " +
					//"@RecurrenceFlag, " +
					"@EventStatus, " +
					"@CreatedByUserId, " +
					"@DateCreated, " +
					"@DateLastModified, " +
					"@LastModifiedByUserID " +
					") ";
				strSql += "SELECT @@IDENTITY";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Clear();
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 255));
				com.Parameters.Add(new SqlParameter("@RepeatRule", SqlDbType.NVarChar, 1000));
				com.Parameters.Add(new SqlParameter("@NegetiveException", SqlDbType.NVarChar, 4000));
				com.Parameters.Add(new SqlParameter("@RecurrenceText", SqlDbType.NVarChar, 255));
				//com.Parameters.Add(new SqlParameter("@RecurrenceFlag", SqlDbType.Bit));
				com.Parameters.Add(new SqlParameter("@EventStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@Description"].Value = Description;
				com.Parameters["@RepeatRule"].Value = RepeatRule;
				com.Parameters["@NegetiveException"].Value = NegativeException;
				com.Parameters["@RecurrenceText"].Value = RecurrenceText;
				//com.Parameters["@RecurrenceFlag"].Value = RecurrenceFlag;
                //if (EventStatus < 0) EventStatus = 1;
				com.Parameters["@EventStatus"].Value = EventStatus;
				com.Parameters["@CreatedByUserId"].Value = Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Common.LogonID;

				Reader = com.ExecuteReader();
				if (Reader.Read()) {
					EventID = Convert.ToInt32(Reader[0].ToString());
				}
				Reader.Close();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        /// <summary>
        /// Updates the information in the 'Event' table.
        /// </summary>
        /// <returns>A boolean indicating whether the operation was successfull or not.</returns>
		public bool UpdateData() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				strSql = "Update [Event] Set " +
					"Description=@Description, " +
					"RepeatRule=@RepeatRule, " +
					"NegetiveException=@NegetiveException, " +
					"RecurrenceText=@RecurrenceText, " +
					"EventStatus=@EventStatus, " +
					"DateLastModified=@DateLastModified, " +
					"LastModifiedByUserID=@LastModifiedByUserID " +
					"WHERE EventID=@EventID ";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 255));
				com.Parameters.Add(new SqlParameter("@RepeatRule", SqlDbType.NVarChar, 1000));
				com.Parameters.Add(new SqlParameter("@NegetiveException", SqlDbType.NVarChar, 4000));
				com.Parameters.Add(new SqlParameter("@RecurrenceText", SqlDbType.NVarChar, 255));
				//com.Parameters.Add(new SqlParameter("@RecurrenceFlag", SqlDbType.Bit));
				com.Parameters.Add(new SqlParameter("@EventStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@EventID"].Value = EventID;
				com.Parameters["@Description"].Value = Description;
				com.Parameters["@RepeatRule"].Value = RepeatRule;
				com.Parameters["@NegetiveException"].Value = NegativeException;
				com.Parameters["@RecurrenceText"].Value = RecurrenceText;
				//com.Parameters["@RecurrenceFlag"].Value = RecurrenceFlag;
                if (EventStatus < 0) EventStatus = 1;
				com.Parameters["@EventStatus"].Value = EventStatus;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Common.LogonID;
				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        public void UpdateClassEvent(int ClassId,string strField)
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;

            try
            {
                strSql = "Update [Course] SET " + strField + "=@EventId WHERE CourseId=@CourseId;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@EventId", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
                com.Parameters["@EventId"].Value = EventID;
                com.Parameters["@CourseId"].Value = ClassId;
                com.ExecuteNonQuery();
            }
			catch (SqlException ex)
            {
				Message = ex.Message;
				return;
			}
            finally
            {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
        }

        public void UpdateProgramEvent(int ProgramId, string strField)
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;

            try
            {
                strSql = "Update [Program] SET " + strField + "=@EventId WHERE ProgramId=@ProgramId;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@EventId", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@ProgramId", SqlDbType.Int));
                com.Parameters["@EventId"].Value = EventID;
                com.Parameters["@ProgramId"].Value = ProgramId;
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Message = ex.Message;
                return;
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
		
        public string CheckClassEvent() {
			string strSql = "";
			string Result = "";
			SqlDataReader Reader = null;
			SqlCommand com = null;
			Connection con = null;
			try {
				//first check if the event is recurrence event and if yes, then skip the checking...
				strSql = "Select EventID from Event Where EventID=@EventID and (RecurrenceText='' OR RecurrenceText IS NULL)";
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters["@EventID"].Value = EventID;
				Reader = com.ExecuteReader();
				if (Reader.HasRows == false) {
					Reader.Close();
					return "";
				}
				Reader.Close();

				strSql = "Select [Name] from course " +
					"Where EventID=@EventID or " +
					"TestInitialEventID=@EventID or " +
					"TestMidTermEventID=@EventID or TestFinalEventID=@EventID ";

				com.CommandText = strSql;
				//com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters["@EventID"].Value = EventID;
				Reader = com.ExecuteReader();

				bool IsDelete = false;
				if (Reader.Read()) {
					Result = Reader["Name"].ToString();
					Result = " Class - '" + Result + "' ";
					IsDelete = true;
				}
				Reader.Close();

				if (IsDelete) {
					strSql = "Update Course Set EventID=0 where EventID=@EventID";
					com.CommandText = strSql;
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();

					strSql = "Update Course Set TestInitialEventID=0 where TestInitialEventID=@EventID";
					com.CommandText = strSql;
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();

					strSql = "Update Course Set TestMidTermEventID=0 where TestMidTermEventID=@EventID";
					com.CommandText = strSql;
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();

					strSql = "Update Course Set TestFinalEventID=0 where TestFinalEventID=@EventID";
					com.CommandText = strSql;
					com.ExecuteNonQuery();
				}

				//return Result;
				return "";
			} catch (SqlException ex) {
				Message = ex.Message;
				return "";
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public string CheckProgramEcent() {
			bool OK = false;
			string strSql = "";
			string Result = "";
			SqlDataReader Reader = null;
			SqlCommand com = null;
			Connection con = null;
			try {
				//first check if the event is recurrence event and if yes, then skip the checking...
				strSql = "Select EventID from Event Where EventID=@EventID and (RecurrenceText='' OR RecurrenceText IS NULL)";
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters["@EventID"].Value = EventID;
				Reader = com.ExecuteReader();
				if (Reader.HasRows == false) {
					Reader.Close();
					return "";
				}
				Reader.Close();

				strSql = "Select [Name] from program Where TestInitialEventID=@EventID or  TestMidTermEventID=@EventID or TestFinalEventID=@EventID ";
				com.CommandText = strSql;
				Reader = com.ExecuteReader();

				bool IsDelete = false;
				if (Reader.Read()) {
					Result = Reader["Name"].ToString();
					Result = " Program - '" + Result + "' ";
					IsDelete = true;
				}
				Reader.Close();

				if (IsDelete) {
					strSql = "Update program Set TestInitialEventID=0 where TestInitialEventID=@EventID";
					com.CommandText = strSql;
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();

					strSql = "Update program Set TestMidTermEventID=0 where TestMidTermEventID=@EventID";
					com.CommandText = strSql;
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();

					strSql = "Update program Set TestFinalEventID=0 where TestFinalEventID=@EventID";
					com.CommandText = strSql;
					com.ExecuteNonQuery();
				}

				//return Result;
				return "";
			} catch (SqlException ex) {
				Message = ex.Message;
				return "";
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        public bool DeleteExtraClassEvents()
        {
            try
            {
                string strSql = "";
                SqlCommand com = null;
                Connection con = null;
                strSql = "Delete From [CalendarEvent] Where EventID=@EventID AND EventType = 'Extra Class'";
                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = strSql;
                com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                com.Parameters["@EventID"].Value = EventID;
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public bool DeleteData(bool DeleteMaster) {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				if (DeleteMaster) {
					strSql = "Delete From [CalendarEvent] " +
						"WHERE EventID=@EventID ";
				} else {
					strSql = "Delete From [CalendarEvent] " +
						"WHERE CalendarEventID=@EventID ";
				}

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				if (DeleteMaster)
					com.Parameters["@EventID"].Value = EventID;
				else
					com.Parameters["@EventID"].Value = CalendarEventID;
				com.ExecuteNonQuery();

				if (DeleteMaster) {
					com.CommandText = "Delete from Event Where EventID=@EventID";
					com.Parameters["@EventID"].Value = EventID;
					com.ExecuteNonQuery();
				}

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        public bool DeleteSingleCalendarEvent()
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;
            try
            {
                strSql = "Delete From [CalendarEvent] " +
                        "WHERE CalendarEventID=@CalendarEventID ";

                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = strSql;
                com.Parameters.Add(new SqlParameter("@CalendarEventID", SqlDbType.Int));
                com.Parameters["@CalendarEventID"].Value = CalendarEventID;
                com.ExecuteNonQuery();

                return true;
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

        public bool DeleteCalendarEvent() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				strSql = "Delete From [CalendarEvent] " +
                        "WHERE EventID=@EventID AND EventType<>'Extra Class'";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                com.Parameters["@EventID"].Value = EventID;
				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public bool Exists() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			SqlDataReader Reader = null;
			try {
				strSql = "Select EventID From Event " +
					"Where EventID=@EventID ";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int, 8));
				com.Parameters["@EventID"].Value = EventID;

				Reader = com.ExecuteReader();
				if (Reader.HasRows) {
					return true;
				}
				return false;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public bool CalendarExists() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				strSql = "Select Count(*) From [CalendarEvent] " +
					"WHERE [EventID]=@EventID ";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters["@EventID"].Value = EventID;

				object o = com.ExecuteScalar();
				if (Convert.ToInt32(o) > 0) {
					return true;
				}

				return false;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		/// <summary>
		/// Inserts a new record into the 'CalendarEvent' table.
		/// </summary>
		/// <returns>A boolean indicating whether the new record was inserted successfully or not.</returns>
        public bool InsertCalendarEventData() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				strSql = "Insert Into [CalendarEvent] " +
					"(" +
					"EventID," +
					"StartDateTime, " +
					"EndDateTime, " +
					"DateCompleted, " +
					"EventType, " +
					"Name, " +
					"NamePhonetic, " +
					"NameRomaji, " +
					"Location, " +
					"BlockCode, " +
					"RoomNumber, " +
					"ScheduledTeacherId, " +
					"RealTeacherID, " +
					"ChangeReason, " +
					"IsHoliday, " +
					"Note, " +
					"CalendarEventStatus, " +
					"ExceptionReason, " +
					"CreatedByUserId, " +
					"DateCreated, " +
					"DateLastModified, " +
					"LastModifiedByUserID) " +
				"Values( " +
					"@EventID," +
					"@StartDateTime, " +
					"@EndDateTime, " +
					"@DateCompleted, " +
					"@EventType, " +
					"@Name, " +
					"@NamePhonetic, " +
					"@NameRomaji, " +
					"@Location, " +
					"@BlockCode, " +
					"@RoomNumber, " +
					"@ScheduledTeacherId, " +
					"@RealTeacherID, " +
					"@ChangeReason, " +
					"@IsHoliday, " +
					"@Note, " +
					"@CalendarEventStatus, " +
					"@ExceptionReason, " +
					"@CreatedByUserId, " +
					"@DateCreated, " +
					"@DateLastModified, " +
					"@LastModifiedByUserID) ";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@StartDateTime", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@EndDateTime", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateCompleted", SqlDbType.DateTime));

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NameRomaji", SqlDbType.NVarChar));

				com.Parameters.Add(new SqlParameter("@EventType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@BlockCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@RoomNumber", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ExceptionReason", SqlDbType.NVarChar));

				com.Parameters.Add(new SqlParameter("@ScheduledTeacherId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@RealTeacherID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ChangeReason", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@IsHoliday", SqlDbType.Int));

				com.Parameters.Add(new SqlParameter("@CalendarEventStatus", SqlDbType.Int));

				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@EventID"].Value = EventID;
				com.Parameters["@StartDateTime"].Value = StartDate;
				com.Parameters["@EndDateTime"].Value = EndDate;
				com.Parameters["@DateCompleted"].Value = DateCompleted;

				com.Parameters["@Name"].Value = Name;
				com.Parameters["@NamePhonetic"].Value = NamePhonetic;
				com.Parameters["@NameRomaji"].Value = NameRomaji;
				com.Parameters["@Location"].Value = Location;
				com.Parameters["@BlockCode"].Value = BlockCode;
				com.Parameters["@RoomNumber"].Value = RoomNo;

				com.Parameters["@ScheduledTeacherId"].Value = SchedulerTeacherID;
				com.Parameters["@RealTeacherID"].Value = RealTeacherID;
				com.Parameters["@ChangeReason"].Value = ChangeReason;
				com.Parameters["@IsHoliday"].Value = IsHoliday;

				com.Parameters["@EventType"].Value = EventType;
				com.Parameters["@Note"].Value = Notes;
				com.Parameters["@ExceptionReason"].Value = ExceptionReason;
				com.Parameters["@CalendarEventStatus"].Value = CalendarEventStatus;

				com.Parameters["@CreatedByUserId"].Value = Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Common.LogonID;

				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public bool UpdateCalendarEventData() {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				strSql = "Update [CalendarEvent] " +
					"Set " +
					//"EventID," +
					"StartDateTime=@StartDateTime, " +
					"EndDateTime=@EndDateTime, " +
					"DateCompleted=@DateCompleted, " +
					"EventType=@EventType, " +
					"Name=@Name, " +
					"NamePhonetic=@NamePhonetic, " +
					"NameRomaji=@NameRomaji, " +
					"Location=@Location, " +
					"BlockCode=@BlockCode, " +
					"RoomNumber=@RoomNumber, " +
					"ScheduledTeacherId=@ScheduledTeacherId, " +
					"RealTeacherID=@RealTeacherID, " +
					"ChangeReason=@ChangeReason, " +
					"IsHoliday=@IsHoliday, " +
					"Note=@Note, " +
					"ExceptionReason=@ExceptionReason, " +
					"CalendarEventStatus=@CalendarEventStatus, " +
					"DateCreated=@DateCreated, " +
					"DateLastModified=@DateLastModified, " +
					"LastModifiedByUserID=@LastModifiedByUserID " +
					"Where CalendarEventID=@CalendarEventID ";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@CalendarEventID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@StartDateTime", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@EndDateTime", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateCompleted", SqlDbType.DateTime));

				com.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NameRomaji", SqlDbType.NVarChar));

				com.Parameters.Add(new SqlParameter("@EventType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@BlockCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@RoomNumber", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ExceptionReason", SqlDbType.NVarChar));

				com.Parameters.Add(new SqlParameter("@ScheduledTeacherId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@RealTeacherID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ChangeReason", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@IsHoliday", SqlDbType.Int));

				com.Parameters.Add(new SqlParameter("@CalendarEventStatus", SqlDbType.Int));

				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));

				com.Parameters["@CalendarEventID"].Value = CalendarEventID;
				com.Parameters["@StartDateTime"].Value = StartDate;
				com.Parameters["@EndDateTime"].Value = EndDate;
				com.Parameters["@DateCompleted"].Value = DateCompleted;

				com.Parameters["@Name"].Value = Name;
				com.Parameters["@NamePhonetic"].Value = NamePhonetic;
				com.Parameters["@NameRomaji"].Value = NameRomaji;
				com.Parameters["@Location"].Value = Location;
				com.Parameters["@BlockCode"].Value = BlockCode;
				com.Parameters["@RoomNumber"].Value = RoomNo;

				com.Parameters["@ScheduledTeacherId"].Value = SchedulerTeacherID;
				com.Parameters["@RealTeacherID"].Value = RealTeacherID;
				com.Parameters["@ChangeReason"].Value = ChangeReason;
				com.Parameters["@IsHoliday"].Value = IsHoliday;

				com.Parameters["@EventType"].Value = EventType;
				com.Parameters["@Note"].Value = Notes;
				com.Parameters["@ExceptionReason"].Value = ExceptionReason;
				com.Parameters["@CalendarEventStatus"].Value = CalendarEventStatus;

				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Common.LogonID;

				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public bool RemoveTestEvent(int eventID, int tableID) {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;

				//Class
				strSql = "Update Course set EventID=0 Where EventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestInitialEventID=0 Where TestInitialEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestMidtermEventID=0 Where TestMidtermEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestFinalEventID=0 Where TestFinalEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				//Program
				strSql = "Update Program set TestInitialEventID=0 Where TestInitialEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Program set TestMidtermEventID=0 Where TestMidtermEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Program set TestFinalEventID=0 Where TestFinalEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        /// <summary>
        /// Deletes a test or class event from both 'CalendarEvent' and 'Event' tables.
        /// </summary>
        /// <returns>A boolean indicating whether the deletion was successful or not.</returns>
        public bool DeleteTestEvent(string strType, int tableID)
        { 
            string strSql = "";
            string strField = "";
			SqlCommand com = null;
			Connection con = null;
            int result;

            switch (EventType)
            {
                case "Test Initial": strField = "TestInitialEventId"; break;
                case "Test Midterm": strField = "TestMidtermEventId"; break;
                case "Test Final": strField = "TestFinalEventId"; break;
                case "Event": strField = "EventId"; break;
            }

            try
            {
                strSql = "Delete from [Event] WHERE EventId=@EventId;";
                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@EventId",SqlDbType.Int));
                com.Parameters["@EventId"].Value = EventID;
                result = com.ExecuteNonQuery();

                if(result==1)
                {
                    com.Parameters.Clear();
                    strSql = "Delete from [CalendarEvent] WHERE CalendarEventId=@CalendarEventId;";
                    com.CommandText = strSql;
                    com.Parameters.Add(new SqlParameter("@CalendarEventId", SqlDbType.Int));
                    com.Parameters["@CalendarEventId"].Value = CalendarEventID;
                    result = com.ExecuteNonQuery();

                    if (result == 1)
                    {
                        com.Parameters.Clear();
                        strSql = "Update ["+ strType +"] SET "+ strField +"=0 WHERE "+strType+"Id="+ tableID +";";
                        com.CommandText = strSql;
                        //com.Parameters.Add(new SqlParameter("@CourseId", SqlDbType.Int));
                        //com.Parameters["@CourseId"].Value = courseID;
                        result = com.ExecuteNonQuery();

                        if (result == 1)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
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

		public bool UpdateTestEvent(string type, string field, int eventID, int tableID)
        {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;

				//Class
				strSql = "Update Course set EventID=0 Where EventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestInitialEventID=0 Where TestInitialEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestMidtermEventID=0 Where TestMidtermEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Course set TestFinalEventID=0 Where TestFinalEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				//Program
				strSql = "Update Program set TestInitialEventID=0 Where TestInitialEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Program set TestMidtermEventID=0 Where TestMidtermEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();

				strSql = "Update Program set TestFinalEventID=0 Where TestFinalEventID=" + eventID.ToString();
				com.CommandText = strSql;
				com.ExecuteNonQuery();


				if (type == "Class") {
					strSql = "Update Course set EventID=0 Where CourseID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Course set TestInitialEventID=0 Where CourseID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Course set TestMidtermEventID=0 Where CourseID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Course set TestFinalEventID=0 Where CourseID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Course set " + field + "=@EventID Where CourseID=@ID";
				} else if (type == "Program") {
					strSql = "Update Program set TestInitialEventID=0 Where ProgramID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Program set TestMidtermEventID=0 Where ProgramID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Program set TestFinalEventID=0 Where ProgramID=" + tableID.ToString();
					com.CommandText = strSql;
					com.ExecuteNonQuery();

					strSql = "Update Program set " + field + "=@EventID Where ProgramID=@ID";
				}
				com.CommandText = strSql;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));

				com.Parameters["@EventID"].Value = eventID;
				com.Parameters["@ID"].Value = tableID;

				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

        /// <summary>
        /// Checks whether an event clashes with another event in the same program or class.
        /// </summary>
        /// <param name="dtStart">Start Date and Time to check.</param>
        /// <param name="dtEnd">End Date and Time to check.</param>
        /// <returns>A boolean indicating whether there are any conflicts or not.</returns>
        public bool IsConflicting(DateTime dtStart, DateTime dtEnd)
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;

            try
            {
                strSql = "Select Count(*) from [CalendarEvent] WHERE (([StartDateTime] BETWEEN @StartTime AND @EndTime) OR ([EndDateTime] BETWEEN @StartTime AND @EndTime));";

                con = new Connection();
                con.Connect();
                com = new SqlCommand(strSql, con.SQLCon);
                com.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime));
                com.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.DateTime));
                com.Parameters["@StartTime"].Value = dtStart.ToString();
                com.Parameters["@EndTime"].Value = dtEnd.ToString();

                int result = (int)com.ExecuteScalar();

                if (result == 0)
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
        
        public bool UpdateProgramEvent(string field, int eventID, int tableID) {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;

				com.CommandText = "Update Program Set " + field + " = @EventID Where ProgramID=@ID"; ;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));

				com.Parameters["@EventID"].Value = eventID;
				com.Parameters["@ID"].Value = tableID;

				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public bool UpdateClassEvent(string field, int eventID, int tableID) {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try {
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;

				com.CommandText = "Update Course Set " + field + " = @EventID Where CourseID=@ID"; ;
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));
				com.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));

				com.Parameters["@EventID"].Value = eventID;
				com.Parameters["@ID"].Value = tableID;

				com.ExecuteNonQuery();

				return true;
			} catch (SqlException ex) {
				Message = ex.Message;
				return false;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

		public int GetEvent(int eventID, ref string module, ref int eventtypeindex) {
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			SqlDataReader Reader = null;
			int _id = 0;
			try {
				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection = con.SQLCon;

				com.CommandText = "Select CourseID, EventID, " +
					"TestInitialEventID, TestMidtermEventID, " +
					"TestFinalEventID from Course " +
					"Where EventID=@EventID " +
					"or TestInitialEventID=@EventID " +
					"or TestMidTermEventID=@EventID " +
					"or TestFinalEventID=@EventID";
				com.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt));

				com.Parameters["@EventID"].Value = eventID;

				Reader = com.ExecuteReader();
				if (Reader.HasRows) {
					if (Reader.Read()) {
						_id = Convert.ToInt32(Reader["CourseID"].ToString());
						if (Reader["EventID"] != DBNull.Value) {
							if (Convert.ToInt32(Reader["EventID"].ToString()) == eventID) {
								eventtypeindex = 3;
							}
						}
						if (Reader["TestInitialEventID"] != DBNull.Value) {
							if (Convert.ToInt32(Reader["TestInitialEventID"].ToString()) == eventID) {
								eventtypeindex = 0;
							}
						}
						if (Reader["TestMidtermEventID"] != DBNull.Value) {
							if (Convert.ToInt32(Reader["TestMidtermEventID"].ToString()) == eventID) {
								eventtypeindex = 1;
							}
						}
						if (Reader["TestFinalEventID"] != DBNull.Value) {
							if (Convert.ToInt32(Reader["TestFinalEventID"].ToString()) == eventID) {
								eventtypeindex = 2;
							}
						}

					}
				}
				Reader.Close();

				if (_id > 0) {
					module = "Class";
				} 
                else 
                {
					//check program Table
					com.CommandText = "Select ProgramID, " +
						"TestInitialEventID, TestMidtermEventID, " +
						"TestFinalEventID from Program " +
						"Where TestInitialEventID=@EventID " +
						"or TestMidTermEventID=@EventID " +
						"or TestFinalEventID=@EventID";

					Reader = com.ExecuteReader();
					if (Reader.HasRows) {
						if (Reader.Read()) {
							_id = Convert.ToInt32(Reader["ProgramID"].ToString());
							if (Reader["TestInitialEventID"] != DBNull.Value) {
								if (Convert.ToInt32(Reader["TestInitialEventID"].ToString()) == eventID) {
									eventtypeindex = 0;
								}
							}
							if (Reader["TestMidtermEventID"] != DBNull.Value) {
								if (Convert.ToInt32(Reader["TestMidtermEventID"].ToString()) == eventID) {
									eventtypeindex = 1;
								}
							}
							if (Reader["TestFinalEventID"] != DBNull.Value) {
								if (Convert.ToInt32(Reader["TestFinalEventID"].ToString()) == eventID) {
									eventtypeindex = 2;
								}
							}

						}
					}
					Reader.Close();

					if (_id > 0) {
						module = "Program";
					}

				}

				return _id;
			} catch (SqlException ex) {
				Message = ex.Message;
				return 0;
			} finally {
				if (com != null) {
					com.Dispose();
					com = null;
					con.DisConnect();
				}
			}
		}

	}
}