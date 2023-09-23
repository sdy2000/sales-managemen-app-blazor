using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IEmployeeManagementService
    {
        Task<List<EmployeeViewModel>> GetEmployees();
    }
}
