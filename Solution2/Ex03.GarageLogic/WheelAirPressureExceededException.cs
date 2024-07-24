using System;

namespace Ex03.GarageLogic
{
    public class AirPressureExceededException : Exception
    {
        public AirPressureExceededException()
        {
        }

        public AirPressureExceededException(string i_message)
            : base(i_message)
        {
        }

        public AirPressureExceededException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
