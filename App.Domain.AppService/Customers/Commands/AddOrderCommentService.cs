using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Customers.Commands
{
    public class AddOrderCommentService : IAddOrderCommentService
    {
        private readonly IOrderCommentRepository _orderCommentRepository;

        public AddOrderCommentService(IOrderCommentRepository orderCommentRepository)
        {
            _orderCommentRepository = orderCommentRepository;
        }

        public async Task AddOrderComment(AddOrderCommentInputDto orderCommentDto, CancellationToken cancellationToken)
        {
            await _orderCommentRepository.AddOrderComment(orderCommentDto, cancellationToken);
        }
    }
}
