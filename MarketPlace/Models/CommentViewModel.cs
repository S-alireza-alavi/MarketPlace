using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class CommentViewModel
    {
        public int? UserId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "عنوان نظر")]
        public string? Title { get; set; }

        [Display(Name = "متن نظر")]
        public string? CommentBody { get; set; }
    }
}
