using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class MoneyReceiptRepository : Repository<MoneyReceipt, Guid>, IMoneyReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MoneyReceiptRepository(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public (IList<MoneyReceipt> data, int total, int totalDisplay) GetPagedMoneyReceipts(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }

            return GetDynamic(x =>
                    x.Invoice.Contains(search.Value) ||
                    x.Participant.Contains(search.Value) ||
                    x.VoucherType.Contains(search.Value) ||
                    x.Status.Contains(search.Value) ||
                    x.Amount.ToString().Contains(search.Value),
                order,
                null,
                pageIndex,
                pageSize,
                true);
        }
    }
}
