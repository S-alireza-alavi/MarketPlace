using App.Domain.Core.DtoModels.StoreAddresses;
using App.Domain.Core.DtoModels.Stores;
using MarketPlace.Areas.Seller.Controllers;
using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Areas.Seller.Models
{
    public class AddStoreWithStoreAddressViewModel
    {

        [Required]
        [Display(Name = "نام غرفه")]
        public string Name { get; set; } = null!;

        public int SellerId { get; set; }

        [Required]
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public int StoreId { get; set; }

        [Required]
        [Display(Name = "آدرس")]
        public string FullAddress { get; set; } = null!;
    }
}
