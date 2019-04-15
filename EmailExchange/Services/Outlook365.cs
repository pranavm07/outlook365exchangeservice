using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailExchange.Interfaces;
using Microsoft.Exchange.WebServices.Data;

namespace EmailExchange.Services
{
    public class Outlook365<T> : ICalanderFactory<T> where T:class
    {
        static ExchangeService exService = new ExchangeService(ExchangeVersion.Exchange2010);
        static Outlook365()
        {
            exService.Credentials = new WebCredentials("pranav.mishra@hotmail.com", "varanasi07");   // replace with proper username and password
            exService.Url = new Uri("https://outlook.office365.com/ews/exchange.asmx");   // Office 365 Exchange API URL (replace it with a local server URL if you are using a local Exchange installation)
        }

        public  void CreateAppointments()
        {
            throw new NotImplementedException();
        }

           public  T GetAppointments(DateTime startDate, DateTime endDate)
        {
          
            // load the default calendar
            CalendarFolder calendar = CalendarFolder.Bind(exService, WellKnownFolderName.Calendar, new PropertySet());

            // load events
            CalendarView cView = new CalendarView(startDate, endDate, 50);
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End, AppointmentSchema.Id);
            FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
            return (T)(object)appointments;
        }

        public  T GetCalendarView()
        {
            throw new NotImplementedException();
        }

        public  void RespondMeedings()
        {
            throw new NotImplementedException();
        }

        public  void UpdateAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
