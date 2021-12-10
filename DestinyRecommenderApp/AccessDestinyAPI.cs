using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DestinyRecommenderApp
{
    public class AccessDestinyAPI
    {
        private string API_Key = "d0f9367a82cb40649b44e86cdabca4ff";
        private string UserId = "26202162";
        public string test { get; set; }

        public async Task<string> GetDestinyDataAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", API_Key);

                var response = await client.GetAsync("https://www.bungie.net/platform/Destiny/Manifest/InventoryItem/1274330687/");
                var content = await response.Content.ReadAsStringAsync();
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                return item.Response.data.inventoryItem.itemName;
            }
        }
        public async Task<string> GetDestinyUserData()
        {
            UserData data = new UserData();

            await data.LoadUserDataAysnc(API_Key);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", API_Key);
                int type = 254;
                // User/GetBungieNetUserById/{UserId}/
                // /User/GetMembershipsById/{UserId}/{membershipType}/
                //
                var response = await client.GetAsync($"https://www.bungie.net/platform/Destiny2/254/Account/{UserId}/Character/0/Stats/");
                var content = await response.Content.ReadAsStringAsync();
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                return item.Response.displayName;
            }
        }
    }
}
