using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class LeaveCommentForStoreService : ILeaveCommentForStoreService
    {
        private readonly IStoreCommentRepository _storeCommentRepository;

        public LeaveCommentForStoreService(IStoreCommentRepository storeCommentRepository)
        {
            _storeCommentRepository = storeCommentRepository;
        }

        public async Task LeaveCommentForStore(AddStoreCommentInputDto comment, CancellationToken cancellationToken)
        {
           await _storeCommentRepository.CreateStoreComment(comment, cancellationToken);
        }
    }
}
