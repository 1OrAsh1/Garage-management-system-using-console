using System;

namespace Ex03.GarageLogic
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException()
        {
        }

        public VehicleNotFoundException(string i_message)
            : base(i_message)
        {
        }

        public VehicleNotFoundException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }

}
