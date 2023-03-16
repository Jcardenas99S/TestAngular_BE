using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class PetImp: IPetJc
    {
        private AnalystsDbContext _dbContext;

        public PetImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PetJc>> GetList()
        {
            try
            {
                List<PetJc> PetList = new List<PetJc>();
                PetList = await _dbContext.PetJcs.Include(p => p.Customer)
                .Include(p => p.PetType)
                .Where(e => e.IsActive == true).ToListAsync();
                return PetList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetJc> Get(int idPet)
        {
            PetJc? found = new PetJc();
            found = await _dbContext.PetJcs.Include(p => p.Customer)
                .Include(p => p.PetType)
                .Where(e => e.Id == idPet).FirstOrDefaultAsync();

            return found;
        }

        public async Task<PetJc> Add(PetJc newPet)
        {
            try
            {
                _dbContext.PetJcs.Add(newPet);
                await _dbContext.SaveChangesAsync();
                return newPet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(PetJc updatePet)
        {
            try
            {
                _dbContext.PetJcs.Update(updatePet);
            await _dbContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int idPet)
        {
            try
            {
                PetJc? found = new PetJc();
                found = await _dbContext.PetJcs
                        .Where(e => e.Id == idPet).FirstOrDefaultAsync();
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
