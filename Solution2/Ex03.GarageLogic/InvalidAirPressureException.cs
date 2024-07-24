using System;

namespace Ex03.GarageLogic
{
    public class InvalidAirPressureException : Exception
    {
        public InvalidAirPressureException()
        {
        }

        public InvalidAirPressureException(string i_message)
            : base(i_message)
        {
        }

        public InvalidAirPressureException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}