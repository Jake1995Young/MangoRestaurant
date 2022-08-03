using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    public class HeaderDto
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
