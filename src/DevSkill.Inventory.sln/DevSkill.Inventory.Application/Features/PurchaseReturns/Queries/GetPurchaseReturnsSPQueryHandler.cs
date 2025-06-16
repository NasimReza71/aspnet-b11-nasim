using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.PurchaseReturns.Queries
{
    public class GetPurchaseReturnsSPQueryHandler : IRequestHandler<GetPurchaseReturnsSPQuery, (IList<PurchaseReturn>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetPurchaseReturnsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<PurchaseReturn>, int, int)> Handle(GetPurchaseReturnsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetPurchaseReturnsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem);
        }
    }
}
