using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;



namespace TestAngular_BE.Services.Implementacion
{
    public class EmployeeImp: IEmployeeJc
    {
        private AnalystsDbContext _dbContext;

        public EmployeeImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeJc>> GetList()
        {
            try
            {
                List<EmployeeJc> EmployeeList = new List<EmployeeJc>();
                EmployeeList = await _dbContext.EmployeeJcs
                .Where(e => e.IsActive == true).ToListAsync();
                return EmployeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeJc> Get(int idEmployee)
        {
            EmployeeJc? found = new EmployeeJc();
            found = await _dbContext.EmployeeJcs
                    .Where(e => e.Id == idEmployee).FirstOrDefaultAsync();
            return found;
        }

        public async Task<EmployeeJc> Add(EmployeeJc newEmployee)
        {
            _dbContext.EmployeeJcs.Add(newEmployee);
            await _dbContext.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<bool> Update(EmployeeJc updateEmployee)
        {
            _dbContext.EmployeeJcs.Update(updateEmployee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int idEmployee)
        {
            CustomerJc? found = new CustomerJc();
            found = await _dbContext.CustomerJcs
                    .Where(e => e.Id == idEmployee).FirstOrDefaultAsync();
            found.IsActive = false;
            return true;
        }
    }
}
