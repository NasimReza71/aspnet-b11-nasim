using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Purchases.Queries
{
    public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, Purchase>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetPurchaseByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Purchase> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PurchaseRepository.GetByIdAsync(request.Id);
        }
    }
}
