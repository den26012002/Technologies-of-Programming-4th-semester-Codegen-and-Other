using System.Net;
using Newtonsoft.Json;
using Cats.Entities;

namespace Cats.Server
{
    public class CatsServer
    {
        public Cat GetCatById(int id)
        {
            return JsonConvert.DeserializeObject<Cat>(new HttpClient().GetAsync($"/cats/get/{id}").Result.Content.ReadAsStringAsync().Result);
        }

        public CatsOwner GetCatsOwnerById(int id)
        {
            return JsonConvert.DeserializeObject<CatsOwner>(new HttpClient().GetAsync($"/cats_owners/get/{id}").Result.Content.ReadAsStringAsync().Result);
        }

        public void RegisterCat(CatToServerDto cat)
        {
            new HttpClient().PostAsync($"/cats/register", new StringContent(JsonConvert.SerializeObject(cat), System.Text.Encoding.UTF8, "application/json"));
        }

        public void RegisterCatsOwner(CatsOwnerToServerDto catsOwner)
        {
            new HttpClient().PostAsync($"/cats_owners/register", new StringContent(JsonConvert.SerializeObject(catsOwner), System.Text.Encoding.UTF8, "application/json"));
        }

        public void addFriends(int id1, int id2)
        {
            new HttpClient().PostAsync($"/cats/add_friends?id1={id1}&id2={id2}", new StringContent(""));
        }
    }

    ;
}

;