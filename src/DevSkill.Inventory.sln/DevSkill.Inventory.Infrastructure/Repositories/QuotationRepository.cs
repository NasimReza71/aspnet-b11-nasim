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
    public class QuotationRepository : Repository<Quotation, Guid>, IQuotationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuotationRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public (IList<Quotation> data, int total, int totalDisplay) GetPagedQuotations(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(q =>
                    q.QuotationNumber.Contains(search.Value) ||
                    q.CustomerName.Contains(search.Value),
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
