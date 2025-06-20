using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.MoneyReceipts.Queries
{
    public class GetMoneyReceiptByIdQuery : IRequest<MoneyReceipt>
    {
        public Guid Id { get; set; }
    }
}
