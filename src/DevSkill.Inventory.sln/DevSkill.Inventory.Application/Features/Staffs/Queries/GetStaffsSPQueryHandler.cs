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
    public class GetStaffsSPQueryHandler : IRequestHandler<GetStaffsSPQuery, (IList<Staff>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetStaffsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Staff>, int, int)> Handle(GetStaffsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetStaffsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
