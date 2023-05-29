//using System.ComponentModel.DataAnnotations;

//namespace MarketPlace.Areas.Admin.Models.ViewModels.Product
//{
//    public class ProductUpdateViewModel
//    {
//        [Display(Name = "شناسه")]
//        public int Id { get; set; }

//        [Display(Name = "نام محصول")]
//        [Required(ErrorMessage = "تکمیل فیلد نام محصول الزامی می باشد")]
//        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
//        public string Name { get; set; } = String.Empty;

//        [Required]
//        [Display(Name = "شناسه برند")]
//        public int BrandId { get; set; }

//        [Required]
//        [Display(Name = "شناسه دسته بندی")]
//        public int CategoryId { get; set; }

//        [Required]
//        [Display(Name = "شناسه غرفه")]
//        public int StoreId { get; set; }

//        [Display(Name = "وزن")]
//        public decimal Weight { get; set; }

//        [Display(Name = "توضیحات")]
//        public string Description { get; set; } = null!;

//        [Required]
//        [Range(0, 10000, ErrorMessage = "تعداد محصول باید بین {1} تا {2} باشد")]
//        [Display(Name = "تعداد")]
//        public int Count { get; set; }


//        [Display(Name = "شناسه مدل")]
//        public int ModelId { get; set; }

//        [Required]
//        [Display(Name = "قیمت")]
//        public long Price { get; set; }

//        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
//        [Display(Name = "فعال بودن")]
//        public bool IsActive { get; set; }

//        [Display(Name = "حذف شده")]
//        public bool IsDeleted { get; set; }
//    }
//}
