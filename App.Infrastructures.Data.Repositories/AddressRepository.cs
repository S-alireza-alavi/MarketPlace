//using App.Domain.Core.DataAccess;
//using App.Domain.Core.DtoModels.Addresses;
//using MarketPlace.Database;
//using Microsoft.AspNetCore.Identity;

//namespace App.Infrastructures.Data.Repositories
//{
//    public class AddressRepository : IAddressRepository
//    {
//        private readonly AppDbContext _context;
//        private readonly UserManager<IdentityUser<int>> _userManager;
//        private readonly RoleManager<IdentityRole<int>> _roleManager;

//        public AddressRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task CreateAddress(AddAddressInputDto address, CancellationToken cancellationToken)
//        {
//            await _context.Addresses.AddAsync(new Address()
//            {
//                CustomerId = address.CustomerId,
//                FullAddress = address.FullAddress,
//                IsDeleted = false
//            });

//            await _context.SaveChangesAsync(cancellationToken);
//        }

//        public async Task DeleteAddress(int id, CancellationToken cancellationToken)
//        {
//            Address? address = await _context.Addresses.FindAsync(id);

//            address.IsDeleted = true;

//            await _context.SaveChangesAsync(cancellationToken);
//        }

//        public async Task<List<AddressOutputDto>> GetAllAddresses(CancellationToken cancellationToken)
//        {
//            var addresses = await _context.Addresses.Select(a => new AddressOutputDto
//            {
//                Id = a.Id,
//                CustomerId = a.CustomerId,
//                FullAddress = a.FullAddress
//            }).ToListAsync(cancellationToken);

//            return addresses;
//        }

//        public async Task<AddressOutputDto>? GetAddressBy(int id, CancellationToken cancellationToken)
//        {
//            var customer = await _context.Addresses.Where(a => a.Id == id).Select(c => new AddressOutputDto
//            {
//                Id = c.Id,
//                CustomerId = c.CustomerId,
//                FullAddress = c.FullAddress
//            }).FirstAsync(cancellationToken);

//            return customer;
//        }

//        public async Task UpdateAddress(EditAddressInputDto address, CancellationToken cancellationToken)
//        {
//            var addressToUpdate = await _context.Addresses.Where(a => a.Id == address.Id).FirstOrDefaultAsync(cancellationToken);

//            addressToUpdate.FullAddress = address.FullAddress;

//            await _context.SaveChangesAsync(cancellationToken);
//        }
//    }
//}

//todo: seperate