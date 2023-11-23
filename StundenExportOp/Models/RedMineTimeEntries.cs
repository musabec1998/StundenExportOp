using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StundenExportOp.Models.RedMineTicketFinder;

namespace StundenExportOp.Models
{
    public class RedMineTimeEntries
    {


        public class RedMineTimeEntrie
        {
            public Time_Entries[] time_entries { get; set; }
            public int total_count { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
        }

        public class Time_Entries
        {
            public int id { get; set; }
            public Project project { get; set; }
            public Issue issue { get; set; }
            public User user { get; set; }
            public Activity activity { get; set; }
            public float hours { get; set; }
            public string comments { get; set; }
            public string spent_on { get; set; }
            public DateTime created_on { get; set; }
            public DateTime updated_on { get; set; }
        }

        public class Project
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Issue
        {
            public int id { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Activity
        {
            public int id { get; set; }
            public string name { get; set; }
        }


    }
}