using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Printers
{
    class Printer
    {
        public static void PrintWelcomeMessege()
        {
            Console.WriteLine("Welcome to the Garage Management System!");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add a new vehicle to the garage");
            Console.WriteLine("2. Display license numbers of vehicles in the garage");
            Console.WriteLine("3. Change the status of a vehicle in the garage");
            Console.WriteLine("4. Inflate vehicle wheels to maximum");
            Console.WriteLine("5. Refuel a fuel-powered vehicle");
            Console.WriteLine("6. Charge an electric vehicle");
            Console.WriteLine("7. Display full details of a vehicle");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
        }
        public static string GetVehicleStatus()
        {
            Console.WriteLine("Select the vehicle status to filter by:");
            Console.WriteLine("1. BeingRepaired");
            Console.WriteLine("2. DoneRepairing");
            Console.WriteLine("3. Paid");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return "BeingRepaired";
                case "2":
                    return "DoneRepairing";
                case "3":
                    return "Paid";
                default:
                    throw new ArgumentException("Invalid status choice.");
            }
        }

        public static void PrintLicenseNumbers(List<string> i_licenseNumbers)
        {
            if (i_licenseNumbers.Count == 0)
            {
                Console.WriteLine("No vehicles found with the selected status.");
            }
            else
            {
                int index = 1;
                Console.WriteLine("Vehicles in the garage:");
                foreach (string licenseNumber in i_licenseNumbers)
                {
                    Console.WriteLine($"{index}. {licenseNumber}");
                    index++;
                }
            }
        }

        public static void PrintInvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }

        public static string GetLicenseNumber()
        {
            Console.Write("Enter the license number: ");
            return Console.ReadLine();
        }

        public static void PrintVehicleAlreadyExists()
        {
            Console.WriteLine("The vehicle already exists in the garage. Changing status to 'In Repair'.");
        }

        public static string GetVehicleType()
        {
            Console.WriteLine("Select the vehicle type:");
            Console.WriteLine("1. NormalCar");
            Console.WriteLine("2. ElectricCar");
            Console.WriteLine("3. NormalMotorcycle");
            Console.WriteLine("4. ElectricMotorcycle");
            Console.WriteLine("5. Truck");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        return "NormalCar";
                    case "2":
                        return "ElectricCar";
                    case "3":
                        return "NormalMotorcycle";
                    case "4":
                        return "ElectricMotorcycle";
                    case "5":
                        return "Truck";
                    default:
                        throw new ArgumentException("Invalid vehicle type choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public static bool GetWheelInputOption()
        {
            Console.WriteLine("Do you want to add all wheels at once or one by one?");
            Console.WriteLine("1. Add all wheels at once");
            Console.WriteLine("2. Add wheels one by one");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            return choice == "1";
        }

        public static void AddWheelsOneByOne(Vehicle i_vehicle)
        {
            Console.WriteLine($"Enter details for each wheel (total: {i_vehicle.Wheels.Count}):");

            for (int i = 0; i < i_vehicle.Wheels.Count; i++)
            {
                Console.WriteLine($"Wheel {i + 1}:");

                try
                {
                    float currAirPressure = GetCurrentAirPressureInfo();
                    string manufacturerName = GetManufacturerName();

                    i_vehicle.Wheels[i].CurrAirPressure = currAirPressure;
                    i_vehicle.Wheels[i].ManufacturerName = manufacturerName;
                }
                catch (InvalidAirPressureException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Please enter valid air pressure values.");

                    // Retry entering the wheel details for the current wheel
                    i--;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("Skipping the current wheel.");
                }
            }
        }

        public static string GetModelName()
        {
            Console.Write("Enter the model name: ");
            return Console.ReadLine();
        }

        public static string GetManufacturerName()
        {
            Console.Write("Enter the manufactury name: ");
            return Console.ReadLine();
        }

        public static float GetCurrentAirPressureInfo()
        {
            Console.Write("Current air pressure: ");
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ArgumentException("Invalid air pressure input. Please enter a valid number.", ex);
            }
        }

        public static float GetEnginePowerFromTheUser()
        {
            Console.Write("Current energy (battery hours / fuel amount): ");
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ArgumentException("Invalid energy input. Please enter a valid number.", ex);
            }
        }

        public static string GetOwnerNameFromUser()
        {
            Console.Write("Enter the owner name: ");
            return Console.ReadLine();
        }

        public static string GetOwnerPhoneNumber()
        {
            Console.Write("Enter the owner phone number: ");
            return Console.ReadLine();
        }

        public static void SuccededToChangeStatus()
        {
            Console.Write("Updated Status succeeded ");
        }

        public static eColor GetCarColor()
        {
            Console.WriteLine("Select the car color:");
            Console.WriteLine("1. Yellow");
            Console.WriteLine("2. White");
            Console.WriteLine("3. Red");
            Console.WriteLine("4. Black");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        return eColor.Yellow;
                    case "2":
                        return eColor.White;
                    case "3":
                        return eColor.Red;
                    case "4":
                        return eColor.Black;
                    default:
                        throw new ArgumentException("Invalid color choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static void PrintAllLicenseNumbers(Garage i_garage)
        {
            try
            {
                List<string> licenseNumbers = i_garage.GetLicenseNumbers();
                int index = 1;
                Console.WriteLine($"Existed vehicles in the garage:");

                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine($"{index}.{licenseNumber}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string SelectNewConditionForCar()
        {
            Console.WriteLine("Select the new condition:");
            Console.WriteLine("1. Being repairing");
            Console.WriteLine("2. Done Repairing");
            Console.WriteLine("3. Paid");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        return "BeingRepaired";
                    case "2":
                        return "DoneRepairing";
                    case "3":
                        return "Paid";
                    default:
                        throw new ArgumentException("Invalid condition choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static eNumberOfDoors GetNumberOfDoorsFromUser()
        {
            Console.WriteLine("Select the number of doors:");
            Console.WriteLine("1. Two");
            Console.WriteLine("2. Three");
            Console.WriteLine("3. Four");
            Console.WriteLine("4. Five");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        return eNumberOfDoors.Two;
                    case "2":
                        return eNumberOfDoors.Three;
                    case "3":
                        return eNumberOfDoors.Four;
                    case "4":
                        return eNumberOfDoors.Five;
                    default:
                        throw new ArgumentException("Invalid number of doors choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static eLicenseType GetLicenseType()
        {
            Console.WriteLine("Select the license type:");
            Console.WriteLine("1. A");
            Console.WriteLine("2. A1");
            Console.WriteLine("3. AA");
            Console.WriteLine("4. B1");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        return eLicenseType.A;
                    case "2":
                        return eLicenseType.A1;
                    case "3":
                        return eLicenseType.AA;
                    case "4":
                        return eLicenseType.B1;
                    default:
                        throw new ArgumentException("Invalid license type choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static int GetEngineCapacity()
        {
            Console.Write("Enter the engine capacity: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ArgumentException("Invalid engine capacity input. Please enter a valid number.", ex);
            }
        }

        public static bool GetTransportHazardousMaterials()
        {
            Console.Write("Does the truck transport hazardous materials? (true/false): ");
            try
            {
                return bool.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ArgumentException("Invalid input for hazardous materials. Please enter true or false.", ex);
            }
        }

        public static float GetCargoCapacity()
        {
            Console.Write("Enter the cargo capacity: ");
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ArgumentException("Invalid cargo capacity input. Please enter a valid number.", ex);
            }
        }

        public static void PrintVehicleAdded()
        {
            Console.WriteLine("Vehicle added to the garage successfully.");
        }

        public static void ChangeVehicleCondition(Garage i_garage)
        {
            Console.WriteLine("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = i_garage.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    throw new ArgumentException($"No vehicle found with license number: {licenseNumber}", "licenseNumber");
                }
                Console.WriteLine("Enter new condition status (e.g., BeingRepaired, DoneRepairing, Paid):");
                string newConditionInput = Console.ReadLine();
                eVehicleCondition newCondition;
                if (!IsValidVehicleCondition(newConditionInput, out newCondition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered. Please enter a valid condition.");
                }
                vehicle.VehicleCondition = newCondition;
                Console.WriteLine("Successfully updated vehicle condition.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool IsValidVehicleCondition(string i_newConditionInput, out eVehicleCondition i_newCondition)
        {
            foreach (eVehicleCondition ft in Enum.GetValues(typeof(eVehicleCondition)))
            {
                if (ft.ToString().Equals(i_newConditionInput, StringComparison.OrdinalIgnoreCase))
                {
                    i_newCondition = ft;
                    return true;
                }
            }

            i_newCondition = default(eVehicleCondition);
            return false;
        }

        public static void InflateAllWheelsToMax(Garage i_garage)
        {
            Console.WriteLine("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = i_garage.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    throw new ArgumentException($"No vehicle found with license number: {licenseNumber}", "licenseNumber");
                }
                vehicle.FillAllWheelsAirPressureToMax();
                Console.WriteLine("Successfully inflated all wheels to maximum air pressure.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ChargingRegularVehicle(Garage i_garage)
        {
            Console.WriteLine("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = i_garage.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    throw new ArgumentException($"No vehicle found with license number: {licenseNumber}", "licenseNumber");
                }

                if (vehicle.Engine.GetType().Name == "Battery")
                {
                    throw new ArgumentException("The selected vehicle is not charged by Fuel");
                }

                Console.WriteLine("Enter the fuel type you would like to fill (e.g., Soler, Octan95, Octan96, Octan98):");
                string fuelTypeInput = Console.ReadLine();

                eFuelType fuelType;
                if (!IsValidFuelType(fuelTypeInput, out fuelType))
                {
                    throw new ArgumentException("Invalid fuel type entered. Please enter a valid fuel type.");
                }

                Console.WriteLine("Enter the amount of fuel you would like to fill:");

                try
                {
                    float fuelToFill = float.Parse(Console.ReadLine());
                    vehicle.Engine.ChargeEnergy(fuelType, fuelToFill);
                    Console.WriteLine($"Charging vehicle with {fuelToFill} liters of {fuelType}.");
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Invalid input. Please enter a valid number of liters.", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool IsValidFuelType(string i_fuelTypeInput, out eFuelType i_fuelType)
        {
            foreach (eFuelType ft in Enum.GetValues(typeof(eFuelType)))
            {
                if (ft.ToString().Equals(i_fuelTypeInput, StringComparison.OrdinalIgnoreCase))
                {
                    i_fuelType = ft;
                    return true;
                }
            }

            i_fuelType = default(eFuelType);
            return false;
        }

        public static void ChargingElectricVehicle(Garage i_garage)
        {
            Console.WriteLine("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = i_garage.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    throw new ArgumentException($"No vehicle found with license number: {licenseNumber}", nameof(licenseNumber));
                }
                if (vehicle.Engine.GetType().Name != "Battery")
                {
                    throw new ArgumentException($"The selected vehicle is not charged by electricity");
                }
                Console.WriteLine("Enter the amount of minutes you would like to charge the vehicle:");

                try
                {
                    int minutesToCharge = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Charging vehicle for {minutesToCharge} minutes.");
                    vehicle.Engine.ChargeEnergy(eFuelType.Electricity, (minutesToCharge / 60f));
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Invalid input. Please enter a valid number of minutes.", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintVehicleDetails(Garage i_garage)
        {
            Console.WriteLine("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();
            Vehicle vehicle = null;

            try
            {
                vehicle = i_garage.GetVehicle(licenseNumber);
                if (vehicle == null)
                {
                    throw new VehicleNotFoundException("Vehicle not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

            string vehicleType = string.Empty;
            GetTypeOfVehicle(vehicle, ref vehicleType);
            Console.WriteLine($"Vehicle type: {vehicleType}");
            Console.WriteLine($"Vehicle's license number: {licenseNumber}");
            Console.WriteLine($"Model name: {vehicle.ModelName}");
            Console.WriteLine($"Owner name: {vehicle.OwnerName}");
            Console.WriteLine($"Owner phone number: {vehicle.OwnerPhoneNumber}");
            Console.WriteLine($"Current vehicle condition: {vehicle.VehicleCondition}");
            Console.WriteLine("Vehicle's wheels' details:");
            PrintWheelsDetails(vehicle);
            Console.WriteLine($"Current energy: {vehicle.Engine.CurrEnergy}");
            Console.WriteLine($"Vehicle max energy: {vehicle.Engine.MaxEnergy}");

            try
            {
                switch (vehicleType)
                {
                    case "Regular car":
                        PrintNormalCarDetails((NormalCar)vehicle);
                        break;
                    case "Electric car":
                        PrintElectricCarDetails((ElectricCar)vehicle);
                        break;
                    case "Regular motorcycle":
                        PrintNormalMotorcycleDetails((NormalMotorcycle)vehicle);
                        break;
                    case "Electric motorcycle":
                        PrintElectricMotorcycleDetails((ElectricMotorcycle)vehicle);
                        break;
                    case "Truck":
                        PrintTruckDetails((Truck)vehicle);
                        break;
                    default:
                        Console.WriteLine("Unknown vehicle type.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintWheelsDetails(Vehicle i_vehicle)
        {
            List<Wheel> wheels = i_vehicle.Wheels;
            Console.WriteLine($"The number of wheels in the vehicle: {wheels.Count}");

            for (int i = 0; i < wheels.Count; i++)
            {
                Console.WriteLine($"Wheel {i + 1}:");
                Console.WriteLine($"  Manufacturer name: {wheels[i].ManufacturerName}");
                Console.WriteLine($"  Current air pressure: {wheels[i].CurrAirPressure}");
                Console.WriteLine($"  Maximum air pressure: {wheels[i].MaxAirPressure}");
            }
        }

        public static void PrintNormalCarDetails(NormalCar i_normalCar)
        {
            try
            {
                Console.WriteLine($"Fuel type: {((Fuel)i_normalCar.Engine).FuelType.ToString()}");
                Console.WriteLine($"The color of the car: {i_normalCar.Color}");
                Console.WriteLine($"Number of doors: {i_normalCar.NumberOfDoors}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintElectricCarDetails(ElectricCar i_electricCar)
        {
            try
            {
                Console.WriteLine($"The color of the car: {i_electricCar.Color}");
                Console.WriteLine($"Number of doors: {i_electricCar.NumberOfDoors}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintNormalMotorcycleDetails(NormalMotorcycle i_normalMotorcycle)
        {
            try
            {
                Console.WriteLine($"Fuel type: {((Fuel)i_normalMotorcycle.Engine).FuelType.ToString()}");
                Console.WriteLine($"License type: {i_normalMotorcycle.LicenseType.ToString()}");
                Console.WriteLine($"Engine capacity: {i_normalMotorcycle.EngineCapacity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintElectricMotorcycleDetails(ElectricMotorcycle i_electricMotorcycle)
        {
            try
            {
                Console.WriteLine($"License type: {i_electricMotorcycle.LicenseType.ToString()}");
                Console.WriteLine($"Engine capacity: {i_electricMotorcycle.EngineCapacity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void PrintTruckDetails(Truck i_truck)
        {
            try
            {
                Console.WriteLine($"Fuel type: {((Fuel)i_truck.Engine).FuelType.ToString()}");
                Console.WriteLine($"Is the truck transporting hazardous materials: {(i_truck.TransportHazardousMaterials ? "Yes" : "No")}");
                Console.WriteLine($"Cargo capacity: {i_truck.CargoCapacity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void GetTypeOfVehicle(Vehicle i_vehicle, ref string io_result)
        {
            try
            {
                string type = i_vehicle.GetType().Name;
                switch (type)
                {
                    case "NormalCar":
                        io_result = "Regular car";
                        break;
                    case "ElectricCar":
                        io_result = "Electric car";
                        break;
                    case "NormalMotorcycle":
                        io_result = "Regular motorcycle";
                        break;
                    case "ElectricMotorcycle":
                        io_result = "Electric motorcycle";
                        break;
                    case "Truck":
                        io_result = "Truck";
                        break;
                    default:
                        io_result = "Unknown vehicle type";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
