using System;

public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

public class PermanentEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.2;
    }
}

public class ContractEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.1;
    }
}

public class InternEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.8;
    }
}

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public string EmployeeType { get; set; }

    public Employee(string name, double baseSalary, string employeeType)
    {
        Name = name;
        BaseSalary = baseSalary;
        EmployeeType = employeeType;
    }
}

public class EmployeeSalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        ISalaryCalculator salaryCalculator;

        switch (employee.EmployeeType)
        {
            case "Permanent":
                salaryCalculator = new PermanentEmployeeSalaryCalculator();
                break;
            case "Contract":
                salaryCalculator = new ContractEmployeeSalaryCalculator();
                break;
            case "Intern":
                salaryCalculator = new InternEmployeeSalaryCalculator();
                break;
            default:
                throw new NotSupportedException("Employee type not supported");
        }

        return salaryCalculator.CalculateSalary(employee);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Employee permanentEmployee = new Employee("John Doe", 3000, "Permanent");
        Employee contractEmployee = new Employee("Jane Smith", 2000, "Contract");
        Employee internEmployee = new Employee("Alice Johnson", 1000, "Intern");

        EmployeeSalaryCalculator salaryCalculator = new EmployeeSalaryCalculator();

        Console.WriteLine($"{permanentEmployee.Name} Salary: {salaryCalculator.CalculateSalary(permanentEmployee)}");
        Console.WriteLine($"{contractEmployee.Name} Salary: {salaryCalculator.CalculateSalary(contractEmployee)}");
        Console.WriteLine($"{internEmployee.Name} Salary: {salaryCalculator.CalculateSalary(internEmployee)}");
    }
}
