using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderComment;
using App.Domain.Core.Entities;
using MarketPlace.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories
{
    public class OrderCommentRepository : IOrderCommentRepository
    {
        private readonly AppDbContext _context;

        public OrderCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderComment(AddOrderCommentInputDto orderCommentDto, CancellationToken cancellationToken)
        {
            var orderComment = new OrderComment
            {
                OrderId = orderCommentDto.OrderId,
                Rating = orderCommentDto.Rating,
                CommentText = orderCommentDto.CommentText,
                UserId = orderCommentDto.UserId,
                CreatedAt = orderCommentDto.CreatedAt
            };

            await _context.OrderComments.AddAsync(orderComment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
