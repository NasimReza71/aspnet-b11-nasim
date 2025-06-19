using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IQuotationRepository : IRepository<Quotation, Guid>
    {
        (IList<Quotation> data, int total, int totalDisplay) GetPagedQuotations(int pageIndex, int pageSize, string? order, DataTablesSearch search);
    }
}
