using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(11, ErrorMessage = "{0} باید 11 رقم باشد", MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "{0} حداقل {2} کاراکتر و حداکتر {1} باشد", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار رمز هبور باید یکسان باشند")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "ثبت‌نام به عنوان فروشنده")]
        public bool IsSeller { get; set; }
    }
}
