using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electricity
    }
    public class Fuel : Engine
    {
        private eFuelType m_fuelType;

        public Fuel(float i_currEnergy, float i_maxEnergy, eFuelType i_fuelType)
        : base(i_currEnergy, i_maxEnergy)
        {
            if (i_currEnergy > i_maxEnergy)
            {
                throw new CurrentEnergyExceedsCapacityException("Current energy cannot exceed the maximum energy capacity.");
            }
            this.m_fuelType = i_fuelType;
        }

        public override void ChargeEnergy(eFuelType i_fuelType, float i_amount)
        {
            if (i_fuelType != this.m_fuelType)
            {
                throw new InvalidFuelTypeException("Invalid fuel type for this vehicle.");
            }

            float newEnergy = CurrEnergy + i_amount;
            if (newEnergy > MaxEnergy)
            {
                throw new ChargingExceedsCapacityException("Charging exceeds the maximum energy capacity.");
            }

            CurrEnergy = newEnergy;
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

        public eFuelType FuelType
        {
            get { return this.m_fuelType; }
            set { this.m_fuelType = value; }
        }
    }
}
