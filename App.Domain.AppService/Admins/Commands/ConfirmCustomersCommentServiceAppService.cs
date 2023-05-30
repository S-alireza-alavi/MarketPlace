using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductComments;
using App.Domain.Core.DtoModels.StoreComments;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.AppService.Admins.Commands
{
    public class ConfirmCustomersCommentServiceAppService : IConfirmCustomersCommentServiceAppService
    {
        private readonly AppDbContext _context;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IStoreCommentRepository _storeCommentRepository;

        public ConfirmCustomersCommentServiceAppService(AppDbContext context, IProductCommentRepository productCommentRepository, IStoreCommentRepository storeCommentRepository)
        {
            _context = context;
            _productCommentRepository = productCommentRepository;
            _storeCommentRepository = storeCommentRepository;
        }

        public async Task<bool> ConfirmCustomersProductComment(int productCommentId, CancellationToken cancellationToken)
        {
            bool isDone;

            var productComment = await _productCommentRepository.GetProductCommentBy(productCommentId, cancellationToken);

            if (productComment != null)
            {
                await _productCommentRepository.UpdateProductComment(new EditProductCommentInputDto
                {
                    Id = productComment.Id,
                    Title = productComment.Title,
                    CommentBody = productComment.CommentBody,
                    UserId = productComment.UserId,
                    ProductId = productComment.ProductId,
                    IsConfirmedByAdmin = true,
                    ParentCommentId = productComment.ParentCommentId,
                    Rate = productComment.Rate,
                    LikeCount = productComment.LikeCount,
                    DislikeCount = productComment.DislikeCount
                }, cancellationToken);

                isDone = true;
            }
            else
            {
                isDone = false;
            }

            return isDone;
        }

        public async Task<bool> ConfirmCustomersStoreComment(int storeCommentId, CancellationToken cancellationToken)
        {
            bool isDone;

            var storeComment = await _storeCommentRepository.GetStoreCommentBy(storeCommentId, cancellationToken);

            if (storeComment != null)
            {
                await _storeCommentRepository.UpdateStoreComment(new EditStoreCommentInputDto
                {
                    Id = storeComment.Id,
                    Title = storeComment.Title,
                    CommentBody = storeComment.CommentBody,
                    UserId = storeComment.UserId,
                    StoreId = storeComment.StoreId,
                    IsConfirmedByAdmin = true,
                    ParentCommentId = storeComment.ParentCommentId,
                    Rate = storeComment.Rate,
                    LikeCount = storeComment.LikeCount,
                    DislikeCount = storeComment.DislikeCount
                }, cancellationToken);

                isDone = true;
            }
            else
            {
                isDone = false;
            }

            return isDone;
        }

        public async Task<List<ProductCommentOutputDto>> GetAllUnConfirmedProductComments(CancellationToken cancellationToken)
        {
            var unconfirmedProductComments = await _productCommentRepository.GetAllUnConfirmedProductComments(cancellationToken);
            return unconfirmedProductComments;
        }

        public async Task<List<StoreCommentOutputDto>> GetAllUnConfirmedStoreComments(CancellationToken cancellationToken)
        {
            var unconfirmedStoreComments = await _storeCommentRepository.GetAllUnConfirmedStoreComments(cancellationToken);
            return unconfirmedStoreComments;
        }
    }
}
