using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmailExchange.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace EmailExchange.Services
{
    public class GoogleCalendar<T> : ICalanderFactory<T> where T : class
    {
        public void CreateAppointments()
        {
            throw new NotImplementedException();
        }

        public T GetAppointments(DateTime startDate, DateTime endDate)
        {
            string[] Scopes = { CalendarService.Scope.Calendar };
            string ApplicationName = "Calendar API Quickstart";
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open,
          FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment
                  .SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                   GoogleClientSecrets.Load(stream).Secrets,
                  Scopes,
                  "user",
                  CancellationToken.None,
                  new FileDataStore(credPath, true)).Result;

                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Calendar Service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = startDate;
            request.TimeMax = endDate;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return (T)(object)request.Execute();
        }

        public T GetCalendarView()
        {
            throw new NotImplementedException();
        }

        public void RespondMeedings()
        {
            throw new NotImplementedException();
        }

        public void UpdateAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
