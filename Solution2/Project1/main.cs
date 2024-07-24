using System;
using Ex03.GarageLogic;
using Printers;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    public enum eMenuOptions
    {
        AddVehicle = 1,
        DisplayLicenseNumbers,
        ChangeVehicleStatus,
        InflateWheelsToMax,
        RefuelVehicle,
        ChargeElectricVehicle,
        DisplayVehicleDetails,
        Exit
    }
    class Program
    {


        static void Main(string[] args)
        {
            Garage garage = new Garage();
            bool exit = false;

            Printer.PrintWelcomeMessege();
            while (!exit)
            {
                Printer.PrintMenu();

                if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(eMenuOptions), choice))
                {
                    eMenuOptions operatorChoice = (eMenuOptions)choice;
                    switch (operatorChoice)
                    {
                        case eMenuOptions.AddVehicle:
                            AddVehicleToGarage(garage);
                            break;
                        case eMenuOptions.DisplayLicenseNumbers:
                            DisplayLicenseNumbers(garage);
                            break;
                        case eMenuOptions.ChangeVehicleStatus:
                            ChangeVehicleStatus(garage);
                            break;
                        case eMenuOptions.InflateWheelsToMax:
                            InflateWheelsToMax(garage);
                            break;
                        case eMenuOptions.RefuelVehicle:
                            RefuelVehicle(garage);
                            break;
                        case eMenuOptions.ChargeElectricVehicle:
                            ChargeElectricVehicle(garage);
                            break;
                        case eMenuOptions.DisplayVehicleDetails:
                            DisplayVehicleDetails(garage);
                            break;
                        case eMenuOptions.Exit:
                            exit = true;
                            break;
                        default:
                            Printer.PrintInvalidChoice();
                            break;
                    }
                }
                else
                {
                    Printer.PrintInvalidChoice();
                }

                Console.WriteLine();
            }
        }
        static void AddVehicleToGarage(Garage i_garage)
        {
            try
            {
                string licenseNumber = Printer.GetLicenseNumber();

                if (i_garage.VehicleExists(licenseNumber))
                {
                    Printer.PrintVehicleAlreadyExists();
                    try
                    {
                        i_garage.ChangeVehicleStatus(licenseNumber, "BeingRepaired");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to change vehicle status", ex);
                    }
                }
                else
                {
                    string vehicleType = Printer.GetVehicleType();
                    string modelName = Printer.GetModelName();
                    float currEnergy = Printer.GetEnginePowerFromTheUser();
                    string ownerName = Printer.GetOwnerNameFromUser();
                    string ownerPhoneNumber = Printer.GetOwnerPhoneNumber();

                    object[] vehicleSpecificDetails = null;

                    try
                    {
                        switch (vehicleType)
                        {
                            case "NormalCar":
                            case "ElectricCar":
                                eColor color = Printer.GetCarColor();
                                int numberOfDoors = (int)Printer.GetNumberOfDoorsFromUser();
                                vehicleSpecificDetails = new object[] { color, numberOfDoors };
                                break;
                            case "NormalMotorcycle":
                            case "ElectricMotorcycle":
                                string licenseType = Printer.GetLicenseType().ToString();
                                int engineCapacity = Printer.GetEngineCapacity();
                                vehicleSpecificDetails = new object[] { licenseType, engineCapacity };
                                break;
                            case "Truck":
                                bool transportHazardousMaterials = Printer.GetTransportHazardousMaterials();
                                float cargoCapacity = Printer.GetCargoCapacity();
                                vehicleSpecificDetails = new object[] { transportHazardousMaterials, cargoCapacity };
                                break;
                            default:
                                throw new UnsupportedVehicleTypeException($"Unsupported vehicle type: {vehicleType}");
                        }

                        Console.WriteLine("Enter details for wheels:");
                        bool addWheelsAtOnce = Printer.GetWheelInputOption();

                        float currAirPressure;
                        string manufacturerName;

                        if (addWheelsAtOnce)
                        {
                            currAirPressure = Printer.GetCurrentAirPressureInfo();
                            manufacturerName = Printer.GetManufacturerName();
                        }
                        else
                        {
                            currAirPressure = 0;
                            manufacturerName = "";
                        }


                        VehicleFactory factory = new VehicleFactory();
                        Vehicle vehicle = factory.CreateVehicle(vehicleType, modelName, licenseNumber, ownerName, ownerPhoneNumber, currEnergy, manufacturerName, currAirPressure, vehicleSpecificDetails);
                        if (!addWheelsAtOnce)
                        {
                            Printer.AddWheelsOneByOne(vehicle);
                        }

                        i_garage.AddVehicle(vehicle);
                        Printer.PrintVehicleAdded();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to create or add vehicle to garage.Issue: {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayLicenseNumbers(Garage i_garage)
        {
            try
            {
                Console.WriteLine("Do you want to filter the license numbers by vehicle status? (yes/no): ");
                string filterChoice = Console.ReadLine().ToLower();

                if (filterChoice == "yes")
                {
                    string status = Printer.GetVehicleStatus();
                    List<string> filteredLicenseNumbers = i_garage.GetLicenseNumbers(status);
                    Printer.PrintLicenseNumbers(filteredLicenseNumbers);
                }
                else
                {
                    List<string> allLicenseNumbers = i_garage.GetLicenseNumbers();
                    Printer.PrintLicenseNumbers(allLicenseNumbers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        static void ChangeVehicleStatus(Garage i_garage)
        {
            try
            {
                string licenseNumber = Printer.GetLicenseNumber();
                if (i_garage.VehicleExists(licenseNumber))
                {
                    string newCondition = Printer.SelectNewConditionForCar();
                    i_garage.ChangeVehicleStatus(licenseNumber, newCondition);
                    Printer.SuccededToChangeStatus();
                }
                else
                {
                    Console.WriteLine("The vehicle with the provided license number does not exist.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred in ChangeVehicleStatus: {ex.Message}");
            }
        }

        static void InflateWheelsToMax(Garage i_garage)
        {
            Printer.InflateAllWheelsToMax(i_garage);
        }

        static void RefuelVehicle(Garage i_garage)
        {
            Printer.ChargingRegularVehicle(i_garage);
        }

        static void ChargeElectricVehicle(Garage i_garage)
        {
            Printer.ChargingElectricVehicle(i_garage);
        }

        static void DisplayVehicleDetails(Garage i_garage)
        {
            Printer.PrintVehicleDetails(i_garage);
        }

    }

       
}