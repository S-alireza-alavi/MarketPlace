﻿using App.Domain.Core.DtoModels.Commisions;
using MarketPlace.Entities;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ICalculateCommissionServiceAppService
    {
        Task<bool> CheckIfSellerHasMedal(int sellerId, CancellationToken cancellationToken);
        Task<CommissionOutputDto> CalculateCommission(Order order, CancellationToken cancellationToken);
    }
}