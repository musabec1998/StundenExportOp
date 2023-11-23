using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class WorkPackages
    {
        public class Workpackage
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public int pageSize { get; set; }
            public int offset { get; set; }
            public _Embedded _embedded { get; set; }
            public _Links15 _links { get; set; }
        }

        public class _Embedded
        {
            public Element1[] elements { get; set; }
            public Schemas schemas { get; set; }
        }

        public class Schemas
        {
            public string _type { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public _Embedded1 _embedded { get; set; }
            public _Links13 _links { get; set; }
        }

        public class _Embedded1
        {
            public Element[] elements { get; set; }
        }

        public class Element
        {
            public _Attributegroups[] _attributeGroups { get; set; }
            public string _type { get; set; }
            public object[] _dependencies { get; set; }
            public Lockversion lockVersion { get; set; }
            public Id id { get; set; }
            public Subject subject { get; set; }
            public Description description { get; set; }
            public Duration duration { get; set; }
            public Schedulemanually scheduleManually { get; set; }
            public Ignorenonworkingdays ignoreNonWorkingDays { get; set; }
            public Startdate startDate { get; set; }
            public Duedate dueDate { get; set; }
            public Derivedstartdate derivedStartDate { get; set; }
            public Derivedduedate derivedDueDate { get; set; }
            public Estimatedtime estimatedTime { get; set; }
            public Derivedestimatedtime derivedEstimatedTime { get; set; }
            public Spenttime spentTime { get; set; }
            public Percentagedone percentageDone { get; set; }
            public Createdat createdAt { get; set; }
            public Updatedat updatedAt { get; set; }
            public Author author { get; set; }
            public Project project { get; set; }
            public Parent parent { get; set; }
            public Assignee assignee { get; set; }
            public Responsible responsible { get; set; }
            public Type type { get; set; }
            public Status status { get; set; }
            public Category category { get; set; }
            public Version version { get; set; }
            public Priority priority { get; set; }
            public Overallcosts overallCosts { get; set; }
            public Laborcosts laborCosts { get; set; }
            public Materialcosts materialCosts { get; set; }
            public Costsbytype costsByType { get; set; }
            public Customfield29 customField29 { get; set; }
            public Customfield23 customField23 { get; set; }
            public Customfield28 customField28 { get; set; }
            public Customfield27 customField27 { get; set; }
            public _Links9 _links { get; set; }
            public Budget budget { get; set; }
            public Customfield39 customField39 { get; set; }
            public Remainingtime remainingTime { get; set; }
            public Customfield9 customField9 { get; set; }
            public Customfield10 customField10 { get; set; }
            public Customfield11 customField11 { get; set; }
            public Customfield12 customField12 { get; set; }
            public Customfield14 customField14 { get; set; }
            public Position position { get; set; }
            public Storypoints storyPoints { get; set; }
        }

        public class Lockversion
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options options { get; set; }
        }

        public class Options
        {
        }

        public class Id
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options1 options { get; set; }
        }

        public class Options1
        {
        }

        public class Subject
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public int minLength { get; set; }
            public int maxLength { get; set; }
            public Options2 options { get; set; }
        }

        public class Options2
        {
        }

        public class Description
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options3 options { get; set; }
        }

        public class Options3
        {
        }

        public class Duration
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options4 options { get; set; }
        }

        public class Options4
        {
        }

        public class Schedulemanually
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options5 options { get; set; }
        }

        public class Options5
        {
        }

        public class Ignorenonworkingdays
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options6 options { get; set; }
        }

        public class Options6
        {
        }

        public class Startdate
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options7 options { get; set; }
        }

        public class Options7
        {
        }

        public class Duedate
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options8 options { get; set; }
        }

        public class Options8
        {
        }

        public class Derivedstartdate
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options9 options { get; set; }
        }

        public class Options9
        {
        }

        public class Derivedduedate
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options10 options { get; set; }
        }

        public class Options10
        {
        }

        public class Estimatedtime
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options11 options { get; set; }
        }

        public class Options11
        {
        }

        public class Derivedestimatedtime
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options12 options { get; set; }
        }

        public class Options12
        {
        }

        public class Spenttime
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options13 options { get; set; }
        }

        public class Options13
        {
        }

        public class Percentagedone
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options14 options { get; set; }
        }

        public class Options14
        {
        }

        public class Createdat
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options15 options { get; set; }
        }

        public class Options15
        {
        }

        public class Updatedat
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options16 options { get; set; }
        }

        public class Options16
        {
        }

        public class Author
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public Options17 options { get; set; }
            public string location { get; set; }
        }

        public class Options17
        {
        }

        public class Project
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string location { get; set; }
            public _Links _links { get; set; }
        }

        public class _Links
        {
        }

        public class Parent
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string location { get; set; }
            public _Links1 _links { get; set; }
        }

        public class _Links1
        {
        }

        public class Assignee
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links2 _links { get; set; }
        }

        public class _Links2
        {
        }

        public class Responsible
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links3 _links { get; set; }
        }

        public class _Links3
        {
        }

        public class Type
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string location { get; set; }
            public _Links4 _links { get; set; }
        }

        public class _Links4
        {
        }

        public class Status
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string location { get; set; }
            public _Links5 _links { get; set; }
        }

        public class _Links5
        {
        }

        public class Category
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links6 _links { get; set; }
        }

        public class _Links6
        {
        }

        public class Version
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links7 _links { get; set; }
        }

        public class _Links7
        {
        }

        public class Priority
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links8 _links { get; set; }
        }

        public class _Links8
        {
        }

        public class Overallcosts
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options18 options { get; set; }
        }

        public class Options18
        {
        }

        public class Laborcosts
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options19 options { get; set; }
        }

        public class Options19
        {
        }

        public class Materialcosts
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options20 options { get; set; }
        }

        public class Options20
        {
        }

        public class Costsbytype
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options21 options { get; set; }
        }

        public class Options21
        {
        }

        public class Customfield29
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public int maxLength { get; set; }
            public Options22 options { get; set; }
        }

        public class Options22
        {
            public object rtl { get; set; }
        }

        public class Customfield23
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public int minLength { get; set; }
            public int maxLength { get; set; }
            public Options23 options { get; set; }
        }

        public class Options23
        {
            public object rtl { get; set; }
        }

        public class Customfield28
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public int maxLength { get; set; }
            public Options24 options { get; set; }
        }

        public class Options24
        {
            public object rtl { get; set; }
        }

        public class Customfield27
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public int maxLength { get; set; }
            public Options25 options { get; set; }
        }

        public class Options25
        {
            public object rtl { get; set; }
        }

        public class _Links9
        {
            public Self self { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Budget
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links10 _links { get; set; }
        }

        public class _Links10
        {
        }

        public class Customfield39
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options26 options { get; set; }
        }

        public class Options26
        {
            public object rtl { get; set; }
        }

        public class Remainingtime
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options27 options { get; set; }
        }

        public class Options27
        {
        }

        public class Customfield9
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options28 options { get; set; }
        }

        public class Options28
        {
            public object rtl { get; set; }
        }

        public class Customfield10
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options29 options { get; set; }
        }

        public class Options29
        {
            public object rtl { get; set; }
        }

        public class Customfield11
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links11 _links { get; set; }
        }

        public class _Links11
        {
        }

        public class Customfield12
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options30 options { get; set; }
        }

        public class Options30
        {
            public object rtl { get; set; }
        }

        public class Customfield14
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public string location { get; set; }
            public _Links12 _links { get; set; }
        }

        public class _Links12
        {
        }

        public class Position
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options31 options { get; set; }
        }

        public class Options31
        {
        }

        public class Storypoints
        {
            public string type { get; set; }
            public string name { get; set; }
            public bool required { get; set; }
            public bool hasDefault { get; set; }
            public bool writable { get; set; }
            public string attributeGroup { get; set; }
            public Options32 options { get; set; }
        }

        public class Options32
        {
        }

        public class _Attributegroups
        {
            public string _type { get; set; }
            public string name { get; set; }
            public string[] attributes { get; set; }
        }

        public class _Links13
        {
            public Self1 self { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Element1
        {
            public string derivedStartDate { get; set; }
            public string derivedDueDate { get; set; }
            public string spentTime { get; set; }
            public string laborCosts { get; set; }
            public string materialCosts { get; set; }
            public string overallCosts { get; set; }
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
            public string customField39 { get; set; }
            public string customField29 { get; set; }
            public string customField23 { get; set; }
            public string customField28 { get; set; }
            public string customField27 { get; set; }
            public _Links14 _links { get; set; }
            public string customField9 { get; set; }
            public int? customField12 { get; set; }
            public int? customField10 { get; set; }
            public string remainingTime { get; set; }
            public int? position { get; set; }
            public object storyPoints { get; set; }
        }

        public class Description1
        {
            public string format { get; set; }
            public string raw { get; set; }
            public string html { get; set; }
        }

        public class _Links14
        {
            public Attachments attachments { get; set; }
            public Addattachment addAttachment { get; set; }
            public Update update { get; set; }
            public Schema schema { get; set; }
            public Updateimmediately updateImmediately { get; set; }
            public Delete delete { get; set; }
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
            public Relations relations { get; set; }
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
            public Category1 category { get; set; }
            public Type1 type { get; set; }
            public Priority1 priority { get; set; }
            public Project1 project { get; set; }
            public Status1 status { get; set; }
            public Author1 author { get; set; }
            public Responsible1 responsible { get; set; }
            public Assignee1 assignee { get; set; }
            public Version1 version { get; set; }
            public Logcosts logCosts { get; set; }
            public Showcosts showCosts { get; set; }
            public Costsbytype1 costsByType { get; set; }
            public Github_Pull_Requests github_pull_requests { get; set; }
            public Self2 self { get; set; }
            public Watch watch { get; set; }
            public Ancestor[] ancestors { get; set; }
            public Parent1 parent { get; set; }
            public object[] customActions { get; set; }
            public Budget1 budget { get; set; }
            public Child[] children { get; set; }
            public Customfield141 customField14 { get; set; }
            public Customfield111 customField11 { get; set; }
        }

        public class Attachments
        {
            public string href { get; set; }
        }

        public class Addattachment
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Update
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Schema
        {
            public string href { get; set; }
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

        public class Relations
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

        public class Category1
        {
            public string href { get; set; }
            public string title { get; set; }
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

        public class Status1
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

        public class Version1
        {
            public string href { get; set; }
            public string title { get; set; }
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

        public class Self2
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
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Budget1
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Customfield141
        {
            public string title { get; set; }
            public string href { get; set; }
        }

        public class Customfield111
        {
            public string title { get; set; }
            public string href { get; set; }
        }

        public class Ancestor
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Child
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class _Links15
        {
            public Self3 self { get; set; }
            public Jumpto jumpTo { get; set; }
            public Changesize changeSize { get; set; }
            public Nextbyoffset nextByOffset { get; set; }
            public Editworkpackage editWorkPackage { get; set; }
            public Createworkpackage createWorkPackage { get; set; }
            public Createworkpackageimmediate createWorkPackageImmediate { get; set; }
            public Schemas1 schemas { get; set; }
            public Representation[] representations { get; set; }
        }

        public class Self3
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

        public class Editworkpackage
        {
            public string href { get; set; }
            public string method { get; set; }
            public bool templated { get; set; }
        }

        public class Createworkpackage
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Createworkpackageimmediate
        {
            public string href { get; set; }
            public string method { get; set; }
        }

        public class Schemas1
        {
            public string href { get; set; }
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