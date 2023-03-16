using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface IServiceJc
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<ServiceJc>> GetList();
        Task<ServiceJc> Get(int idService);
        Task<ServiceJc> Add(ServiceJc newService);
        Task<bool> Update(ServiceJc updateService);
        Task<bool> Delete(int idService);
    }
}
