using System;

namespace Ex03.GarageLogic
{
    public class InvalidFuelTypeException : Exception
    {
        public InvalidFuelTypeException()
        {
        }

        public InvalidFuelTypeException(string i_message)
            : base(i_message)
        {
        }

        public InvalidFuelTypeException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }

}
