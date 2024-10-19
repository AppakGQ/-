using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public Vehicle(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public void StartEngine() => Console.WriteLine($"{Brand} {Model} завёл двигатель.");
    public void StopEngine() => Console.WriteLine($"{Brand} {Model} остановил двигатель.");
}

public class Car : Vehicle
{
    public Car(string brand, string model) : base(brand, model) { }
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string brand, string model) : base(brand, model) { }
}

public class Garage
{
    public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle) => Vehicles.Add(vehicle);
    public void RemoveVehicle(Vehicle vehicle) => Vehicles.Remove(vehicle);
}

public class Fleet
{
    public List<Garage> Garages { get; private set; } = new List<Garage>();

    public void AddGarage(Garage garage) => Garages.Add(garage);
}

public class Program
{
    public static void Main()
    {
        Car car = new Car("Toyota", "Camry");
        Motorcycle moto = new Motorcycle("Yamaha", "R1");

        Garage garage = new Garage();
        garage.AddVehicle(car);
        garage.AddVehicle(moto);

        Fleet fleet = new Fleet();
        fleet.AddGarage(garage);

        car.StartEngine();
        moto.StartEngine();
        car.StopEngine();
        moto.StopEngine();

        garage.RemoveVehicle(car);
        Console.WriteLine("Автомобиль удален.");
    }