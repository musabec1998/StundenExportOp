using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class GetTime
    {
        public HttpClient client = new HttpClient();


        public async Task<List<TimeEntries.Element>> GetEntrieTime(string year,string month, string userId, string apiKey)
        {

            int id = Int32.Parse(userId);
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:" + apiKey));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);


            string filter = Uri.EscapeDataString($"[{{\"spentOn\":{{\"operator\":\"<>d\",\"values\":[\"{year + month.Substring(0, 5)}\",\"{year + month.Substring(5)}\"]}}}},{{\"user\":{{\"operator\":\"=\",\"values\":[\"{id}\"]}}}}]");
            string filterpage = filter + "&pageSize=1000";
            string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filterpage}&pageSize=1000";


            string response = await client.GetStringAsync(Url);


            var json = JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel hour = new ViewModel();


            foreach(var element in json._embedded.elements)
            {
                var hours = new TimeEntries.Element
                {
                    hours = ConvertTime(element.hours)
                };

                hour.hours.Add(hours);
            }

            return hour.hours;





        }
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