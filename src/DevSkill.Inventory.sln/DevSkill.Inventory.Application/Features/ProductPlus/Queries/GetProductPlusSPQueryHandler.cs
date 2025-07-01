using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ProductPlus.Queries
{
    public class GetProductPlusSPQueryHandler : IRequestHandler<GetProductPlusSPQuery, (IList<ProductPlusEntity>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetProductPlusSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<ProductPlusEntity>, int, int)> Handle(GetProductPlusSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetProductPlusSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
