using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace DevSkill.Inventory.Application.Features.Purchases.Queries
{
    public class GetPurchasesSPQueryHandler : IRequestHandler<GetPurchasesSPQuery, (IList<Purchase>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetPurchasesSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Purchase>, int, int)> Handle(GetPurchasesSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetPurchasesSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}