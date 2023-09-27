using SalesManagement.Core.Convertors;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;

namespace SalesManagement.Core.Services
{
    public class OrganisationService: IOrganisationService
    {
        private readonly SalesManagementDbContext _context;

        public OrganisationService(SalesManagementDbContext context)
        {
            _context = context;
        }


        public async Task<List<OrganisationModel>> GetHierarchy()
        {
            try
            {
                return await _context.Employees.ConvertToHierarchy(_context);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
