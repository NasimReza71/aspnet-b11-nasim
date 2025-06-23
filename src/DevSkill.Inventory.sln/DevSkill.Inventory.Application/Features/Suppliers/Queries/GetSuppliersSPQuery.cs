using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Suppliers.Queries
{
    public class GetSuppliersSPQuery : IRequest<(IList<Supplier>, int, int)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public SupplierSearchDto SearchItem { get; set; }
    }
}
