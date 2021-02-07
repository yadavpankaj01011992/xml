using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace XML_Testing
{
    public partial class Date_Time : Form
    {
        public static DateTime dateTime;
        public static string Date;
        public static string TimeUTC;
        public static string TimeUTC_hh_mm;
        public static string DayName;
        static int count = 0;
        static DateTime systemDatetime;
        static string systeoldtime = "";
        public static string tt_Time_Work = "";
        public Date_Time()
        {
            InitializeComponent();
            GetDateTime();
        }
        public static DateTime GetDateTime()
        {
            try
            {

                if (count == 0)
                {
                    count++;
                    systemDatetime = DateTime.Now;

                    Date = string.Empty;
                    TimeUTC = string.Empty;
                    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.google.com/");
                    var response = myHttpWebRequest.GetResponse();
                    string todaysDates = response.Headers["date"];      // Get DateTime in server in UTC
                    dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat);

                    Date = dateTime.ToString("yyyy/MM/dd");
                    TimeUTC = dateTime.ToString("HH:mm:ss");
                    TimeUTC_hh_mm = dateTime.ToString("HH:mm tt");
                    DayName = dateTime.ToString("dddd");
                    systeoldtime = systemDatetime.ToString("HH:mm:ss");       // Save time in local system 
                    //return DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal); // LOcal Time
                    tt_Time_Work = dateTime.ToString("HH:mm:ss");
                }
                else
                {
                    Date = dateTime.ToString("yyyy/MM/dd");
                    DayName = dateTime.ToString("dddd");

                    systemDatetime = DateTime.Now;

                    string sysnewtime = systemDatetime.ToString("HH:mm:ss");  // get current time in local system 

                    TimeSpan oldtimespam;
                    oldtimespam = TimeSpan.Parse(systeoldtime);         //convert old and new time system in TimeSpam
                    TimeSpan newtimespam;
                    newtimespam = TimeSpan.Parse(sysnewtime);

                    TimeSpan diffTimeSpan = newtimespam - oldtimespam;      // 

                    TimeSpan finaltime;
                    finaltime = TimeSpan.Parse(TimeUTC);
                    TimeUTC = Convert.ToString(finaltime.Add(diffTimeSpan));        // diff Time add Utc time 

                    DateTime hh_MM_Days = Convert.ToDateTime(TimeUTC);
                    //hh_MM_Days = hh_MM_Days.ToUniversalTime();

                    TimeUTC_hh_mm = hh_MM_Days.ToString("HH:mm tt");        // time get in hh mm AM/PM  formate

                    systeoldtime = "";
                    systeoldtime = sysnewtime;


                }
            }
            catch
            { }
            return dateTime;
        }
    }
}
