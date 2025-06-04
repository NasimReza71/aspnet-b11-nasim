using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsSPQuery, (IList<Product>, int, int)>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetProductsQueryHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<(IList<Product>, int, int)> Handle(GetProductsSPQuery request, CancellationToken cancellationToken)
        {
            return await _applicationUnitOfWork.GetProductsSP(request.PageIndex, request.PageSize, request.SortExpression, request.SearchItem);
        }

    }
}
