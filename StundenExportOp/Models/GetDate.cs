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
    public class GetDate
    {
        public HttpClient client = new HttpClient();



        public async Task<List<TimeEntries.Element>> GetSpentOnDate(string year, string month, string userId, string apiKey)
        {
            int id = Int32.Parse(userId);
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:" + apiKey));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);


            string filter = Uri.EscapeDataString($"[{{\"spentOn\":{{\"operator\":\"<>d\",\"values\":[\"{year + month.Substring(0, 5)}\",\"{year + month.Substring(5)}\"]}}}},{{\"user\":{{\"operator\":\"=\",\"values\":[\"{id}\"]}}}}]");
            string filterpage = filter + "&pageSize=1000";
            string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filterpage}&pageSize=1000";


            string response = await client.GetStringAsync(Url);


            var json = JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel date = new ViewModel();


            foreach(var element in json._embedded.elements)
            {
                var spentOnDate = new TimeEntries.Element
                {
                    spentOn= element.spentOn
                };

                date.date.Add(spentOnDate);
            
            }

            return date.date;






        }

    }

}