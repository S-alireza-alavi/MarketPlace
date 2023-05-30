using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.Commisions
{
    public class CommissionOutputDto
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "شناسه سفارش")]
        public int OrderId { get; set; }

        [Display(Name = "میزان کارمزد")]
        public int CommissionAmount { get; set; }

        [Display(Name = "نام کاربری فروشنده")]
        public string? SellerUserName { get; set; }
    }
}
