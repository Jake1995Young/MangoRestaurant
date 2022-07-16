using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }  

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel= new ResponseDto();
            this.httpClient = httpClient;
        }


        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            var client = httpClient.CreateClient("MangoAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();

            if(apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }


        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
