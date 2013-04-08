using System;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsEventData.
	/// </summary>
	public class EventData
	{
		public EventData()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int EventID=0;
		public int CalendarEventID=0;
		public string RepeatRule;
		public string NegativeException;
		public string RecurrenceText;
		//public int RecurrenceFlag;
		
		public string Name;
		public string NamePhonetic;
		public string NameRomaji;

		public string Description;
		public int EventType;
		public string Location;
		public string BlockCode;
		public string RoomNo;
		public string ExceptionReason;
		public string Notes;

		public DateTime StartDate;
		public DateTime EndDate;
		public DateTime DateCompleted;

		public int SchedulerTeacherID=0;
		public int RealTeacherID=0;
		public int IsHoliday=0;
		public string ChangeReason="";
		
		public int CalendarEventStatus;
		public int EventStatus=0;
		//private string _message="";


	}
}
