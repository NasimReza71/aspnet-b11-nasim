using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.DebitVouchers.Queries
{
    public class GetDebitVouchersSPQueryHandler : IRequestHandler<GetDebitVouchersSPQuery, (IList<DebitVoucher>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetDebitVouchersSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<DebitVoucher>, int, int)> Handle(GetDebitVouchersSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetDebitVouchersSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
