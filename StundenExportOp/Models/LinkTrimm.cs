using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StundenExportOp.Models
{
    public class LinkTrimm
    {
        public string TrimStringforId(string input)
        {
            int Index = input.LastIndexOf("/");

            string trimmed = input.Substring(Index + 1);

            return trimmed;

        }

    }
}