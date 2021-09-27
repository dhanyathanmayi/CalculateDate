using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDate
{
   public class clsCalculate
    {
        public static bool checkValidaDate(string strDate)
        {
            bool isValid = true;
            try
            {
                int Day = 0, Month = 0, Year = 0;
                string txtdate = strDate;
                if (txtdate.Contains('/') == true)
                {
                    var arr = txtdate.Split('/');
                    if (arr.Length == 3)
                    {
                        Day = arr[0].ToInt(); Month = arr[1].ToInt(); Year = arr[2].ToInt();
                        int NoOfDaysinaMonth = extender.NoOfDaysInAMonth(Month, Year);
                        if (Day > NoOfDaysinaMonth || Day <= 0)
                        {
                            isValid = false;
                        }
                        else if (Month > 12 || Month <= 0)
                        {
                            isValid = false;
                        }
                        else if ((Year + "").Length != 4)
                        {
                            isValid = false;
                        }
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                // writing the log into the file
                ex.WriteToFile();
            }
            return isValid;
        }
    }
}
