namespace AlmeidaERP.Application.Employees.Dtos;
public class EmployeeDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Role { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public short Status { get; set; }
}