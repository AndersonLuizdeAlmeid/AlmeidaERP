using AlmeidaERP.Application.Employees.Dtos;
using AlmeidaERP.Core.Factory.Interfaces;
using Dapper;

namespace AlmeidaERP.Application.Employees.Queries;
public class EmployeeQuery : IEmployeeQuery
{
    public IDatabaseFactory LocalDatabase { get; }

    public EmployeeQuery(IDatabaseFactory localDatabase)
    {
        LocalDatabase = localDatabase;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken)
    {
        string sql = @"select id as ID,
                              name as Name,
                              cpf as Cpf,
                              role as Role,
                              salary as Salary,
                              hire_date as HireDate,
                              status as Status
                         from employees ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<EmployeeDto>(command);
    }

    public async Task<EmployeeDto?> GetById(long Id, CancellationToken cancellationToken)
    {
        string sql = @"select id as ID,
                              name as Name,
                              cpf as Cpf,
                              role as Role,
                              salary as Salary,
                              hire_date as HireDate,
                              status as Status                         
                         from employess
                        where id = @Id";

        var command = new CommandDefinition(sql, new { Id }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<EmployeeDto>(command);
    }
}