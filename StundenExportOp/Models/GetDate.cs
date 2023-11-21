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
string windowsbranchtest = "hallobranch";


        public async Task<List<TimeEntries.Element>> GetSpentOnDate(string response)
        {
            
            var json =  JsonSerializer.Deserialize<TimeEntrie>(response);

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