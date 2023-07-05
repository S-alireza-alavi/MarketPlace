using MarketPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class OrderComment
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int Rating { get; set; }

        public string? CommentText { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
