﻿using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.ProductComments
{
    public class ProductCommentOutputDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? CommentBody { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public bool IsConfirmedByAdmin { get; set; }

        public int? ParentCommentId { get; set; }

        public int? Rate { get; set; }

        public int? LikeCount { get; set; }

        public int? DislikeCount { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
