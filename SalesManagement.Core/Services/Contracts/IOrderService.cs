using SalesManagement.Core.DTOs;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IOrderService
    {
        bool SavaChange();
        Task CreateOrder(OrderViewModel orderViewModel);
    }
}
