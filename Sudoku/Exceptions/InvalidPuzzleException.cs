using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sudoku.Exceptions
{
    public class InvalidPuzzleException : Exception
    {
        public InvalidPuzzleException()
        {
        }

        public InvalidPuzzleException(string message) 
            : base(message)
        {
        }

        public InvalidPuzzleException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidPuzzleException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
