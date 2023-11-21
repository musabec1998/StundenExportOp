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

        public async Task<List<TimeEntries.Comment>> GetTimeEntries(string response)
        {
        
        string test = "hallo commit test";
        string test2 = "hallo";
        
        string test3 = "hallo3";
        string test4 = "hallo4";

          
            var json = JsonSerializer.Deserialize<TimeEntrie>(response);
                
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
