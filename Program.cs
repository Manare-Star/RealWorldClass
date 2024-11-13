// This interactive console program simulates the experience of owning and driving a Mercedes-AMG GT. Users can interact with the car's features, change driving modes, track fuel levels, and engage in various driving scenarios. The program incorporates real-world elements such as fuel consumption, driving mode selection (Comfort, Sport, Race), and random events during a drive, which adds unpredictability and excitement to the simulation.

using System;

public class MercedesAMG
{
    // Private members
    private string model;
    private int horsepower;
    private double topSpeed;
    private double fuelLevel;
    private string drivingMode;

    // Public variables
    public string Color { get; set; }
    public double Price { get; set; }

    // Constructor
    public MercedesAMG(string model, int horsepower, double topSpeed, string color, double price)
    {
        this.model = model;
        this.horsepower = horsepower;
        this.topSpeed = topSpeed;
        this.fuelLevel = 100.0; // Default fuel level as percentage
        this.drivingMode = "Comfort"; // Default driving mode
        this.Color = color;
        this.Price = price;
    }

    // Public method to display the car details
    public void DisplayDetails()
    {
        Console.WriteLine($"\n--- Mercedes-AMG {model} Details ---");
        Console.WriteLine($"Horsepower: {horsepower} HP");
        Console.WriteLine($"Top Speed: {topSpeed} km/h");
        Console.WriteLine($"Fuel Level: {fuelLevel}%");
        Console.WriteLine($"Driving Mode: {drivingMode}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Price: R{Price:N2}");
    }

    // Method to change the driving mode
    public void ChangeDrivingMode()
    {
        Console.WriteLine("\nChoose a Driving Mode: Comfort, Sport, Race");
        string newMode = Console.ReadLine();
        if (newMode == "Sport" || newMode == "Comfort" || newMode == "Race")
        {
            drivingMode = newMode;
            Console.WriteLine($"Driving mode changed to: {newMode}");
        }
        else
        {
            Console.WriteLine("Invalid driving mode. Defaulting to Comfort.");
            drivingMode = "Comfort";
        }
    }

    // Method to simulate driving with user input
    public void Drive()
    {
        Console.WriteLine("\nEnter distance to drive (km):");
        if (double.TryParse(Console.ReadLine(), out double distance))
        {
            double fuelConsumptionRate = GetFuelConsumptionRate();
            double fuelConsumed = distance * fuelConsumptionRate;

            if (fuelLevel > fuelConsumed)
            {
                fuelLevel -= fuelConsumed;
                Console.WriteLine($"You drove {distance} km in {drivingMode} mode. Fuel consumed: {fuelConsumed:F2}%.");
                Console.WriteLine($"Remaining fuel level: {fuelLevel:F2}%.");

                // Random event
                TriggerRandomEvent();
            }
            else
            {
                Console.WriteLine("Not enough fuel to complete the drive. Please refuel.");
            }
        }
        else
        {
            Console.WriteLine("Invalid distance input. Please try again.");
        }
    }

    // Method to refuel the car
    public void Refuel()
    {
        fuelLevel = 100.0;
        Console.WriteLine("The car has been refueled to 100%.");
    }

    // Method to get fuel consumption rate based on driving mode
    private double GetFuelConsumptionRate()
    {
        return drivingMode switch
        {
            "Comfort" => 0.5,
            "Sport" => 0.8,
            "Race" => 1.2,
            _ => 0.5,
        };
    }

    // Random event simulation
    private void TriggerRandomEvent()
    {
        Random random = new Random();
        int eventChance = random.Next(1, 4); // Randomly pick an event

        switch (eventChance)
        {
            case 1:
                Console.WriteLine("Event: You hit a speed bump! Slowing down...");
                break;
            case 2:
                Console.WriteLine("Event: You found a clear highway stretch and pushed the speed to max!");
                break;
            case 3:
                Console.WriteLine("Event: Heavy traffic ahead. Reducing speed...");
                break;
            default:
                Console.WriteLine("Smooth drive with no surprises.");
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of MercedesAMG
        MercedesAMG amgCar = new MercedesAMG("AMG GT", 523, 310, "Black", 25000000);

        // User engagement loop
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Mercedes-AMG Interactive Menu ---");
            Console.WriteLine("1. Display Car Details");
            Console.WriteLine("2. Change Driving Mode");
            Console.WriteLine("3. Drive");
            Console.WriteLine("4. Refuel");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    amgCar.DisplayDetails();
                    break;
                case "2":
                    amgCar.ChangeDrivingMode();
                    break;
                case "3":
                    amgCar.Drive();
                    break;
                case "4":
                    amgCar.Refuel();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting the interactive menu. Drive safely!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
