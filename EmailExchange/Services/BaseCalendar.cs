using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExchange.Services
{
    public class BaseCalendar<T> : AbstractCalendar<T> where T : class
    {
        public override void CreateAppointments()
        {
            _calanderFactory.CreateAppointments();
        }

        public override T GetAppointments(DateTime startDate, DateTime endDate)
        {
            return _calanderFactory.GetAppointments(startDate, endDate);
        }

        public override T GetCalendarView()
        {
            return _calanderFactory.GetCalendarView();
        }

        public override void RespondMeedings()
        {
            _calanderFactory.RespondMeedings();
        }

        public override void UpdateAppointments()
        {
           _calanderFactory.UpdateAppointments();
        }
    }
}
