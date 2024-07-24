using System;

namespace Ex03.GarageLogic
{
    public class InvalidLicenseTypeException : Exception
    {
        public InvalidLicenseTypeException()
        {
        }

        public InvalidLicenseTypeException(string i_message)
            : base(i_message)
        {
        }

        public InvalidLicenseTypeException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
