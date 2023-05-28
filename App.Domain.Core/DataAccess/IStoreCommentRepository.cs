using App.Domain.Core.DtoModels.StoreComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IStoreCommentRepository
    {
        Task<List<StoreCommentOutputDto>> GetAllStoreComments(CancellationToken cancellationToken);
        Task<StoreCommentOutputDto>? GetStoreCommentBy(int id, CancellationToken cancellationToken);
        Task CreateStoreComment(AddStoreCommentInputDto storeComment, CancellationToken cancellationToken);
        Task UpdateStoreComment(EditStoreCommentInputDto storeComment, CancellationToken cancellationToken);
        Task DeleteStoreComment(int id, CancellationToken cancellationToken);
    }
}
