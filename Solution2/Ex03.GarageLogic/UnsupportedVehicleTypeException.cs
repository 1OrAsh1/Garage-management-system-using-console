using System;

namespace Ex03.GarageLogic
{
    public class UnsupportedVehicleTypeException : Exception
    {
        public UnsupportedVehicleTypeException()
        {
        }

        public UnsupportedVehicleTypeException(string i_message)
            : base(i_message)
        {
        }

        public UnsupportedVehicleTypeException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
