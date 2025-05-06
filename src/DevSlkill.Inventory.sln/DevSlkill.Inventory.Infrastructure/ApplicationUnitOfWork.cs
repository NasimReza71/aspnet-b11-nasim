using DevSlkill.Inventory.Domain;
using DevSlkill.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext context, IProductRepository productRepository) : base(context)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }
    }
}
