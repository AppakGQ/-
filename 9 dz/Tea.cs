using System;

public abstract class Beverage
{
    public abstract string Description { get; }
    public abstract double Cost();
}

public class Espresso : Beverage
{
    public override string Description => "Espresso";
    public override double Cost() => 1.5;
}

public class Tea : Beverage
{
    public override string Description => "Tea";
    public override double Cost() => 1.0;
}

public class Latte : Beverage
{
    public override string Description => "Latte";
    public override double Cost() => 2.0;
}

public class Mocha : Beverage
{
    public override string Description => "Mocha";
    public override double Cost() => 2.5;
}

public abstract class BeverageDecorator : Beverage
{
    protected Beverage _beverage;
    public BeverageDecorator(Beverage beverage)
    {
        _beverage = beverage;
    }
    public override string Description => _beverage.Description;
    public override double Cost() => _beverage.Cost();
}

public class Milk : BeverageDecorator
{
    public Milk(Beverage beverage) : base(beverage) { }
    public override string Description => _beverage.Description + ", Milk";
    public override double Cost() => _beverage.Cost() + 0.3;
}

public class Sugar : BeverageDecorator
{
    public Sugar(Beverage beverage) : base(beverage) { }
    public override string Description => _beverage.Description + ", Sugar";
    public override double Cost() => _beverage.Cost() + 0.2;
}

public class WhippedCream : BeverageDecorator
{
    public WhippedCream(Beverage beverage) : base(beverage) { }
    public override string Description => _beverage.Description + ", Whipped Cream";
    public override double Cost() => _beverage.Cost() + 0.5;
}

public class Vanilla : BeverageDecorator
{
    public Vanilla(Beverage beverage) : base(beverage) { }
    public override string Description => _beverage.Description + ", Vanilla";
    public override double Cost() => _beverage.Cost() + 0.4;
}

class Program
{
    static void Main()
    {
        Beverage beverage = new Espresso();
        beverage = new Milk(beverage);
        beverage = new Sugar(beverage);
        beverage = new WhippedCream(beverage);

        Console.WriteLine($"Description: {beverage.Description}");
        Console.WriteLine($"Cost: {beverage.Cost():C2}");

        Beverage tea = new Tea();
        tea = new Vanilla(tea);
        tea = new Milk(tea);

        Console.WriteLine($"Description: {tea.Description}");
        Console.WriteLine($"Cost: {tea.Cost():C2}");
    }
}

