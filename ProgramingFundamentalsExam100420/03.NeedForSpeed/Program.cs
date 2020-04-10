using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeed
{
    class Program
    {
        class Car
        {
            private const int MaxFuel = 75;

            public Car()
            {
            }

            public Car(string name, int mileage, int fuel) : this()
            {
                Name = name;
                Mileage = mileage;
                Fuel = fuel;
            }

            public string Name { get; }
            public int Mileage { get; private set; }
            public int Fuel { get; private set; }

            public bool IsOld { get; private set; }

            internal void Drive(int distanceToDrive, int fuelNeeded)
            {
                //check
                if (this.Fuel < fuelNeeded)
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }
                else
                {
                    this.Mileage += distanceToDrive;
                    this.Fuel -= fuelNeeded;
                    Console.WriteLine($"{this.Name} driven for {distanceToDrive} kilometers. {fuelNeeded} liters of fuel consumed.");

                    if (this.Mileage >= 100000)
                    {
                        this.IsOld = true;
                        Console.WriteLine($"Time to sell the {this.Name}!");
                    }
                }
            }

            internal void Refuel(int fuelToAdd)
            {
                var currentFuel = this.Fuel;
                var difference = 0;

                if ((currentFuel + fuelToAdd) > MaxFuel)
                {
                    difference = MaxFuel - this.Fuel;
                    this.Fuel = MaxFuel;
                }
                else
                {
                    this.Fuel += fuelToAdd;
                    difference = fuelToAdd;
                }

                Console.WriteLine($"{this.Name} refueled with {difference} liters");
            }

            internal void Revert(int kilometers)
            {
                var currentMileage = this.Mileage;
                var estimatedMileage = currentMileage - kilometers;
                // check
                if (this.Mileage >= 10000 && estimatedMileage >= 10000)
                {
                    this.Mileage -= kilometers;

                    Console.WriteLine($"{this.Name} mileage decreased by {kilometers} kilometers");
                }
                else
                {
                    this.Mileage = 10000;
                }
            }
        }

        static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());

            var car = new Car();

            var listCars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var args = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                var carName = args[0];
                var mileage = int.Parse(args[1]);
                var fuel = int.Parse(args[2]);

                car = new Car(carName, mileage, fuel);

                listCars.Add(car);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                var commandArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];

                Car carToDrive = null;

                switch (command)
                {
                    case "Drive":
                        var carName = commandArgs[1];
                        var distance = int.Parse(commandArgs[2]);
                        var fuel = int.Parse(commandArgs[3]);

                        carToDrive = listCars.First(c => c.Name == carName);

                        carToDrive.Drive(distance, fuel);

                        if (carToDrive.IsOld)
                        {
                            listCars.Remove(carToDrive);
                        }
                        break;
                    case "Refuel":
                        var fuelToRecharge = int.Parse(commandArgs[2]);

                        carToDrive = listCars.First(c => c.Name == commandArgs[1]);
                        carToDrive.Refuel(fuelToRecharge);
                        break;
                    case "Revert":
                        var kilometers = int.Parse(commandArgs[2]);

                        carToDrive = listCars.First(c => c.Name == commandArgs[1]);
                        carToDrive.Revert(kilometers);
                        break;
                }

            }

            var sortedCars = listCars.OrderByDescending(c => c.Mileage)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var vehicle in sortedCars)
            {
                Console.WriteLine($"{vehicle.Name} -> Mileage: {vehicle.Mileage} kms, Fuel in the tank: {vehicle.Fuel} lt.");
            }
        }
    }
}
