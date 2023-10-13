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

        HttpClient client = new HttpClient();
        static string apiKey = "dcc4870b2b96bc1936e1065a6bf0172ed6632b976f2d454983157639390cfc20";
        string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:" + apiKey));







        //public async Task<ActionResult> GetTimeEntries(string userId, string month, string year)
        //{

        //    GetEntries entries = new GetEntries();

        //    List<TimeEntries.Comment> commentraw = await entries.GetTimeEntries(year, month, userId, apiKey, client, auth);

        //    ViewModel model = new ViewModel
        //    {

        //        entries = commentraw

        //    };




        //    return View(model);
        //}


        //public async Task<ActionResult> GetNames(string month, string year, string userId)
        //{
        //    //GetNames user = new GetNames();

        //    //List<UserData> userdata = await user.GetUserData(apiKey, client, auth);

        //    //ViewModel model = new ViewModel
        //    //{

        //    //    userData = userdata

        //    //};
        //    //return View(model);


        //    //GetEntries entries = new GetEntries();

        //    //GetNames user = new GetNames();

        //    //List<UserData> userdata = await user.GetUserData(apiKey, client, auth);

        //    //List<TimeEntries.Comment> commentraw = await entries.GetTimeEntries(year, month, apiKey,userId, client, auth);

        //    //ViewModel model = new ViewModel
        //    //{
        //    //    entries = commentraw,
        //    //    userData = userdata
        //    //};

        //    //return View(model);




        //}




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

        public async Task<ActionResult> GetCombinedView(string year,string month)
        {
            GetEntries entries = new GetEntries();
            GetNames user = new GetNames();

            List<TimeEntries.Comment> commentraw = new List<TimeEntries.Comment>();
            List<UserData> userdata = await user.GetUserData(apiKey, client, auth);

            if (!string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year))
            {
                commentraw = await entries.GetTimeEntries(year, month, apiKey, client, auth);
            }

            ViewModel model = new ViewModel
            {
                entries = commentraw.Any() ? commentraw : null,  
                userData = userdata
            };

            return View("GetCombinedView", model);
        }




    }
}