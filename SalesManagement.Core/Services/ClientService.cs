using SalesManagement.Core.Convertors;
using SalesManagement.Core.DTOs.Client;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;

namespace SalesManagement.Core.Services
{
    public class ClientService : IClientService
    {
		private SalesManagementDbContext _context;

		public ClientService(SalesManagementDbContext context)
		{
			_context = context;
		}



        public async Task<List<ClientViewModel>> GetClients()
        {
			try
			{
				List<ClientViewModel> clients = await _context.Clients.Convert(_context);

				return clients;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
