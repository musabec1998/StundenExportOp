using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace StundenExportOp.Models
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();


        public async Task<string> GetApiResponseAsync(string url, string auth)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return await client.GetStringAsync(url);
        }

        public async Task<string> GetData(string year,string month,string userId,string auth) 
        {
            string filter = Uri.EscapeDataString($"[{{\"spentOn\":{{\"operator\":\"<>d\",\"values\":[\"{year + month.Substring(0, 5)}\",\"{year + month.Substring(5)}\"]}}}},{{\"user\":{{\"operator\":\"=\",\"values\":[\"{userId}\"]}}}}]");
            string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filter}";

            string response = await GetApiResponseAsync(Url, auth);

            return response;

        }


    }
}