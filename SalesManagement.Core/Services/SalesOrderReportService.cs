using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;

namespace SalesManagement.Core.Services
{
    public class SalesOrderReportService : ISalesOrderReportService
    {
        private SalesManagementDbContext _context;

        public SalesOrderReportService(SalesManagementDbContext context)
        {
            _context = context;
        }


        public async Task<List<GroupedFieldPriceModel>> GetEmployeePricePerMonthData()
        {
            try
            {

                var reportData = await (from s in _context.SalesOrderReports
                                       where s.EmployeeId == 9 && s.OrderDateTime.Year == DateTime.Now.Year
                                       group s by s.OrderDateTime.Month into GroupedData
                                       orderby GroupedData.Key
                                       select new GroupedFieldPriceModel
                                       {
                                           GroupedFieldKey = (
                                               GroupedData.Key == 1 ? "Jan" :
                                               GroupedData.Key == 2 ? "Feb" :
                                               GroupedData.Key == 3 ? "Mar" :
                                               GroupedData.Key == 4 ? "Apr" :
                                               GroupedData.Key == 5 ? "May" :
                                               GroupedData.Key == 6 ? "Jun" :
                                               GroupedData.Key == 7 ? "Jul" :
                                               GroupedData.Key == 8 ? "Aug" :
                                               GroupedData.Key == 9 ? "Sep" :
                                               GroupedData.Key == 10 ? "Oct" :
                                               GroupedData.Key == 11 ? "Nov" :
                                               GroupedData.Key == 12 ? "Dec" :
                                               ""
                                           ),
                                           Price = Math.Round(GroupedData.Sum(o => o.OrderItemPrice), 2)

                                       }).ToListAsync();
                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<GroupedFieldQtyModel>> GetQtyPerProductCategory()
        {
            try
            {
                List<GroupedFieldQtyModel> reportData = await (from s in _context.SalesOrderReports
                                                               group s by s.ProductCategoryName into GroupedData
                                                               orderby GroupedData.Key
                                                               select new GroupedFieldQtyModel
                                                               {
                                                                   GroupedFieldKey = GroupedData.Key,
                                                                   Qty = GroupedData.Sum(oi => oi.OrderItemQty)
                                                               }).ToListAsync();

                return reportData;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
