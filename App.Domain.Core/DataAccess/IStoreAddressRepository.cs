using App.Domain.Core.DtoModels.StoreAddresses;

namespace App.Domain.Core.DataAccess
{
    public interface IStoreAddressRepository
    {
        Task<List<StoreAddressOutputDto>> GetAllStoreAddresses();
        Task<StoreAddressOutputDto> GetStoreAddressBy(int id);
        Task CreateStoreAddress(AddStoreAddressInputDto storeAddress,CancellationToken cancellationToken);
        Task UpdateStoreAddress(EditStoreAddressInputDto storeAddress);
        Task DeleteStoreAddress(int id);
    }
}
