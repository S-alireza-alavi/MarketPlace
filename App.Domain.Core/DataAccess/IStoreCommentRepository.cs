using App.Domain.Core.DtoModels.StoreComments;

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
