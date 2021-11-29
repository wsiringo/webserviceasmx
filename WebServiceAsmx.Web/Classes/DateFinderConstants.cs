using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAsmx.Web.Classes
{
    public static class DateFinderConstants
    {
        public static string DefaultDateFormat = "dd/MM/yyyy"; // output date format is defined as a constant to enforce consistency
        public static DateTime DefaultInvalidResult = DateTime.MinValue; // default value for invalid input
    }
}