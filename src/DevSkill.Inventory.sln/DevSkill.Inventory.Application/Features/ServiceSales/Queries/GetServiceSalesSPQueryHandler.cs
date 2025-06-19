using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceSales.Queries
{
    public class GetServiceSalesSPQueryHandler : IRequestHandler<GetServiceSalesSPQuery, (IList<ServiceSaleDto>, int, int)>

    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetServiceSalesSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<ServiceSaleDto>, int, int)> Handle(GetServiceSalesSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetServiceSalesSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }

    }
}
