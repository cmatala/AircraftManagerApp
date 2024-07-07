using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;




namespace AircraftNamespace
{
    public class Fleet
    {
        // Instance variables
        private Aircraft[] aircrafts;
        private int count;


        // Constructor
        public Fleet( int size = 5)
        {   
            aircrafts = new Aircraft[size];
            count = 0;
        }


        // Method to add an aircraft to the fleet
         public void AddAircraft(Aircraft aircraft)
        {
            if (count >= aircrafts.Length)
            {
                throw new InvalidOperationException("Fleet is full");
            }

            // Check if the aircraft is already in the fleet
            for (int i = 0; i < count; i++)
            {
                if (aircrafts[i].RegNumber.Equals(aircraft.RegNumber, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Aircraft is already in the fleet");
                }
            }

            // Add the aircraft to the fleet
            aircrafts[count] = aircraft;
            count++;
        }

        public void readFile(string fileName)
        {
            try
            {
                using (StreamReader input = new StreamReader(fileName))
                {
                    while (!input.EndOfStream)
                    {
                        string[] parts = input.ReadLine().Split(' ');
                        string aircraftName = parts[0];
                        string regNumber = parts[1];
                        string manufacturer = input.ReadLine();
                        double maxRange = double.Parse(input.ReadLine());
                        int crewSize = int.Parse(input.ReadLine());
                        int yearPutInService = int.Parse(input.ReadLine());
                        double maxServiceWeight = double.Parse(input.ReadLine());
                        int numPassengers = int.Parse(input.ReadLine());
                        double currentAirMiles = double.Parse(input.ReadLine());
                        string lastMaintenanceDate = input.ReadLine();
                        double lastMaintenanceMiles = double.Parse(input.ReadLine());


                         // Create an Aircraft object
                        Aircraft aircraft = new Aircraft(aircraftName, regNumber, manufacturer, maxRange, crewSize, yearPutInService, maxServiceWeight, numPassengers, currentAirMiles, lastMaintenanceDate, lastMaintenanceMiles);

                        // Add the aircraft to the collection
                        AddAircraft(aircraft);
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"File not found: {fnfe.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Data format error: {fe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


         // Method to sort the aircraft array by registration number
        public Aircraft[] SortArray()
        {
            // Create a copy of the aircraft array to avoid modifying the original array
            Aircraft[] sortedArray = new Aircraft[count];
            Array.Copy(aircrafts, sortedArray, count);

            // Sort the array using a custom comparer based on RegNumber
            Array.Sort(sortedArray, (a, b) => string.Compare(a.RegNumber, b.RegNumber, StringComparison.OrdinalIgnoreCase));

            return sortedArray;
        }

        // Method to write the contents of the fleet to a file
        public void WriteFile(string fileName)
        {
            // Get the sorted array
            Aircraft[] sortedArray = SortArray();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Write each aircraft's information to the file
                    foreach (var aircraft in sortedArray)
                    {
                        writer.WriteLine($"{aircraft.AircraftName}");
                        writer.WriteLine($"{aircraft.RegNumber}");
                        writer.WriteLine($"{aircraft.Manufacturer}");
                        writer.WriteLine($"{aircraft.MaxRange}");
                        writer.WriteLine($"{aircraft.CrewSize}");
                        writer.WriteLine($"{aircraft.MaxServiceWeight}");
                        writer.WriteLine($"{aircraft.NumPassengers}");
                        writer.WriteLine($"{aircraft.CurrentAirMiles}");
                        writer.WriteLine($"{aircraft.LastMaintenanceDate}");
                        writer.WriteLine($"{aircraft.LastMaintenanceMiles}");
                        writer.WriteLine(); // Blank line for separation
                    }
                    Console.WriteLine($"File '{fileName}' writing completed.");
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Error writing to file '{fileName}': {e.Message}");
            }
        }

        public string PrintFleetCount()
        {
            
            string result = $"Number of Aircraft in Fleet: {count}\n";
            return result;
            
        }

        // Method to display the fleet
    
        
        public string DisplayFleet()
        {   

            string fleetCount = PrintFleetCount(); // Get the fleet count

            if (count == 0)
            {
                return "No aircraft in the fleet.";
            }

             // Start with the title
            string result = "CURRENT FLEET COMPOSITION\n";

            // Add the header
            string header = string.Format("{0,-10}{1,-10}{2,-15}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-15}{9,-15}{10,-15}", 
                "Name", "Reg", "Manuf", "Range", "Crew", "YIS", "TOWeight", "Pass", "CMiles", "LMDate", "LMMiles");
            result += header + "\n";

            for (int i = 0; i < count; i++)
            {
                result += aircrafts[i].ToString() + "\n";
            }

            result += fleetCount; // Append the fleet count to the result
            return result;    
            
        }

        // Method to remove an aircraft from the fleet by registration number
        public void RemoveAircraft(string regNumber)
        {
             // Find the index of the aircraft with the given registration number
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (aircrafts[i].RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            // If the aircraft is not found, throw an exception
            if (index == -1)
            {
                throw new InvalidOperationException("Aircraft not found in the fleet");
            }

            // Shift all subsequent elements one position to the left
            for (int i = index; i < count - 1; i++)
            {
                aircrafts[i] = aircrafts[i + 1];
            }

            // Nullify the last element and decrement the count
            aircrafts[count - 1] = null;
            count--;
        }
        
         
        

    }



    
}