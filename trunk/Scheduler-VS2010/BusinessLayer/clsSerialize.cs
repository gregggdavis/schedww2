using System;
using System.IO;
using System.Xml.Serialization;


namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for AutoRepriceParams.
	/// </summary>
	public class Serialize
	{
		private string _StartDate = string.Empty;
		private string _EndDate = string.Empty;
		private string _NoEntries = string.Empty;
		private string _ReccType = string.Empty;
		private string _Pattern1 = string.Empty;
		private string _Pattern2 = string.Empty;
		private string _filelocation = string.Empty;
		public string XMLData = string.Empty;

		public string StartDate
		{
			get{ return(_StartDate); }
			set{ _StartDate = value; }
		}
		public string EndDate
		{
			get{ return(_EndDate); }
			set{ _EndDate = value; }
		}
		public string NoEntries
		{
			get{ return(_NoEntries); }
			set{ _NoEntries = value; }
		}
		public string ReccType
		{
			get{ return(_ReccType); }
			set{ _ReccType = value; }
		}
		public string Pattern1
		{
			get{ return(_Pattern1); }
			set{ _Pattern1 = value; }
		}
		public string Pattern2
		{
			get{ return(_Pattern2); }
			set{ _Pattern2 = value; }
		}
		public string FileLocation
		{
			get{ return(_filelocation); }
			set{ _filelocation = value; }
		}

		public Serialize()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Serialize Load(string file)
		{
			try
			{
				Serialize objLoad = new Serialize();

				XmlSerializer serializer = new XmlSerializer(typeof(Serialize));
				StreamReader reader = new StreamReader(file);
				objLoad = (Serialize)serializer.Deserialize(reader);
				objLoad.FileLocation = file;
				reader.Close();
				
				return(objLoad);
			}
			catch{return null;}
		}

		public Serialize ReLoad()
		{
			Serialize objLoad = new Serialize();

			if(this._filelocation == string.Empty)
			{
				return(objLoad);
			}
			
			XmlSerializer serializer = new XmlSerializer(typeof(Serialize));
			StreamReader reader = new StreamReader(this._filelocation);
			objLoad = (Serialize)serializer.Deserialize(reader);

			return(objLoad);
		}

		public void Save(string file)
		{
			doSave(file);
		}

		public void Save()
		{
			doSave(this._filelocation);
		}

		private void doSave(string file)
		{
			string whatup;

			string strSaveFile = string.Empty;
			if(file.Length > 0)
			{
				strSaveFile = file;
			}
			else
			{
				strSaveFile = _filelocation;
			}

			XmlSerializer serializer = new XmlSerializer(typeof(Serialize));
			StreamWriter writer = new StreamWriter(strSaveFile);
			try
			{
				serializer.Serialize(writer,this);
				//writer.Close();
			}
			catch(Exception ex)
			{
				whatup = ex.Message.ToString();
			}
			finally
			{
				writer.Close();
			}
		}

		private string BuildString(string leftSide, string rightSide)
		{
			string newString = string.Empty;

			if(leftSide == string.Empty)
			{
				newString = rightSide;
			}
			else
			{
				newString = leftSide + ";" + rightSide;
			}

			return(newString);
		}
	}
}