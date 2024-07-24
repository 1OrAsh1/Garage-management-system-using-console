using System;

namespace Ex03.GarageLogic
{

    public class ChargingExceedsCapacityException : Exception
    {
        public ChargingExceedsCapacityException()
        {
        }

        public ChargingExceedsCapacityException(string i_message)
            : base(i_message)
        {
        }

        public ChargingExceedsCapacityException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
