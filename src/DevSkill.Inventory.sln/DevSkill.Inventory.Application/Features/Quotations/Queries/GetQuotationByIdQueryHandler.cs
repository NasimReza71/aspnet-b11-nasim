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
    public class GetQuotationByIdQueryHandler : IRequestHandler<GetQuotationByIdQuery, Quotation>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetQuotationByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Quotation> Handle(GetQuotationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.QuotationRepository.GetByIdAsync(request.Id);
        }
    }
}
