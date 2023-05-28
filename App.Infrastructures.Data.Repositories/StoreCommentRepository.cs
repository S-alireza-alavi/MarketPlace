using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreComments;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Data.Repositories
{
    public class StoreCommentRepository : IStoreCommentRepository
    {
        private readonly AppDbContext _context;

        public StoreCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStoreComment(AddStoreCommentInputDto storeComment, CancellationToken cancellationToken)
        {
            await _context.StoreComments.AddAsync(new StoreComment
            {
                Title = storeComment.Title,
                CommentBody = storeComment.CommentBody,
                UserId = storeComment.UserId,
                StoreId = storeComment.StoreId,
                IsConfirmedByAdmin = false,
                ParentCommentId = storeComment.ParentCommentId,
                Rate = storeComment.Rate,
                LikeCount = storeComment.LikeCount,
                DislikeCount = storeComment.DislikeCount
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStoreComment(int id, CancellationToken cancellationToken)
        {
            StoreComment? storeComment = await _context.StoreComments.FindAsync(id);

            storeComment.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<StoreCommentOutputDto>> GetAllStoreComments(CancellationToken cancellationToken)
        {
            var storeComments = await _context.StoreComments.Select(sc => new StoreCommentOutputDto
            {
                Id = sc.Id,
                Title = sc.Title,
                CommentBody = sc.CommentBody,
                UserId = sc.UserId,
                StoreId = sc.StoreId,
                IsConfirmedByAdmin = sc.IsConfirmedByAdmin,
                ParentCommentId = sc.ParentCommentId,
                Rate = sc.Rate,
                LikeCount = sc.LikeCount,
                DislikeCount = sc.DislikeCount

            }).ToListAsync(cancellationToken);

            return storeComments;
        }

        public async Task<StoreCommentOutputDto>? GetStoreCommentBy(int id, CancellationToken cancellationToken)
        {
            var storeComment = await _context.StoreComments.Where(sc => sc.Id == id).Select(sc =>
                new StoreCommentOutputDto
                {
                    Id = sc.Id,
                    Title = sc.Title,
                    CommentBody = sc.CommentBody,
                    UserId = sc.UserId,
                    StoreId = sc.StoreId,
                    IsConfirmedByAdmin = sc.IsConfirmedByAdmin,
                    ParentCommentId = sc.ParentCommentId,
                    Rate = sc.Rate,
                    LikeCount = sc.LikeCount,
                    DislikeCount = sc.DislikeCount
                }).FirstAsync(cancellationToken);

            return storeComment;
        }

        public async Task UpdateStoreComment(EditStoreCommentInputDto storeComment, CancellationToken cancellationToken)
        {
            var storeCommentToUpdate = await _context.StoreComments.Where(sc => sc.Id == storeComment.Id)
                .FirstOrDefaultAsync(cancellationToken);

            storeCommentToUpdate.Title = storeComment.Title;
            storeCommentToUpdate.CommentBody = storeComment.CommentBody;
            storeCommentToUpdate.UserId = storeComment.UserId;
            storeCommentToUpdate.StoreId = storeComment.StoreId;
            storeCommentToUpdate.IsConfirmedByAdmin = storeComment.IsConfirmedByAdmin;
            storeCommentToUpdate.ParentCommentId = storeComment.ParentCommentId;
            storeCommentToUpdate.Rate = storeComment.Rate;
            storeCommentToUpdate.LikeCount = storeComment.LikeCount;
            storeCommentToUpdate.DislikeCount = storeComment.DislikeCount;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
