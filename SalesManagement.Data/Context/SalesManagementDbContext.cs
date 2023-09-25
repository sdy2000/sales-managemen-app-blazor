using Microsoft.EntityFrameworkCore;
using SalesManagement.Data.Context.Seed;
using SalesManagement.Data.Entities;

namespace SalesManagement.Data.Context
{
    public class SalesManagementDbContext:DbContext
    {
        public SalesManagementDbContext(DbContextOptions<SalesManagementDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            SeedEmployeeData.AddEmployeeData(modelBuilder);
            SeedProductData.AddProductData(modelBuilder);
        }
    }
}
