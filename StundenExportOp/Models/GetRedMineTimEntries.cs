using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.RedMineTimeEntries;

namespace StundenExportOp.Models
{
    public class GetRedMineTimEntries
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

            foreach( var element in data.time_entries)
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


    }
}