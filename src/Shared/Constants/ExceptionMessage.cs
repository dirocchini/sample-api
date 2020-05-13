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
        public static string DOMAIN_ORDER_CUSTOMER_ID_INVALID = "Order customer should not be null or empty";
        public static string DOMAIN_ORDER_ITEMS_INVALID = "Order items should not be null or empty";

        public static string DOMAIN_ORDER_ITEM_AMOUNT_INVALID = "Order item amount should not be less or equal to zero";
        public static string DOMAIN_ORDER_ITEM_PRICE_INVALID = "Order item price should not be less than zero";
    }
}
