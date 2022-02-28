using System;

namespace eCommerce.Utilities
{
    public class eCommerceException: Exception
    {
        // Define Exception

        public eCommerceException()
        {

        }

        public eCommerceException(string message): base(message)
        {

        }

        public eCommerceException(string message, Exception inner):base(message, inner)
        {

        }


    }
}
