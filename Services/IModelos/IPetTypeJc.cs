using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface IPetTypeJc
    {
        Task<List<PetTypeJc>> GetList();
    }
}
