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

        public DbSet<Client> Clients { get; set; }
        public DbSet<RetailOutlet> RetailOutlets { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<SalesOrderReport> SalesOrderReports { get; set; }

        public Task<List<SalesManagement.Core.DTOs.OrganisationModel>> ConvertToHierarchy(object salesManagementDbContext)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Tables
            SeedEmployeeData.AddEmployeeData(modelBuilder);
            SeedProductData.AddProductData(modelBuilder);
            SeedClientData.AddClientData(modelBuilder);
        }
    }
}
