using AlmeidaERP.Application.Employees.Domain;
using AlmeidaERP.Core.Factory.Interfaces;
using Dapper;

namespace AlmeidaERP.Application.Employees.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    public IDatabaseFactory LocalDatabase { get; }

    public EmployeeRepository(IDatabaseFactory localDatabase)
    {
        LocalDatabase = localDatabase;
    }

    public async Task Insert(Employee employee, CancellationToken cancellationToken)
    {
        string sql = @"insert into addresses (id, 
                                              name, 
                                              cpf, 
                                              role, 
                                              salary, 
                                              hire_date, 
                                              status)
                                      values (@ID,
                                              @Name,
                                              @Cpf,
                                              @Role,
                                              @Salary,
                                              @HireDate,
                                              @Status)";

        var command = new CommandDefinition(sql, employee, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Employee employee, CancellationToken cancellationToken)
    {
        string sql = @"update addresses 
                          set name = @Name, 
                              cpf = @Cpf, 
                              role = @Role, 
                              salary = @Salary, 
                              hire_date = @HireDate, 
                              status = @Status
                        where id = @ID";

        var command = new CommandDefinition(sql, employee, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
