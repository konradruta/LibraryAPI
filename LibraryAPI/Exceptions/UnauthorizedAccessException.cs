using System;

namespace LibraryAPI.Exceptions
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string LoginMessage) : base(LoginMessage)
        {
            
        }
    }
}
