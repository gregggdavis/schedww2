using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsCommon.
	/// </summary>
	public class Common
	{

		[DllImport("user32.dll",EntryPoint="LockWindowUpdate")]
		private static extern bool LockWindowUpdate(IntPtr hWnd);

		private static string strCaption;
		private static string mConnString;
		private static string mConnString1;
		private static string mSqlServer;
		private static string mDatabasePwd;

		private static int mLogonID;
		private static string mLogonCode;
		private static string mLogonName;
		private static DateTime mLogonDate;
		private static int mLogonType;

		private static string mFontName="";
		private static float mFontSize=10;

		private static string mShortVersionInfo;

		public Common()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string Caption
		{
			get{return strCaption;}
			set{strCaption=value;}
		}
		public static string ConnString
		{
			get
            {return mConnString;}
			set{mConnString=value;
            DAC.ConnectionString = value;
        }
		}
		public static string ConnString1
		{
			get{return mConnString1;}
			set{mConnString1=value;}
		}
		public static string SqlServer
		{
			get{return mSqlServer;}
			set{mSqlServer=value;}
		}
		public static string DBPassword
		{
			get{return mDatabasePwd;}
			set{mDatabasePwd=value;}
		}

		public static int LogonID
		{
			get{return mLogonID;}
			set{mLogonID=value;}
		}
		public static string LogonUser
		{
			get{return mLogonCode;}
			set{mLogonCode=value;}
		}
		public static string LogonName
		{
			get{return mLogonName;}
			set{mLogonName=value;}
		}
		public static DateTime LogonDate
		{
			get{return mLogonDate;}
			set{mLogonDate=value;}
		}
		public static int LogonType
		{
			get{return mLogonType;}
			set{mLogonType=value;}
		}

		public static string ShortVersionInfo
		{
			get{return mShortVersionInfo;}
			set{mShortVersionInfo=value;}
		}
		public static string FontName
		{
			get{return mFontName;}
			set{mFontName=value;}
		}
		public static float FontSize
		{
			get{return mFontSize;}
			set{mFontSize=value;}
		}

		public static string ReadFromRegistry(RegistryKey RegHive, string RegPath, string KeyName)
		{
			string[] regStrings;
			string result = "";
			regStrings = RegPath.Split(new char[1]{'\\'});

			RegistryKey[] RegKey;
			RegKey = new RegistryKey[regStrings.Length + 1];
			RegKey[0] = RegHive;
			for(int i=0; i<regStrings.Length; i++)
			{
				RegKey[i + 1] = RegKey[i].OpenSubKey(regStrings[i]);
				if (i == regStrings.Length - 1)
				{
					if (RegKey[i + 1] == null)
						result = "";
					else
						result = RegKey[i + 1].GetValue(KeyName).ToString();
				}
			}
			return result;
		}

		public static void WriteToRegistry(RegistryKey RegHive, string RegPath, string KeyName, string KeyValue)
		{
			//Split the registry path 
			string[] regStrings;
			regStrings = RegPath.Split(new char[1]{'\\'});
			//First item of array will be the base key, so be carefull iterating below
			RegistryKey[] RegKey;
			RegKey = new RegistryKey[regStrings.Length + 1];
			RegKey[0] = RegHive;

			for(int i=0; i<regStrings.Length;i++)
			{
				RegKey[i + 1] = RegKey[i].OpenSubKey(regStrings[i], true);
				//If key does not exist, create it
				if(RegKey[i + 1] == null)
				{
					RegKey[i + 1] = RegKey[i].CreateSubKey(regStrings[i]);
				}
				//Write the value to the registry
				RegKey[regStrings.Length].SetValue(KeyName, KeyValue);
			}
		}

		public static void LockWindow(IntPtr hWnd)
		{
			LockWindowUpdate(hWnd);
		}
		public static void UnLockWindow()
		{
			LockWindowUpdate(IntPtr.Zero);
		}

		public static string DoubleAmpersand(string strPara)
		{
			string strVar,strXar;
			int intCtr;
			strVar = "";
			for (intCtr=0; intCtr<=(strPara.Length-1); intCtr++)
			{
				strXar = strPara.Substring(intCtr,1);
				if (strXar == "&")
					strVar = strVar + "&";
				strVar = strVar + strXar;
			}

			return strVar;
		}

		public static bool PopulateDropdown(ComboBox cb, string sql)
		{
			SqlDataReader Reader=null;
			SqlCommand com=null;
			Connection con=null;

			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;
				Reader = com.ExecuteReader();
                
				cb.Items.Clear();
				cb.Items.Add("");
				while(Reader.Read())
				{
					if(Reader[0].ToString().Trim()!="")
					{
						cb.Items.Add(Reader[0].ToString());
					}
				}
				Reader.Close();
				return true;
			}
			catch
			{
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

        public static bool PopulateDropdownWithValue(ComboBox cb, string sql)
        {
            SqlDataReader Reader = null;
            SqlCommand com = null;
            Connection con = null;

            try
            {
                con = new Connection();
                con.Connect();
                com = new SqlCommand();
                com.Connection = con.SQLCon;
                com.CommandText = sql;
                Reader = com.ExecuteReader();

                cb.Items.Clear();
                cb.Items.Add(new ValuePair("",""));
                while (Reader.Read())
                    if (Reader[1].ToString().Trim() != "")
                        cb.Items.Add(new ValuePair(Reader[1].ToString(),Reader[0].ToString()));

                Reader.Close();
                cb.DisplayMember = "Name";
                cb.ValueMember = "Value";
                cb.SelectedIndex = 0;

                return true;
            }
            catch
            {
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

        public static int GetID(string sql)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;
				object o = com.ExecuteScalar();
				if(o!=null)
				{
					intID = Convert.ToInt32(o);
				}
				return intID;
			}
			catch
			{
				return 0;
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

		public static string GetString(string sql)
		{
			string strReturn="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;
				object o = com.ExecuteScalar();
				if(o!=null)
				{
					strReturn = o.ToString();
				}
				return strReturn;
			}
			catch
			{
				return strReturn;
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

		public static int GetID(string sql, string Value)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql + "'" + Value + "'";
				object o = com.ExecuteScalar();
				if(o!=null)
				{
					intID = Convert.ToInt32(o);
				}
				return intID;
			}
			catch
			{
				return 0;
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

		public static int GetProgramID(string sql, string Value)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@Name", SqlDbType.NVarChar);
				com.Parameters["@Name"].Value = Value;

				object o = com.ExecuteScalar();
				if(o!=null)
				{
					intID = Convert.ToInt32(o);
				}
				return intID;
			}
			catch
			{
				return 0;
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

		public static int GetCompanyID(string sql, string Value)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
				com.Parameters["@CompanyName"].Value = Value;

				object o = com.ExecuteScalar();
				if(o!=null)
				{
					intID = Convert.ToInt32(o);
				}
				return intID;
			}
			catch
			{
				return 0;
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

		public static int GetTeacherID(string sql, string Value1, string Value2)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@FirstName", SqlDbType.NVarChar);
				com.Parameters["@FirstName"].Value = Value1;
				com.Parameters.Add("@LastName", SqlDbType.NVarChar);
				com.Parameters["@LastName"].Value = Value2;

				object o = com.ExecuteScalar();
				if(o!=null)
				{
					intID = Convert.ToInt32(o);
				}
				return intID;
			}
			catch
			{
				return 0;
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

		public static int GetContactID(string sql, string Value1, string Value2)
		{
			int intID=0;
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@FName", SqlDbType.NVarChar);
				com.Parameters["@FName"].Value = Value1;
				com.Parameters.Add("@LName", SqlDbType.NVarChar);
				com.Parameters["@LName"].Value = Value2;

				SqlDataReader Reader=com.ExecuteReader();
				if(Reader.Read())
				{
					intID = Convert.ToInt32(Reader["ContactID"].ToString());
				}
				Reader.Close();
				return intID;
			}
			catch
			{
				return 0;
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

		public static string GetCompanyName(string sql, int Value)
		{
			string str="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@ContactID", SqlDbType.BigInt);
				com.Parameters["@ContactID"].Value = Value;

				object o = com.ExecuteScalar();
				if(o!=null)
				{
					str = Convert.ToString(o);
				}
				return str;
			}
			catch
			{
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

		public static string GetShortVersionInfo()
		{
			try
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				AssemblyName assemblyname = assembly.GetName();
				
				string strVersion = "Version " + assemblyname.Version.Major.ToString() + "." +
					assemblyname.Version.Minor.ToString() + "." +
					assemblyname.Version.Build .ToString(); // + "." +
					//assemblyname.Version.Revision.ToString();
				mShortVersionInfo = strVersion;
				return strVersion;
			}
			catch
			{
				return "";
			}
		}

		public static void MaskInteger(KeyPressEventArgs e)
		{
			if((Char.IsDigit(e.KeyChar)) || (Convert.ToByte(e.KeyChar)==8)) 
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;;
			}
		}

		public static bool IsBlankDate(DateTime dt)
		{

			return false;
		}

		public static DateTime GetDate(string day, string month, string year)
		{
			return new DateTime(Convert.ToInt16(year), Convert.ToInt16(month), Convert.ToInt16(day));
		}

		public static void MakeReadOnly(Control ParentControl, bool boolSelfOnly)
		{
			int intChildCount = ParentControl.Controls.Count;
			int intChildIndex;
			string strChildName;
			string strControlType;

			//*****************************//
			if (boolSelfOnly)
			{
				string strParentName = ParentControl.Name;
				if ((strParentName != "")&&(ParentControl.Enabled))
				{
					strControlType = ParentControl.GetType().Name;

					if (strControlType=="TextBox")
					{
						TextBox txt_temp = ParentControl as TextBox;
						txt_temp.ReadOnly = true;
						ParentControl = txt_temp;
					}
					if (strControlType=="RichTextBox")
					{
						System.Windows.Forms.RichTextBox txt_temp = ParentControl as System.Windows.Forms.RichTextBox;
						txt_temp.ReadOnly = true;
						txt_temp.BackColor = SystemColors.Control;
						ParentControl = txt_temp;
					}
					if (strControlType=="CheckedListBox")
					{
						System.Windows.Forms.CheckedListBox cbx_temp = ParentControl as System.Windows.Forms.CheckedListBox;
						cbx_temp.SelectionMode = SelectionMode.None;
						cbx_temp.BackColor = SystemColors.Control;
						ParentControl = cbx_temp;
					}
					if (strControlType=="ComboBox")
					{
						ComboBox cmb_temp = ParentControl as ComboBox;
						cmb_temp.Enabled = false;
						ParentControl = cmb_temp;
					}
					if (strControlType=="CheckBox")
					{
						System.Windows.Forms.CheckBox cbx_temp = ParentControl as System.Windows.Forms.CheckBox;
						cbx_temp.Enabled = false;
						ParentControl = cbx_temp;
					}
					if (strControlType=="DateTimePicker")
					{
						DateTimePicker cbx_temp = ParentControl as DateTimePicker;
						cbx_temp.Enabled = false;
						ParentControl = cbx_temp;
					}
					if (strControlType=="LinkLabel")
					{
						LinkLabel cbx_temp = ParentControl as LinkLabel;
						cbx_temp.Enabled = false;
						ParentControl = cbx_temp;
					}
                    if (strControlType == "RadioButton")
                    {
                        RadioButton cbx_temp = ParentControl as RadioButton;
                        cbx_temp.Enabled = false;
                        ParentControl = cbx_temp;
                    }
				}

				return;
			}
			//*****************************//

			strControlType = "";
			for (intChildIndex = 0; intChildIndex < intChildCount; intChildIndex++)
			{
				Control ChildControl = ParentControl.Controls[intChildIndex];
				strChildName = ChildControl.Name;
				if ((strChildName != "")&&(ChildControl.Enabled))
				{
					strControlType = ChildControl.GetType().Name;

					if (strControlType=="TextBox")
					{
						TextBox txt_temp = ChildControl as TextBox;
						txt_temp.ReadOnly = true;
						ChildControl = txt_temp;
					}
					if (strControlType=="RichTextBox")
					{
						System.Windows.Forms.RichTextBox txt_temp = ChildControl as System.Windows.Forms.RichTextBox;
						txt_temp.ReadOnly = true;
						txt_temp.BackColor = SystemColors.Control;
						ChildControl = txt_temp;
					}
					if (strControlType=="CheckedListBox")
					{
						System.Windows.Forms.CheckedListBox cbx_temp = ChildControl as System.Windows.Forms.CheckedListBox;
						cbx_temp.SelectionMode = SelectionMode.None;
						cbx_temp.BackColor = SystemColors.Control;
						ChildControl = cbx_temp;
					}
					if (strControlType=="ComboBox")
					{
						ComboBox cmb_temp = ChildControl as ComboBox;
						cmb_temp.Enabled = false;
						ChildControl = cmb_temp;
					}
					if (strControlType=="CheckBox")
					{
						System.Windows.Forms.CheckBox cbx_temp = ChildControl as System.Windows.Forms.CheckBox;
						cbx_temp.Enabled = false;
						ChildControl = cbx_temp;
					}
					if (strControlType=="DateTimePicker")
					{
						DateTimePicker cbx_temp = ChildControl as DateTimePicker;
						cbx_temp.Enabled = false;
						ChildControl = cbx_temp;
					}
					if (strControlType=="LinkLabel")
					{
						LinkLabel cbx_temp = ChildControl as LinkLabel;
						cbx_temp.Enabled = false;
						ChildControl = cbx_temp;
					}
                    if (strControlType == "RadioButton")
                    {
                        RadioButton cbx_temp = ChildControl as RadioButton;
                        cbx_temp.Enabled = false;
                        ChildControl = cbx_temp;
                    }
					MakeReadOnly(ChildControl,false);
				}
			}
		}
	
		public static void MakeEnabled(Control ParentControl, bool boolSelfOnly)
		{
			int intChildCount = ParentControl.Controls.Count;
			int intChildIndex;
			string strChildName;
			string strControlType;

			//*****************************//
			if (boolSelfOnly)
			{
				string strParentName = ParentControl.Name;
				if (strParentName != "")
				{
					strControlType = ParentControl.GetType().Name;

					if (strControlType=="TextBox")
					{
						TextBox txt_temp = ParentControl as TextBox;
						txt_temp.ReadOnly = false;
						ParentControl = txt_temp;
					}
					if (strControlType=="RichTextBox")
					{
						System.Windows.Forms.RichTextBox txt_temp = ParentControl as System.Windows.Forms.RichTextBox;
						txt_temp.ReadOnly = false;
						txt_temp.BackColor = SystemColors.Control;
						ParentControl = txt_temp;
					}
					if (strControlType=="CheckedListBox")
					{
						System.Windows.Forms.CheckedListBox cbx_temp = ParentControl as System.Windows.Forms.CheckedListBox;
						cbx_temp.SelectionMode = SelectionMode.None;
						cbx_temp.BackColor = SystemColors.Control;
						ParentControl = cbx_temp;
					}
					if (strControlType=="ComboBox")
					{
						ComboBox cmb_temp = ParentControl as ComboBox;
						cmb_temp.Enabled = true;
						ParentControl = cmb_temp;
					}
					if (strControlType=="CheckBox")
					{
						System.Windows.Forms.CheckBox cbx_temp = ParentControl as System.Windows.Forms.CheckBox;
						cbx_temp.Enabled = true;
						ParentControl = cbx_temp;
					}
					if (strControlType=="DateTimePicker")
					{
						DateTimePicker cbx_temp = ParentControl as DateTimePicker;
						cbx_temp.Enabled = true;
						ParentControl = cbx_temp;
					}
					if (strControlType=="LinkLabel")
					{
						LinkLabel cbx_temp = ParentControl as LinkLabel;
						cbx_temp.Enabled = true;
						ParentControl = cbx_temp;
					}
                    if (strControlType == "RadioButton")
                    {
                        RadioButton cbx_temp = ParentControl as RadioButton;
                        cbx_temp.Enabled = true;
                        ParentControl = cbx_temp;
                    }
				}

				return;
			}
			//*****************************//

			strControlType = "";
			for (intChildIndex = 0; intChildIndex < intChildCount; intChildIndex++)
			{
				Control ChildControl = ParentControl.Controls[intChildIndex];
				strChildName = ChildControl.Name;
				if (strChildName != "")
				{
					strControlType = ChildControl.GetType().Name;

					if (strControlType=="TextBox")
					{
						TextBox txt_temp = ChildControl as TextBox;
						txt_temp.ReadOnly = false;
						ChildControl = txt_temp;
					}
					if (strControlType=="RichTextBox")
					{
						System.Windows.Forms.RichTextBox txt_temp = ChildControl as System.Windows.Forms.RichTextBox;
						txt_temp.ReadOnly = false;
						txt_temp.BackColor = SystemColors.Control;
						ChildControl = txt_temp;
					}
					if (strControlType=="CheckedListBox")
					{
						System.Windows.Forms.CheckedListBox cbx_temp = ChildControl as System.Windows.Forms.CheckedListBox;
						cbx_temp.SelectionMode = SelectionMode.None;
						cbx_temp.BackColor = SystemColors.Control;
						ChildControl = cbx_temp;
					}
					if (strControlType=="ComboBox")
					{
						ComboBox cmb_temp = ChildControl as ComboBox;
						cmb_temp.Enabled = true;
						ChildControl = cmb_temp;
					}
					if (strControlType=="CheckBox")
					{
						System.Windows.Forms.CheckBox cbx_temp = ChildControl as System.Windows.Forms.CheckBox;
						cbx_temp.Enabled = true;
						ChildControl = cbx_temp;
					}
					if (strControlType=="DateTimePicker")
					{
						DateTimePicker cbx_temp = ChildControl as DateTimePicker;
						cbx_temp.Enabled = true;
						ChildControl = cbx_temp;
					}
					if (strControlType=="LinkLabel")
					{
						LinkLabel cbx_temp = ChildControl as LinkLabel;
						cbx_temp.Enabled = true;
						ChildControl = cbx_temp;
					}
                    if (strControlType == "RadioButton")
                    {
                        RadioButton cbx_temp = ChildControl as RadioButton;
                        cbx_temp.Enabled = true;
                        ChildControl = cbx_temp;
                    }
					MakeEnabled(ChildControl,false);
				}
			}
		}

		public static void SetControlFont(Form frm)
		{
			if(Common.FontName=="") return;

			Label lbl;
			Button btn;
			CheckBox chk;
			RadioButton rbtn;
			LinkLabel llbl;

			foreach(Control c in frm.Controls)
			{
				if(c.GetType().ToString()=="System.Windows.Forms.TabControl")
				{
					foreach(Control c1 in c.Controls)
					{
						if(c1.GetType().ToString()=="System.Windows.Forms.TabPage")
						{
							foreach(Control c2 in c1.Controls)
							{
								if(c2.GetType().ToString()=="System.Windows.Forms.Label")
								{
									lbl = c2 as Label;
									lbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.Button")
								{
									btn = c2 as Button;
									btn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.CheckBox")
								{
									chk = c2 as CheckBox;
									chk.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.RadioButton")
								{
									rbtn = c2 as RadioButton;
									rbtn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.LinkLabel")
								{
									llbl = c2 as LinkLabel;
									llbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.GroupBox")
								{
									(c2 as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
								}
							}
						}
					}
				}
				if(c.GetType().ToString()=="System.Windows.Forms.Label")
				{
					lbl = c as Label;
					lbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.Button")
				{
					btn = c as Button;
					btn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.CheckBox")
				{
					chk = c as CheckBox;
					chk.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.RadioButton")
				{
					rbtn = c as RadioButton;
					rbtn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.LinkLabel")
				{
					llbl = c as LinkLabel;
					llbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.GroupBox")
				{
					(c as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
				}
			}
		}

		public static void SetControlFont(Panel frm)
		{
			if(Common.FontName=="") return;

			Label lbl;
			Button btn;
			CheckBox chk;
			RadioButton rbtn;
			LinkLabel llbl;

			foreach(Control c in frm.Controls)
			{
				if(c.GetType().ToString()=="System.Windows.Forms.TabControl")
				{
					foreach(Control c1 in c.Controls)
					{
						if(c1.GetType().ToString()=="System.Windows.Forms.TabPage")
						{
							foreach(Control c2 in c1.Controls)
							{
								if(c2.GetType().ToString()=="System.Windows.Forms.Label")
								{
									lbl = c2 as Label;
									lbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.Button")
								{
									btn = c2 as Button;
									btn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.CheckBox")
								{
									chk = c2 as CheckBox;
									chk.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.RadioButton")
								{
									rbtn = c2 as RadioButton;
									rbtn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.LinkLabel")
								{
									llbl = c2 as LinkLabel;
									llbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.GroupBox")
								{
									(c2 as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
								}
							}
						}
					}
				}
				if(c.GetType().ToString()=="System.Windows.Forms.Label")
				{
					lbl = c as Label;
					lbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.Button")
				{
					btn = c as Button;
					btn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.CheckBox")
				{
					chk = c as CheckBox;
					chk.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.RadioButton")
				{
					rbtn = c as RadioButton;
					rbtn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.LinkLabel")
				{
					llbl = c as LinkLabel;
					llbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.GroupBox")
				{
					(c as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
				}
			}
		}

		public static void SetControlFont(GroupBox frm)
		{
			if(Common.FontName=="") return;

			Label lbl;
			Button btn;
			CheckBox chk;
			RadioButton rbtn;
			LinkLabel llbl;

			foreach(Control c in frm.Controls)
			{
				if(c.GetType().ToString()=="System.Windows.Forms.TabControl")
				{
					foreach(Control c1 in c.Controls)
					{
						if(c1.GetType().ToString()=="System.Windows.Forms.TabPage")
						{
							foreach(Control c2 in c1.Controls)
							{
								if(c2.GetType().ToString()=="System.Windows.Forms.Label")
								{
									lbl = c2 as Label;
									lbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.Button")
								{
									btn = c2 as Button;
									btn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.CheckBox")
								{
									chk = c2 as CheckBox;
									chk.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.RadioButton")
								{
									rbtn = c2 as RadioButton;
									rbtn.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.LinkLabel")
								{
									llbl = c2 as LinkLabel;
									llbl.Font = new Font(Common.FontName, Common.FontSize);
								}
								else if(c2.GetType().ToString()=="System.Windows.Forms.GroupBox")
								{
									(c2 as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
								}
							}
						}
					}
				}
				if(c.GetType().ToString()=="System.Windows.Forms.Label")
				{
					lbl = c as Label;
					lbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.Button")
				{
					btn = c as Button;
					btn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.CheckBox")
				{
					chk = c as CheckBox;
					chk.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.RadioButton")
				{
					rbtn = c as RadioButton;
					rbtn.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.LinkLabel")
				{
					llbl = c as LinkLabel;
					llbl.Font = new Font(Common.FontName, Common.FontSize);
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.GroupBox")
				{
					(c as GroupBox).Font = new Font(Common.FontName, Common.FontSize);
				}
			}
		}

		public static void SetGridFont(DevExpress.XtraGrid.GridControl grd)
		{
			grd.Styles.AddReplace("Preview", new DevExpress.Utils.ViewStyle("Preview", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, true, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, null, System.Drawing.SystemColors.Window, System.Drawing.Color.Blue));
			grd.Styles.AddReplace("FooterPanel", new DevExpress.Utils.ViewStyle("FooterPanel", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("GroupButton", new DevExpress.Utils.ViewStyle("GroupButton", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("FilterButtonPressed", new DevExpress.Utils.ViewStyle("FilterButtonPressed", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlText, System.Drawing.SystemColors.Window));
			grd.Styles.AddReplace("EvenRow", new DevExpress.Utils.ViewStyle("EvenRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.WhiteSmoke, System.Drawing.SystemColors.WindowText));
			grd.Styles.AddReplace("HideSelectionRow", new DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.InactiveCaptionText));
			grd.Styles.AddReplace("FilterButton", new DevExpress.Utils.ViewStyle("FilterButton", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlLightLight));
			grd.Styles.AddReplace("GroupPanel", new DevExpress.Utils.ViewStyle("GroupPanel", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("ColumnFilterButtonPressed", new DevExpress.Utils.ViewStyle("ColumnFilterButtonPressed", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlText, System.Drawing.Color.Blue));
			grd.Styles.AddReplace("Empty", new DevExpress.Utils.ViewStyle("Empty", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Window));
			grd.Styles.AddReplace("HeaderPanel", new DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("GroupRow", new DevExpress.Utils.ViewStyle("GroupRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.WindowText));
			grd.Styles.AddReplace("HorzLine", new DevExpress.Utils.ViewStyle("HorzLine", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlDark));
			grd.Styles.AddReplace("ColumnFilterButton", new DevExpress.Utils.ViewStyle("ColumnFilterButton", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("FocusedRow", new DevExpress.Utils.ViewStyle("FocusedRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
			grd.Styles.AddReplace("VertLine", new DevExpress.Utils.ViewStyle("VertLine", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlDark));
			grd.Styles.AddReplace("GroupFooter", new DevExpress.Utils.ViewStyle("GroupFooter", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
			grd.Styles.AddReplace("FocusedCell", new DevExpress.Utils.ViewStyle("FocusedCell", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText));
			grd.Styles.AddReplace("OddRow", new DevExpress.Utils.ViewStyle("OddRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.White, System.Drawing.SystemColors.WindowText));
			grd.Styles.AddReplace("SelectedRow", new DevExpress.Utils.ViewStyle("SelectedRow", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
			grd.Styles.AddReplace("FocusedGroup", new DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
			grd.Styles.AddReplace("Row", new DevExpress.Utils.ViewStyle("Row", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText));
			grd.Styles.AddReplace("FilterPanel", new DevExpress.Utils.ViewStyle("FilterPanel", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlLightLight));
			grd.Styles.AddReplace("DetailTip", new DevExpress.Utils.ViewStyle("DetailTip", "GridView", new System.Drawing.Font(Common.FontName, Common.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
				| DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
				| DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
				| DevExpress.Utils.StyleOptions.UseFont) 
				| DevExpress.Utils.StyleOptions.UseForeColor) 
				| DevExpress.Utils.StyleOptions.UseHorzAlignment) 
				| DevExpress.Utils.StyleOptions.UseImage) 
				| DevExpress.Utils.StyleOptions.UseWordWrap) 
				| DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Info, System.Drawing.SystemColors.InfoText));
		}

		public static int CheckOverlapTime(int teacherid, int eventid, 
			string instructortype, ref string conflictingevent,
			string dt1, string dt2)
		{
			bool Ok=false;
			int intID=0;
			int _eventid=0;
			string sql="";
			SqlCommand com=null;
			Connection con=null;
			try
			{
				sql = "Select Name as EventName, EventID From CalendarEvent Where " +
					"(RealTeacherID=" + teacherid  + ") AND " +
					"((StartDateTime>=@date1 and StartDateTime<=@date2) " +
					"OR (@date1>=StartDateTime and @date1<=EndDateTime)) ";

				if(eventid>0)
				{
					sql += "AND EventID <> " + eventid.ToString() + " ";
				}
                sql += " AND CalendarEventStatus = 0";
				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = sql;

				com.Parameters.Add("@date1", SqlDbType.DateTime);
				com.Parameters["@date1"].Value = Convert.ToDateTime(dt1);
				com.Parameters.Add("@date2", SqlDbType.DateTime);
				com.Parameters["@date2"].Value = Convert.ToDateTime(dt2);

				SqlDataReader Reader = com.ExecuteReader();
				if(Reader.HasRows) intID=1;
				if(Reader.Read())
				{
					conflictingevent = Reader[0].ToString();
					_eventid = Convert.ToInt32(Reader[1].ToString());
				}
				Reader.Close();
				if(intID>0)
				{
					Ok = true;
				}
				else
				{
					intID=0;
					sql = "Select Name as EventName, EventID From CalendarEvent Where " +
						"((ScheduledTeacherID=" + teacherid  + ") AND (RealTeacherID=0)) AND " +
						"((StartDateTime>=@date1 and StartDateTime<=@date2) " +
						"OR (@date1>=StartDateTime and @date1<=EndDateTime)) ";

					if(eventid>0)
					{
						sql += "AND EventID <> " + eventid.ToString() + " ";
					}
                    sql += " AND CalendarEventStatus = 0";

					com.CommandText = sql;

					Reader = com.ExecuteReader();
					if(Reader.HasRows) intID=1;
					if(Reader.Read())
					{
						conflictingevent = Reader[0].ToString();
						_eventid = Convert.ToInt32(Reader[1].ToString());
					}
					Reader.Close();
					if(intID>0)
					{
						Ok = true;
					}
				}
				if(Ok)
				{
					return _eventid;
				}
				return 0;
			}
			catch(SqlException ex)
			{
				return 0;
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

		public static string GetConflictMess(int evtid)
		{
			bool Ok=false;
			string strSql="";
			SqlCommand com=null;
			Connection con=null;
			SqlDataReader Reader=null;

			int CourseID=0;
			int ProgramID=0;
			string sEvent=string.Empty;
			string sClient=string.Empty;
			string sDepartment=string.Empty;
			string sProgram=string.Empty;
			string sEventName = string.Empty;
			string strOverLapMess=string.Empty;


			try
			{
				strSql = "Select CourseID from Course C Where " +
					"(C.EventID=" + evtid.ToString() + " OR "+
					"C.TestInitialEventID=" + evtid.ToString() + " OR "+
					"C.TestMidtermEventID=" + evtid.ToString() + " OR "+
					"C.TestFinalEventID=" + evtid.ToString() + ")";

				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;


				Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					Ok = true;
					CourseID = Convert.ToInt32(Reader[0].ToString());
				}
				Reader.Close();

				if(!Ok)
				{
					strSql = "Select ProgramID from Program P Where " +
						"(P.TestInitialEventID=" + evtid.ToString() + " OR "+
						"P.TestMidtermEventID=" + evtid.ToString() + " OR "+
						"P.TestFinalEventID=" + evtid.ToString() + ")";

					com.CommandText=strSql;
					Reader = com.ExecuteReader();
					while(Reader.Read())
					{
						Ok = true;
						ProgramID = Convert.ToInt32(Reader[0].ToString());
					}
					Reader.Close();
				}
				
				if(Ok)
				{
					strSql="";
					if(CourseID>0)
					{
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
							"Where C.CourseID=" + CourseID.ToString() + " ";

						com.CommandText = strSql;

						Reader = com.ExecuteReader();
						while(Reader.Read())
						{
							Ok = true;
							sClient = Reader["Client"].ToString();
							sProgram = Reader["Program"].ToString();
							sDepartment = Reader["Department"].ToString();
						}
						Reader.Close();
					}

					if(!Ok)
					{
						strSql="";
						if(ProgramID>0)
						{
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
								"From Program P " +
								"Left Join Department D on (P.DepartmentID=D.DepartmentID) " +
								"Left Join Contact CO on (D.ContactID=CO.ContactID) " +
								"Left Join Contact CO1 on (D.ClientID=CO1.ContactID) " +
								"Where P.ProgramID=" + ProgramID.ToString() + " ";

							com.CommandText = strSql;

							Reader = com.ExecuteReader();
							while(Reader.Read())
							{
								Ok = true;
								sClient = Reader["Client"].ToString();
								sProgram = Reader["Program"].ToString();
								sDepartment = Reader["Department"].ToString();
							}
							Reader.Close();
						}
					}

				}
				else return "";

				/*strSql=string.Empty;
				strSql = "SELECT DISTINCT NAME FROM CALENDAREVENT WHERE EVENTID=" + evtid.ToString();
				com.CommandText = strSql;

				Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					Ok = true;
					sEventName = Reader["Name"].ToString();
				}
				Reader.Close();*/

				strOverLapMess=string.Empty;
				if(sClient!="")
				{
					strOverLapMess += "-<" + sClient + ">";
					if(sDepartment!="")
					{
						strOverLapMess += "<" + sDepartment + ">";
					}
					if(sProgram!="")
					{
						strOverLapMess += "<" + sProgram + ">";
					}
				}
				strOverLapMess = strOverLapMess.Trim();

				/*
				strSql = "Select " +
					"ClientName = CASE " +
					"WHEN CL.NickName IS NULL THEN CL.LastName + ', ' + CL.FirstName " +
					"WHEN CL.NickName = '' THEN CL.LastName + ', ' + CL.FirstName " +
					"ELSE CL.NickName " +
					"END, " +
					"C.[Name] from Course C " +
					"Left Outer Join Program P ON(C.ProgramID=P.ProgramID) "+
					"Left Outer Join Department D ON(P.DepartmentID=D.DepartmentID) "+
					"Left Outer Join Contact CL ON(D.ClientID=CL.ContactID) "+
					"WHERE "+
					"(C.EventID=" + evtid.ToString() + " OR "+
					"C.TestInitialEventID=" + evtid.ToString() + " OR "+
					"C.TestMidtermEventID=" + evtid.ToString() + " OR "+
					"C.TestFinalEventID=" + evtid.ToString() + ")";


				con=new Connection();
				con.Connect();
				com = new SqlCommand();
				com.Connection=con.SQLCon;
				com.CommandText = strSql;


				Reader = com.ExecuteReader();
				while(Reader.Read())
				{
					Ok = true;
					sClientName = Reader[0].ToString();
					sClassProgName = Reader[1].ToString();
				}
				Reader.Close();
				
				if(Ok)
				{
					sClientName=sClientName.Trim();
					sClassProgName=sClassProgName.Trim();
					if(sClassProgName==",") sClassProgName="";
				}
				else
				{
					strSql = "Select " +
						"ClientName = CASE " +
						"WHEN CL.NickName IS NULL THEN CL.LastName + ', ' + CL.FirstName " +
						"WHEN CL.NickName = '' THEN CL.LastName + ', ' + CL.FirstName " +
						"ELSE CL.NickName " +
						"END, " +
						"C.[Name] from Program C " +
						"Left Outer Join Department D ON(C.DepartmentID=D.DepartmentID) "+
						"Left Outer Join Contact CL ON(D.ClientID=CL.ContactID) "+
						"WHERE " +
						"(C.TestInitialEventID=" + evtid.ToString() + " OR "+
						"C.TestMidtermEventID=" + evtid.ToString() + " OR "+
						"C.TestFinalEventID=" + evtid.ToString() + ")";

					com.CommandText = strSql;
					Reader = com.ExecuteReader();
					while(Reader.Read())
					{
						Ok = true;
						sClientName = Reader[0].ToString();
						sClassProgName = Reader[1].ToString();
					}
					Reader.Close();
				}

				string strOverLapMess=string.Empty;
				if(sClientName!="")
				{
					strOverLapMess = "-<" + sClientName + ">";
					if(sClassProgName!="")
					{
						strOverLapMess += "<" + sClassProgName + ">";
					}
				}
				strOverLapMess = strOverLapMess.Trim();*/


				return strOverLapMess;

			}
			catch(SqlException ex)
			{
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

        public static int ConvertToInteger(string strText)
        {
            if (strText != "" && strText != null)
            {
                return Convert.ToInt32(strText);
            }
            else return 0;
        }

	}
}
