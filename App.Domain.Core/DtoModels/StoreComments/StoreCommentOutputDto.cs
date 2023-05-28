﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.StoreComments
{
    public class StoreCommentOutputDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? CommentBody { get; set; }

        public int UserId { get; set; }

        public int StoreId { get; set; }

        public bool IsConfirmedByAdmin { get; set; }

        public int? ParentCommentId { get; set; }

        public int? Rate { get; set; }

        public int? LikeCount { get; set; }

        public int? DislikeCount { get; set; }
    }
}
