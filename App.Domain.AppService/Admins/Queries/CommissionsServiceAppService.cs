using App.Domain.Core.DtoModels.Commisions;
using App.Domain.Core.AppServices.Admins.Queries;
using MarketPlace.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.AppService.Admins.Queries
{
    public class CommissionsServiceAppService : ICommissionsServiceAppService
    {
        private readonly AppDbContext _context;

        public CommissionsServiceAppService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommissionOutputDto>> GetCommissions(CancellationToken cancellationToken)
        {
            //todo: نباید به context دسترسی داشته باشه، اصلاح شه
            var commissions = await _context.Commissions.Include(c => c.Order).ThenInclude(o => o.Seller).ToListAsync(cancellationToken);

            var outputDto = commissions.Select(c => new CommissionOutputDto
            {
                Id = c.Id,
                OrderId = c.Order.Id,
                CommissionAmount = c.CommissionAmount,
                SellerUserName = c.Order.Seller.UserName
            }).ToList();

            return outputDto;
        }
    }
}
