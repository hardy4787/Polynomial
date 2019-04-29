using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    class PolynomialException : Exception
    {
        public PolynomialException() { }
        public PolynomialException(string message) : base(message) { }
        public PolynomialException(string message, Exception inner) : base(message, inner) { }
        protected PolynomialException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
