using System;
using System.Collections.Generic;

public abstract class OrganizationComponent
{
    public string Name { get; protected set; }
    public abstract void DisplayHierarchy(int depth = 0);
    public abstract decimal GetBudget();
    public abstract int GetEmployeeCount();
    public abstract OrganizationComponent FindEmployee(string name);
}

public class Employee : OrganizationComponent
{
    public string Position { get; private set; }
    public decimal Salary { get; private set; }

    public Employee(string name, string position, decimal salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public override void DisplayHierarchy(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $"{Name} - {Position} (${Salary})");
    }

    public override decimal GetBudget() => Salary;

    public override int GetEmployeeCount() => 1;

    public override OrganizationComponent FindEmployee(string name) => Name == name ? this : null;
}

public class Department : OrganizationComponent
{
    private List<OrganizationComponent> _components = new List<OrganizationComponent>();

    public Department(string name)
    {
        Name = name;
    }

    public void Add(OrganizationComponent component) => _components.Add(component);

    public void Remove(OrganizationComponent component) => _components.Remove(component);

    public override void DisplayHierarchy(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $"Department: {Name}");
        foreach (var component in _components)
            component.DisplayHierarchy(depth + 2);
    }

    public override decimal GetBudget()
    {
        decimal totalBudget = 0;
        foreach (var component in _components)
            totalBudget += component.GetBudget();
        return totalBudget;
    }

    public override int GetEmployeeCount()
    {
        int count = 0;
        foreach (var component in _components)
            count += component.GetEmployeeCount();
        return count;
    }

    public override OrganizationComponent FindEmployee(string name)
    {
        foreach (var component in _components)
        {
            var found = component.FindEmployee(name);
            if (found != null)
                return found;
        }
        return null;
    }
}

public class Contractor : OrganizationComponent
{
    public string Position { get; private set; }
    public decimal FixedPay { get; private set; }

    public Contractor(string name, string position, decimal fixedPay)
    {
        Name = name;
        Position = position;
        FixedPay = fixedPay;
    }

    public override void DisplayHierarchy(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $"{Name} - {Position} (Contractor, Fixed Pay: ${FixedPay})");
    }

    public override decimal GetBudget() => 0;

    public override int GetEmployeeCount() => 1;

    public override OrganizationComponent FindEmployee(string name) => Name == name ? this : null;
}

public class Program
{
    public static void Main()
    {
        var ceo = new Employee("Alice", "CEO", 200000);
        var headSales = new Department("Head of Sales");
        headSales.Add(new Employee("Bob", "Sales Manager", 90000));
        headSales.Add(new Contractor("Charlie", "Sales Consultant", 50000));

        var salesDept = new Department("Sales Department");
        salesDept.Add(new Employee("Dave", "Salesperson", 50000));
        salesDept.Add(new Employee("Eva", "Salesperson", 50000));
        headSales.Add(salesDept);

        var headIT = new Department("Head of IT");
        headIT.Add(new Employee("Frank", "IT Manager", 100000));
        headIT.Add(new Contractor("Grace", "IT Consultant", 60000));

        var company = new Department("Company");
        company.Add(ceo);
        company.Add(headSales);
        company.Add(headIT);

        company.DisplayHierarchy();
        Console.WriteLine("Total Budget: $" + company.GetBudget());
        Console.WriteLine("Total Employees: " + company.GetEmployeeCount());
        var employee = company.FindEmployee("Dave");
        employee?.DisplayHierarchy();
    }
}
