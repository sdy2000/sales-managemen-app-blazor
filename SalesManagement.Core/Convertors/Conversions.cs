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
    }
}
