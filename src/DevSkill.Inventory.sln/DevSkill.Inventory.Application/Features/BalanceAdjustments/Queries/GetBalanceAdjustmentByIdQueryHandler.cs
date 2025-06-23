using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.BalanceAdjustments.Queries
{
    public class GetBalanceAdjustmentByIdQueryHandler : IRequestHandler<GetBalanceAdjustmentByIdQuery, BalanceAdjustment>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetBalanceAdjustmentByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BalanceAdjustment> Handle(GetBalanceAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BalanceAdjustmentRepository.GetByIdAsync(request.Id);
        }
    }
}
