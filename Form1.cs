using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (!checkValidaDate()) 
            MessageBox.Show("invalid date format.please check the date u have entered!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkValidaDate())
            {
                int Day = 0, Month = 0, Year = 0, dayapart = 0, month1 = 0;
                var txtdate = txtDate.Text;
                int NoOfDays = txtDays.Text.ToInt();
                if (txtdate.Contains('/') == true)
                {
                    var arr = txtdate.Split('/');
                    if (arr != null && arr.Length == 3)
                    {
                        Day = arr[0].ToInt(); Month = arr[1].ToInt(); Year = arr[2].ToInt();
                        int NoOfDaysinaMonth = NoOfDaysInAMonth(Month, Year);
                        Day = Day + NoOfDays;
                        if (Day > NoOfDaysinaMonth)
                        {
                            int tmpDay = Day % NoOfDaysinaMonth;
                            dayapart = Day / NoOfDaysinaMonth;
                            Day = tmpDay;
                        }
                        if (dayapart > 0)
                        {
                            month1 = Month + dayapart;
                            Month = Month + dayapart;
                            Month = Month % 12;
                        }

                        Year = Year + (month1 / 12);
                        string strDay = "", strMonth = "";
                        strDay = (Day + "").Length < 2 ? ("0" + Day + "") : Day.ToString();
                        strMonth = (Month + "").Length < 2 ? ("0" + (Month + "")) : Month.ToString();
                        lblResult.Text = strDay + "/" + strMonth + "/" + Year;
                    }

                }
                else
                {
                    lblResult.Text = "invalid date format. please use the format dd/MM/yyyy";
                }
            }

        }


        public bool checkValidaDate()
        {
            bool isValid = true;
            int Day = 0, Month = 0, Year = 0;
            string txtdate = txtDate.Text;
            if (txtdate.Contains('/') == true)
            {
                var arr = txtdate.Split('/');
                if (arr.Length == 3)
                {
                    Day = arr[0].ToInt(); Month = arr[1].ToInt(); Year = arr[2].ToInt();
                    int NoOfDaysinaMonth = NoOfDaysInAMonth(Month, Year);
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
            return isValid;
        }

        public int NoOfDaysInAMonth(int month, int Year)
        {
            int NoofDaysinamonth = 0;
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
            return NoofDaysinamonth;
        }

       
    }
   
}
