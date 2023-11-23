using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

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

        public List<string> timeSum { get; set; }

        public List<TimeEntries.Workpackage> workpackages { get; set; }

       
        public List<Projects._Links> ancestorprojects { get; set; }
        public Dictionary<string, List<string>> ancestorGroup { get; set; }
        public Dictionary<string, List<string>> customFields { get; set; }

        public string ticketselect { get; set; }




        //public List<WorkPackages.Customfield39> customfield39 { get; set; }


        public string name { get; set; }
        public string month { get; set; }
        public string year { get; set; }

        public int? userId { get; set; }



        public ViewModel()
        {
            userData = new List<UserData>();
            entries = new List<TimeEntries.Comment>();
            project = new List<TimeEntries.Project>();
            hours = new List<TimeEntries.Element>();
            date = new List<TimeEntries.Element>();
            id = new List<TimeEntries.Element>();
            timeSum = new List<string>();
            workpackages = new List<TimeEntries.Workpackage>();
            ancestorprojects = new List<Projects._Links>();
            ancestorGroup = new Dictionary<string, List<string>>();
            customFields = new Dictionary<string, List<string>>();

            //customfield39 = new List<WorkPackages.Customfield39>();
        }
    }
}