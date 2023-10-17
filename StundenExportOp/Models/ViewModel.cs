using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class ViewModel
    {
        public List<UserData> userData { get; set; }

        public List<TimeEntries.Project> project { get; set; }


        public List<TimeEntries.Comment> entries { get; set; }
        
        public List<TimeEntries.Element> hours { get; set; }

       public List<TimeEntries.Element> date { get; set; }
         public List<TimeEntries.Element> id { get; set; }


        public ViewModel()
        {
            userData = new List<UserData>();
            entries = new List<TimeEntries.Comment>();
            project = new List<TimeEntries.Project>();
            hours = new List<TimeEntries.Element>();
            date = new List<TimeEntries.Element>();
            id = new List<TimeEntries.Element>();

        }
    }
}