using SalesManagement.Core.DTOs;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IEmployeeManagementService
    {
        Task<Employee> AddEmployee(EmployeeViewModel employeeViewModel);
        Task<bool> UpdateEmployee(EmployeeViewModel employeeViewModel);
        Task<bool> DeleteEmployee(int employeeId);
        Task<bool> SaveChanges();

        Task<List<EmployeeViewModel>> GetEmployees();
        Task<List<EmployeeJobTitle>> GetEmployeeJobTitles();
        Task<List<ReportToViewModel>> GetReportToEmployees();

    }
}
