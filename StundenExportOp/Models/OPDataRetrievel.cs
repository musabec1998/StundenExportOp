using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.Projects;
using static StundenExportOp.Models.TimeEntries;
using Project = StundenExportOp.Models.TimeEntries.Project;

namespace StundenExportOp.Models
{
    public class OPDataRetrievel
    {
        LinkTrimm trimmer = new LinkTrimm();





        public async Task<List<TimeEntries.Element>> GetSpentOnDate(string response)
        {

            var json = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel date = new ViewModel();


            foreach (var element in json._embedded.elements)
            {
                var spentOnDate = new TimeEntries.Element
                {
                    spentOn = element.spentOn
                };

                date.date.Add(spentOnDate);

            }

            return date.date;

        }

        public async Task<List<TimeEntries.Comment>> GetTimeEntries(string response)
        {


            var json = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel entrie = new ViewModel();

            //daten von Anfrage werden in die Viewmodel Liste geschrieben
            foreach (var element in json._embedded.elements)
            {
                var entries = new TimeEntries.Comment
                {
                    raw = element.comment.raw
                };

                entrie.entries.Add(entries);

            }


            return entrie.entries;

        }


        public async Task<List<TimeEntries.Element>> GetTicketId(string response)
        {

            var json = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel ticket = new ViewModel();

            foreach (var element in json._embedded.elements)
            {
                var tId = new TimeEntries.Element
                {
                    id = element.id
                };

                ticket.id.Add(tId);

            }
            return ticket.id;

        }


        public async Task<List<TimeEntries.Project>> GetProjectTitle(string response)
        {


            var json = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel project = new ViewModel();

            foreach (var element in json._embedded.elements)
            {
                var projects = new TimeEntries.Project
                {

                    title = element._links.project.title,
                    href = trimmer.TrimStringforId(element._links.project.href)

                };
                project.project.Add(projects);


            }

            return project.project;


        }

        public async Task<List<UserData>> GetUserData(string auth, ApiClient client)
        {
            //suchstring für User
            string usersUrl = "https://project.aixtrusion.de/api/v3/users?pageSize=500";
            string response = await client.GetApiResponseAsync(usersUrl, auth);
            var data = System.Text.Json.JsonSerializer.Deserialize<Users.User>(response);

            List<UserData> userDataList = new List<UserData>();

            //daten von Anfrage werden in die Viewmodel Liste geschrieben
            foreach (var element in data._embedded.elements)
            {
                var user = new UserData
                {
                    id = element.id,
                    name = element.name
                };

                userDataList.Add(user);
            }
            return userDataList;

        }

        public async Task<List<TimeEntries.Workpackage>> GetWorkpackages(string response)
        {


            var data = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel packages = new ViewModel();


            foreach (var element in data._embedded.elements)
            {
                var packageId = new TimeEntries._Links
                {
                    workPackage = new Workpackage
                    {
                        href = trimmer.TrimStringforId(element._links.workPackage.href)

                    }
                };


                packages.workpackages.Add(packageId.workPackage);
            }


            return packages.workpackages;

        }

        public List<string> GetWorkpackageProjectId(string response)
        {

            var data = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            List<string> projects = new List<string>();

            foreach (var element in data._embedded.elements)
            {
                var packageId = new TimeEntries._Links
                {
                    project = new Project
                    {
                        href = trimmer.TrimStringforId(element._links.project.href),
                    }
                };
                projects.Add(trimmer.TrimStringforId(element._links.project.href));


                //projects.Add(packageId);
            }


            return projects;

        }

        public async Task<List<string>> GetCustomField(string auth, ApiClient client, List<TimeEntries.Workpackage> projectId)
        {
            List<string> customField = new List<string>();

            //um keine doppelte abfrage für die selbe ID durchzuführen
            var distinctWorkpackages = projectId.GroupBy(p => p.href).Select(g => g.First());

            foreach (var id in distinctWorkpackages)
            {

                string url = ($"https://project.aixtrusion.de/api/v3/work_packages/{id.href}");

                string response = await client.GetApiResponseAsync(url, auth);

                dynamic data = await Task.Run(() => JsonConvert.DeserializeObject(response));


                if (data.customField39 != null)
                {
                    if (data.customField39 != null)
                    {//WorkpackageNr einfügen um später leichter die Customfields den jeweiligen Workpackages zuordnen zu können
                        customField.Add(id.href + "/KundenProjNr:" + data.customField39.ToString());
                    }
                    if (data.customField29 != null)
                    {
                        customField.Add(id.href + "/KundenTicketNr:" + data.customField29.ToString());
                    }
                    if (data.customField28 != null)
                    {
                        customField.Add(id.href + "/Bestellnummer:" + data.customField28);
                    }
                    if (data.customField27 != null)
                    {
                        customField.Add(id.href + "/aiX-Angebotsnr:" + data.customField27);
                    }
                    else if (data.customField23 != null)
                    {
                        customField.Add("CustomField23 " + data.customField23);
                    }
                }
            }

            return customField;
        }


        public async Task<List<Projects._Links>> GetAncestProjects(string auth, List<string> projectId, ApiClient client)
        {
            List<Projects._Links> ancestorList = new List<Projects._Links>();

            //um keine doppelte abfrage für die selbe ID durchzuführen
            var distinctProjectIds = projectId.Distinct();

            //liste mit ProjektIds als parameter übergeben um diese als Filter in der URL zu verwenden.
            foreach (var id in distinctProjectIds)
            {
                string urlFilter = Uri.EscapeDataString($"[{{\"id\":{{\"operator\":\"=\",\"values\":[\"{id}\"]}}}}]");
                string url = ($"https://project.aixtrusion.de/api/v3/projects?filters={urlFilter}&pageSize=1000");

                string response = await client.GetApiResponseAsync(url, auth);
                var data = await Task.Run(() => System.Text.Json.JsonSerializer.Deserialize<Projects.Project>(response));



                foreach (var element in data._embedded.elements)
                {
                    foreach (var entry in element._links.ancestors)
                    {
                        var ancestor = new Projects._Links
                        {
                            ancestors = new Ancestor[]
                        {
                        new Ancestor
                        {
                            //in title schreibe ich die ID des jeweiligen Projekts um die Ancestor den Projekten zurodnen zu können
                         href = trimmer.TrimStringforId(entry.href) +" / "+ entry.title,
                         title= id.ToString()
                        }

                        }

                        };

                        ancestorList.Add(ancestor);


                    }

                }

            }

            return ancestorList;

        }


        public async Task<List<TimeEntries.Element>> GetEntrieTime(string response)
        {

            var json = System.Text.Json.JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel hour = new ViewModel();

            foreach (var element in json._embedded.elements)
            {
                var hours = new TimeEntries.Element
                {
                    hours = ConvertTime(element.hours)
                };

                hour.hours.Add(hours);
            }

            return hour.hours;

        }

        //Zeit von OpenProject Format ""PT1H1M" in "HH:MM" umformen
        public string ConvertTime(string input)
        {
            string pattern = @"PT(?:(\d+)H)?(?:(\d+)M)?";

            Match m = Regex.Match(input, pattern);

            string hour = m.Groups[1].Value;
            string minute = m.Groups[2].Value;

            hour = string.IsNullOrEmpty(hour) ? "00" : int.Parse(hour).ToString("00");
            minute = string.IsNullOrEmpty(minute) ? "00" : int.Parse(minute).ToString("00");


            string zeit = hour + ":" + minute;

            return zeit;
        }











    }






















}
