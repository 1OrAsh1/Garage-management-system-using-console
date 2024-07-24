using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A,
        A1,
        AA,
        B1
    }
    public class NormalMotorcycle : Vehicle
    {
        private eLicenseType m_licenseType;
        private int m_engineCapacity;

        public NormalMotorcycle(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber, string i_licenseType, int i_engineCapacity, float i_currEnergy, string i_manufacturerName, float i_currAirPressure) : base(i_modelName, i_licenseNumber, i_ownerName, i_ownerPhoneNumber)
        {
            if (!Enum.IsDefined(typeof(eLicenseType), i_licenseType))
            {
                throw new InvalidLicenseTypeException(string.Format("Invalid license type: {0}", i_licenseType));
            }
            this.m_licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_licenseType, true);

            this.m_engineCapacity = i_engineCapacity;
            this.Engine = new Fuel(i_currEnergy, 5.5f, eFuelType.Octan98);
            this.Wheels = new List<Wheel>();
            for (int i = 0; i < (int)eVehicleWheelsAmount.Motorcycle; i++)
            {
                Wheels.Add(new Wheel(i_manufacturerName, i_currAirPressure, 33));
            }
        }

        public eLicenseType LicenseType
        {
            get { return m_licenseType; }
            set { m_licenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_engineCapacity; }
            set { m_engineCapacity = value; }
        }
    }
}
