using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class BidRegistrationViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Display(Name = "قیمت")]
        public int ProductPrice { get; set; }

        [Required]
        [Display(Name = "مبلغ پیشنهادی")]
        public int BidAmount { get; set; }
    }
}
