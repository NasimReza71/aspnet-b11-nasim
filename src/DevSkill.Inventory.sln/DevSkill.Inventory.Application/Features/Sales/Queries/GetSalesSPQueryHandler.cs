using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Sales.Queries
{
    public class GetSalesSPQueryHandler : IRequestHandler<GetSalesSPQuery, (IList<Sale>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSalesSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Sale>, int, int)> Handle(GetSalesSPQuery request, CancellationToken cancellationToken)
        {
            
            return await _unitOfWork.GetSalesSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
