using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDate
{
   public static class extender
    {
        //converting the string into date - extender function
        public static DateTime ToDate(this string s)
        {
            DateTime output;
            DateTime.TryParse(s, out output);
            return (output);
        }
        //converting the string into int - extender function
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
        //error log into file
        public static void WriteToFile(this Exception ex)
        {
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "CalculateDateLog.txt";
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path);
                }
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(string.Format(ex.Message, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                    writer.Close();
                }
            }
            catch (Exception ex1)
            {
                throw;
            }
        }
        //Calculating number of days in a given month
        public static  int NoOfDaysInAMonth(int month, int Year)
        {
            int NoofDaysinamonth = 0;
            try
            {
                switch (month)
                {
                    case 1:
                        NoofDaysinamonth = 31;
                        break;
                    case 2:
                        NoofDaysinamonth = Year % 4 == 0 ? 29 : 28;
                        break;
                    case 3:
                        NoofDaysinamonth = 31;
                        break;
                    case 4:
                        NoofDaysinamonth = 30;
                        break;
                    case 5:
                        NoofDaysinamonth = 31;
                        break;
                    case 6:
                        NoofDaysinamonth = 30;
                        break;
                    case 7:
                        NoofDaysinamonth = 31;
                        break;
                    case 8:
                        NoofDaysinamonth = 31;
                        break;
                    case 9:
                        NoofDaysinamonth = 30;
                        break;
                    case 10:
                        NoofDaysinamonth = 31;
                        break;
                    case 11:
                        NoofDaysinamonth = 30;
                        break;
                    case 12:
                        NoofDaysinamonth = 31;
                        break;
                }
            }
            catch (Exception ex)
            {
                // writing the log into the file
                ex.WriteToFile();
            }
            return NoofDaysinamonth;
        }
    }
}
