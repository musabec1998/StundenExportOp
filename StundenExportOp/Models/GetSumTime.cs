using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class GetSumTime
    {
        //Frankenstein Methode um die Summe der Stunden zu erhalten
        public List<string> GetTimeSum(List<string> time)
        {

            List<double> hours = new List<double>();
            List<double> minutes = new List<double>();
            List<string> totalreturn = new List<string>();

            ViewModel total = new ViewModel();

            foreach (var element in time)
            {

                string[] geteilt = element.Split(':');
                //HH:MM Format in zwei Listen schreiben. Eine für Stunden eine für Minuten
                hours.Add((double)Int32.Parse(geteilt[0]));
                minutes.Add((double)Int32.Parse(geteilt[1]));

            }
            //Summe der Stunden und Minuten berechnen
            double hoursSum = hours.Sum();
            double minutesSum = minutes.Sum();
            //Minuten welche keine Stunde "bilden" ermitteln
            double minutesRest = minutesSum % 60;
            //Minuten in Stunden umrechnen
            double minutesWoRest = minutesSum / 60;
            //Minuten welche ganze Stunden ergeben und Stunden addieren
            double hoursTotal = hoursSum + minutesWoRest;
            //In string umwandeln da ich "komische" Ergebnisse bekomme die aber richtig sind. Mit Substring den falschen Teil entfernen
            string hoursTotalString = hoursTotal.ToString();
            string minutesString = minutesRest.ToString();

          
            try
            {

                for (int i = 0; i < hoursTotalString.Length; i++)
                {
                    if (hoursTotalString[i] == ',')
                    {
                        hoursTotalString = hoursTotalString.Remove(i);

                    }
                   
                }
                string combinedTime = hoursTotalString + ":" + minutesString;

                totalreturn.Add(combinedTime);


                total.timeSum = totalreturn;

                return totalreturn;

          
            }
            catch (Exception e)
            {
                return new List<string> {"keine Einträge"};
            }
        }

        //Konvertierung der Daten um mit ihnen arbeiten zu können.
        public List<string> GetTimeEntriesforConv(string response)
        {

            var json = JsonSerializer.Deserialize<TimeEntrie>(response);

            List<string> einträge = new List<string>();

            foreach (var element in json._embedded.elements)
            {

                einträge.Add(ConvertTime(element.hours));
            }

            return einträge;

        }
        //hatte diese methode schon zum umformen. So lässt sich die Zeit leichter in H und M aufteilen
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