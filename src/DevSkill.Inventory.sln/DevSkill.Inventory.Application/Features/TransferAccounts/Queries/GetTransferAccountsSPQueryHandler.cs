using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.TransferAccounts.Queries
{
    public class GetTransferAccountsSPQueryHandler : IRequestHandler<GetTransferAccountsSPQuery, (IList<TransferAccount>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetTransferAccountsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<TransferAccount>, int, int)> Handle(GetTransferAccountsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetTransferAccountsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
