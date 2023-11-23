using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class RedMineUsers
    {

        public class RedMineUser
        {
            public Membership[] memberships { get; set; }
            public int total_count { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
        }

        public class Membership
        {
            public int id { get; set; }
            public Project project { get; set; }
            public User user { get; set; }
            public Role[] roles { get; set; }
            public Group group { get; set; }
        }

        public class Project
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Group
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Role
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool inherited { get; set; }
        }



    }
}