using Application.Ports;
using Domain.Model.Employees;

namespace Application.UseCases.Employees
{
    public class GetAllEmployeesUseCase
    {
        private readonly IEmployeesRepositorySqlServerPort _repository;

        public GetAllEmployeesUseCase(IEmployeesRepositorySqlServerPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeesReadModel>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
