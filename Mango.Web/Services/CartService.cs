using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "api/cart/AddCart",
                Token = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "api/cart/GetCart/"+userId,
                Token = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cartId,
                Url = SD.ShoppingCartAPIBase + "api/cart/RemoveCart",
                Token = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "api/cart/UpdateCart",
                Token = token
            });
        }
    }
}
