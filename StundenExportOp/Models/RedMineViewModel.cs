using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StundenExportOp.Models.RedMineTicketFinder;

namespace StundenExportOp.Models
{
    public class RedMineViewModel
    {
        public List<string> user { get; set; }

        public List <RedMineTimeEntries.Time_Entries> entries { get; set; }

        public List<RedMineTicketFinder.Issue> tickets { get; set; }

        public List<string> projektNum { get; set; }

        public ViewModel model { get; set; }

        public string selectedProjekt { get; set; }

        public int? ticketselect { get; set; }

        public ViewModel filtered = new ViewModel();



        public RedMineViewModel()
        {
            user = new List<string>();
            entries = new List<RedMineTimeEntries.Time_Entries>();
            tickets = new List<RedMineTicketFinder.Issue>();
            projektNum= new List<string>();
            model = new ViewModel();
           
        }
        



    }
}