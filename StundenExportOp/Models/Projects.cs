using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace StundenExportOp.Models
{
    public class Projects
    {



        public class Project
        {
            internal string href;

            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public int pageSize { get; set; }
            public int offset { get; set; }
            public _Embedded _embedded { get; set; }
            public _Links1 _links { get; set; }
        }

        [XmlType(TypeName = "ProjectEmebedded")]
        public class _Embedded
        {
            public Element[] elements { get; set; }
        }
        [XmlType(TypeName = "ProjectElement")]
        public class Element
        {
            public string _type { get; set; }
            public int id { get; set; }
            public string identifier { get; set; }
            public string name { get; set; }
            public bool active { get; set; }
            public bool _public { get; set; }
            public Description description { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public Statusexplanation statusExplanation { get; set; }
            public bool? customField30 { get; set; }
            public _Links _links { get; set; }
        }

        public class Description
        {
            public string format { get; set; }
            public string raw { get; set; }
            public string html { get; set; }
        }

        public class Statusexplanation
        {
            public string format { get; set; }
            public string raw { get; set; }
            public string html { get; set; }
        }

        [XmlType(TypeName="ProjectLinks")]
        public class _Links
        {
            public Self self { get; set; }
            public Createworkpackage createWorkPackage { get; set; }
            public Createworkpackageimmediately createWorkPackageImmediately { get; set; }
            public Workpackages workPackages { get; set; }
            public Categories categories { get; set; }
            public Versions versions { get; set; }
            public Memberships memberships { get; set; }
            public Types types { get; set; }
            public Update update { get; set; }
            public Updateimmediately updateImmediately { get; set; }
            public Delete delete { get; set; }
            public Schema schema { get; set; }
            public Status status { get; set; }
            public Ancestor[] ancestors { get; set; }
            public Parent parent { get; set; }
        }

        [XmlType(TypeName="ProjectSelf")]
        public class Self
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Createworkpackage

        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Createworkpackageimmediately
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Workpackages
        {
            public string href { get; set; }
        }

        public class Categories
        {
            public string href { get; set; }
        }

        public class Versions
        {
            public string href { get; set; }
        }

        public class Memberships
        {
            public string href { get; set; }
        }

        public class Types
        {
            public string href { get; set; }
        }
        [XmlType(TypeName = "ProjectUpdate")]
        public class Update
        {
            public string href { get; set; }
            public string method { get; set; }
        }
        [XmlType(TypeName = "ProjectUpdateimmediately")]
        public class Updateimmediately
        {
            public string href { get; set; }
            public string method { get; set; }
        }
        [XmlType(TypeName = "ProjectDelete")]
        public class Delete
        {
            public string href { get; set; }
            public string method { get; set; }
        }
        [XmlType(TypeName = "ProjectSchema")]
        public class Schema
        {
            public string href { get; set; }
        }

        public class Status
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Parent
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Ancestor
        {
            public string href { get; set; }
            public string title { get; set; }
        }
        [XmlType(TypeName = "ProjectLinks1")]
        public class _Links1
        {
            public Self1 self { get; set; }
            public Jumpto jumpTo { get; set; }
            public Changesize changeSize { get; set; }
            public Representation[] representations { get; set; }
        }
        [XmlType(TypeName = "ProjectSelf1")]
        public class Self1
        {
            public string href { get; set; }
        }
        [XmlType(TypeName = "ProjectJumpto")]
        public class Jumpto
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }
        [XmlType(TypeName = "ProjectChangeSize")]
        public class Changesize
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Representation
        {
            public string href { get; set; }
            public string identifier { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

    }
}