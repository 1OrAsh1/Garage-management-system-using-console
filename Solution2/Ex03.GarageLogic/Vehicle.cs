using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleWheelsAmount
    {
        ElectricOrRegularCar = 4,
        Motorcycle = 2,
        Truck = 12
    }
    public enum eVehicleCondition
    {
        BeingRepaired,
        DoneRepairing,
        Paid
    }
    public interface IFuelable
    {
        void ChargeEnergy(eFuelType i_fuelType, float i_amount);
    }

    public interface IElectric
    {
        void ChargeEnergy(eFuelType i_fuelType, float i_amount);
    }


    public abstract class Vehicle : IFuelable, IElectric
    {
        private string m_modelName;
        private string m_licenseNumber;
        private List<Wheel> m_wheels;
        private Engine m_engine;
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private eVehicleCondition m_vehicleCondition;

        public Vehicle(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber)
        {
            this.m_modelName = i_modelName;
            this.m_licenseNumber = i_licenseNumber;
            this.m_ownerName = i_ownerName;
            this.m_vehicleCondition = eVehicleCondition.BeingRepaired;
            this.m_ownerPhoneNumber = i_ownerPhoneNumber;
        }

        public void FillAllWheelsAirPressureToMax()
        {
            for (int i = 0; i < this.m_wheels.Count; i++)
            {
                this.m_wheels[i].InflateToMax();
            }
        }

        public string GetOwnerPhoneNumber()
        {
            return m_ownerPhoneNumber;
        }
        public virtual void ChargeEnergy(eFuelType i_fuelType, float i_amount)
        {
        }

        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_licenseNumber; }
            set { m_licenseNumber = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_wheels; }
            set { m_wheels = value; }
        }

        public Engine Engine
        {
            get { return m_engine; }
            set { m_engine = value; }
        }

        public string OwnerName
        {
            get { return m_ownerName; }
            set { m_ownerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_ownerPhoneNumber; }
            set { m_ownerPhoneNumber = value; }

        }
        public eVehicleCondition VehicleCondition
        {
            get { return m_vehicleCondition; }
            set { m_vehicleCondition = value; }
        }

    }
}