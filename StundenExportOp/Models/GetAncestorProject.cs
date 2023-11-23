using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;

using static StundenExportOp.Models.Projects;

namespace StundenExportOp.Models
{
    public class GetAncestorProject
    {
        public LinkTrimm trimmer = new LinkTrimm();


        public async Task<List<Projects._Links>> GetAncestProjects(string auth, List<string> projectId, ApiClient client)
        {
            List<Projects._Links> ancestorList = new List<Projects._Links>();

            //um keine doppelte abfrage für die selbe ID durchzuführen
            var distinctProjectIds = projectId.Distinct();

            //liste mit ProjektIds als parameter übergeben um diese als Filter in der URL zu verwenden.
            foreach (var id in distinctProjectIds)
            {
                string urlFilter = Uri.EscapeDataString($"[{{\"id\":{{\"operator\":\"=\",\"values\":[\"{id}\"]}}}}]");
                string url= ($"https://project.aixtrusion.de/api/v3/projects?filters={urlFilter}&pageSize=1000");

                    string response = await client.GetApiResponseAsync(url, auth);
                    var data = await Task.Run(() => JsonSerializer.Deserialize<Project>(response));



                    foreach (var element in data._embedded.elements)
                    {
                        foreach (var entry in element._links.ancestors)
                        {
                            var ancestor = new Projects._Links
                            {
                                ancestors = new Ancestor[]
                            {
                        new Ancestor
                        {
                            //in title schreibe ich die ID des jeweiligen Projekts um die Ancestor den Projekten zurodnen zu können
                         href = trimmer.TrimStringforId(entry.href) +" / "+ entry.title,
                         title= id.ToString()
                        }

                            }

                            };

                            ancestorList.Add(ancestor);


                        }

                    }

                }

            return ancestorList;

        }

        }


    }
    




            





        
            
     





