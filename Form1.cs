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
        //The date textbox leave event
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                //checking whether the date is valid or not 
                if (!clsCalculate.checkValidaDate(txtDate.Text))
                {
                    txtDate.Text = "";
                    MessageBox.Show("invalid date format.please check the date u have entered!");
                }
            }
            catch (Exception ex)
            { 
                // writing the log into the file
                ex.WriteToFile();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //checking whether the date is valid or not 
                if (clsCalculate.checkValidaDate(txtDate.Text))
                {
                    int Day = 0, Month = 0, Year = 0, dayapart = 0, month1 = 0;
                    var txtdate = txtDate.Text;
                    int NoOfDays = txtDays.Text.ToInt();
                    //checking the date value contains '/'
                    if (txtdate.Contains('/') == true)
                    {
                        //spliting the date value with '/'
                        var arr = txtdate.Split('/');
                        //checking the array length and null
                        if (arr != null && arr.Length == 3)
                        {
                            //setting the day, month & year
                            Day = arr[0].ToInt(); Month = arr[1].ToInt(); Year = arr[2].ToInt();
                            //Finding number of days in a month with user defined function NoOfDaysInAMonth 
                            int NoOfDaysinaMonth = extender.NoOfDaysInAMonth(Month, Year);
                            //Adding the number of days with Day 
                            Day = Day + NoOfDays;
                            if (Day > NoOfDaysinaMonth) // checking the day with number of days in month whether it is greater than or not 
                            {
                                // finding the number of days & months
                                int tmpDay = Day % NoOfDaysinaMonth;
                                dayapart = Day / NoOfDaysinaMonth;
                                Day = tmpDay;
                            }
                            if (dayapart > 0)
                            {
                                // counting the value of a month
                                month1 = Month + dayapart;
                                Month = Month + dayapart;
                                Month = Month % 12;
                            }
                            // finding the year
                            Year = Year + (month1 / 12);
                            string strDay = "", strMonth = "";

                            // finding the new date value 
                            strDay = (Day + "").Length < 2 ? ("0" + Day + "") : Day.ToString();
                            strMonth = (Month + "").Length < 2 ? ("0" + (Month + "")) : Month.ToString();
                            //Setting the new date value into the label
                            lblResult.Text = strDay + "/" + strMonth + "/" + Year;
                        }
                    }
                    else
                    {
                        MessageBox.Show("invalid date format.please check the date u have entered!");
                    }
                }
                else
                {
                    MessageBox.Show("invalid date format.please check the date u have entered!");
                }

            }
            catch (Exception ex)
            {
                // writing the log into the file
                ex.WriteToFile();
            }
        }

       
    }
   
}
