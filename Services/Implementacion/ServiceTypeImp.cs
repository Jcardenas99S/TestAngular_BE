using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class ServiceTypeImp: IServiceTypeJc
    {
        private AnalystsDbContext _dbContext;

        public ServiceTypeImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ServiceTypeJc>> GetList()
        {
            try
            {
                List<ServiceTypeJc> listServiceType = new List<ServiceTypeJc>();
                listServiceType = await _dbContext.ServiceTypeJcs.ToListAsync();
                return listServiceType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
