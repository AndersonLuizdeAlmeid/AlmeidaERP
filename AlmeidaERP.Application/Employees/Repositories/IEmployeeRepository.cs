using AlmeidaERP.Application.Employees.Domain;
using AlmeidaERP.Core.Repository;

namespace AlmeidaERP.Application.Employees.Repositories;
public interface IEmployeeRepository : ILocalDatabaseRepository
{
    Task Insert(Employee employee, CancellationToken cancellationToken);
    Task Update(Employee employee, CancellationToken cancellationToken);
}
