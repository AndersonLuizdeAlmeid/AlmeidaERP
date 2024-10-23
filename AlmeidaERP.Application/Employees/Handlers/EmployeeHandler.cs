using AlmeidaERP.Application.Employees.Commands;
using AlmeidaERP.Application.Employees.Domain;
using AlmeidaERP.Application.Employees.Queries;
using AlmeidaERP.Application.Employees.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace AlmeidaERP.Application.Employees.Handlers;
public class EmployeeHandler : IRequestHandler<CreateEmployeeCommand, Result>,
                               IRequestHandler<ChangeEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeQuery _employeeQuery;

    public EmployeeHandler(IEmployeeRepository employeeRepository, IEmployeeQuery employeeQuery)
    {
        _employeeRepository = employeeRepository;
        _employeeQuery = employeeQuery;
    }

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var employee = Employee.Create(request.Name, request.Cpf, request.Role, request.Salary, request.HireDate);

        await _employeeRepository.Insert(employee, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> Handle(ChangeEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeDto = await _employeeQuery.GetById(request.Id, cancellationToken);
        if (employeeDto == null)
            return Result.Failure("Funcionário não encontrado");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var employee = new Employee(employeeDto.Id, 
                                    request.Name, 
                                    request.Cpf, 
                                    request.Role, 
                                    request.Salary, 
                                    request.HireDate, 
                                    request.Status) ;

        employee.Update(request.Name, request.Cpf, request.Role, request.Salary, request.HireDate, request.Status);

        await _employeeRepository.Update(employee, cancellationToken);

        return Result.Success();
    }
}