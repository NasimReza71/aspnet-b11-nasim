using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class PurchaseRepository : Repository<Purchase, Guid>, IPurchaseRepository
    {
        public PurchaseRepository(ApplicationDbContext context) : base(context) { }

        public bool IsInvoiceDuplicate(string invoice, Guid? id = null)
        {
            return id.HasValue
                ? GetCount(x => x.Id != id.Value && x.PurchaseInvoice == invoice) > 0
                : GetCount(x => x.PurchaseInvoice == invoice) > 0;
        }

        public (IList<Purchase> data, int total, int totalDisplay) GetPagedPurchases(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);

            return GetDynamic(x =>
                x.PurchaseInvoice.Contains(search.Value) ||
                x.Name.Contains(search.Value) ||
                x.Products.Contains(search.Value),
                order, null, pageIndex, pageSize, true);
        }
    }
}
