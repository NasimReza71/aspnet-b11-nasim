using DevSlkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Domain.Services
{
    public interface IProductService
    {
        public void AddProduct(Product product);
    }
}
