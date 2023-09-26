using SalesManagement.Core.DTOs.Client;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IClientService
    {
        Task<List<ClientViewModel>> GetClients();
    }
}
