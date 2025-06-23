using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Suppliers.Queries
{
    public class GetSuppliersSPQueryHandler : IRequestHandler<GetSuppliersSPQuery, (IList<Supplier>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSuppliersSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Supplier>, int, int)> Handle(GetSuppliersSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetSuppliersSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
