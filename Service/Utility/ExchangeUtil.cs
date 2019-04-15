using Microsoft.Exchange.WebServices.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Utility
{
    public class ExchangeUtil
    {
        static ExchangeService exService = new ExchangeService(ExchangeVersion.Exchange2010);
        public static void SetExchange()
        {

            exService.Credentials = new WebCredentials("pranav.mishra@hotmail.com", "varanasi07");   // replace with proper username and password
            exService.Url = new Uri("https://outlook.office365.com/ews/exchange.asmx");   // Office 365 Exchange API URL (replace it with a local server URL if you are using a local Exchange installation)
        }
        
        public static FindItemsResults<Appointment> GetAppointments()
        {
            SetExchange();
            // this week
            DateTime startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endDate = startDate.AddDays(7);

            // load the default calendar
            CalendarFolder calendar = CalendarFolder.Bind(exService, WellKnownFolderName.Calendar, new PropertySet());

            // load events
            CalendarView cView = new CalendarView(startDate, endDate, 50);
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End, AppointmentSchema.Id);
            FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
            return appointments;
        }

        public static void CreateMeetings()
        {
            SetExchange();
            Appointment appointment = new Appointment(exService);

            appointment.Subject = "test appointment creation Event";
            appointment.Start = DateTime.Now.AddDays(1);
            appointment.End = appointment.Start.AddMinutes(30);
            appointment.RequiredAttendees.Add("trivikrama@nalashaa.com");
            CalendarFolder folder = FindNamedCalendarFolder("Calendar");
            
            appointment.Save(folder.Id, SendInvitationsMode.SendToAllAndSaveCopy);
            
        }

        private static CalendarFolder FindNamedCalendarFolder(string name)
        {
            FolderView view = new FolderView(100);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            view.PropertySet.Add(FolderSchema.DisplayName);
            view.Traversal = FolderTraversal.Deep;

            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.FolderClass, "IPF.Appointment");

            FindFoldersResults findFolderResults = exService.FindFolders(WellKnownFolderName.Root, sfSearchFilter, view);
            return findFolderResults.Where(f => f.DisplayName == name).Cast<CalendarFolder>().FirstOrDefault();
        }
        public static void UpdateMeetings(Appointment appointment)
        {
            SetExchange();
            appointment.Subject = "test appointment creation Event";
            appointment.Start = DateTime.Now.AddDays(1);
            appointment.End = appointment.Start.AddMinutes(30);
            appointment.RequiredAttendees.Add("trivikrama@nalashaa.com");
            CalendarFolder folder = FindNamedCalendarFolder("Calendar");
            appointment.Update(ConflictResolutionMode.AlwaysOverwrite, SendInvitationsOrCancellationsMode.SendOnlyToChanged);
        }
        public static void CancleMeeting(Appointment appointment)
        {
            appointment.CancelMeeting("Cancellation Reason");

        }
    }
}