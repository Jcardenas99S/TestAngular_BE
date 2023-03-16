using TestAngular_BE.Models;
namespace TestAngular_BE.Services.IModelos
{
    public interface ICustomerJc
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<CustomerJc>> GetList();
        Task<CustomerJc> Get(int idCustomer);
        Task<CustomerJc> Add(CustomerJc newCustomer);
        Task<bool> Update(CustomerJc updateCustomer);
        Task<bool> Delete(int idCustomer);
    }
}
