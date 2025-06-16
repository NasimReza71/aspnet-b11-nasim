using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceFeatures.Queries
{
    public class GetServicesSPQueryHandler : IRequestHandler<GetServicesSPQuery, (IList<Service>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetServicesSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Service>, int, int)> Handle(GetServicesSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetServicesSP(request.PageIndex, request.PageSize, request.SortExpression, request.SearchItem);
        }
    }
}
