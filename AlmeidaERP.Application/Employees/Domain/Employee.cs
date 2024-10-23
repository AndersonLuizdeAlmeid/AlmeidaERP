namespace AlmeidaERP.Application.Employees.Domain;
public class Employee
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public short Role { get; private set; }
    public decimal Salary { get; private set; } 
    public DateTime HireDate { get; private set; }
    public short Status { get; private set; }

    public Employee(long id, string name, string cpf, short role, decimal salary, DateTime hireDate, short status)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        Role = role;
        Salary = salary;
        HireDate = hireDate;
        Status = status;
    }

    public static Employee Create(string name, string cpf, short role, decimal salary, DateTime hireDate) =>
        new(0, name, cpf, role, salary, hireDate, 1);

    public void Update(string name, string cpf, short role, decimal salary, DateTime hireDate, short status)
    {
        Name = name;
        Cpf = cpf; 
        Role = role; 
        Salary = salary; 
        HireDate = hireDate; 
        Status = status;
    }
}
