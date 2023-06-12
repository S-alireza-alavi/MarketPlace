﻿using App.Domain.Core.DtoModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface ICreateAuctionService
    {
        Task<int> CreateAuctionAsync(AddAuctionInputDto inputDto, CancellationToken cancellationToken);
    }
}