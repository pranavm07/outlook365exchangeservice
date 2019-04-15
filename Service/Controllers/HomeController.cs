using System.Web.Http;
using Service.Utility;
namespace Service.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : ApiController
    {
        public HomeController()
        {

        }
        [Route("content")]
        //[ActionName("index")]
        [HttpGet]
        public IHttpActionResult GetContent()
        {
            var content = FileHandler.GetContents();
            return Ok(content);
        }

        [HttpGet, Route("calander")]
        public IHttpActionResult Calander()
        {
            //ExchangeUtil.CreateMeetings();

            var appt = ExchangeUtil.GetAppointments();
            
            //ClaimsPrincipal principal = new ClaimsPrincipal();
            //string userid = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string userObjectId= ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            //AuthorizationContext autContext = new AuthorizationContext(principal, new ADALTokenCache())
            return Ok(appt.Items);
        }
    }
}
