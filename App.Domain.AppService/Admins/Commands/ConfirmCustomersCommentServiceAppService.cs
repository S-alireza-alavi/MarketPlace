using App.Domain.Core.AppServices.Admins.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreComments;
using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.AppService.Admins.Commands
{
    public class ConfirmCustomersCommentServiceAppService : IConfirmCustomersCommentServiceAppService
    {
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IStoreCommentRepository _storeCommentRepository;

        public ConfirmCustomersCommentServiceAppService(IProductCommentRepository productCommentRepository, IStoreCommentRepository storeCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
            _storeCommentRepository = storeCommentRepository;
        }

        public async Task<bool> ConfirmCustomersProductComment(int productCommentId, CancellationToken cancellationToken)
        {
            bool isDone;

            var productComment = await _productCommentRepository.GetProductCommentBy(productCommentId, cancellationToken);

            if (productComment != null)
            {
               productComment.IsConfirmedByAdmin = true;
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
                storeComment.IsConfirmedByAdmin = true;
                isDone = true;
            }
            else
            {
                isDone = false;
            }

            return isDone;
        }
    }
}
