using SalesManagement.Core.DTOs;

namespace SalesManagement.Core.Services.Contracts
{
    public interface IOrganisationService
    {
        Task<List<OrganisationModel>> GetHierarchy();
    }
}
