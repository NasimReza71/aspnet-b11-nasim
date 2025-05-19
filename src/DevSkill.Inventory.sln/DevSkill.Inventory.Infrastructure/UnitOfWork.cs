using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Repositories;
using DevSkill.Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbcontext;

        

        public UnitOfWork(DbContext context) 
        {
            _dbcontext = context;
            
        
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
