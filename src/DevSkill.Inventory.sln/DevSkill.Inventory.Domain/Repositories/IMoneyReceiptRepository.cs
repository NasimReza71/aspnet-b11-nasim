using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IMoneyReceiptRepository : IRepository<MoneyReceipt, Guid>
    {

        (IList<MoneyReceipt> data, int total, int totalDisplay) GetPagedMoneyReceipts(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
