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

      

        public async Task<List<TimeEntries.Comment>> GetTimeEntries(string year,string month,string _apiKey,HttpClient client,string auth)
        {
            

            using (client)           
            {
                //Autorisierung
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

                //filter für Api Anfrage.Jahr und Monat getrennt für Dynamische Filteranpassung
                string filter = Uri.EscapeDataString($"[{{\"spentOn\":{{\"operator\":\"<>d\",\"values\":[\"{year + month.Substring(0, 5)}\",\"{year + month.Substring(5)}\"]}}}},{{\"user\":{{\"operator\":\"=\",\"values\":[\"108\"]}}}}]");
                string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filter}";
                
                //Api antwort wird deserialized
                string response = await client.GetStringAsync("https://project.aixtrusion.de/api/v3/time_entries");
                var data = JsonSerializer.Deserialize<TimeEntrie>(response);
                
                List<TimeEntries.Comment> timeEntriesList = new List<TimeEntries.Comment>();

                ViewModel entrie = new ViewModel();

                //daten von Anfrage werden in die Viewmodel Liste geschrieben
                foreach (var element in data._embedded.elements)
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
}