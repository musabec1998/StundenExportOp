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
using static StundenExportOp.Models.RedMineVersions;

namespace StundenExportOp.Models
{
    public class GetRedMineVersions
    {
        //string proxyAddress = "192.168.179.35:3128";
        //HttpClient client = new HttpClient();


        //projektnummer = customfield39
        //in dieser Methode werden die projektnummern mit den Einträgen in Redmine verglichen.
        
        public async Task<List<Issue>> GetRedMineVersion(string projektnummer,string auth,RedMineApiClient client)
        {
            //List<string> projektnummer = parameter;


            //var handler = new HttpClientHandler()
            //{
            //    Proxy = new WebProxy(proxyAddress),
            //    UseProxy = true,
            //};

            //client = new HttpClient(handler);

           //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

            string versionAllUrl = "http://redmine.stiebel-eltron.com/redmine/projects/projektzeiterfassung-2014/versions.json";
            string response = await client.GetRedmineApiResponse(versionAllUrl,auth);

            var data = JsonSerializer.Deserialize<RedMineVersion>(response);

            List<int> versionsNumbers = new List<int>();


            //wenn die projektnummer mit dem eintrag in der redmine roadmap übereinstimmt wird die versionsID der liste hinzugefügt.
            foreach ( var element in data.versions)
            {
                //foreach (var nummer in projektnummer)
                //{

                    if (element.name.Split(' ')[0] == projektnummer)
                    {
                        versionsNumbers.Add(element.id);  
                    }
                //}

            }

            List<int> ticketIds = new List<int>();

            List<Issue> tickets = new List<Issue>();


            //anhand der versionsid is es möglich die einzelnen tickets welche einem Projekt zugeordnet sind zu erhalten
            foreach( var versionsNumber in versionsNumbers)
            {
                string versionUrl = ($"http://redmine.stiebel-eltron.com/redmine/issues.json?fixed_version_id={versionsNumber}");
                string versionresponse = await client.GetRedmineApiResponse(versionUrl,auth);

                var versionData = JsonSerializer.Deserialize<RedMineFinder>(versionresponse);

                foreach(var ticketid in versionData.issues)
                {
                    foreach(var value in ticketid.custom_fields)
                    {
                        //sind noch stunden verfügbar?
                        if (double.Parse(value.value) == 0)
                        {
                            DateTime dueDate = DateTime.Parse(ticketid.due_date);

                            if (dueDate <= DateTime.Today)
                            {
                                ticketIds.Add(ticketid.id);

                                var ticket = new Issue
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
                                    due_date=ticketid.due_date
                                    

                                
                                    
                                    


                                
                                    


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