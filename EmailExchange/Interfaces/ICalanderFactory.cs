using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExchange.Interfaces
{
    public interface ICalanderFactory<T> where T:class
    {
        T GetAppointments(DateTime startDate, DateTime endDate);
        void CreateAppointments();
        void UpdateAppointments();
        void RespondMeedings();
        T GetCalendarView();
    }
}
