using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.OrderComment
{
    public class AddOrderCommentInputDto
    {
        public int? OrderId { get; set; }

        public int Rating { get; set; }

        public string? CommentText { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
