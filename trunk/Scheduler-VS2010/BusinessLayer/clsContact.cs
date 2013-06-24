using System;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsContact.
	/// </summary>
	public class Contact
	{

		private int _contactid=0;
		private string message="";
		private DataTable _dtbl=null;

		public int 		RefID=0;
		public string 	LastName;
		public string 	LastNamePhonetic;
		public string 	LastNameRomaji;
		public string 	FirstName;
		public string 	FirstNamePhonetic;
		public string 	FirstNameRomaji;
		public string 	NickName="";
		public string 	CompanyName;
		public string 	CompanyNamePhonetic;
		public string 	CompanyNameRomaji;
		public string 	TitleForName;
		public string 	TitleForJob;
		public string 	Street1;
		public string 	Street2;
		public string 	Street3;
		public string 	City;
		public string 	State;
		public string 	PostalCode;
		public string 	Country;
		public int	ContactType;
		public string 	BlockCode;
		public string 	Email1;
		public string 	Email2;
		public string 	AccountRepLastName;
		public string 	AccountRepLastNamePhonetic;
		public string 	AccountRepLastNameRomaji;
		public string 	AccountRepFirstName;
		public string 	AccountRepFirstNamePhonetic;
		public string 	AccountRepFirstNameRomaji;
		public string 	Phone1;
		public string 	Phone2;
		public string 	PhoneMobile1;
		public string 	PhoneMobile2;
		public string 	PhoneBusiness1;
		public string 	PhoneBusiness2;
		public string 	PhoneFax1;
		public string 	PhoneFax2;
		public string 	PhoneOther;
		public string 	Url;
		public DateTime	DateBirth;
		public DateTime	DateJoined;
		public DateTime	DateEnded;
		public string	TimeStatus="";
		public string 	Nationality;
		public int	Married;
		public int	NumberDependents;
		public string 	VisaStatus;
		public DateTime	VisaFromDate;
		public DateTime	VisaUntilDate;
		public string 	ClosestStation1;
		public string 	ClosestLine1;
		public int	MinutesToStation1;
		public string 	ClosestStation2;
		public string 	ClosestLine2;
		public int	MinutesToStation2;
		public int	ContactStatus;
        public decimal BaseRate = 0;
		public Contact()
		{
		}

		public int ContactID
		{
			get{return _contactid;}
			set{_contactid=value;}
		}
		public DataTable dtblContacts
		{
			get{return _dtbl;}
			set{_dtbl=value;}
		}
		public string Message
		{
			get{return message;}
			set{message=value;}
		}

		
		public DataTable LoadData(string option)
		{
			string strSql="";
			int contacttypeid=0;
			SqlCommand com=null;
			Connection con=null;
			SqlDataAdapter adpt=null;

		
			if(option=="User") contacttypeid=0;
			if(option=="Instructor") contacttypeid=1;
			if(option=="Client") contacttypeid=2;
			if(option=="Department") contacttypeid=3;
			if(option=="ClientContact") contacttypeid=4;
			if(option=="DepartmentContact") contacttypeid=5;

			if(_dtbl==null)
			{
				_dtbl=new DataTable();
			}
			try
			{
				if(_contactid<=0)
				{
					strSql = "select CASE " +
						"WHEN NickName IS NULL THEN CompanyName " +
						"WHEN NickName = '' THEN CompanyName " +
						"ELSE NickName " +
                        "END AS BrowseName,  " +
						"*,  " +
					"CASE ContactType " +
					"When '0' Then 'User' " +
					"When '1' Then 'Teacher' " +
					"When '2' Then 'Client' " +
					"When '3' Then 'Department' " +
                    "END AS Type, " +
					"CASE ContactStatus " +
					"When '0' Then 'Active' " +
					"When '1' Then 'Inactive' " +
                    "END AS Status, " +
					"CASE Married " +
					"When '0' Then 'Yes' " +
					"When '1' Then 'No' " +
					"ELSE '' " +
                    "END AS MaritalStatus,Email1,Email2,Phone1,Phone2,PhoneMobile1,PhoneMobile2,PhoneBusiness1,PhoneBusiness2, CASE When (AccountRepLastName + ', ' + AccountRepFirstName) <> ', ' Then (AccountRepLastName + ', ' + AccountRepFirstName) Else '' End as  AccRepName " +
					"From Contact ";
					if(option!="Contact")
					{
						strSql += "Where ContactType = " + contacttypeid.ToString() + " ";
						if(RefID>0)
						{
							strSql += "and RefID = " + RefID.ToString() + " ";
						}
					}
					if(option=="Instructor")
					{
						strSql += "Order By LastName, FirstName ";
					}
					else if(option=="Client")
					{
						strSql += "Order By BrowseName ";
					}
					else if(option=="DepartmentContact")
					{
						strSql += "Order By LastName, FirstName ";
					}
					else
					{
						strSql += "Order By ContactID";
					}
				}
				else
				{
					strSql = "select CASE " +
						"WHEN NickName IS NULL THEN CompanyName " +
						"WHEN NickName = '' THEN CompanyName " +
						"ELSE NickName " +
                        "END AS BrowseName,  " +
						"*,  " +
						"CASE ContactType " +
						"When '0' Then 'User' " +
						"When '1' Then 'Teacher' " +
						"When '2' Then 'Client' " +
						"When '3' Then 'Department' " +
                        "END AS Type, " +
						"CASE ContactStatus " +
						"When '0' Then 'Active' " +
						"When '1' Then 'Inactive' " +
                        "END AS Status, " +
						"CASE Married " +
						"When '0' Then 'Yes' " +
						"When '1' Then 'No' " +
						"ELSE '' " +
                        "END AS MaritalStatus, CASE When (AccountRepLastName + ', ' + AccountRepFirstName) <> ', ' Then (AccountRepLastName + ', ' + AccountRepFirstName) Else '' End as  AccRepName " +
						"From Contact " +
						"WHERE ContactID = " + _contactid + " ";
				}

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				adpt=new SqlDataAdapter();
				adpt.SelectCommand = com;
				adpt.Fill(_dtbl);


				if(contacttypeid==2)
				{
					_dtbl.Columns.Add("Contact1", Type.GetType("System.String"));
					_dtbl.Columns.Add("Contact2", Type.GetType("System.String"));
					_dtbl.Columns.Add("Contact1Phone", Type.GetType("System.String"));
					_dtbl.Columns.Add("Contact2Phone", Type.GetType("System.String"));
                    
					//Get the contacts
					int contid=0;
					string contact1="";
					string contact2="";
					string phone1="";
					string phone2="";
					foreach(DataRow dr in _dtbl.Rows)
					{
						contid=0;
						contact1="";
						contact2="";
						phone1="";
						phone2="";
						contid=Convert.ToInt32(dr["ContactID"].ToString());				
						GetContact(contid, ref contact1, ref contact2, ref phone1, ref phone2);
						dr["Contact1"] = contact1;
						dr["Contact2"] = contact2;
						dr["Contact1Phone"] = phone1;
						dr["Contact2Phone"] = phone2;
						dr.AcceptChanges();
					}
				}
				
				return _dtbl;
			}
			catch(SqlException ex)
			{
				Message=ex.Message;				
				return null;
			}
			finally
			{
				if(com!=null)
				{
					com.Dispose();
					com=null;
					con.DisConnect();
					adpt.Dispose();
					adpt=null;
				}
			}
		}

		private bool GetContact(int mclientid, ref string contact1, ref string contact2, ref string phone1, ref string phone2)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Top 2 LastName + ', ' + FirstName As ContactName, Phone1 From Contact Where ContactType=4 AND RefID=" + mclientid.ToString() + " Order by ContactID";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				SqlDataReader Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					if(contact1=="")
					{
						contact1 = Reader["ContactName"].ToString();
						phone1 = Reader["Phone1"].ToString();
					}
					else
					{
						contact2 = Reader["ContactName"].ToString();
						phone2 = Reader["Phone1"].ToString();
					}
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
			string sql="";
			SqlCommand com=null;
			Connection con=null;
			SqlDataReader Reader=null;

			try
			{
				sql = "Insert into [Contact] (";
				sql += "RefID, ";
				sql += "LastName, ";
				sql += "LastNamePhonetic, ";
				sql += "LastNameRomaji, ";
				sql += "FirstName, ";
				sql += "FirstNamePhonetic, ";
				sql += "FirstNameRomaji, ";
				sql += "NickName, ";
				sql += "CompanyName, ";
				sql += "CompanyNamePhonetic, ";
				sql += "CompanyNameRomaji, ";
				sql += "TitleForName, ";
				sql += "TitleForJob, ";
				sql += "Street1, ";
				sql += "Street2, ";
				sql += "Street3, ";
				sql += "City, ";
				sql += "State, ";
				sql += "PostalCode, ";
				sql += "Country, ";
				sql += "ContactType, ";
				sql += "BlockCode, ";
				sql += "Email1, ";
				sql += "Email2, ";
				sql += "AccountRepLastName, ";
				sql += "AccountRepLastNamePhonetic, ";
				sql += "AccountRepLastNameRomaji, ";
				sql += "AccountRepFirstName, ";
				sql += "AccountRepFirstNamePhonetic, ";
				sql += "AccountRepFirstNameRomaji, ";
				sql += "Phone1, ";
				sql += "Phone2, ";
				sql += "PhoneMobile1, ";
				sql += "PhoneMobile2, ";
				sql += "PhoneBusiness1, ";
				sql += "PhoneBusiness2, ";
				sql += "PhoneFax1, ";
				sql += "PhoneFax2, ";
				sql += "PhoneOther, ";
				sql += "Url, ";
				sql += "DateBirth, ";
				sql += "DateJoined, ";
				sql += "DateEnded, ";
				sql += "TimeStatus, ";
				sql += "Nationality, ";
				sql += "Married, ";
				sql += "NumberDependents, ";
				sql += "VisaStatus, ";
				sql += "VisaFromDate, ";
				sql += "VisaUntilDate, ";
				sql += "ClosestStation1, ";
				sql += "ClosestLine1, ";
				sql += "MinutesToStation1, ";
				sql += "ClosestStation2, ";
				sql += "ClosestLine2, ";
				sql += "MinutesToStation2, ";
				sql += "ContactStatus, ";
				sql += "CreatedByUserId, ";
				sql += "DateCreated, ";
				sql += "DateLastModified, ";
				sql += "LastModifiedByUserID, ";
                sql += "BasePayField ";
				sql += ")";
				sql += "Values( ";
				sql += "@RefID, ";
				sql += "@LastName, ";
				sql += "@LastNamePhonetic, ";
				sql += "@LastNameRomaji, ";
				sql += "@FirstName, ";
				sql += "@FirstNamePhonetic, ";
				sql += "@FirstNameRomaji, ";
				sql += "@NickName, ";
				sql += "@CompanyName, ";
				sql += "@CompanyNamePhonetic, ";
				sql += "@CompanyNameRomaji, ";
				sql += "@TitleForName, ";
				sql += "@TitleForJob, ";
				sql += "@Street1, ";
				sql += "@Street2, ";
				sql += "@Street3, ";
				sql += "@City, ";
				sql += "@State, ";
				sql += "@PostalCode, ";
				sql += "@Country, ";
				sql += "@ContactType, ";
				sql += "@BlockCode, ";
				sql += "@Email1, ";
				sql += "@Email2, ";
				sql += "@AccountRepLastName, ";
				sql += "@AccountRepLastNamePhonetic, ";
				sql += "@AccountRepLastNameRomaji, ";
				sql += "@AccountRepFirstName, ";
				sql += "@AccountRepFirstNamePhonetic, ";
				sql += "@AccountRepFirstNameRomaji, ";
				sql += "@Phone1, ";
				sql += "@Phone2, ";
				sql += "@PhoneMobile1, ";
				sql += "@PhoneMobile2, ";
				sql += "@PhoneBusiness1, ";
				sql += "@PhoneBusiness2, ";
				sql += "@PhoneFax1, ";
				sql += "@PhoneFax2, ";
				sql += "@PhoneOther, ";
				sql += "@Url, ";
				sql += "@DateBirth, ";
				sql += "@DateJoined, ";
				sql += "@DateEnded, ";
				sql += "@TimeStatus, ";
				sql += "@Nationality, ";
				sql += "@Married, ";
				sql += "@NumberDependents, ";
				sql += "@VisaStatus, ";
				sql += "@VisaFromDate, ";
				sql += "@VisaUntilDate, ";
				sql += "@ClosestStation1, ";
				sql += "@ClosestLine1, ";
				sql += "@MinutesToStation1, ";
				sql += "@ClosestStation2, ";
				sql += "@ClosestLine2, ";
				sql += "@MinutesToStation2, ";
				sql += "@ContactStatus, ";
				sql += "@CreatedByUserId, ";
				sql += "@DateCreated, ";
				sql += "@DateLastModified, ";
				sql += "@LastModifiedByUserID, ";
                sql += "@BasePayField ";
				sql += ") ";
				sql += "SELECT @@IDENTITY";


				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add(new SqlParameter("@RefID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@LastNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@LastNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TitleForName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TitleForJob", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street3", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@State", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@BlockCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Email1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Email2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneMobile1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneMobile2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneBusiness1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneBusiness2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneFax1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneFax2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneOther", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@DateBirth", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateJoined", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateEnded", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@TimeStatus", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Married", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@NumberDependents", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@VisaFromDate", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@VisaUntilDate", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@ClosestStation1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ClosestLine1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@MinutesToStation1", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ClosestStation2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ClosestLine2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@MinutesToStation2", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ContactStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@CreatedByUserId", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@BasePayField", SqlDbType.Decimal));


				com.Parameters["@RefID"].Value = RefID;
				com.Parameters["@LastName"].Value = LastName;
				com.Parameters["@LastNamePhonetic"].Value = LastNamePhonetic;
				com.Parameters["@LastNameRomaji"].Value = LastNameRomaji;
				com.Parameters["@FirstName"].Value = FirstName;
				com.Parameters["@FirstNamePhonetic"].Value = FirstNamePhonetic;
				com.Parameters["@FirstNameRomaji"].Value = FirstNameRomaji;
				com.Parameters["@NickName"].Value = NickName;
				com.Parameters["@CompanyName"].Value = CompanyName;
				com.Parameters["@CompanyNamePhonetic"].Value = CompanyNamePhonetic;
				com.Parameters["@CompanyNameRomaji"].Value = CompanyNameRomaji;
				com.Parameters["@TitleForName"].Value = TitleForName;
				com.Parameters["@TitleForJob"].Value = TitleForJob;
				com.Parameters["@Street1"].Value = Street1;
				com.Parameters["@Street2"].Value = Street2;
				com.Parameters["@Street3"].Value = Street3;
				com.Parameters["@City"].Value = City;
				com.Parameters["@State"].Value = State;
				com.Parameters["@PostalCode"].Value = PostalCode;
				com.Parameters["@Country"].Value = Country;
				com.Parameters["@ContactType"].Value = ContactType;
				com.Parameters["@BlockCode"].Value = BlockCode;
				com.Parameters["@Email1"].Value = Email1;
				com.Parameters["@Email2"].Value = Email2;
				com.Parameters["@AccountRepLastName"].Value = AccountRepLastName;
				com.Parameters["@AccountRepLastNamePhonetic"].Value = AccountRepLastNamePhonetic;
				com.Parameters["@AccountRepLastNameRomaji"].Value = AccountRepLastNameRomaji;
				com.Parameters["@AccountRepFirstName"].Value = AccountRepFirstName;
				com.Parameters["@AccountRepFirstNamePhonetic"].Value = AccountRepFirstNamePhonetic;
				com.Parameters["@AccountRepFirstNameRomaji"].Value = AccountRepFirstNameRomaji;
				com.Parameters["@Phone1"].Value = Phone1;
				com.Parameters["@Phone2"].Value = Phone2;
				com.Parameters["@PhoneMobile1"].Value = PhoneMobile1;
				com.Parameters["@PhoneMobile2"].Value = PhoneMobile2;
				com.Parameters["@PhoneBusiness1"].Value = PhoneBusiness1;
				com.Parameters["@PhoneBusiness2"].Value = PhoneBusiness2;
				com.Parameters["@PhoneFax1"].Value = PhoneFax1;
				com.Parameters["@PhoneFax2"].Value = PhoneFax2;
				com.Parameters["@PhoneOther"].Value = PhoneOther;
				com.Parameters["@Url"].Value = Url;
                
				if(DateBirth==Convert.ToDateTime(null))
					com.Parameters["@DateBirth"].Value = DBNull.Value;
				else
					com.Parameters["@DateBirth"].Value = DateBirth;

				if(DateJoined==Convert.ToDateTime(null))
					com.Parameters["@DateJoined"].Value = DBNull.Value;
				else
					com.Parameters["@DateJoined"].Value = DateJoined;

				if(DateEnded==Convert.ToDateTime(null))
					com.Parameters["@DateEnded"].Value = DBNull.Value;
				else			
					com.Parameters["@DateEnded"].Value = DateEnded;
				
				com.Parameters["@TimeStatus"].Value = TimeStatus;
				com.Parameters["@Nationality"].Value = Nationality;
				com.Parameters["@Married"].Value = Married;
				com.Parameters["@NumberDependents"].Value = NumberDependents;
				com.Parameters["@VisaStatus"].Value = VisaStatus;

				if(VisaFromDate==Convert.ToDateTime(null))
					com.Parameters["@VisaFromDate"].Value = DBNull.Value;
				else
					com.Parameters["@VisaFromDate"].Value = VisaFromDate;

				if(VisaUntilDate==Convert.ToDateTime(null))
					com.Parameters["@VisaUntilDate"].Value = DBNull.Value;
				else
					com.Parameters["@VisaUntilDate"].Value = VisaUntilDate;

				com.Parameters["@ClosestStation1"].Value = ClosestStation1;
				com.Parameters["@ClosestLine1"].Value = ClosestLine1;
				com.Parameters["@MinutesToStation1"].Value =MinutesToStation1;
				com.Parameters["@ClosestStation2"].Value = ClosestStation2;
				com.Parameters["@ClosestLine2"].Value = ClosestLine2;
				com.Parameters["@MinutesToStation2"].Value = MinutesToStation2;
				com.Parameters["@ContactStatus"].Value = ContactStatus;
				com.Parameters["@CreatedByUserId"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;
				com.Parameters["@BasePayField"].Value = BaseRate;
				Reader = com.ExecuteReader();
				if(Reader.Read())
				{
					_contactid = Convert.ToInt32(Reader[0].ToString());
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
				if(Reader!=null)
				{
					if(Reader.IsClosed==false)
					{
						Reader.Close();
						Reader=null;
					}
				}
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
			string sql="";
			SqlCommand com=null;
			Connection con=null;

			try
			{
				sql = "Update [Contact] Set ";
				sql += "LastName=@LastName, ";
				sql += "LastNamePhonetic=@LastNamePhonetic, ";
				sql += "LastNameRomaji=@LastNameRomaji, ";
				sql += "FirstName=@FirstName, ";
				sql += "FirstNamePhonetic=@FirstNamePhonetic, ";
				sql += "FirstNameRomaji=@FirstNameRomaji, ";
				sql += "NickName=@NickName, ";
				sql += "CompanyName=@CompanyName, ";
				sql += "CompanyNamePhonetic=@CompanyNamePhonetic, ";
				sql += "CompanyNameRomaji=@CompanyNameRomaji, ";
				sql += "TitleForName=@TitleForName, ";
				sql += "TitleForJob=@TitleForJob, ";
				sql += "Street1=@Street1, ";
				sql += "Street2=@Street2, ";
				sql += "Street3=@Street3, ";
				sql += "City=@City, ";
				sql += "State=@State, ";
				sql += "PostalCode=@PostalCode, ";
				sql += "Country=@Country, ";
				sql += "ContactType=@ContactType, ";
				sql += "BlockCode=@BlockCode, ";
				sql += "Email1=@Email1, ";
				sql += "Email2=@Email2, ";
				sql += "AccountRepLastName=@AccountRepLastName, ";
				sql += "AccountRepLastNamePhonetic=@AccountRepLastNamePhonetic, ";
				sql += "AccountRepLastNameRomaji=@AccountRepLastNameRomaji, ";
				sql += "AccountRepFirstName=@AccountRepFirstName, ";
				sql += "AccountRepFirstNamePhonetic=@AccountRepFirstNamePhonetic, ";
				sql += "AccountRepFirstNameRomaji=@AccountRepFirstNameRomaji, ";
				sql += "Phone1=@Phone1, ";
				sql += "Phone2=@Phone2, ";
				sql += "PhoneMobile1=@PhoneMobile1, ";
				sql += "PhoneMobile2=@PhoneMobile2, ";
				sql += "PhoneBusiness1=@PhoneBusiness1, ";
				sql += "PhoneBusiness2=@PhoneBusiness2, ";
				sql += "PhoneFax1=@PhoneFax1, ";
				sql += "PhoneFax2=@PhoneFax2, ";
				sql += "PhoneOther=@PhoneOther, ";
				sql += "Url=@Url, ";
				sql += "DateBirth=@DateBirth, ";
				sql += "DateJoined=@DateJoined, ";
				sql += "DateEnded=@DateEnded, ";
				sql += "TimeStatus=@TimeStatus, ";
				sql += "Nationality=@Nationality, ";
				sql += "Married=@Married, ";
				sql += "NumberDependents=@NumberDependents, ";
				sql += "VisaStatus=@VisaStatus, ";
				sql += "VisaFromDate=@VisaFromDate, ";
				sql += "VisaUntilDate=@VisaUntilDate, ";
				sql += "ClosestStation1=@ClosestStation1, ";
				sql += "ClosestLine1=@ClosestLine1, ";
				sql += "MinutesToStation1=@MinutesToStation1, ";
				sql += "ClosestStation2=@ClosestStation2, ";
				sql += "ClosestLine2=@ClosestLine2, ";
				sql += "MinutesToStation2=@MinutesToStation2, ";
				sql += "ContactStatus=@ContactStatus, ";
				sql += "DateLastModified=@DateLastModified, "; 
				sql += "LastModifiedByUserID=@LastModifiedByUserID, ";
                sql += "BasePayField=@BasePayField ";
				sql += "WHERE ContactID=@ContactID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@LastNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@LastNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@FirstNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@CompanyNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TitleForName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@TitleForJob", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Street3", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@State", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@BlockCode", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Email1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Email2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepLastNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstName", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstNamePhonetic", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@AccountRepFirstNameRomaji", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneMobile1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneMobile2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneBusiness1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneBusiness2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneFax1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneFax2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@PhoneOther", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@DateBirth", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateJoined", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateEnded", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@TimeStatus", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@Married", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@NumberDependents", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@VisaFromDate", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@VisaUntilDate", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@ClosestStation1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ClosestLine1", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@MinutesToStation1", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ClosestStation2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@ClosestLine2", SqlDbType.NVarChar));
				com.Parameters.Add(new SqlParameter("@MinutesToStation2", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@ContactStatus", SqlDbType.Int));
				com.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@DateLastModified", SqlDbType.DateTime));
				com.Parameters.Add(new SqlParameter("@LastModifiedByUserID", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@BasePayField", SqlDbType.Decimal));

				com.Parameters["@ContactID"].Value = _contactid;
				com.Parameters["@LastName"].Value = LastName;
				com.Parameters["@LastNamePhonetic"].Value = LastNamePhonetic;
				com.Parameters["@LastNameRomaji"].Value = LastNameRomaji;
				com.Parameters["@FirstName"].Value = FirstName;
				com.Parameters["@FirstNamePhonetic"].Value = FirstNamePhonetic;
				com.Parameters["@FirstNameRomaji"].Value = FirstNameRomaji;
				com.Parameters["@NickName"].Value = NickName;
				com.Parameters["@CompanyName"].Value = CompanyName;
				com.Parameters["@CompanyNamePhonetic"].Value = CompanyNamePhonetic;
				com.Parameters["@CompanyNameRomaji"].Value = CompanyNameRomaji;
				com.Parameters["@TitleForName"].Value = TitleForName;
				com.Parameters["@TitleForJob"].Value = TitleForJob;
				com.Parameters["@Street1"].Value = Street1;
				com.Parameters["@Street2"].Value = Street2;
				com.Parameters["@Street3"].Value = Street3;
				com.Parameters["@City"].Value = City;
				com.Parameters["@State"].Value = State;
				com.Parameters["@PostalCode"].Value = PostalCode;
				com.Parameters["@Country"].Value = Country;
				com.Parameters["@ContactType"].Value = ContactType;
				com.Parameters["@BlockCode"].Value = BlockCode;
				com.Parameters["@Email1"].Value = Email1;
				com.Parameters["@Email2"].Value = Email2;
				com.Parameters["@AccountRepLastName"].Value = AccountRepLastName;
				com.Parameters["@AccountRepLastNamePhonetic"].Value = AccountRepLastNamePhonetic;
				com.Parameters["@AccountRepLastNameRomaji"].Value = AccountRepLastNameRomaji;
				com.Parameters["@AccountRepFirstName"].Value = AccountRepFirstName;
				com.Parameters["@AccountRepFirstNamePhonetic"].Value = AccountRepFirstNamePhonetic;
				com.Parameters["@AccountRepFirstNameRomaji"].Value = AccountRepFirstNameRomaji;
				com.Parameters["@Phone1"].Value = Phone1;
				com.Parameters["@Phone2"].Value = Phone2;
				com.Parameters["@PhoneMobile1"].Value = PhoneMobile1;
				com.Parameters["@PhoneMobile2"].Value = PhoneMobile2;
				com.Parameters["@PhoneBusiness1"].Value = PhoneBusiness1;
				com.Parameters["@PhoneBusiness2"].Value = PhoneBusiness2;
				com.Parameters["@PhoneFax1"].Value = PhoneFax1;
				com.Parameters["@PhoneFax2"].Value = PhoneFax2;
				com.Parameters["@PhoneOther"].Value = PhoneOther;
				com.Parameters["@Url"].Value = Url;
				if(DateBirth==Convert.ToDateTime(null))
					com.Parameters["@DateBirth"].Value = System.DBNull.Value;
				else
					com.Parameters["@DateBirth"].Value = DateBirth;

				if(DateJoined==Convert.ToDateTime(null))
					com.Parameters["@DateJoined"].Value = System.DBNull.Value;
				else
					com.Parameters["@DateJoined"].Value = DateJoined;

				if(DateEnded==Convert.ToDateTime(null))
					com.Parameters["@DateEnded"].Value = System.DBNull.Value;
				else
					com.Parameters["@DateEnded"].Value = DateEnded;

				com.Parameters["@TimeStatus"].Value = TimeStatus;
				com.Parameters["@Nationality"].Value = Nationality;
				com.Parameters["@Married"].Value = Married;
				com.Parameters["@NumberDependents"].Value = NumberDependents;
				com.Parameters["@VisaStatus"].Value = VisaStatus;

				if(VisaFromDate==Convert.ToDateTime(null))
					com.Parameters["@VisaFromDate"].Value = System.DBNull.Value;
				else
					com.Parameters["@VisaFromDate"].Value = VisaFromDate;

				if(VisaUntilDate==Convert.ToDateTime(null))
					com.Parameters["@VisaUntilDate"].Value = System.DBNull.Value;
				else
					com.Parameters["@VisaUntilDate"].Value = VisaUntilDate;

				com.Parameters["@ClosestStation1"].Value = ClosestStation1;
				com.Parameters["@ClosestLine1"].Value = ClosestLine1;
				com.Parameters["@MinutesToStation1"].Value =MinutesToStation1;
				com.Parameters["@ClosestStation2"].Value = ClosestStation2;
				com.Parameters["@ClosestLine2"].Value = ClosestLine2;
				com.Parameters["@MinutesToStation2"].Value = MinutesToStation2;
				com.Parameters["@ContactStatus"].Value = ContactStatus;
				com.Parameters["@DateCreated"].Value = DateTime.Now;
				com.Parameters["@DateLastModified"].Value = DateTime.Now;
				com.Parameters["@LastModifiedByUserID"].Value = Scheduler.BusinessLayer.Common.LogonID;
                com.Parameters["@BasePayField"].Value = BaseRate;
				
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
				strSql =  "Delete From [Contact] " +
					"WHERE ContactID=@ContactID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int));
				com.Parameters["@ContactID"].Value = _contactid;
				com.ExecuteNonQuery();

				strSql = "Delete from contact where RefID=@ContactID AND ContactType=4";
				com.Parameters["@ContactID"].Value = _contactid;
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

		public static int CloneData(int contactid)
		{
			string strSql = "";
			SqlCommand com = null;
			Connection con = null;
			try
			{
				strSql = "usp_ContactClone";

				con = new Connection();
				con.Connect();
				com = new SqlCommand();
				com.CommandType = CommandType.StoredProcedure;
				com.Connection = con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("ContactID", SqlDbType.Int));
				com.Parameters["ContactID"].Value = contactid;
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
		public bool Exists()
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE LastName=@LastName and FirstName=@FirstName";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
				com.Parameters["@LastName"].Value = LastName;

				com.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
				com.Parameters["@FirstName"].Value = FirstName;

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

		public bool Exists(string strComp, int ContactType)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE CompanyName=@CompanyName AND ContactType=@ContactType";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters["@CompanyName"].Value = strComp;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;

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

		public bool NickNameExists(string strComp, int ContactType)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE NickName=@CompanyName AND ContactType=@ContactType";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters["@CompanyName"].Value = strComp;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;

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

		public bool Exists(string FirstName, string LastName, int ContactType)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE LastName=@LastName and FirstName=@FirstName And ContactType=@ContactType and ContactID<>" + _contactid + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
				com.Parameters["@LastName"].Value = LastName;

				com.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
				com.Parameters["@FirstName"].Value = FirstName;

				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;

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

		public bool Exists(string strComp, int ClientID, int ContactType)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) as cnt From [Contact] C, Department D " +
						  "Where C.ContactID=D.ContactID and " +
						  "C.ContactType=@ContactType and " +
						  "C.CompanyName=@CompanyName and " +
						  "D.ClientID=@ClientID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters["@CompanyName"].Value = strComp;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;
				com.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.BigInt));
				com.Parameters["@ClientID"].Value = ClientID;

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

		public bool NickNameExists(string strComp, int ClientID, int ContactType)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) as cnt From [Contact] C, Department D " +
					"Where C.ContactID=D.ContactID and " +
					"C.ContactType=@ContactType and " +
					"C.NickName=@CompanyName and " +
					"D.ClientID=@ClientID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar));
				com.Parameters["@CompanyName"].Value = strComp;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;
				com.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.BigInt));
				com.Parameters["@ClientID"].Value = ClientID;

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

		public bool ContactExists(string fname, string lname)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE FirstName=@FName AND LastName=@LName AND ContactType=@ContactType";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
				com.Parameters["@FName"].Value = fname;
				com.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
				com.Parameters["@LName"].Value = lname;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;

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

		public bool ContactExists(int refid, string fname, string lname)
		{
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				strSql =  "Select Count(*) From [Contact] " +
					"WHERE FirstName=@FName AND LastName=@LName AND ContactType=@ContactType and RefID=@RefID ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;

				com.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
				com.Parameters["@FName"].Value = fname;
				com.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
				com.Parameters["@LName"].Value = lname;
				com.Parameters.Add(new SqlParameter("@ContactType", SqlDbType.NVarChar));
				com.Parameters["@ContactType"].Value = ContactType;
				com.Parameters.Add(new SqlParameter("@RefID", SqlDbType.Int));
				com.Parameters["@RefID"].Value = refid;

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

		public bool UpdateRefID(int randomno)
		{
			string sql="";
			SqlCommand com=null;
			Connection con=null;

			try
			{
				sql = "Update [Contact] Set RefID=" + RefID.ToString() + " Where RefID=" + randomno.ToString() + " ";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

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

        public void DeleteContactFromProgram()
        {
            string strSql = "";
            SqlCommand com = null;
            Connection con = null;
            try
            {
                strSql = "Update [Program] SET Contact1ID=0 WHERE Contact1ID=@ContactID;";
                strSql += "Update [Program] SET Contact2ID=0 WHERE Contact2ID=@ContactID;";

                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = strSql;

                com.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int));
                com.Parameters["@ContactID"].Value = _contactid;
                com.ExecuteNonQuery();
                /*
                strSql = "Delete from contact where RefID=@ContactID AND ContactType=4";
                com.Parameters["@ContactID"].Value = _contactid;
                com.CommandText = strSql;
                com.ExecuteNonQuery();
                */
                return;
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
	}
}

/*
 * 
 * Alphabetically sort all Listviews by the main item name:

Users - Last name field, then by First Name field
Instructors - Last Name field, then by First Name field
Client - by Client Abbreviated Name (or by Client name if Abbreviated name is not defined)
Department - by Department Abbreviated Name (or by Department name if Abbreviated name is not defined)
Program - by Program Abbreviated Name (or by Program name if Abbreviated name is not defined)
Class - by Class Abbreviated Name (or by Class name if Abbreviated name is not defined)
Event - by Class Abbreviated Name (or by Class name if Abbreviated name is not defined)

ALSO, please sort all items in all dropdowns (on many dialogs) by alphabetical order according to the above rules for each object type.  For instance, on the Scheduled and Real Instructor combo box drop down on the Event Dialog, refer to the above rule for Instructor order - Last Name field, then by First Name field.
*/
