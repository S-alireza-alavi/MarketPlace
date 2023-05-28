using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.Users
{
    public class UsersOutputDto
    {
        [Display(Name = ("شناسه"))]
        public int Id { get; set; }

        [Display(Name = ("ایمیل"))]
        public string Email { get; set; }

        [Display(Name = ("نام کاربری"))]
        public string UserName { get; set; }

        [Display(Name = ("نقش‌ها"))]
        public List<string>? Roles { get; set; }
    }
}
