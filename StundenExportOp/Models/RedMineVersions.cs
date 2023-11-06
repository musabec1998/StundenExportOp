using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    //diese Klasse stellt die Struktur von dem unterpunkt"Roadmap" in Redmine dar welcher die Projektnummern beinhaltet
    public class RedMineVersions
    {

        public class RedMineVersion
        {
            public Version[] versions { get; set; }
            public int total_count { get; set; }
        }

        public class Version
        {
            public int id { get; set; }
            public Project project { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string status { get; set; }
            public string sharing { get; set; }
            public Custom_Fields[] custom_fields { get; set; }
            public DateTime created_on { get; set; }
            public DateTime updated_on { get; set; }
            public string due_date { get; set; }
        }

        public class Project
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Custom_Fields
        {
            public int id { get; set; }
            public string name { get; set; }
            public string value { get; set; }
        }




    }
}