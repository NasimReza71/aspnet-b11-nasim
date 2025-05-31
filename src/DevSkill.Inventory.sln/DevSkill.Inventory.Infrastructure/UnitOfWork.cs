using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Repositories;
using DevSkill.Inventory.Domain.Utilities;
using DevSkill.Inventory.Infrastructure.Repositories;
using DevSkill.Inventory.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbcontext;
        protected ISqlUtility SqlUtility { get; private set; }


        public UnitOfWork(DbContext context) 
        {
            _dbcontext = context;
            SqlUtility = new SqlUtility(_dbcontext.Database.GetDbConnection());

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
