using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductComments;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly AppDbContext _context;

        public ProductCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductComment(AddProductCommentInputDto productComment, CancellationToken cancellationToken)
        {
            await _context.ProductComments.AddAsync(new ProductComment
            {
                Title = productComment.Title,
                CommentBody = productComment.CommentBody,
                UserId = productComment.UserId,
                ProductId = productComment.ProductId,
                IsConfirmedByAdmin = false,
                ParentCommentId = productComment.ParentCommentId,
                Rate = productComment.Rate,
                LikeCount = productComment.LikeCount,
                DislikeCount = productComment.DislikeCount
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductComment(int id, CancellationToken cancellationToken)
        {
            ProductComment? productComment = await _context.ProductComments.FindAsync(id);

            productComment.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductCommentOutputDto>> GetAllProductComments(CancellationToken cancellationToken)
        {
            var productComments = await _context.ProductComments.Select(pc => new ProductCommentOutputDto
            {
                Id = pc.Id,
                Title = pc.Title,
                CommentBody = pc.CommentBody,
                UserId = pc.UserId,
                ProductId = pc.ProductId,
                IsConfirmedByAdmin = pc.IsConfirmedByAdmin,
                ParentCommentId = pc.ParentCommentId,
                Rate = pc.Rate,
                LikeCount = pc.LikeCount,
                DislikeCount = pc.DislikeCount

            }).ToListAsync(cancellationToken);

            return productComments;
        }

        public async Task<ProductCommentOutputDto>? GetProductCommentBy(int id, CancellationToken cancellationToken)
        {
            var productComment = await _context.ProductComments.Where(pc => pc.Id == id).Select(pc =>
                new ProductCommentOutputDto
                {
                    Id = pc.Id,
                    Title = pc.Title,
                    CommentBody = pc.CommentBody,
                    UserId = pc.UserId,
                    ProductId = pc.ProductId,
                    IsConfirmedByAdmin = pc.IsConfirmedByAdmin,
                    ParentCommentId = pc.ParentCommentId,
                    Rate = pc.Rate,
                    LikeCount = pc.LikeCount,
                    DislikeCount = pc.DislikeCount
                }).FirstAsync(cancellationToken);

            return productComment;
        }

        public async Task UpdateProductComment(EditProductCommentInputDto productComment, CancellationToken cancellationToken)
        {
            var productCommentToUpdate = await _context.ProductComments.Where(pc => pc.Id == productComment.Id)
                .FirstOrDefaultAsync(cancellationToken);

            productCommentToUpdate.Title = productComment.Title;
            productCommentToUpdate.CommentBody = productComment.CommentBody;
            productCommentToUpdate.UserId = productComment.UserId;
            productCommentToUpdate.ProductId = productComment.ProductId;
            productCommentToUpdate.IsConfirmedByAdmin = productComment.IsConfirmedByAdmin;
            productCommentToUpdate.ParentCommentId = productComment.ParentCommentId;
            productCommentToUpdate.Rate = productComment.Rate;
            productCommentToUpdate.LikeCount = productComment.LikeCount;
            productCommentToUpdate.DislikeCount = productComment.DislikeCount;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
