using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDate
{
   public static class extender
    {
        public static DateTime ToDate(this string s)
        {
            DateTime output;
            DateTime.TryParse(s, out output);
            return (output);
        }
        public static int ToInt(this string strValue)
        {
            int intRet = 0;
            float fltTmp = 0;
            if (strValue == null) strValue = "";
            strValue = strValue.Replace(",", "");
            if (strValue.Contains("."))
            {
                if (float.TryParse(strValue, out fltTmp))
                    intRet = (int)Math.Round(fltTmp, 0);
            }
            else int.TryParse(strValue, out intRet);
            return intRet;

        }
    }
}
