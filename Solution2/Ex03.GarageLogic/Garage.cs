using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_vehicles;

        public Garage()
        {
            m_vehicles = new Dictionary<string, Vehicle>();
        }

        public Dictionary<string, Vehicle> GetVehicles()
        {
            return m_vehicles;
        }

        public void AddVehicle(Vehicle i_vehicle)
        {
            m_vehicles[i_vehicle.LicenseNumber] = i_vehicle;
        }

        public bool RemoveVehicle(string i_licenseNumber)
        {
            return m_vehicles.Remove(i_licenseNumber);
        }

        public Vehicle GetVehicle(string i_licenseNumber)
        {
            if (m_vehicles.TryGetValue(i_licenseNumber, out Vehicle vehicle))
            {
                return vehicle;
            }
            throw new ArgumentException($"No vehicle found with license number: {i_licenseNumber}", nameof(i_licenseNumber));
        }

        public void ChangeVehicleStatus(string i_licenseNumber, string i_newStatus)
        {
            Vehicle vehicle = GetVehicle(i_licenseNumber);
            if (vehicle == null)
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }

            try
            {
                vehicle.VehicleCondition = (eVehicleCondition)Enum.Parse(typeof(eVehicleCondition), i_newStatus, true);
            }
            catch (ArgumentException)
            {
                throw new InvalidVehicleConditionException("Invalid vehicle condition provided.");
            }
        }

        public void InflateWheelsToMax(string i_licenseNumber)
        {
            Vehicle vehicle = GetVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                foreach (Wheel wheel in vehicle.Wheels)
                {
                    wheel.InflateToMax();
                }
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }
        }

        public void RefuelVehicle(string i_licenseNumber, eFuelType i_fuelType, float i_amount)
        {
            Vehicle vehicle = GetVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                if (vehicle is IFuelable fuelableVehicle)
                {
                    fuelableVehicle.ChargeEnergy(i_fuelType, i_amount);
                }
                else
                {
                    throw new InvalidOperationException("Vehicle is not fuelable.");
                }
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }
        }

        public void ChargeElectricVehicle(string i_licenseNumber, float i_duration)
        {
            Vehicle vehicle = GetVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                if (vehicle is IElectric electricVehicle)
                {
                    eFuelType electype = eFuelType.Electricity;
                    electricVehicle.ChargeEnergy(electype, i_duration);
                }
                else
                {
                    throw new InvalidOperationException("Vehicle is not electric.");
                }
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }
        }

        public List<string> GetLicenseNumbers(string i_filter = null)
        {
            List<string> licenseNumbers = new List<string>(m_vehicles.Keys);

            if (!string.IsNullOrEmpty(i_filter))
            {
                try
                {
                    eVehicleCondition condition = (eVehicleCondition)Enum.Parse(typeof(eVehicleCondition), i_filter, true);
                    licenseNumbers = licenseNumbers.FindAll(license => m_vehicles[license].VehicleCondition == condition);
                }
                catch (ArgumentException)
                {
                    throw new InvalidVehicleConditionException("Invalid vehicle condition provided.");
                }
            }

            return licenseNumbers;
        }

        public string GetVehicleDetails(string i_licenseNumber)
        {
            Vehicle vehicle = GetVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                return vehicle.ToString();
            }
            throw new VehicleNotFoundException("Vehicle not found.");
        }

        public bool VehicleExists(string i_licenseNumber)
        {
            return m_vehicles.ContainsKey(i_licenseNumber);
        }
    }
}
