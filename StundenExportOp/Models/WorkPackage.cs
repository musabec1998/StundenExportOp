using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class WorkPackage
    {


        public class Package
        {
            public object derivedStartDate { get; set; }
            public object derivedDueDate { get; set; }
            public string spentTime { get; set; }
            public string laborCosts { get; set; }
            public string materialCosts { get; set; }
            public string overallCosts { get; set; }
            public _Embedded _embedded { get; set; }
            public string _type { get; set; }
            public int id { get; set; }
            public int lockVersion { get; set; }
            public string subject { get; set; }
            public Description1 description { get; set; }
            public bool scheduleManually { get; set; }
            public string startDate { get; set; }
            public string dueDate { get; set; }
            public string estimatedTime { get; set; }
            public object derivedEstimatedTime { get; set; }
            public string duration { get; set; }
            public bool ignoreNonWorkingDays { get; set; }
            public int percentageDone { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public int position { get; set; }
            public object storyPoints { get; set; }
            public object remainingTime { get; set; }
            public object customField39 { get; set; }
            public object customField29 { get; set; }
            public object customField23 { get; set; }
            public object customField28 { get; set; }
            public object customField27 { get; set; }
            public _Links10 _links { get; set; }
        }

        public class _Embedded
        {
            public Attachments attachments { get; set; }
            public Relations relations { get; set; }
            public Type type { get; set; }
            public Priority priority { get; set; }
            public Project project { get; set; }
            public Status1 status { get; set; }
            public Author author { get; set; }
            public Responsible responsible { get; set; }
            public Assignee assignee { get; set; }
            public object[] customActions { get; set; }
            public Costsbytype costsByType { get; set; }
        }

        public class Attachments
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public _Embedded1 _embedded { get; set; }
            public _Links _links { get; set; }
        }

        public class _Embedded1
        {
            public object[] elements { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Relations
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public _Embedded2 _embedded { get; set; }
            public _Links1 _links { get; set; }
        }

        public class _Embedded2
        {
            public object[] elements { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Type
        {
            public string _type { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string color { get; set; }
            public int position { get; set; }
            public bool isDefault { get; set; }
            public bool isMilestone { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public _Links2 _links { get; set; }
        }

        public class _Links2
        {
            public Self2 self { get; set; }
        }

        public class Self2
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Priority
        {
            public string _type { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int position { get; set; }
            public object color { get; set; }
            public bool isDefault { get; set; }
            public bool isActive { get; set; }
            public _Links3 _links { get; set; }
        }

        public class _Links3
        {
            public Self3 self { get; set; }
        }

        public class Self3
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Project
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
            public object customField30 { get; set; }
            public _Links4 _links { get; set; }
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

        public class _Links4
        {
            public Self4 self { get; set; }
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

        public class Self4
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

        public class Update
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Updateimmediately
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

        public class Status
        {
            public object href { get; set; }
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

        public class Status1
        {
            public string _type { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public bool isClosed { get; set; }
            public object color { get; set; }
            public bool isDefault { get; set; }
            public bool isReadonly { get; set; }
            public object defaultDoneRatio { get; set; }
            public int position { get; set; }
            public _Links5 _links { get; set; }
        }

        public class _Links5
        {
            public Self5 self { get; set; }
        }

        public class Self5
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Author
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
            public _Links6 _links { get; set; }
        }

        public class _Links6
        {
            public Self6 self { get; set; }
            public Memberships1 memberships { get; set; }
            public Showuser showUser { get; set; }
            public Updateimmediately1 updateImmediately { get; set; }
            public Lock _lock { get; set; }
            public Delete1 delete { get; set; }
        }

        public class Self6
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Memberships1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Showuser
        {
            public string href { get; set; }
            public string type { get; set; }
        }

        public class Updateimmediately1
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

        public class Delete1
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Responsible
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
            public _Links7 _links { get; set; }
        }

        public class _Links7
        {
            public Self7 self { get; set; }
            public Memberships2 memberships { get; set; }
            public Showuser1 showUser { get; set; }
            public Updateimmediately2 updateImmediately { get; set; }
            public Lock1 _lock { get; set; }
            public Delete2 delete { get; set; }
        }

        public class Self7
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Memberships2
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Showuser1
        {
            public string href { get; set; }
            public string type { get; set; }
        }

        public class Updateimmediately2
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Lock1
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Delete2
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Assignee
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
            public _Links8 _links { get; set; }
        }

        public class _Links8
        {
            public Self8 self { get; set; }
            public Memberships3 memberships { get; set; }
            public Showuser2 showUser { get; set; }
            public Updateimmediately3 updateImmediately { get; set; }
            public Lock2 _lock { get; set; }
            public Delete3 delete { get; set; }
        }

        public class Self8
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Memberships3
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Showuser2
        {
            public string href { get; set; }
            public string type { get; set; }
        }

        public class Updateimmediately3
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Lock2
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Delete3
        {
            public string href { get; set; }
            public string title { get; set; }
            public string method { get; set; }
        }

        public class Costsbytype
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public _Embedded3 _embedded { get; set; }
            public _Links9 _links { get; set; }
        }

        public class _Embedded3
        {
            public object[] elements { get; set; }
        }

        public class _Links9
        {
            public Self9 self { get; set; }
        }

        public class Self9
        {
            public string href { get; set; }
        }

        public class Description1
        {
            public string format { get; set; }
            public string raw { get; set; }
            public string html { get; set; }
        }

        public class _Links10
        {
            public Attachments1 attachments { get; set; }
            public Addattachment addAttachment { get; set; }
            public Update1 update { get; set; }
            public Schema1 schema { get; set; }
            public Updateimmediately4 updateImmediately { get; set; }
            public Delete4 delete { get; set; }
            public Logtime logTime { get; set; }
            public Move move { get; set; }
            public Copy copy { get; set; }
            public Pdf pdf { get; set; }
            public Atom atom { get; set; }
            public Availablerelationcandidates availableRelationCandidates { get; set; }
            public Customfields customFields { get; set; }
            public Configureform configureForm { get; set; }
            public Activities activities { get; set; }
            public Availablewatchers availableWatchers { get; set; }
            public Relations1 relations { get; set; }
            public Revisions revisions { get; set; }
            public Watchers watchers { get; set; }
            public Addwatcher addWatcher { get; set; }
            public Removewatcher removeWatcher { get; set; }
            public Addrelation addRelation { get; set; }
            public Addchild addChild { get; set; }
            public Changeparent changeParent { get; set; }
            public Addcomment addComment { get; set; }
            public Previewmarkup previewMarkup { get; set; }
            public Timeentries timeEntries { get; set; }
            public Category category { get; set; }
            public Type1 type { get; set; }
            public Priority1 priority { get; set; }
            public Project1 project { get; set; }
            public Status2 status { get; set; }
            public Author1 author { get; set; }
            public Responsible1 responsible { get; set; }
            public Assignee1 assignee { get; set; }
            public Version version { get; set; }
            public Budget budget { get; set; }
            public Logcosts logCosts { get; set; }
            public Showcosts showCosts { get; set; }
            public Costsbytype1 costsByType { get; set; }
            public Github_Pull_Requests github_pull_requests { get; set; }
            public Self10 self { get; set; }
            public Watch watch { get; set; }
            public object[] ancestors { get; set; }
            public Parent1 parent { get; set; }
            public object[] customActions { get; set; }
        }

        public class Attachments1
        {
            public string href { get; set; }
        }

        public class Addattachment
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Update1
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Schema1
        {
            public string href { get; set; }
        }

        public class Updateimmediately4
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Delete4
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Logtime
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Move
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Copy
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Pdf
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Atom
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Availablerelationcandidates
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Customfields
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Configureform
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Activities
        {
            public string href { get; set; }
        }

        public class Availablewatchers
        {
            public string href { get; set; }
        }

        public class Relations1
        {
            public string href { get; set; }
        }

        public class Revisions
        {
            public string href { get; set; }
        }

        public class Watchers
        {
            public string href { get; set; }
        }

        public class Addwatcher
        {
            public string href { get; set; }
            public string method { get; set; }
            public Payload payload { get; set; }
            public bool templated { get; set; }
        }

        public class Payload
        {
            public User user { get; set; }
        }

        public class User
        {
            public string href { get; set; }
        }

        public class Removewatcher
        {
            public string href { get; set; }
            public string method { get; set; }
            public bool templated { get; set; }
        }

        public class Addrelation
        {
            public string href { get; set; }
            public string method { get; set; }
            public string title { get; set; }
        }

        public class Addchild
        {
            public string href { get; set; }
            public string method { get; set; }
            public string title { get; set; }
        }

        public class Changeparent
        {
            public string href { get; set; }
            public string method { get; set; }
            public string title { get; set; }
        }

        public class Addcomment
        {
            public string href { get; set; }
            public string method { get; set; }
            public string title { get; set; }
        }

        public class Previewmarkup
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Timeentries
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Category
        {
            public object href { get; set; }
        }

        public class Type1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Priority1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Project1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Status2
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Author1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Responsible1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Assignee1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Version
        {
            public object href { get; set; }
        }

        public class Budget
        {
            public object href { get; set; }
        }

        public class Logcosts
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Showcosts
        {
            public string href { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Costsbytype1
        {
            public string href { get; set; }
        }

        public class Github_Pull_Requests
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Self10
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Watch
        {
            public string href { get; set; }
            public string method { get; set; }
            public Payload1 payload { get; set; }
        }

        public class Payload1
        {
            public User1 user { get; set; }
        }

        public class User1
        {
            public string href { get; set; }
        }

        public class Parent1
        {
            public object href { get; set; }
            public object title { get; set; }
        }



    }
}