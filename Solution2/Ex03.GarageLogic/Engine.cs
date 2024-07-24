using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_currEnergy;
        private float m_maxEnergy;

        public abstract void ChargeEnergy(eFuelType i_fuelType, float i_amount);

        protected Engine(float i_currEnergy, float i_maxEnergy)
        {
            this.m_currEnergy = i_currEnergy;
            this.m_maxEnergy = i_maxEnergy;
        }

        public float CurrEnergy
        {
            get { return this.m_currEnergy; }
            set
            {
                if (value > this.m_maxEnergy)
                {
                    throw new CurrentEnergyExceedsCapacityException("Current energy cannot exceed the maximum energy capacity.");
                }
                this.m_currEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get { return this.m_maxEnergy; }
            set
            {
                if (value < 0)
                {
                    throw new NegativeMaximumEnergyException("Maximum energy cannot be negative.");
                }
                this.m_maxEnergy = value;
            }
        }
    }
}
