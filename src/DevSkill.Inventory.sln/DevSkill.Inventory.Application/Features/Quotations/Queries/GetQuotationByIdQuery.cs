using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Quotations.Queries
{
    public class GetQuotationByIdQuery : IRequest<Quotation>
    {
        public Guid Id { get; set; }
    }
}
