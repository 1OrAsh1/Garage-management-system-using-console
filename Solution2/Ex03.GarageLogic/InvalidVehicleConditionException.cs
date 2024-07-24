using System;

namespace Ex03.GarageLogic
{
    public class InvalidVehicleConditionException : Exception
    {
        public InvalidVehicleConditionException()
        {
        }

        public InvalidVehicleConditionException(string i_message)
            : base(i_message)
        {
        }

        public InvalidVehicleConditionException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
