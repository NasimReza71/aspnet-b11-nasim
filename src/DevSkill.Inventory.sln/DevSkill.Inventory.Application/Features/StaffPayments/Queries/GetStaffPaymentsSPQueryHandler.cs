using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.StaffPayments.Queries
{
    public class GetStaffPaymentsSPQueryHandler : IRequestHandler<GetStaffPaymentsSPQuery, (IList<StaffPayment>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetStaffPaymentsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<StaffPayment>, int, int)> Handle(GetStaffPaymentsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetStaffPaymentsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
