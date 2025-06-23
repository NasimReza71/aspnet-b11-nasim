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
    public class GetStaffPaymentByIdQueryHandler : IRequestHandler<GetStaffPaymentByIdQuery, StaffPayment>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetStaffPaymentByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StaffPayment> Handle(GetStaffPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StaffPaymentRepository.GetByIdAsync(request.Id);
        }
    }
}
