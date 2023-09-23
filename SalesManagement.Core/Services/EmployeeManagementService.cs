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
