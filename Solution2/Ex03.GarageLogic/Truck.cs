using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_transportHazardousMaterials;
        private float m_cargoCapacity;

        public Truck(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber, bool i_transportHazardousMaterials, float i_cargoCapacity, float i_currEnergy, string i_manufacturerName, float i_currAirPressure) : base(i_modelName, i_licenseNumber, i_ownerName, i_ownerPhoneNumber)
        {
            this.m_cargoCapacity = i_cargoCapacity;
            this.m_transportHazardousMaterials = i_transportHazardousMaterials;
            this.Engine = new Fuel(i_currEnergy, (float)120, eFuelType.Soler);
            this.Wheels = new List<Wheel>();
            for (int i = 0; i < (int)eVehicleWheelsAmount.Truck; i++)
            {
                Wheels.Add(new Wheel(i_manufacturerName, i_currAirPressure, 28));
            }
        }

        public bool TransportHazardousMaterials
        {
            get { return m_transportHazardousMaterials; }
            set { m_transportHazardousMaterials = value; }
        }

        public float CargoCapacity
        {
            get { return m_cargoCapacity; }
            set { m_cargoCapacity = value; }
        }
    }
}