using App.Domain.Core.Entities;
using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.DtoModels.Stores
{
    public class StoreOutputDto
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام غرفه")]
        public string Name { get; set; } = null!;

        [Display(Name = "شناسه فروشنده")]
        public int SellerId { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;

        [Display(Name = "نام کاربری فروشنده")]
        public string SellerUserName { get; set; } = null!;

        [Display(Name = "شروع به فعالیت")]
        public DateTime CreatedAt { get; set; }

        public StoreAddress Address { get; set; } = null!;

        public virtual ApplicationUser Seller { get; set; } = null!;
    }
}
