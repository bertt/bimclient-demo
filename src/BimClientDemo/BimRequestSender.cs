using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BimClientDemo
{
    public static class BimRequestSender
    {
        public static async Task<T> SendBimRequest<T>(string url, StringContent body)
        {
            var client = new HttpClient();
            var result = await client.PostAsync(url, body);
            string resp = await result.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(resp);
            return model;
        }

    }
}
