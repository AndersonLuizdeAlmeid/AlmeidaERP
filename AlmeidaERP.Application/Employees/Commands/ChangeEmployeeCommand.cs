using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace AlmeidaERP.Application.Employees.Commands;
public class ChangeEmployeeCommand : IRequest<Result>, IEmployeeCommand
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Role { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public short Status { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do funcionário não pode ser nulo.");
        if (Name.IsNullOrEmpty())
            return Result.Failure("Nome do funcionário não pode ser nulo.");
        if (Cpf.IsNullOrEmpty())
            return Result.Failure("CPF do funcionário não pode ser nulo.");
        if (Role.ToString().IsNullOrEmpty())
            return Result.Failure("Cargo do funcionário não pode ser nulo.");
        if (Salary.ToString().IsNullOrEmpty())
            return Result.Failure("Salário do funcionário não pode ser nulo.");
        if (HireDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de admissão do funcionário não pode ser nulo.");
        if (Status.ToString().IsNullOrEmpty())
            return Result.Failure("Status do funcionário não pode ser nulo.");

        return Result.Success();
    }
}