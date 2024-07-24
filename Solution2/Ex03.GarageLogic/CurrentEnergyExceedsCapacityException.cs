using System;

namespace Ex03.GarageLogic
{
    public class CurrentEnergyExceedsCapacityException : Exception
    {
        public CurrentEnergyExceedsCapacityException()
        {
        }

        public CurrentEnergyExceedsCapacityException(string i_message)
            : base(i_message)
        {
        }

        public CurrentEnergyExceedsCapacityException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }

}
