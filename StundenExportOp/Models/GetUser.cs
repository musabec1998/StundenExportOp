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
        public ApiClient apiclient1 = new ApiClient();

        
       

        public async Task<List<UserData>> GetUserData(string auth)
        {

           
                //suchstring für User
                string users = "https://project.aixtrusion.de/api/v3/users?pageSize=500";
                //Antwort von Api(Users)
                string response = await apiclient1.GetApiResponseAsync(users,auth);
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
