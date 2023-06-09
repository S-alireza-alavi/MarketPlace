using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.DtoModels.Stores
{
    public class AddStoreInputDto
    {
        [Required]
        [Display(Name ="نام غرفه")]
        public string Name { get; set; } = null!;

        public int SellerId { get; set; }

        [Required]
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<StoreAddress> StoreAddresses { get; set; } = new List<StoreAddress>();
    }
}
