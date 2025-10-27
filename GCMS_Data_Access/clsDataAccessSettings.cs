using System.Diagnostics;
using System.Configuration;

namespace GCMS_Data_Access
{
    public static class clsDataAccessSettings
    {
        //Database Connection string
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["GCMS_ConnectionString"].ConnectionString;

        public enum enEventType { Information = 1, Error, Warnning };

        //this is an event logger procedure to log Every Exception or information that could happend
        public static void EventLogger(string SourceName, string Message, enEventType EventType)
        {
            //if the Souce name does not exsits this will create one
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }


            // a switch case to specify which Type to log in log viewer
            switch (EventType)
            {

                case enEventType.Information:
                    {
                        EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Information);
                        break;
                    }
                case enEventType.Warnning:
                    {
                        EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Warning);
                        break;
                    }
                case enEventType.Error:
                    {
                        EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
                        break;
                    }
            }

        }
    }
}
