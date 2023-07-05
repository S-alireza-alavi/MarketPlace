using App.Domain.Core.DtoModels.OrderComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IOrderCommentRepository
    {
        Task AddOrderComment(AddOrderCommentInputDto orderCommentDto, CancellationToken cancellationToken);
    }
}
