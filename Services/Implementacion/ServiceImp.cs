using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class ServiceImp: IServiceJc
    {
        private AnalystsDbContext _dbContext;

        public ServiceImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ServiceJc>> GetList()
        {
            try
            {
                List<ServiceJc> SeerviceList = new List<ServiceJc>();
                SeerviceList = await _dbContext.ServiceJcs
                               .Include(p => p.ServiceType)
                               .Include(p => p.Pet)
                               .Include(p => p.Employee)
                               .Where(e => e.IsActive == true).ToListAsync();
                return SeerviceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ServiceJc> Get(int idService)
        {
            try
            {
                ServiceJc? found = new ServiceJc();
                found = await _dbContext.ServiceJcs
                        .Include(p => p.ServiceType)
                        .Include(p => p.Pet)
                        .Include(p => p.Employee)
                    .Where(e => e.Id == idService).FirstOrDefaultAsync();

                return found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceJc> Add(ServiceJc newService)
        {
            try
            {
                _dbContext.ServiceJcs.Add(newService);
                await _dbContext.SaveChangesAsync();
                return newService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
              
        public async Task<bool> Update(ServiceJc updateService)
        {
            try
            {
                _dbContext.ServiceJcs.Update(updateService);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int idService)
        {
            try
            {
                ServiceJc? found = new ServiceJc();
                found = await _dbContext.ServiceJcs
                        .Where(e => e.Id == idService).FirstOrDefaultAsync();
                found.IsActive = false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
