using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure.Repositories
{
    public class ProductPlusRepository : Repository<ProductPlusEntity, Guid>, IProductPlusRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductPlusRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool IsProductCodeDuplicate(string productCode, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.ProductCode == productCode) > 0;
            else
                return GetCount(x => x.ProductCode == productCode) > 0;
        }

        public int GetProductPlusCount()
        {
            return _dbContext.ProductPluses.Count();
        }

        public (IList<ProductPlusEntity> data, int total, int totalDisplay) GetPagedProductPlus(
            int pageIndex, int pageSize, string order, ProductPlusSearchDto search)
        {
            if (string.IsNullOrWhiteSpace(search.ProductName) && string.IsNullOrWhiteSpace(search.ProductCode))
            {
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            }
            else
            {
                return GetDynamic(x =>
                        x.ProductName.Contains(search.ProductName) ||
                        x.ProductCode.Contains(search.ProductCode) ||
                        x.Category.Contains(search.Category),
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
