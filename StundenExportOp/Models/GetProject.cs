using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class GetProject
    {
        LinkTrimm trimmer = new LinkTrimm();

        public async Task<List<TimeEntries.Project>> GetProjectTitle(string response)
        {
            

            var json = JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel project = new ViewModel();

            foreach(var element in json._embedded.elements)
            {
                var projects = new TimeEntries.Project
                {

                    title = element._links.project.title,
                    href= trimmer.TrimStringforId(element._links.project.href)
                               
                };
                project.project.Add(projects);


            }

            return project.project;


        }


    }
}