using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static StundenExportOp.Models.RedMineUsers;

namespace StundenExportOp.Models
{
    public class GetRedMineUsers
    {
        public async Task<List<string>> GetUserRedMine(string auth,RedMineApiClient client)
        {
            string userUrl = "http://redmine.stiebel-eltron.com/redmine/projects/262/memberships.json";
            string response = await client.GetRedmineApiResponse(userUrl, auth);

            var data = JsonSerializer.Deserialize<RedMineUser>(response);

            List<string> userIds = new List<string>();

            foreach(var element in data.memberships)
            {
                if (element.user == null || element.user.name == null)
                {
                    continue;
                }

                if (element.user.name.Contains("(aix)"))
                {
                    userIds.Add(element.user.id.ToString()+":"+element.user.name);
                }


            }

            return userIds;


        }


    }
}