using System;

namespace Ex03.GarageLogic
{

    public class NegativeMaximumEnergyException : Exception
    {
        public NegativeMaximumEnergyException()
        {
        }

        public NegativeMaximumEnergyException(string i_message)
            : base(i_message)
        {
        }

        public NegativeMaximumEnergyException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
