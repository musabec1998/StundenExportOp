using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StundenExportOp.Models
{
    public class ViewModelFiller
    {
        public async Task <ViewModel>  ViewModelFilling(int?userId,ApiClient apiclient,string auth,string year,string month)
        {

            //id in string Konvertieren...andernfalls Fehlermeldung???
            string id = userId.ToString();


            GetEntries entries = new GetEntries();
            GetUser user = new GetUser();
            GetProject project = new GetProject();
            GetTime hours = new GetTime();
            GetDate date = new GetDate();
            GetId tId = new GetId();
            GetSumTime sumTime = new GetSumTime();




            //erstelle Listen um Daten an Viewmodel weitergeben zu können
            List<TimeEntries.Comment> commentRaw = new List<TimeEntries.Comment>();
            List<UserData> userData = await user.GetUserData(auth, apiclient);
            List<TimeEntries.Project> projectTitel = new List<TimeEntries.Project>();
            List<TimeEntries.Element> entrieTime = new List<TimeEntries.Element>();
            List<TimeEntries.Element> spentonDate = new List<TimeEntries.Element>();
            List<TimeEntries.Element> ticketId = new List<TimeEntries.Element>();
            List<string> Sum = new List<String>();


            if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(month))
            {
                //in "response" werden die Time_Entries(in bereits gefilterter Form) geschrieben und an die anderen Methoden weitergegeben als Parameter
                string response = await apiclient.GetData(id, auth,year,month);

                commentRaw = await entries.GetTimeEntries(response);
                projectTitel = await project.GetProjectTitle(response);
                entrieTime = await hours.GetEntrieTime(response);
                spentonDate = await date.GetSpentOnDate(response);
                ticketId = await tId.GetTicketId(response);
                Sum = sumTime.GetTimeSum(sumTime.GetTimeEntriesforConv(response));
            }

            userData = userData.OrderBy(u => u.name).ToList();

            ViewModel model = new ViewModel
            {
                entries = commentRaw,
                userData = userData,
                project = projectTitel,
                hours = entrieTime,
                date = spentonDate,
                id = ticketId,
                timeSum = Sum,
                
            };
            return model;

        }












    }
}