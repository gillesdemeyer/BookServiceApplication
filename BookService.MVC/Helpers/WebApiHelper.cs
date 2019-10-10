using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookService.MVC.Helpers
{
    public class WebApiHelper
    {
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew
                            (
                                () => JsonConvert
                                      .DeserializeObject<T>(response.Result)
                            )
                            .Result;
            }
        }
    }
}
