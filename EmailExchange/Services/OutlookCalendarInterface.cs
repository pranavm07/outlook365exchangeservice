using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExchange.Services
{
    public class OutlookCalendarInterface
    {
        public static FindItemsResults<Appointment> GetAppointments(DateTime startDate, DateTime endDate)
        {
            AbstractCalendar<FindItemsResults<Appointment>> calendar = new BaseCalendar<FindItemsResults<Appointment>>();
            calendar._calanderFactory = new Outlook365<FindItemsResults<Appointment>>();
            return calendar.GetAppointments(startDate, endDate);
        }

    
    }
}
