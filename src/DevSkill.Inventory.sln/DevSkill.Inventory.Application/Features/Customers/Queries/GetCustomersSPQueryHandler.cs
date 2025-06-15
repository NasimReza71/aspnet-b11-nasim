using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Customers.Queries
{
    public class GetCustomersSPQueryHandler : IRequestHandler<GetCustomersSPQuery, (IList<Customer>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetCustomersSPQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Customer>, int, int)> Handle(GetCustomersSPQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetCustomersSP(
                request.PageIndex,
                request.PageSize,
                request.SortExpression,
                request.SearchItem
            );
        }
    }

}
