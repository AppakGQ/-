using System;

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Car : IVehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string FuelType { get; set; }

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public void Drive()
    {
        Console.WriteLine($"Driving a {Brand} {Model} on {FuelType} fuel.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Refueling the {Brand} {Model}.");
    }
}

public class Motorcycle : IVehicle
{
    public string Type { get; set; }
    public double EngineCapacity { get; set; }

    public Motorcycle(string type, double engineCapacity)
    {
        Type = type;
        EngineCapacity = engineCapacity;
    }

    public void Drive()
    {
        Console.WriteLine($"Riding a {Type} motorcycle with {EngineCapacity}L engine.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Refueling the {Type} motorcycle.");
    }
}

public class Truck : IVehicle
{
    public double PayloadCapacity { get; set; }
    public int Axles { get; set; }

    public Truck(double payloadCapacity, int axles)
    {
        PayloadCapacity = payloadCapacity;
        Axles = axles;
    }

    public void Drive()
    {
        Console.WriteLine($"Driving a truck with {PayloadCapacity} tons capacity and {Axles} axles.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Refueling the truck.");
    }
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    private readonly string _brand;
    private readonly string _model;
    private readonly string _fuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        _brand = brand;
        _model = model;
        _fuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(_brand, _model, _fuelType);
    }
}

public class MotorcycleFactory : VehicleFactory
{
    private readonly string _type;
    private readonly double _engineCapacity;

    public MotorcycleFactory(string type, double engineCapacity)
    {
        _type = type;
        _engineCapacity = engineCapacity;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(_type, _engineCapacity);
    }
}

public class TruckFactory : VehicleFactory
{
    private readonly double _payloadCapacity;
    private readonly int _axles;

    public TruckFactory(double payloadCapacity, int axles)
    {
        _payloadCapacity = payloadCapacity;
        _axles = axles;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(_payloadCapacity, _axles);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Грузовик");
        int choice = int.Parse(Console.ReadLine());

        VehicleFactory factory = null;

        switch (choice)
        {
            case 1:
                Console.Write("Введите марку автомобиля: ");
                string brand = Console.ReadLine();
                Console.Write("Введите модель автомобиля: ");
                string model = Console.ReadLine();
                Console.Write("Введите тип топлива: ");
                string fuelType = Console.ReadLine();
                factory = new CarFactory(brand, model, fuelType);
                break;
            case 2:
                Console.Write("Введите тип мотоцикла: ");
                string type = Console.ReadLine();
                Console.Write("Введите объем двигателя (литры): ");
                double engineCapacity = double.Parse(Console.ReadLine());
                factory = new MotorcycleFactory(type, engineCapacity);
                break;
            case 3:
                Console.Write("Введите грузоподъемность (тонн): ");
                double payloadCapacity = double.Parse(Console.ReadLine());
                Console.Write("Введите количество осей: ");
                int axles = int.Parse(Console.ReadLine());
                factory = new TruckFactory(payloadCapacity, axles);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        IVehicle vehicle = factory.CreateVehicle();
        vehicle.Drive();
        vehicle.Refuel();
    }
}
