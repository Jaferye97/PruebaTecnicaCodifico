using Domain.Model.Employees;

namespace Application.Ports
{
    public interface IEmployeesRepositorySqlServerPort
    {
        Task<IEnumerable<EmployeesReadModel>> GetAllAsync();
    }
}
