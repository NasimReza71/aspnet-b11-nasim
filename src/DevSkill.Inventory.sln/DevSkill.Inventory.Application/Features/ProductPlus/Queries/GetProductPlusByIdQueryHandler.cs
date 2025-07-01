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
    public class GetProductPlusByIdQueryHandler : IRequestHandler<GetProductPlusByIdQuery, ProductPlusEntity>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetProductPlusByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductPlusEntity> Handle(GetProductPlusByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductPlusRepository.GetByIdAsync(request.Id);
        }
    }
}
