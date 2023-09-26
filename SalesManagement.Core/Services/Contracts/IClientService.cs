using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IClientService
    {
        Task<List<ClientViewModel>> GetClients();
    }
}
