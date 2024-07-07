using System;
using System.Globalization;

namespace AircraftNamespace
{
    public class Aircraft
    {
        // Instance variables
        public string AircraftName { get; set; } = string.Empty;
        public string RegNumber { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public double MaxRange { get; set; } // in kilometers or miles
        public int CrewSize { get; set; }
        public int YearPutInService { get; set; }
        public double MaxServiceWeight { get; set; } // in kilograms or pounds
        public int NumPassengers { get; set; }
        public double CurrentAirMiles { get; set; } // in kilometers or miles
        public string LastMaintenanceDate { get; set; } = string.Empty;
        public double LastMaintenanceMiles { get; set; } // in kilometers or miles


         // Default constructor
        public Aircraft()
        {
        }

         // Constructor with all instance variables
        public Aircraft(string aircraftName, string regNumber, string manufacturer, double maxRange, int crewSize, int yearPutInService, double maxServiceWeight, int numPassengers, double currentAirMiles, string lastMaintenanceDate, double lastMaintenanceMiles)
        {
            AircraftName = aircraftName;
            RegNumber = regNumber;
            Manufacturer = manufacturer;
            MaxRange = maxRange;
            CrewSize = crewSize;
            YearPutInService = yearPutInService;
            MaxServiceWeight = maxServiceWeight;
            NumPassengers = numPassengers;
            CurrentAirMiles = currentAirMiles;
            LastMaintenanceDate = lastMaintenanceDate;
            LastMaintenanceMiles = lastMaintenanceMiles;
        }


        // Method to check if maintenance is needed
        public bool NeedsMaintenance()
        {
            // Check last maintenance date
            DateTime lastMaintenanceDate = DateTime.ParseExact(LastMaintenanceDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            TimeSpan timeSinceLastMaintenance = DateTime.Now - lastMaintenanceDate;
            bool isDateThresholdMet = timeSinceLastMaintenance.TotalDays >= 90; // 3 months

            // Check last maintenance mileage
            bool isMileageThresholdMet = CurrentAirMiles - LastMaintenanceMiles >= 150000;

            // Aircraft needs maintenance if either condition is met
            return isDateThresholdMet || isMileageThresholdMet;
        }  

        // Method to check if the aircraft should retire
        public bool ShouldRetire()
        {
            int currentYear = DateTime.Now.Year;
            bool isOldEnough = (currentYear - YearPutInService) > 20;
            bool hasFlownEnough = CurrentAirMiles > 2000000;

            return isOldEnough || hasFlownEnough;
        } 

        // tostring Method 
        public override string ToString()
        {
            //return $"{AircraftName} {RegNumber} {Manufacturer} {MaxRange} {CrewSize} {YearPutInService} {MaxServiceWeight} {NumPassengers} {CurrentAirMiles} {LastMaintenanceDate} {LastMaintenanceMiles}";
            string details = string.Format("{0,-10}{1,-10}{2,-15}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-15}{9,-15}{10,-15}",
                                           AircraftName, RegNumber, Manufacturer, MaxRange, CrewSize, YearPutInService, MaxServiceWeight, NumPassengers, CurrentAirMiles, LastMaintenanceDate, LastMaintenanceMiles);
            return $"{details}";                                      
        } 




    }




}