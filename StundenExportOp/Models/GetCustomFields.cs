using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.WorkPackage;

namespace StundenExportOp.Models
{
    public class GetCustomFields
    {
        public async Task<List<string>> GetCustomField(string auth, ApiClient client, List<TimeEntries.Workpackage> projectId)
        {
            List<string> customField = new List<string>();

            //um keine doppelte abfrage für die selbe ID durchzuführen
            var distinctWorkpackages = projectId.GroupBy(p => p.href).Select(g => g.First());

            foreach (var id in distinctWorkpackages)
            {

                string url =($"https://project.aixtrusion.de/api/v3/work_packages/{id.href}");

                string response = await client.GetApiResponseAsync(url, auth);

                dynamic data = await Task.Run(() => JsonConvert.DeserializeObject(response));


                if (data.customField39 != null)
                {
                    if (data.customField39 != null)
                    {//WorkpackageNr einfügen um später leichter die Customfields den jeweiligen Workpackages zuordnen zu können
                        customField.Add(id.href +"/KundenProjNr:" + data.customField39.ToString());
                    }
                    if (data.customField29 != null)
                    {
                        customField.Add(id.href+"/KundenTicketNr:" + data.customField29.ToString());
                    }
                    if (data.customField28 != null)
                    {
                        customField.Add(id.href+"/Bestellnummer:" + data.customField28);
                    }
                    if (data.customField27 != null)
                    {
                        customField.Add(id.href+"/aiX-Angebotsnr:" + data.customField27);
                    }
                    else if (data.customField23 != null)
                    {
                        customField.Add("CustomField23 " + data.customField23);
                    }
                }
            }

            return customField;
        }

    }
}


