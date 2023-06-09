using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Areas.Seller.Models.Auction
{
    public class CreateAuctionViewModel
    {
        [Required]
        [Display(Name = "شناسه غرفه")]
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "شناسه فروشنده")]
        public int SellerId { get; set; }

        [Required]
        [Display(Name = "زمان شروع مزایده")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "زمان پایان مزایده")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "قیمت اولیه")]
        public int MinimumPrice { get; set; }

        public bool IsRunning { get; set; }

        [Required]
        [Display(Name = "شناسه کالا")]
        public int ProductId { get; set; }
    }
}
