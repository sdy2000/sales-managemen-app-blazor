using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface ISalesOrderReportService
    {
        //SR
        Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData();
        Task<List<GroupedFieldQtyModel>> GetQtyPerProductCategory();
        Task<List<GroupedFieldQtyModel>> GetQtyPerMonthData();

        //TL

        //TL
        Task<List<GroupedFieldPriceModel>> GetGrossSalesPerTeamMemberData();
        Task<List<GroupedFieldQtyModel>> GetQtyPerTeamMemberData();
        Task<List<GroupedFieldQtyModel>> GetTeamQtyPerMonthData();

        //SM
        Task<List<LocationProductCategoryModel>> GetQtyLocationProductCatData();
        Task<List<GroupedFieldQtyModel>> GetQtyPerLocationData();
        Task<List<MonthLocationModel>> GetQtyPerMonthLocationData();

    }
}
