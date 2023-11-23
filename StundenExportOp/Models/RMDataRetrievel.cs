using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.RedMineTicketFinder;
using static StundenExportOp.Models.RedMineTimeEntries;
using static StundenExportOp.Models.RedMineUsers;
using static StundenExportOp.Models.RedMineVersions;
using Project = StundenExportOp.Models.RedMineTimeEntries.Project;
using User = StundenExportOp.Models.RedMineTimeEntries.User;

namespace StundenExportOp.Models
{
    public class RMDataRetrievel
    {

        HttpClient client = new HttpClient();
        private string proxyAdress = "192.168.179.35:3128";


        public async Task<List<RedMineTimeEntries.Time_Entries>> GetTimeEntriesRedMine(string auth/*,RedMineApiClient client*/)
        {


            var handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyAdress),
                UseProxy = true,
            };

            client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);


            string entriesUrl = "http://redmine.stiebel-eltron.com/redmine/time_entries.json?project_id=262";
            string response = await client.GetStringAsync(entriesUrl);

            var data = JsonSerializer.Deserialize<RedMineTimeEntrie>(response);

            List<Time_Entries> entries = new List<Time_Entries>();

            foreach (var element in data.time_entries)
            {
                if (element.user.name.Contains("(aix)"))
                {
                    var entrie = new Time_Entries
                    {
                        project = new Project { name = element.project.name },
                        user = new User { name = element.user.name },
                        comments = element.comments
                    };
                }
            }


            return entries;

        }


        public async Task<List<string>> GetUserRedMine(string auth, RedMineApiClient client)
        {
            string userUrl = "http://redmine.stiebel-eltron.com/redmine/projects/262/memberships.json";
            string response = await client.GetRedmineApiResponse(userUrl, auth);

            var data = JsonSerializer.Deserialize<RedMineUser>(response);

            List<string> userIds = new List<string>();

            foreach (var element in data.memberships)
            {
                if (element.user == null || element.user.name == null)
                {
                    continue;
                }

                if (element.user.name.Contains("(aix)"))
                {
                    userIds.Add(element.user.id.ToString() + ":" + element.user.name);
                }

            }

            return userIds;


        }


        public async Task<List<RedMineTicketFinder.Issue>> GetRedMineVersion(string projektnummer, string auth, RedMineApiClient client)
        {
    
            string versionAllUrl = "http://redmine.stiebel-eltron.com/redmine/projects/projektzeiterfassung-2014/versions.json";
            string response = await client.GetRedmineApiResponse(versionAllUrl, auth);

            var data = JsonSerializer.Deserialize<RedMineVersion>(response);

            List<int> versionsNumbers = new List<int>();


            //wenn die projektnummer mit dem eintrag in der redmine roadmap übereinstimmt wird die versionsID der liste hinzugefügt.
            foreach (var element in data.versions)
            {
               
                if (element.name.Split(' ')[0] == projektnummer)
                {
                    versionsNumbers.Add(element.id);
                }
                

            }

            List<int> ticketIds = new List<int>();

            List<RedMineTicketFinder.Issue> tickets = new List<RedMineTicketFinder.Issue>();


            //anhand der versionsid is es möglich die einzelnen tickets welche einem Projekt zugeordnet sind zu erhalten
            foreach (var versionsNumber in versionsNumbers)
            {
                string versionUrl = ($"http://redmine.stiebel-eltron.com/redmine/issues.json?fixed_version_id={versionsNumber}");
                string versionresponse = await client.GetRedmineApiResponse(versionUrl, auth);

                var versionData = JsonSerializer.Deserialize<RedMineTicketFinder.RedMineFinder>(versionresponse);

                foreach (var ticketid in versionData.issues)
                {
                    foreach (var value in ticketid.custom_fields)
                    {
                        //sind noch stunden verfügbar?
                        if (double.Parse(value.value) == 0)
                        {
                            DateTime dueDate = DateTime.Parse(ticketid.due_date);

                            if (dueDate <= DateTime.Today)
                            {
                                ticketIds.Add(ticketid.id);

                                var ticket = new RedMineTicketFinder.Issue
                                {
                                    id = ticketid.id,
                                    subject = ticketid.subject,
                                    description = ticketid.description,
                                    fixed_version = new Fixed_Version
                                    {
                                        name = ticketid.fixed_version.name
                                    },

                                    custom_fields = new RedMineTicketFinder.Custom_Fields[]
                                    {
                                        new RedMineTicketFinder.Custom_Fields
                                        {
                                            value = value.value
                                        }
                                    },
                                    due_date = ticketid.due_date


                                };
                                tickets.Add(ticket);

                            }
                        }
                    }

                }

            }

            return tickets;


        }

      


    }



    }
