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
    public class GetEntries
    {



        public async Task<List<TimeEntries.Comment>> GetTimeEntries(string year,string month, string userId,ApiClient client,string auth)
        {

            int id = Int32.Parse(userId);

            string filter = Uri.EscapeDataString($"[{{\"spentOn\":{{\"operator\":\"<>d\",\"values\":[\"{year + month.Substring(0, 5)}\",\"{year + month.Substring(5)}\"]}}}},{{\"user\":{{\"operator\":\"=\",\"values\":[\"{id}\"]}}}}]")+"&pageSize=500";
            string filterpage = filter + "&pageSize=500";
            string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filter}";


            string response = await client.GetApiResponseAsync(Url,auth);



            var json =JsonSerializer.Deserialize<TimeEntrie>(response);
                

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
    }
}