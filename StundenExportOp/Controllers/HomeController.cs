using StundenExportOp.Functions;
using StundenExportOp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using static StundenExportOp.Models.RedMineTicketFinder;

namespace StundenExportOp.Controllers
{
    public class HomeController : Controller
    {

        private static string apiKey = "0";
        private string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:" + apiKey));
        public ApiClient apiclient = new ApiClient();
        public ViewModelFiller filler = new ViewModelFiller();

        private static string redmineApiKey = "";
        private string redmineAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(":" + ""));
        public RedMineApiClient redmineApiClient = new RedMineApiClient();

        LinkTrimm trimmer = new LinkTrimm();

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

        public async Task<ActionResult> GetCombinedView(int? userId,string year,string month)
        {
            //userid in string Konvertieren...andernfalls Fehlermeldung???
            string id = userId.ToString();


           // OPDataRetrievel opData = new OPDataRetrievel();
            var opData = new OPDataManager();
            GetSumTime sumTime = new GetSumTime();
         


            //erstelle Listen um Daten an Viewmodel weitergeben zu können
            List<TimeEntries.Comment> commentRaw = new List<TimeEntries.Comment>();
            List<UserData> userData = await opData.GetUserData(auth, apiclient);
            List<TimeEntries.Project> projectTitel = new List<TimeEntries.Project>();
            List<TimeEntries.Element> entrieTime = new List<TimeEntries.Element>();
            List<TimeEntries.Element> spentonDate = new List<TimeEntries.Element>();
            List<TimeEntries.Element> ticketId = new List<TimeEntries.Element>();
            List<string> Sum = new List<String>();
            List<TimeEntries.Workpackage> packageId = new List<TimeEntries.Workpackage>();
            List<string> workPackageProject = new List<string>();
            List<Projects._Links> ancestor = new List<Projects._Links>();
            List<string> customField = new List<string>();

            //name des in der View ausgewählten Users wird hier ermittelt
            UserData selecetedUser = userData.FirstOrDefault(u => u.id == userId);
            string selectedUserName = "";

            //wenn nicht gewartet wird das Jahr Id oder Monat übergeben wird kommt es zum Fehler
            if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(month))
            {
                //in "response" werden die Time_Entries(in bereits gefilterter Form) geschrieben und an die anderen Methoden weitergegeben als Parameter
                string response = await apiclient.GetData(id, auth,year,month);

                commentRaw = await opData.GetTimeEntries(response);
                projectTitel = await opData.GetProjectTitle(response);
                entrieTime = await opData.GetEntrieTime(response);
                spentonDate = await opData.GetSpentOnDate(response);
                ticketId = await opData.GetTicketId(response);
                packageId = await opData.GetWorkpackages(response);
                workPackageProject = opData.GetWorkpackageProjectId(response);
                ancestor = await opData.GetAncestProjects(auth, workPackageProject,apiclient);
                customField = await opData.GetCustomField(auth,apiclient,packageId);
                Sum = sumTime.GetTimeSum(sumTime.GetTimeEntriesforConv(response));
                selectedUserName = selecetedUser.name;

            }

            Dictionary<string, List<string>> customFieldsSort = new Dictionary<string, List<string>>();
            //Workpackage IDS den jeweiligen customfields zuordnen
            foreach (var field in customField)
            {
                string[] parts = field.Split('/');
                if (!customFieldsSort.ContainsKey(parts[0]))
                {
                    customFieldsSort[parts[0]] = new List<string>();
                }
                if (!customFieldsSort[parts[0]].Contains(parts[1]))
                {
                    customFieldsSort[parts[0]].Add(parts[1]);
                }
                  
            }


            userData = userData.OrderBy(u => u.name).ToList();

            //Dictionary um die Ancestor Projekte den jeweiligen Projekten zuweisen zu können
            Dictionary<string, List<string>> ancestorGroup = new Dictionary<string, List<string>>();

           //"href" Attribut von Project und "title" Attribut von Ancestor sind die selbe Id. Diese nutzen um die Ancestor zuweisen zu können.
            foreach (var link in ancestor)
            {
                foreach (var entrie in link.ancestors)
                {
                    foreach (var projectId in projectTitel)
                    {
                        if (entrie.title == projectId.href)
                        {
                            if (!ancestorGroup.ContainsKey(projectId.href))
                            {
                                ancestorGroup[projectId.href] = new List<string>();
                            }
                            //sind ancestorIds bereits einmal einer projektId zugewiesen werden hiermit doppelte Einträge vermieden
                            if (!ancestorGroup[projectId.href].Contains(entrie.href))
                            {
                                ancestorGroup[projectId.href].Add(entrie.href);
                            }
                        }
                    }
                }
            }

           
            ViewModel model = new ViewModel
            {
                ancestorGroup=ancestorGroup,
                entries = commentRaw,
                userData = userData,
                project = projectTitel,
                hours = entrieTime,
                date = spentonDate,
                id = ticketId,
                timeSum = Sum,
                month = month,
                year = year,
                ancestorprojects = ancestor,
                workpackages = packageId,
                userId=userId,
                customFields=customFieldsSort,
                name=selectedUserName
            };

            //zur übergabe von model an andere Methode
            TempData["model"] = model;
     
            return View("GetCombinedView", model);
        }


        public async Task<ActionResult> GetRedMineData(string projectselect,int? ticketselect, List<int> packagechoice)
        {
            //übergabe von Model aus der ActionMethode"GetCombinedView"
            ViewModel model = TempData["model"] as ViewModel;
            TempData.Keep("model");

            var test1 = new RedMineTicketFinder();
            var test2 = new GetRedMineTimEntries();
            var test3 = new GetRedMineVersions();
            var test4 = new GetRedMineUsers();

            List<string> projektNum = new List<string>();

            foreach(var eintrag in model.customFields)
            {
                foreach (var kek in eintrag.Value)
                {
                    projektNum.Add(kek.Split(':')[1]);
                }
            }





            //RMDataRetrievel RedMineDataHandling = new RMDataRetrievel();
            RMDataManager RedMineDataHandling = new RMDataManager();
            RedMineEntrieFilter timeEntries = new RedMineEntrieFilter();

            List<RedMineTicketFinder.Issue> tickets = new List<Issue>();
            var entries = new List<RedMineTimeEntries.Time_Entries>();
            List<string> users = new List<string>();
            var filtered = new ViewModel();

            //wieder int? in string umgefordert...sonst Fehlermeldungen??
            string ticketnumber = ticketselect.ToString();
            
            

            if(packagechoice != null && packagechoice.Any())
            {
                filtered = await timeEntries.TimeEntrieFilter(projectselect, packagechoice, model,ticketnumber);
            }

            if (!string.IsNullOrEmpty(projectselect))
            {
                tickets = await RedMineDataHandling.GetRedMineVersion(projectselect, redmineAuth, redmineApiClient);
            }

                 entries= await RedMineDataHandling.GetTimeEntriesRedMine(redmineAuth);   
                 users = await RedMineDataHandling.GetUserRedMine(redmineAuth, redmineApiClient);



            var redmineModel = new RedMineViewModel
            {
                user = users,
                entries = entries,
                tickets = tickets,
                model = model,
                selectedProjekt = projectselect,
                filtered = filtered,
                projektNum = projektNum

            };




            return View("GetRedMineData",redmineModel);



        }




    }
}