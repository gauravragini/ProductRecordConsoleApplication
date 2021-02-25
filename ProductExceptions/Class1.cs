using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExceptions
{
    public class productException:ApplicationException
    {
        public productException() : base()
        {

        }
        public productException(string message) : base(message)
        {

        }
        public productException(string message,Exception innerException) : base(message, innerException)
        {

        }
    }
}
