using System;

public abstract class ToolVehicle
{
    public static int TotalVehicles { get; private set; }
    public static int TotalTaxPayingVehicles { get; set; }
    public static int TotalNonTaxPayingVehicles { get; private set; }
    public static decimal TotalTaxCollected { get; set; }

    public int VehicleID { get; }
    public string RegNo { get; }
    public string Model { get; }
    public string Brand { get; }
    public decimal BasePrice { get; }
    public string VehicleType { get; }

    public ToolVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice, string vehicleType)
    {
        VehicleID = vehicleID;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;

        TotalVehicles++;
    }

    public abstract void PayTax();

    public static void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;
    }
}

public class Car : ToolVehicle
{
    public Car(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Car")
    {
    }

    public override void PayTax()
    {
        TotalTaxPayingVehicles++;
        TotalTaxCollected += 2; // Tax amount for cars is $2
    }
}

public class Bike : ToolVehicle
{
    public Bike(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Bike")
    {
    }

    public override void PayTax()
    {
        TotalTaxPayingVehicles++;
        TotalTaxCollected += 1; // Tax amount for bikes is $1
    }
}

public class HeavyVehicle : ToolVehicle
{
    public HeavyVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Heavy Vehicle")
    {
    }

    public override void PayTax()
    {
        TotalTaxPayingVehicles++;
        TotalTaxCollected += 4; // Tax amount for heavy vehicles is $4
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car(1, "ABC123", "Toyota", "corolla", 20000);
        car1.PayTax();

        Bike bike1 = new Bike(2, "DEF456", "Honda", "Cd70", 3000);
        bike1.PayTax();

        HeavyVehicle heavyVehicle1 = new HeavyVehicle(3, "GHI789", "Volvo", "VNL64T", 80000);
        heavyVehicle1.PayTax();

        ToolVehicle.PassWithoutPaying();

        Console.WriteLine($"Total Vehicles: {ToolVehicle.TotalVehicles}");
        Console.WriteLine($"Total Tax Paying Vehicles: {ToolVehicle.TotalTaxPayingVehicles}");
        Console.WriteLine($"Total Non-Tax Paying Vehicles: {ToolVehicle.TotalNonTaxPayingVehicles}");
        Console.WriteLine($"Total Tax Collected: ${ToolVehicle.TotalTaxCollected}");
    }
}
