using SalesManagement.Core.DTOs;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IEmployeeManagementService
    {
        Task<List<EmployeeViewModel>> GetEmployees();
        Task<List<EmployeeJobTitle>> GetEmployeeJobTitles();
        Task<List<ReportToViewModel>> GetReportToEmployees();
    }
}
