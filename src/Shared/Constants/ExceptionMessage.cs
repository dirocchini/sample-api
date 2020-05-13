using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Constants
{
    public static class ExceptionMessage
    {
        
        public const string DOMAIN_CUSTOMER_EMAIL_INVALID = "Customer email should not be null or empty";
        public const string DOMAIN_CUSTOMER_NAME_INVALID = "Customer name should not be null or empty";

        public static string DOMAIN_ORDER_DESCRIPTION_INVALID = "Order description should not be null or empty";
        public static string DOMAIN_ORDER_DATE_INVALID = "Order date should not be null or empty";
    }
}
