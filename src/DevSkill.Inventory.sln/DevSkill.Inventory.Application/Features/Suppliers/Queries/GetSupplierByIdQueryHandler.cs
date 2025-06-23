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
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Supplier>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSupplierByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Supplier> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SupplierRepository.GetByIdAsync(request.Id);
        }
    }
}
