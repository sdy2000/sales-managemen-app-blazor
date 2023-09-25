using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Convertors;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private readonly SalesManagementDbContext _context;

        public EmployeeManagementService(SalesManagementDbContext context)
        {
            _context = context;
        }




        public async Task<Employee> AddEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employeeToAdd = employeeViewModel.Convert();

                var result = await _context.Employees.AddAsync(employeeToAdd);

                return result.Entity;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employeeToUpdate = await _context.Employees.FindAsync(employeeViewModel.Id);

                if (employeeToUpdate != null)
                {
                    employeeToUpdate.FirstName = employeeViewModel.FirstName;
                    employeeToUpdate.LastName = employeeViewModel.LastName;
                    employeeToUpdate.ReportToEmpId = employeeViewModel.ReportToEmpId;
                    employeeToUpdate.DateOfBirth = employeeViewModel.DateOfBirth;
                    employeeToUpdate.ImagePath = employeeViewModel.ImagePath;
                    employeeToUpdate.Gender = employeeViewModel.Gender;
                    employeeToUpdate.Email = employeeViewModel.Email;
                    employeeToUpdate.EmployeeJobTitleId = employeeViewModel.EmployeeJobTitleId;
                }
                else
                {
                    return false;
                }


                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                Employee employeeToDelete = await _context.Employees.FindAsync(employeeId);

                if (employeeToDelete != null)
                {
                    _context.Employees.Remove(employeeToDelete);
                }
                else
                {
                    return false;
                }

                return true;
                }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }




        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            try
            {
                return await _context.Employees.Convert();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<EmployeeJobTitle>> GetEmployeeJobTitles()
        {
            try
            {
                return await _context.EmployeeJobTitles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReportToViewModel>> GetReportToEmployees()
        {
            try
            {
                List<ReportToViewModel> employees = await (from e in _context.Employees
                              join j in _context.EmployeeJobTitles
                              on e.EmployeeJobTitleId equals j.EmployeeJobTitleId
                              where j.Name.ToUpper() == "TL" || j.Name.ToUpper() == "SM"
                              select new ReportToViewModel
                              {
                                  ReportToEmpId = e.Id,
                                  ReportToName = e.FirstName + " " + e.LastName.Substring(0, 1).ToUpper()
                              }).ToListAsync();

                employees.Add(new ReportToViewModel { ReportToEmpId = null, ReportToName = "<None>" });

                return employees.OrderBy(o=>o.ReportToEmpId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
