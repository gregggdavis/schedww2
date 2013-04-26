using System;
using DevExpress.Xpo;

namespace Scheduler.BusinessLayer
{
    [Persistent("dbo.ViewClassEventsN")]
    public class CoursePO : XPLiteObject
    {
        public CoursePO()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public CoursePO(Session session)
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
        [Key]
        public int CourseId;
        public string Name;
        public string NamePhonetic;
        public string NameRomaji;
        public string NickName;
        public int ProgramId;
        public string CourseType;
        public int EventId;
        public string Description;
        public string SpecialRemarks;
        public string Curriculam;
        public int NumberStudents;
        public int HomeworkMinutes;
        public int TestInitialEventId;
        public int TestMidtermEventId;
        public int TestFinalEventId;
        public string TestInitialForm;
        public string TestMidtermForm;
        public string TestFinalForm;
        public string CourseStatus;
        public int CreatedByUserId;
        public DateTime DateCreated;
        public DateTime DateLastModified;
        public int LastModifiedByUserId;
        public int BreakDuration;
        public string BrowseName;
        public string ProgramNickName;
        public string Program;
        public string Department;
        public string Client;
        public DateTime EventStartDateTime;
        public DateTime EventEndDateTime;
        public string ScheduledInstructor;
        public string OccurrenceCount;
    }

}