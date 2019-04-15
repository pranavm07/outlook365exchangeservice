using EmailExchange.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExchange.Services
{
    public abstract class AbstractCalendar<T> where T : class
    {
        public ICalanderFactory<T> _calanderFactory ;
        public abstract T GetAppointments(DateTime startDate, DateTime endDate);
        public abstract void CreateAppointments();
        public abstract void UpdateAppointments();
        public abstract void RespondMeedings();
        public abstract T GetCalendarView();

    }
}
