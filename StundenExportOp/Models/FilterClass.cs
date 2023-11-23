using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class FilterClass
    {
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public Spenton spentOn { get; set; }
        }
        public class Class2
        {
            public User user { get; set; }
        }

        public class Class3
        {
            public Project project { get; set; }
        }

        public class Spenton
        {
            public string @operator { get; set; }
            public string[] values { get; set; }
        }

        public class User
        {
            public string @operator { get; set; }
            public string[] values { get; set; }
        }

        public class Project
        {
            public string @operator { get; set; }
            public string[]values { get; set; }
        }
    }
}