using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class TimeEntries
    {
        //Datum und Ticket ID noch anzeigen


        public class TimeEntrie
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public int pageSize { get; set; }
            public int offset { get; set; }
            public _Embedded _embedded { get; set; }
            public _Links1 _links { get; set; }
        }

        public class _Embedded
        {
            public Element[] elements { get; set; }
        }

        public class Element
        {
            public string _type { get; set; }
            public int id { get; set; }
            public Comment comment { get; set; }
            public string spentOn { get; set; }
            public string hours { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string customField22 { get; set; }
            public string customField25 { get; set; }
            public _Links _links { get; set; }
        }

        public class Comment
        {
            public string format { get; set; }
            public string raw { get; set; }
            public string html { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public Updateimmediately updateImmediately { get; set; }
            public Update update { get; set; }
            public Delete delete { get; set; }
            public Schema schema { get; set; }
            public Project project { get; set; }
            public Workpackage workPackage { get; set; }
            public User user { get; set; }
            public Activity activity { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Updateimmediately
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Update
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Delete
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Schema
        {
            public string href { get; set; }
        }

        public class Project
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Workpackage
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class User
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Activity
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
            public Jumpto jumpTo { get; set; }
            public Changesize changeSize { get; set; }
            public Nextbyoffset nextByOffset { get; set; }
            public Createtimeentry createTimeEntry { get; set; }
            public Createtimeentryimmediately createTimeEntryImmediately { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Jumpto
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Changesize
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Nextbyoffset
        {
            public string href { get; set; }
        }

        public class Createtimeentry
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Createtimeentryimmediately
        {
            public string href { get; set; }
            public string method { get; set; }
        }



    }
}