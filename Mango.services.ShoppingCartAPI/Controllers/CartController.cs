using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ShoppingCartAPI.Controllers
{

    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        protected ResponseDto _response;

        public CartController(ICartRepository cartRepository, ResponseDto response)
        {
            this.cartRepository = cartRepository;
            _response = response;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await cartRepository.GetCartByUserID(userId);
                _response.Result = cartDto;
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                if (cartDto.CartDetails != null && cartDto.CartDetails.Count() > 0)
                {
                    foreach (var detail in cartDto.CartDetails)
                    {
                        if (detail.CartHeaderId == 0) detail.CartHeader = null;
                    }
                }

                CartDto cartDt = await cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody]int cartId)
        {
            try
            {
                bool isSuccess = await cartRepository.RemoveFromCart(cartId);
                _response.Result = isSuccess; 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
