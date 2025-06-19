using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Quotations.Queries
{
    public class GetQuotationsSPQueryHandler : IRequestHandler<GetQuotationsSPQuery, (IList<Quotation>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetQuotationsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Quotation>, int, int)> Handle(GetQuotationsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetQuotationsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
