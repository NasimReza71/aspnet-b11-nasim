using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repositories
{
    public interface IProductPlusRepository : IRepository<ProductPlusEntity, Guid>
    {
        bool IsProductCodeDuplicate(string productCode, Guid? id = null);
        int GetProductPlusCount();

        (IList<ProductPlusEntity> data, int total, int totalDisplay) GetPagedProductPlus(
            int pageIndex, int pageSize, string order, ProductPlusSearchDto search);
    }
}
