using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.TimeEntries;

namespace StundenExportOp.Models
{
    public class GetWorkPackageId
    {

        public LinkTrimm trimmer = new LinkTrimm();

        public async Task<List<TimeEntries.Workpackage>> GetWorkpackages(string response)
        {


            var data = JsonSerializer.Deserialize<TimeEntrie>(response);

            ViewModel packages = new ViewModel();


            foreach (var element in data._embedded.elements)
            {
                var packageId = new TimeEntries._Links
                {
                    workPackage = new Workpackage
                    {
                        href = trimmer.TrimStringforId(element._links.workPackage.href)

                    }
                };


                packages.workpackages.Add(packageId.workPackage);
            }


            return packages.workpackages;

        }
        
    }
}

      

    