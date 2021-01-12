using System;
using System.Globalization;

namespace BlazorAppDataSource1.Server.Helper
{
    public class Conv
    {
        public static int ToInt(string value)
        {
            int valret = 0;
            if (String.IsNullOrEmpty(value) == false)
            {
                valret = Convert.ToInt32(value);
            }
            return valret;
        }

        public static double ToDouble(string value, bool hascomma = false)
        {
            double valret = 0;
            CultureInfo ci = CultureInfo.InvariantCulture;
            if (String.IsNullOrEmpty(value) == false)
            {
                if (hascomma == false)
                    valret = Convert.ToDouble(value, ci);
                else valret = Convert.ToDouble(value);
            }
            return valret;
        }

        public static decimal ToDecimal(string value, bool hascomma = false)
        {
            decimal valret = 0;
            CultureInfo ci = CultureInfo.InvariantCulture;
            if (String.IsNullOrEmpty(value) == false)
            {
                if (hascomma == false)
                    valret = Convert.ToDecimal(value, ci);
                else valret = Convert.ToDecimal(value);
            }
            return valret;
        }

        public static DateTime? ToDate(string value)
        {
            DateTime? valret = null;
            if (String.IsNullOrEmpty(value) == false)
            {
                valret = Convert.ToDateTime(value);
            }
            return valret;
        }

        public static string ToString(string value)
        {
            string valret = "";
            if (String.IsNullOrEmpty(value) == false)
            {
                valret = value.Trim();
            }
            return valret;
        }
    }
}
