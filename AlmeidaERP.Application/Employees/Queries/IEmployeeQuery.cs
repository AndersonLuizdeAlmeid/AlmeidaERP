using AlmeidaERP.Application.Employees.Dtos;

namespace AlmeidaERP.Application.Employees.Queries;
public interface IEmployeeQuery
{
    Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken);
    Task<EmployeeDto?> GetById(long id, CancellationToken cancellationToken);
}