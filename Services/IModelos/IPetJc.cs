using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface IPetJc
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<PetJc>> GetList();
        Task<PetJc> Get(int idPet);
        Task<PetJc> Add(PetJc newPet);
        Task<bool> Update(PetJc updatePet);
        Task<bool> Delete(int idPet);
    }
}
