using System;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// This class serves to store the selected indexes of the dropdowns found on
    /// frmEventBrw and frmCalendar to ensure consistency of selections as the user 
    /// switches to and fro between the Event List and the Calendar Views.
	/// </summary>
	public class CalendarFilter
	{
		public static bool ShowAll=false;
		public static DateTime StartDate = DateTime.MinValue;
		public static DateTime EndDate = DateTime.MaxValue;
		public static int ClientIndex=0;
        public static string ClientName = "";
        public static string InstructorName = "";
		public static int InstructorIndex=0;
		public static int ProgramIndex=0;
        public static string ProgramName = "";
		public static int ClassIndex=0;
        public static string ClassName = "";
        public static bool MonthlyHideWeekends = true;
        public static bool WeeklyHideWeekends = true;
        public static bool DailyHideWeekends = true;
	}
}
