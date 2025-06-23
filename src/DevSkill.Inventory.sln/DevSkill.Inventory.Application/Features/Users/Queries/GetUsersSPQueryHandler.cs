using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Users.Queries
{
    public class GetUsersSPQueryHandler : IRequestHandler<GetUsersSPQuery, (IList<User>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetUsersSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<User>, int, int)> Handle(GetUsersSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetUsersSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }
}
