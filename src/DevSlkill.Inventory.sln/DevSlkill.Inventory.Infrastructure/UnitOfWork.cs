using DevSlkill.Inventory.Domain;
using DevSlkill.Inventory.Domain.Repositories;
using DevSlkill.Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbcontext;

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(DbContext context) 
        {
            _dbcontext = context;
            ProductRepository = new ProductRepository((ApplicationDbContext)context);
        
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }



    }
}
