using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class CustomerTypeImp: ICustomerTypeJc
    {
        private AnalystsDbContext _dbContext;

        public CustomerTypeImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerTypeJc>> GetList()
        {
            try
            {
                List<CustomerTypeJc> listCustType = new List<CustomerTypeJc>();
                listCustType = await _dbContext.CustomerTypeJcs.ToListAsync();
                return listCustType;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
