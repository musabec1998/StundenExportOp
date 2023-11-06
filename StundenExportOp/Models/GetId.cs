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
    public class GetId
    {


        public async Task<List<TimeEntries.Element>> GetTicketId(string response)
        {
        
            var json = JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel ticket = new ViewModel();

            foreach (var element in json._embedded.elements)
            {
                var tId = new TimeEntries.Element
                {
                    id = element.id
                };

                ticket.id.Add(tId);

            }
            return ticket.id;



        }
    }
}