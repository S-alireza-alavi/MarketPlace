using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DtoModels.Addresses;

namespace App.Domain.Core.DataAccess
{
    public interface IAddressRepository
    {
        //todo: add separate DTOs and repositories for customerAddress and storeAddress entities
        Task<List<AddressOutputDto>> GetAllAddresses(CancellationToken cancellationToken);
        Task<AddressOutputDto>? GetAddressBy(int id, CancellationToken cancellationToken);
        Task CreateAddress(AddAddressInputDto address, CancellationToken cancellationToken);
        Task UpdateAddress(EditAddressInputDto address, CancellationToken cancellationToken);
        Task DeleteAddress(int id, CancellationToken cancellationToken);
    }
}