using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface IServiceTypeJc
    {
        Task<List<ServiceTypeJc>> GetList();
    }

}
