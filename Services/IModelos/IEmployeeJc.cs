using TestAngular_BE.Models;

namespace TestAngular_BE.Services.IModelos
{
    public interface IEmployeeJc
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<EmployeeJc>> GetList();
        Task<EmployeeJc> Get(int idEmployee);
        Task<EmployeeJc> Add(EmployeeJc newEmployee);
        Task<bool> Update(EmployeeJc updateEmployee);
        Task<bool> Delete(int idEmployee);
    }
}
