using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        ApiFilterConstructor filter = new ApiFilterConstructor();


        //Methoden um Daten zu beziehen

        public async Task<string> GetApiResponseAsync(string url, string auth)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return await client.GetStringAsync(url);
        }
        public async Task<string> GetData(string userId,string auth,string year,string month) 
        {
            //Sortierfilter von OpenProjet. Für weitere Optionen die OpenProjekt Doku lesen
            string sort = "&sortBy=[[\"spentOn\",\"asc\"]]";

            //PageSize als Defaultwert 500 gesetzt. Dürfte immer alle Einträge abdecken
            string filter = this.filter.FilterConstruct(userId,year,month) + "&pageSize=500"+sort;

            string Url = $"https://project.aixtrusion.de/api/v3/time_entries?filters={filter}";
            
            string response = await GetApiResponseAsync(Url, auth);

            return response;

        }


    }
}