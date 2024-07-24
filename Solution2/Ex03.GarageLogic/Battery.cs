using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : Engine
    {
        public Battery(float i_currEnergy, float i_maxEnergy) : base(i_currEnergy, i_maxEnergy)
        {
            if (i_currEnergy > i_maxEnergy)
            {
                throw new CurrentEnergyExceedsCapacityException("Current energy cannot exceed the maximum energy capacity.");
            }
        }
        public override void ChargeEnergy(eFuelType i_fuelType, float i_amount)
        {
            if (i_fuelType != eFuelType.Electricity)
            {
                throw new InvalidFuelTypeException("Invalid fuel type for battery charging.");
            }

            float newEnergy = CurrEnergy + i_amount;
            if (newEnergy > MaxEnergy)
            {
                throw new CurrentEnergyExceedsCapacityException("Charging exceeds the maximum energy capacity.");
            }

            CurrEnergy = newEnergy;
        }

        public new float CurrEnergy
        {
            get { return base.CurrEnergy; }
            set { base.CurrEnergy = value; }
        }

        public new float MaxEnergy
        {
            get { return base.MaxEnergy; }
            set { base.MaxEnergy = value; }
        }
    }
}