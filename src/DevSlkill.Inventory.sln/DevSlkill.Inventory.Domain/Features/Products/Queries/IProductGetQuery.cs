using DevSlkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Domain.Features.Products.Queries
{
    public interface IProductGetQuery
    {
        Product Get(Guid id);
    }
}
