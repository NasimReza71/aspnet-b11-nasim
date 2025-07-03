using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class PurchaseRepository : Repository<Purchase, Guid>, IPurchaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseRepository(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public bool IsInvoiceDuplicate(string invoice, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => x.Id != id.Value && x.PurchaseInvoice == invoice) > 0;
            }
            else
            {
                return GetCount(x => x.PurchaseInvoice == invoice) > 0;
            }
        }

        public (IList<Purchase> data, int total, int totalDisplay) GetPagedPurchases(
            int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(x =>
                    x.PurchaseInvoice.Contains(search.Value) ||  
                    x.Name.Contains(search.Value) ||              
                    x.Products.Contains(search.Value),             
                    order,
                    null,
                    pageIndex,
                    pageSize,
                    true
                );
            }
        }
    }
}
