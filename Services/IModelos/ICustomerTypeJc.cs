using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface ICustomerTypeJc
    {
        Task<List<CustomerTypeJc>> GetList();
    }
}
