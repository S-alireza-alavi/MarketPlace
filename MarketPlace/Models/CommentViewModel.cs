using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class CommentViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "پر کردن {0} الزامی‌ست.")]
        public string Title { get; set; } = null!;

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "پر کردن {0} الزامی‌ست.")]
        public string CommentBody { get; set; } = null!;
    }
}
