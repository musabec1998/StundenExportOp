using StundenExportOp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StundenExportOp.Controllers
{
    public class HomeController : Controller
    {

        private static string apiKey = "dcc4870b2b96bc1936e1065a6bf0172ed6632b976f2d454983157639390cfc20";
        private string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:" + apiKey));
        public ApiClient apiclient = new ApiClient();
        public HttpClient client = new HttpClient();



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> GetCombinedView(string year,string month,int? userId)
        {
            GetEntries entries = new GetEntries();
            GetUser user = new GetUser();
            GetProject project = new GetProject();
            GetTime hours = new GetTime();
            GetDate date = new GetDate();
            GetId tId = new GetId();

            //übergebe die userId als string Parameter in die Methode "GetTimeEntries" und Konvertiere die userId in der Klasse selbst wieder zu Int. Andernfalls kommen Fehlermeldungen(???)
            string id = userId.ToString();

            //Antwort von Api(Time_Entries)
            //var response = await apiclient.GetData(year, month, id, auth);
           


            //erstelle Listen um Daten an Viewmodel weitergeben zu können
            List<TimeEntries.Comment> commentraw = new List<TimeEntries.Comment>();
            List<UserData> userdata = await user.GetUserData(auth);
            List<TimeEntries.Project> projecttitel = new List<TimeEntries.Project>();
            List<TimeEntries.Element> entrietime = new List<TimeEntries.Element>();
            List<TimeEntries.Element> spentonDate = new List<TimeEntries.Element>();
            List<TimeEntries.Element> ticketId = new List<TimeEntries.Element>();


            //userdata = userdata.OrderBy(u => u.name).ToList();

            //GetTimeEntries Methode führt somit nicht zum crash der Anwendung da die Einträge Monat und Jahr auch Null sein können.
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year))
            {


                commentraw = await entries.GetTimeEntries(year, month, id, apiclient, auth);
                //List<TimeEntries.Project> projecttitel = await project.GetProjectTitle(response);


            }

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year)) {
                projecttitel = await project.GetProjectTitle(year, month, id, apiKey);
                entrietime = await hours.GetEntrieTime(year, month, id, apiKey);
                spentonDate = await date.GetSpentOnDate(year, month, id, apiKey);
                ticketId = await tId.GetTicketId(year, month, id, apiKey);

            }
           

                userdata = userdata.OrderBy(u => u.name).ToList();




            ViewModel model = new ViewModel
            {
                entries = commentraw.Any() ? commentraw : null,
                userData = userdata,
                project = projecttitel.Any() ? projecttitel : null,
                hours = entrietime.Any() ? entrietime : null,
                date = spentonDate.Any() ? spentonDate : null,
                id = ticketId.Any()? ticketId :null
            };

            return View("GetCombinedView", model);
        }




    }
}