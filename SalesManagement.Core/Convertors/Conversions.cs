using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.DTOs;
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
                              Id=e.Id,
                              FirstName=e.FirstName,
                              LastName=e.LastName,
                              EmployeeJobTitleId=e.EmployeeJobTitleId,
                              Email=e.Email,
                              DateOfBirth=e.DateOfBirth,
                              ReportToEmpId=e.ReportToEmpId,
                              Gender=e.Gender,
                              ImagePath=e.ImagePath,
                          }).ToListAsync();
        }
    }
}
