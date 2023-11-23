using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class GetWorkPackageProjectId
    {
        public LinkTrimm trimmer = new LinkTrimm();

        public  List <string> GetWorkpackageProjectId(string response)
        {

            var data = JsonSerializer.Deserialize<TimeEntrie>(response);

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


    }
}