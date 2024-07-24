using System;

namespace Ex03.GarageLogic
{
    public class InvalidNumberOfDoorsException : Exception
    {
        public InvalidNumberOfDoorsException()
        {
        }

        public InvalidNumberOfDoorsException(string i_message)
            : base(i_message)
        {
        }

        public InvalidNumberOfDoorsException(string i_message, Exception i_inner)
            : base(i_message, i_inner)
        {
        }
    }
}
