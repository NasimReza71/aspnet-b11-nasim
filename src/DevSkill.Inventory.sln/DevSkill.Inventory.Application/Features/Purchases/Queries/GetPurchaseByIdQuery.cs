using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Purchases.Queries
{
    public class GetPurchaseByIdQuery : IRequest<Purchase>
    {
        public Guid Id { get; set; }
    }
}
