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


        public async Task<List<TimeEntries.Element>> GetEntrieTime(string response)
        {
       
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

        //Zeit von OpenProject Format ""PT1H1M" in "HH:MM" umformen
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