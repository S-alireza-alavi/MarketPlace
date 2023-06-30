using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class ProfileViewModel
    {
        public int? CustomerId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string? FullName { get; set; }

        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }

        [Display(Name = "ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "شماره موبایل")]
        public string? PhoneNumber { get; set; }
    }
}
