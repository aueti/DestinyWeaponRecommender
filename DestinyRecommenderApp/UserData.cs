using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DestinyRecommenderApp
{
    public class UserData
    {
        public string bungieMembershipId = "26202162";
        public int bungieMembershipType = 3;
        public string destinyMembershipId { get; set; }
        public string distinyMembershipType { get; set; }
        public async Task LoadUserDataAysnc(string API_Key)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", API_Key);

                var response = await client.GetAsync($"https://www.bungie.net/Platform/User/GetMembershipsById/{bungieMembershipId}/{bungieMembershipType}/");
                var content = await response.Content.ReadAsStringAsync();
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                destinyMembershipId = item.destinyMemberships.membershipId;
                distinyMembershipType = item.destinyMemberships.membershipType;
            }
        }
    }
}
