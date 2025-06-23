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

    public class GetBalanceAdjustmentsSPQueryHandler : IRequestHandler<GetBalanceAdjustmentsSPQuery, (IList<BalanceAdjustment>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetBalanceAdjustmentsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<BalanceAdjustment>, int, int)> Handle(GetBalanceAdjustmentsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetBalanceAdjustmentsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
