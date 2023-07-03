using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using MarketPlace.Database;

namespace App.Infrastructures.Data.Repositories
{
    public class MedalRepository : IMedalRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;

        public MedalRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task SetMedalForSeller(int sellerId, CancellationToken cancellationToken)
        {
            var seller = await _userRepository.GetUserBy(sellerId);

            if (seller != null)
            {
                var medal = new Medal
                {
                    Id = sellerId,
                    SellerId = sellerId
                };

                await _context.Medals.AddAsync(medal, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
