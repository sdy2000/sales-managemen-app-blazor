using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface ISalesOrderReportService
    {
        Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData();
        Task<List<GroupedFieldQtyModel>> GetQtyPerProductCategory();
    }
}
