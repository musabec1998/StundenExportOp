using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace StundenExportOp.Models
{
    public class GetUser
    {

             
        public async Task<List<UserData>> GetUserData(string auth,ApiClient client)
        {           
                //suchstring für User
                string usersUrl = "https://project.aixtrusion.de/api/v3/users?pageSize=500";
                string response = await client.GetApiResponseAsync(usersUrl, auth);
                var data =  JsonSerializer.Deserialize<Users.User>(response);

                List<UserData> userDataList = new List<UserData>();

                //daten von Anfrage werden in die Viewmodel Liste geschrieben
                foreach (var element in data._embedded.elements)
                {
                    var user = new UserData
                    {
                        id = element.id,
                        name = element.name
                    };

                    userDataList.Add(user);
                }
                return userDataList;
            
        }
    }



}
