using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Inventory.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;


        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceSale> ServiceSales { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<MoneyReceipt> MoneyReceipts { get; set; }

        public DbSet<DebitVoucher> DebitVouchers { get; set; }

        public DbSet<SupplierPay> SupplierPays { get; set; }

        public DbSet<TransferAccount> TransferAccounts { get; set; }

        public DbSet<BalanceAdjustment> BalanceAdjustments { get; set; }

        public DbSet<StaffPayment> StaffPayments { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }



        public DbSet<Staff> Staffs { get; set; }

        public DbSet<User> Users { get; set; }


         public DbSet<ProductPlusEntity> ProductPluses { get; set; }


        public DbSet<Purchase> Purchases { get; set; }





        public ApplicationDbContext(string connectionString, string migrationAssembly )
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
