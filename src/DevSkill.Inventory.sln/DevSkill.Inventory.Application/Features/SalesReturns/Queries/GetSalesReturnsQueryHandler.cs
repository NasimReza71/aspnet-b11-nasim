using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.SalesReturns.Queries
{
    public class GetSalesReturnsSPQueryHandler : IRequestHandler<GetSalesReturnsSPQuery, (IList<SalesReturn>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSalesReturnsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<SalesReturn>, int, int)> Handle(GetSalesReturnsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetSalesReturnsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }

}
