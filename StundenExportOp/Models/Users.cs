using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class Users
    {

        public class User
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
            public string name { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string login { get; set; }
            public bool admin { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string avatar { get; set; }
            public string status { get; set; }
            public object identityUrl { get; set; }
            public string language { get; set; }
            public _Links _links { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public Memberships memberships { get; set; }
            public Showuser showUser { get; set; }
            public Updateimmediately updateImmediately { get; set; }
            public Lock _lock { get; set; }
            public Delete delete { get; set; }
            public Unlock unlock { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Memberships
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Showuser
        {
            public string href { get; set; }
            public string type { get; set; }
        }

        public class Updateimmediately
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Lock
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Delete
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Unlock
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
            public Jumpto jumpTo { get; set; }
            public Changesize changeSize { get; set; }
            public Nextbyoffset nextByOffset { get; set; }
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

    }
}