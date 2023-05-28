using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Commisions;
using MarketPlace.Database;
using MarketPlace.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Data.Repositories
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly AppDbContext _context;

        public CommissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCommission(AddCommissionInputDto commission, CancellationToken cancellationToken)
        {
            await _context.Commissions.AddAsync(new Commission
            {
                CommissionAmount = commission.CommissionAmount
            });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCommission(int id, CancellationToken cancellationToken)
        {
            Commission? commission = await _context.Commissions.FindAsync(id);

            commission.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CommissionOutputDto>> GetAllCommissions(CancellationToken cancellationToken)
        {
            var commissions = await _context.Commissions.Select(c => new CommissionOutputDto
            {
                Id = c.Id,
                CommissionAmount = c.CommissionAmount
            }).ToListAsync(cancellationToken);

            return commissions;
        }

        public async Task<CommissionOutputDto>? GetCommissionBy(int id, CancellationToken cancellationToken)
        {
            var commission = await _context.Commissions.Where(c => c.Id == id).Select(c =>
            new CommissionOutputDto
            {
                Id = c.Id,
                CommissionAmount = c.CommissionAmount
            }).FirstAsync(cancellationToken);

            return commission;
        }

        public async Task UpdateCommission(EditCommissionInputDto commission, CancellationToken cancellationToken)
        {
            var commissionToUpdate = await _context.Commissions.Where(c => c.Id == commission.Id)
            .FirstOrDefaultAsync(cancellationToken);

            commissionToUpdate.CommissionAmount = commission.CommissionAmount;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
