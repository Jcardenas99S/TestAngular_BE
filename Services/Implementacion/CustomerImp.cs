using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class CustomerImp: ICustomerJc
    {
        private AnalystsDbContext _dbContext;

        public CustomerImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerJc>> GetList()
        {
            try 
            {
                List<CustomerJc> CustomerList = new List<CustomerJc>();
                CustomerList = await _dbContext.CustomerJcs.Include(p => p.CustomerType)
                .Where(e => e.IsActive == true).ToListAsync();
                return CustomerList;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
        }
        public async Task<CustomerJc> Get(int idCustomer)
        {
            try
            {
                CustomerJc? found = new CustomerJc();
                found = await _dbContext.CustomerJcs.Include(p => p.CustomerType)
                    .Where(e => e.Id == idCustomer).FirstOrDefaultAsync();

                return found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerJc> Add(CustomerJc newCustomer)
        {
            try
            {
                _dbContext.CustomerJcs.Add(newCustomer);
                await _dbContext.SaveChangesAsync();
                return newCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<bool> Update(CustomerJc updateCustomer)
        {
            try
            {
                _dbContext.CustomerJcs.Update(updateCustomer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int idCustomer)
        {
            try
            {
                CustomerJc? found = new CustomerJc();
                found = await _dbContext.CustomerJcs
                        .Where(e => e.Id == idCustomer).FirstOrDefaultAsync(); 
                found.IsActive = false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
