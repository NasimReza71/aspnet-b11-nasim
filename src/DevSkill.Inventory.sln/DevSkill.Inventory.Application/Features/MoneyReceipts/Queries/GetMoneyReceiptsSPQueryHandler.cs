using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.MoneyReceipts.Queries
{
    public class GetMoneyReceiptsSPQueryHandler : IRequestHandler<GetMoneyReceiptsSPQuery, (IList<MoneyReceipt>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetMoneyReceiptsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<MoneyReceipt>, int, int)> Handle(GetMoneyReceiptsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetMoneyReceiptsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
