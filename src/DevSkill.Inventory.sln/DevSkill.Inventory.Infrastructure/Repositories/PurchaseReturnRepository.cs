using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class PurchaseReturnRepository : Repository<PurchaseReturn, Guid>, IPurchaseReturnRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseReturnRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool IsInvoiceDuplicate(string returnInvoice, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => x.Id != id.Value && x.ReturnInvoice == returnInvoice) > 0;
            }
            else
            {
                return GetCount(x => x.ReturnInvoice == returnInvoice) > 0;
            }
        }

        public (IList<PurchaseReturn> data, int total, int totalDisplay) GetPagedPurchaseReturns(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(x => x.ReturnInvoice.Contains(search.Value) ||
                                     x.Supplier.Contains(search.Value),
                                     order, null, pageIndex, pageSize, true);
            }
        }
    }
}
