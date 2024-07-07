using System;
using AircraftNamespace;

class Program
{
    static void Main(string[] args)
    {
       // Create a fleet with a capacit
        Fleet fleet = new Fleet(15);

        // Create some aircraft
        Aircraft aircraft1 = new Aircraft("Boeing-747", "ABC123", "Boeing", 14815, 10, 1990, 183500, 416, 1200000, "01/15/2024", 1100000);
        Aircraft aircraft2 = new Aircraft("Airbus-A320", "XYZ456", "Airbus", 6150, 6, 2000, 73500, 180, 850000, "02/20/2024", 800000);
        Aircraft aircraft3 = new Aircraft("Concorde", "CON789", "Aerospatiale/BAC", 7240, 9, 1976, 187000, 100, 700000, "03/25/2024", 600000);

        // Add the first aircraft
        fleet.AddAircraft(aircraft1);
        fleet.AddAircraft(aircraft2);
        fleet.AddAircraft(aircraft3);
        // File path to the sample data
        string fileName = "deltafleet.txt";

        // Call the WriteFile method
        //fleet.WriteFile(fileName);

        // Read aircraft data from the file
        fleet.readFile(fileName);

        // Display the fleet before removal
        Console.WriteLine("Fleet before removal:");
        Console.WriteLine(fleet.DisplayFleet());

        // Remove an aircraft by registration number
        fleet.RemoveAircraft("CON789");

        // Display the fleet after removal
        Console.WriteLine("\nFleet after removal:");
        Console.WriteLine(fleet.DisplayFleet());
        

        

        
        
    }
}


