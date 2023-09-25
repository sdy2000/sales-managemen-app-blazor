using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts();
    }
}
