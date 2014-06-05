using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Json;
using System.Json;
using System.Net.Http;

namespace Wmt
{
    public class BaseService
    {
        public BaseService()
        {
        }

        public static async Task<JsonValue> GetData(string url)
        {

            var client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                var parsed = JsonValue.Parse(content);

                return parsed;
            }


            return null;
        }
    }
}

