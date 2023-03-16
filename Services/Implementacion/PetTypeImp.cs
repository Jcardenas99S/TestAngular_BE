using Microsoft.EntityFrameworkCore;
using TestAngular_BE.Models;
using TestAngular_BE.Services.IModelos;

namespace TestAngular_BE.Services.Implementacion
{
    public class PetTypeImp: IPetTypeJc
    {
        private AnalystsDbContext _dbContext;

        public PetTypeImp(AnalystsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PetTypeJc>> GetList()
        {
            try
            {
                List<PetTypeJc> listPetType = new List<PetTypeJc>();
                listPetType = await _dbContext.PetTypeJcs.ToListAsync();
                return listPetType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
