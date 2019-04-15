using System;
using EmailExchange.Services;


namespace ClientConsole
{
    class Program
    {
        public static void Main(string [] args)
        {

           var outlookCalendar= OutlookCalendarInterface.GetAppointments(DateTime.Now.AddDays(-30), DateTime.Now);

            
        }
        
    }
}
