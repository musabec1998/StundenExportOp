using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StundenExportOp.Models
{
    public class RedMineEntrieFilter
    {

        public async Task<ViewModel> TimeEntrieFilter(string projektnummer,List<int> entrieIndex, ViewModel model,string ticketselect)
        {

            ViewModel filtered= new ViewModel();

            ViewModel test = model;


            foreach(var number in entrieIndex)
            {
                filtered.entries.Add(model.entries[number]);
                filtered.date.Add(model.date[number]);
                filtered.hours.Add(model.hours[number]);
                filtered.project.Add(model.project[number]);
                filtered.workpackages.Add(model.workpackages[number]);
                filtered.name= model.name;
                filtered.ticketselect = ticketselect;


                
            }





            return filtered;


        }







    }
}