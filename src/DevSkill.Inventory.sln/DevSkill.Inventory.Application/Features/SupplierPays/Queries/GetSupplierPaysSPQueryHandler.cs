using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.SupplierPays.Queries
{
    public class GetSupplierPaysSPQueryHandler : IRequestHandler<GetSupplierPaysSPQuery, (IList<SupplierPay>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSupplierPaysSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<SupplierPay>, int, int)> Handle(GetSupplierPaysSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetSupplierPaysSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
