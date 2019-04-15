using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExchange.Services
{
    public class GoogleCalendarInterface
    {
        public static Events GetAppointments(DateTime startDate, DateTime endDate)
        {
            AbstractCalendar<Events> calendar = new BaseCalendar<Events>();
            calendar._calanderFactory = new GoogleCalendar<Events>();
            return calendar.GetAppointments(startDate, endDate);
        }
    }
}
