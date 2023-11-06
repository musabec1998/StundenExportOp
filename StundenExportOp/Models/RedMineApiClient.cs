using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StundenExportOp.Models
{
    public class RedMineApiClient
    {

        HttpClient client = new HttpClient();
        private string proxyAdress= "192.168.179.35:3128";





        public async Task<string> GetRedmineApiResponse(string url,string auth)
        {
            var handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyAdress),
                UseProxy = true,
            };

            client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

            return await client.GetStringAsync(url);

        }

    
    }
}