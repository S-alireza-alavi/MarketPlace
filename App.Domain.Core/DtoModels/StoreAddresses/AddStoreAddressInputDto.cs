using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.DtoModels.StoreAddresses
{
    public class AddStoreAddressInputDto
    {
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "آدرس")]
        public string FullAddress { get; set; } = null!;

        public bool? IsDeleted { get; set; }
    }
}