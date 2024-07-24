using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturerName;
        private float m_currAirPressure;
        private float m_maxAirPressure;

        public void InflatingWheel(float i_airAdded)
        {
            if ((this.m_currAirPressure + i_airAdded) > this.m_maxAirPressure)
            {
                throw new AirPressureExceededException("You have exceeded the maximum air pressure that can be filled");
            }
            this.m_currAirPressure += i_airAdded;
        }

        public void InflateToMax()
        {
            this.m_currAirPressure = this.m_maxAirPressure;
        }

        public Wheel(string i_manufacturerName, float i_currAirPressure, float i_maxAirPressure)
        {
            if (i_currAirPressure > i_maxAirPressure)
            {
                throw new InvalidAirPressureException("Current air pressure cannot exceed the maximum air pressure.");
            }

            this.m_manufacturerName = i_manufacturerName;
            this.m_currAirPressure = i_currAirPressure;
            this.m_maxAirPressure = i_maxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_manufacturerName; }
            set { m_manufacturerName = value; }
        }

        public float CurrAirPressure
        {
            get { return m_currAirPressure; }
            set
            {
                if (value > m_maxAirPressure)
                {
                    throw new InvalidAirPressureException("Current air pressure cannot exceed the maximum air pressure.");
                }
                m_currAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get { return m_maxAirPressure; }
            set
            {
                if (value < m_currAirPressure)
                {
                    throw new InvalidAirPressureException("Maximum air pressure cannot be less than the current air pressure.");
                }
                m_maxAirPressure = value;
            }
        }
    }
}