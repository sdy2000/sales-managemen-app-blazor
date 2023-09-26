using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.DTOs.Client;
using SalesManagement.Data.Context;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Convertors
{
    public static class Conversions
    {
        public static async Task<List<EmployeeViewModel>> Convert(this IQueryable<Employee> employees)
        {
            return await (from e in employees
                          select new EmployeeViewModel
                          {
                              Id = e.Id,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              EmployeeJobTitleId = e.EmployeeJobTitleId,
                              Email = e.Email,
                              DateOfBirth = e.DateOfBirth,
                              ReportToEmpId = e.ReportToEmpId,
                              Gender = e.Gender,
                              ImagePath = e.ImagePath,
                          }).ToListAsync();
        }

        public static Employee Convert(this EmployeeViewModel employeeViewModel)
        {
            return new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                EmployeeJobTitleId = employeeViewModel.EmployeeJobTitleId,
                Email = employeeViewModel.Email,
                DateOfBirth = employeeViewModel.DateOfBirth,
                ReportToEmpId = employeeViewModel.ReportToEmpId,
                Gender = employeeViewModel.Gender,
                ImagePath = employeeViewModel.Gender.ToUpper() == "MALE" ? "/Images/Profile/MaleDefault.jpg"
                                                                         : "/Images/Profile/FemaleDefault.jpg",
            };
        }

        public static async Task<List<ProductViewModel>> Convert(this IQueryable<Product> products,
                                                           SalesManagementDbContext context)
        {
            return await (from prod in products
                          join prodCat in context.ProductCategories
                          on prod.CategoryId equals prodCat.Id
                          select new ProductViewModel
                          {
                              Id = prod.Id,
                              Name = prod.Name,
                              Description = prod.Description,
                              ImagePath = prod.ImagePath,
                              Price = prod.Price,
                              CategoryId = prod.CategoryId,
                              CategoryName = prodCat.Name
                          }).ToListAsync();
        }

        public static async Task<List<ClientViewModel>> Convert(this IQueryable<Client> clients,
            SalesManagementDbContext context)
        {
            return await (from c in clients
                          join r in context.RetailOutlets
                          on c.RetailOutletId equals r.Id
                          select new ClientViewModel
                          {
                              Id = c.Id,
                              Email = c.Email,
                              FirstName = c.FirstName,
                              LastName = c.LastName,
                              JobTitle = c.JobTitle,
                              PhoneNumber = c.PhoneNumber,
                              RetailOutletId = c.RetailOutletId,
                              RetailOutletName = r.Name,
                              RetailOutletLocation = r.Location
                          }).ToListAsync();
        }
    }
}
