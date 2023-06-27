using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Areas.Seller.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "نام محصول")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "دسته‌بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "برند")]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "غرفه مربوطه")]
        public int StoreId { get; set; }

        [Display(Name = "وزن")]
        public decimal? Weight { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "مدل")]
        public int? ModelId { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "عکس‌های محصول")]
        public IFormFile ProductPhotoFile { get; set; } = null!;
        //public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}
