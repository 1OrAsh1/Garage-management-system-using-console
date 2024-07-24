using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public delegate Vehicle VehicleCreator();

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string typeName, string modelName, string licenseNumber, string ownerName, string ownerPhoneNumber, float currEnergy, string manufacturerName, float currAirPressure, object[] vehicleSpecificDetails)
        {
            Vehicle vehicle = null;

            try
            {
                switch (typeName)
                {
                    case "NormalCar":
                        vehicle = CreateNormalCar(modelName, licenseNumber, ownerName, ownerPhoneNumber, currEnergy, manufacturerName, currAirPressure, (eColor)vehicleSpecificDetails[0], (int)vehicleSpecificDetails[1]);
                        break;
                    case "ElectricCar":
                        vehicle = CreateElectricCar(modelName, licenseNumber, ownerName, ownerPhoneNumber, currEnergy, manufacturerName, currAirPressure, (eColor)vehicleSpecificDetails[0], (int)vehicleSpecificDetails[1]);
                        break;
                    case "NormalMotorcycle":
                        vehicle = CreateNormalMotorcycle(modelName, licenseNumber, ownerName, ownerPhoneNumber, (string)vehicleSpecificDetails[0], (int)vehicleSpecificDetails[1], currEnergy, manufacturerName, currAirPressure);
                        break;
                    case "ElectricMotorcycle":
                        vehicle = CreateElectricMotorcycle(modelName, licenseNumber, ownerName, ownerPhoneNumber, (string)vehicleSpecificDetails[0], (int)vehicleSpecificDetails[1], currEnergy, manufacturerName, currAirPressure);
                        break;
                    case "Truck":
                        vehicle = CreateTruck(modelName, licenseNumber, ownerName, ownerPhoneNumber, (bool)vehicleSpecificDetails[0], (float)vehicleSpecificDetails[1], currEnergy, manufacturerName, currAirPressure);
                        break;
                    default:
                        throw new UnsupportedVehicleTypeException($"Unsupported vehicle type: {typeName}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vehicle;
        }

        private NormalCar CreateNormalCar(string modelName, string licenseNumber, string ownerName, string ownerPhoneNumber, float currEnergy, string manufacturerName, float currAirPressure, eColor color, int numberOfDoors)
        {
            try
            {
                return new NormalCar(modelName, licenseNumber, ownerName, ownerPhoneNumber, color, numberOfDoors, currEnergy, manufacturerName, currAirPressure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ElectricCar CreateElectricCar(string modelName, string licenseNumber, string ownerName, string ownerPhoneNumber, float currEnergy, string manufacturerName, float currAirPressure, eColor color, int numberOfDoors)
        {
            try
            {
                return new ElectricCar(modelName, licenseNumber, ownerName, ownerPhoneNumber, currEnergy, manufacturerName, currAirPressure, color, numberOfDoors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private NormalMotorcycle CreateNormalMotorcycle(string modelName, string licenseNumber, string ownerName, string ownerPhoneNumber, string licenseType, int engineCapacity, float currEnergy, string manufacturerName, float currAirPressure)
        {
            try
            {
                return new NormalMotorcycle(modelName, licenseNumber, ownerName, ownerPhoneNumber, licenseType, engineCapacity, currEnergy, manufacturerName, currAirPressure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ElectricMotorcycle CreateElectricMotorcycle(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber, string i_licenseType, int i_engineCapacity, float i_currEnergy, string i_manufacturerName, float i_currAirPressure)
        {
            try
            {
                return new ElectricMotorcycle(i_modelName, i_licenseNumber, i_ownerName, i_ownerPhoneNumber, i_licenseType, i_engineCapacity, i_currEnergy, i_manufacturerName, i_currAirPressure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Truck CreateTruck(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber, bool i_transportHazardousMaterials, float i_cargoCapacity, float i_currEnergy, string i_manufacturerName, float i_currAirPressure)
        {
            try
            {
                return new Truck(i_modelName, i_licenseNumber, i_ownerName, i_ownerPhoneNumber, i_transportHazardousMaterials, i_cargoCapacity, i_currEnergy, i_manufacturerName, i_currAirPressure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetSupportedVehicleTypes()
        {
            return new List<string>
            {
                "NormalCar",
                "ElectricCar",
                "NormalMotorcycle",
                "ElectricMotorcycle",
                "Truck"
            };
        }
    }
}
