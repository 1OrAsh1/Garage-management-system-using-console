using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Yellow,
        White,
        Red,
        Black
    }
    public enum eNumberOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
    public class NormalCar : Vehicle
    {
        private eColor m_color;
        private eNumberOfDoors m_numberOfDoors;

        public NormalCar(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber, eColor i_color, int i_numberOfDoors, float i_currEnergy, string i_manufacturerName, float i_currAirPressure) : base(i_modelName, i_licenseNumber, i_ownerName, i_ownerPhoneNumber)
        {
            this.m_color = i_color;

            if (!Enum.IsDefined(typeof(eNumberOfDoors), i_numberOfDoors))
            {
                throw new InvalidNumberOfDoorsException(string.Format("Invalid number of doors: {0}", i_numberOfDoors));
            }
            this.m_numberOfDoors = (eNumberOfDoors)i_numberOfDoors;
            this.Engine = new Fuel(i_currEnergy, 45f, eFuelType.Octan95);
            this.Wheels = new List<Wheel>();
            for (int i = 0; i < (int)eVehicleWheelsAmount.ElectricOrRegularCar; i++)
            {
                Wheels.Add(new Wheel(i_manufacturerName, i_currAirPressure, 31));
            }
        }

        public eColor Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_numberOfDoors; }
            set { m_numberOfDoors = value; }
        }
    }
}
