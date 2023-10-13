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
    public class GetNames
    {

       

        public async Task<List<UserData>> GetUserData(string apiKey,HttpClient client,string auth)
        {

            using (client)
            {
                //suchstring für User
                string users = "https://project.aixtrusion.de/api/v3/users?pageSize=500";
                //Autorisierung
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
                //Api antwort wird deserialized
                string response = await client.GetStringAsync(users);
                var data = JsonSerializer.Deserialize<Users.User>(response);

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



}
