using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.AccessSetups
{
    public class GetAccessSetupsSPQueryHandler : IRequestHandler<GetAccessSetupsSPQuery, (IList<AccessSetup>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetAccessSetupsSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<AccessSetup>, int, int)> Handle(GetAccessSetupsSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetAccessSetupsSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
