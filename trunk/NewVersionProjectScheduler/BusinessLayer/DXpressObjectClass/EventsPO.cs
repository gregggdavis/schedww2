using System;
using DevExpress.Xpo;

namespace Scheduler.BusinessLayer
{
    [Persistent("dbo.ViewAllEventsFull")]
    public class EventsPO : XPLiteObject
    {
        public EventsPO()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public EventsPO(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
     
        public int EventId;
        public string RepeatRule;
        public string NegetiveException;
        public string Description;
        public string RecurrenceText;
        [Key]
        public int CalendarEventId;
        public string Note;
        public string EventStatus;
        public DateTime StartDateTime;
        public DateTime EndDateTime;
        public string DayOfWeek;
        public DateTime DateCompleted;
        public string Name;
        public string NamePhonetic;
        public string NameRomaji;
        public string Location;
        public string BlockCode;
        public string RoomNumber;
        public int ScheduledTeacherId;
        public int RealTeacherId;
        public string ChangeReason;
        public int IsHoliday;
        public string EventType;
        public string ExceptionReason;
        public string ScheduledTeacher;
        public string RealTeacher;
        public int CourseId;
        public string Class;
        public int ProgramId;
        public string ProgramName;
        public string Program;
        public string DateAndTime;
        public int CEvent1;
        public int CEvent2;
        public int CEvent3;
        public int CEvent4;
        public int PEvent1;
        public int PEvent2;
        public int PEvent3;
        public string Instructor;
        public string TestEvent;
        public string DeptName;
        public string Department;
        public string ClientName;
        public string Client;

    }

}