using SalesManagement.Core.Convertors;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;

namespace SalesManagement.Core.Services
{
    public class ProductService : IProductService
    {
		private SalesManagementDbContext _context;

		public ProductService(SalesManagementDbContext context)
		{
			_context = context;
		}


        public async Task<List<ProductViewModel>> GetProducts()
        {
			try
			{
                List< ProductViewModel> products = await _context.Products.Convert(_context);

				return products;
			}
			catch (Exception)
			{
				return null;
				throw;
			}
        }
    }
}
