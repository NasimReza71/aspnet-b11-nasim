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
    public class GetServiceSaleByIdQueryHandler : IRequestHandler<GetServiceSaleByIdQuery, ServiceSaleDto>

    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetServiceSaleByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceSaleDto> Handle(GetServiceSaleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ServiceSaleRepository.GetByIdAsDtoAsync(request.Id);
        }

    }

}
