using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class ViewModel
    {
        public List<UserData> userData { get; set; }

        public List<TimeEntries.Comment> entries { get; set; }

        public ViewModel()
        {
            userData = new List<UserData>();
            entries = new List<TimeEntries.Comment>();
        }
    }
}