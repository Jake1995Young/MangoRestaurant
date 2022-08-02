using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartHeaderDto
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
