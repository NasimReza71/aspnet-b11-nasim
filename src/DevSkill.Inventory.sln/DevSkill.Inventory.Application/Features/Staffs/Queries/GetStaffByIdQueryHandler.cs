using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Staffs.Queries
{
    public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, Staff>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetStaffByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Staff> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StaffRepository.GetByIdAsync(request.Id);
        }
    }
}
