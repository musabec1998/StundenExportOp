using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;


namespace StundenExportOp.Models
{
    public class ApiFilterConstructor
    {

        //In die Klasse "FilterClass" weitere Klassen einfügen um diese als weitere Filter parameter verwenden zu können
        public string FilterConstruct(string userId,string year,string month)
        {
            //Filterwerte welche durch die View an den Controller gegeben werden hier verwenden
            string[] spentOnValue = {year+month.Substring(0,5),year+month.Substring(5)};
            string[] userValue = {userId};

            //string[] filterList = new string[25];

            //Objekte von Klassen bilden und im Anschluss in serialisierter form in den "finalFilter" einfügen
            var filter = new FilterClass.Class1
            {
                spentOn = new FilterClass.Spenton
                {
                    @operator = "<>d",
                    values = spentOnValue
                }
            };

            var filter2 = new FilterClass.Class2
            {
                user = new FilterClass.User
                {
                    @operator = "=",
                    values = userValue
                }
            };

            //foreach(var filterValue in filterList)
            //{
            //    JsonSerializer.Serialize(filterValue);

            //}


            //serialisierung der Filter
            string jsonFilter = JsonSerializer.Serialize(filter);
            string jsonFilter2 = JsonSerializer.Serialize(filter2);

            //zusammensetzen des Filterstrings um an die URL anfügen zu können
            string finalFilter = $"[{jsonFilter},{jsonFilter2}]";

            return Uri.EscapeDataString(finalFilter);

        }
    }
}