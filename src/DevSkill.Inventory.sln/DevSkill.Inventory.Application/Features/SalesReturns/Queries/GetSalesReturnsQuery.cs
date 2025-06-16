using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.SalesReturns.Queries
{
    public class GetSalesReturnsSPQuery : IRequest<(IList<SalesReturn>, int, int)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public SalesReturnSearchDto SearchItem { get; set; }
    }
}
