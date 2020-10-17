using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sudoku.Exceptions
{
    public class UnsolvablePuzzleException : Exception
    {
        public UnsolvablePuzzleException()
        {
        }

        public UnsolvablePuzzleException(string message) 
            : base(message)
        {
        }

        public UnsolvablePuzzleException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected UnsolvablePuzzleException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
