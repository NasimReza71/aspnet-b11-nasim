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
    public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, Sale>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetSaleByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Sale> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
           
            return await _unitOfWork.SaleRepository.GetByIdAsync(request.Id);
        }
    }
}
