using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dateTimeHandling
{
    /// <summary>
    /// Interaction logic for DateChangeWindow.xaml
    /// </summary>
    public partial class DateChangeWindow : Window
    {
        int year;
        int month;
        int day;
        int hour;
        int minute;
        int second;
        public DateChangeWindow()
        {
            InitializeComponent();
            TBO_Date.Text = DateTime.Now.ToString();
            //year = DateTime.Now.Year;
            //month = DateTime.Now.Month;
            //day = DateTime.Now.Day;
            //hour = DateTime.Now.Hour;
            //minute = DateTime.Now.Minute;
            //second = DateTime.Now.Second;
        }

        private void StringToIntValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regexValidator = new Regex("[^0-9]+");
            e.Handled = regexValidator.IsMatch(e.Text);

            // "[^0-9]+" : Szám "[^a-z]+" : Az angol ABC kisbetűi "[^A-Z]+" : Az angol ABC nagybetűi
            // "[^A-z]+" : Az angol ABC kis és nagybetűi
            //  Függően a regexValidator példányosításánál a "^" elhelyezkedésétől (Szögletes zárójelen belül vagy kívül), jelentheti
            //  hogy (Belül)csak az  adott karakterek vihetőek be, vagy (Kívül) csak az adott karakterek NEM vihetőek be
        }

        private void BTN_Change_Click(object sender, RoutedEventArgs e)
        {
            #region órapercmásodpercTeszt
            //int ChangedTimeValue = 0;
            //TBO_ChangedDate.Text = DateTime.Now.ToString();

            //if (year != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Year))
            //{
            //    year++;
            //}
            //else
            //{
            //    if (month != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Month))
            //    {
            //        month++;
            //    }
            //    else
            //    {
            //        if (day != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Day))
            //        {
            //            day++;
            //        }
            //        else
            //        {
            //            if (hour != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Hour))
            //            {
            //                ChangedTimeValue = Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Hour) - hour;
            //                hour += ChangedTimeValue;
            //                if (hour > 59)
            //                {
            //                    hour = DateTime.Now.Hour;
            //                }
            //            }
            //            else
            //            {
            //                if (minute != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Minute))
            //                {
            //                    ChangedTimeValue = Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Minute) - minute;
            //                    minute += ChangedTimeValue;
            //                    if (minute > 59)
            //                    {
            //                        minute = DateTime.Now.Minute;
            //                    }
            //                }
            //                else
            //                {
            //                    if (second != Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Second))
            //                    {
            //                        ChangedTimeValue = Convert.ToInt32(Convert.ToDateTime(TBO_ChangedDate.Text).Second)-second;
            //                        second += ChangedTimeValue;
            //                        if (second > 59)
            //                        {
            //                            second = DateTime.Now.Second;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //TBO_EndDate.Text = year.ToString() +" "+ month.ToString() +" "+ day.ToString() +" "+ hour.ToString() + " " + minute.ToString() + " " + second.ToString();
            #endregion


            if (string.IsNullOrEmpty(TBO_StartYear.Text))
            {
                DPI_StartDate.IsDropDownOpen = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TBO_ChangedYear.Text))
                {
                    TBO_ChangedYear.Text = DateTime.Now.Year.ToString();
                    //DPI_ChangedDate.IsDropDownOpen= true;
                }
                else
                {
                    if (string.IsNullOrEmpty(TBO_ChangedMonth.Text))
                    {
                        TBO_ChangedMonth.Focus();
                        TBO_ChangedMonth.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        
                        TBO_EndMonth.Text = (Convert.ToInt32(TBO_ChangedMonth.Text) - Convert.ToInt32(TBO_StartMonth.Text)).ToString();
                        if (string.IsNullOrEmpty(TBO_ChangedDay.Text))
                        {
                            TBO_ChangedDay.Focus();
                            TBO_ChangedDay.BorderBrush = Brushes.Red;
                        }
                        else
                        {
                            if (Convert.ToInt32(TBO_StartMonth.Text) + Convert.ToInt32(TBO_ChangedMonth.Text) <= DateTime.MaxValue.Month)
                            {
                                //TBO_EndMonth.Text = (Convert.ToInt32(TBO_ChangedMonth.Text) - Convert.ToInt32(TBO_StartMonth.Text)).ToString();
                                if (Convert.ToInt32(TBO_StartDay.Text) + Convert.ToInt32(TBO_ChangedDay.Text) <= DateTime.MaxValue.Day)
                                {
                                    TBO_EndDay.Text = (Convert.ToInt32(TBO_ChangedDay.Text) - Convert.ToInt32(TBO_StartDay.Text)).ToString();
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(TBO_StartDay.Text) + Convert.ToInt32(TBO_ChangedDay.Text) <= DateTime.MaxValue.Day)
                                {

                                    TBO_EndDay.Text = (Convert.ToInt32(TBO_ChangedDay.Text) - Convert.ToInt32(TBO_StartDay.Text)).ToString();
                                }
                                else
                                {
                                    TBO_EndMonth.Text = (Convert.ToInt32(TBO_EndMonth.Text) + 1).ToString();
                                }
                            }
                        }
                    }
                    //TBO_EndYear.Text = (Convert.ToInt32(TBO_ChangedYear.Text) - Convert.ToInt32(TBO_StartYear.Text)).ToString();

                    /*Számolás hónapokkal*/
                    //if (Convert.ToInt32(TBO_StartMonth.Text) + Convert.ToInt32(TBO_ChangedMonth.Text) <= DateTime.MaxValue.Month)
                    //{
                    //    TBO_EndMonth.Text = (Convert.ToInt32(TBO_ChangedMonth.Text) - Convert.ToInt32(TBO_StartMonth.Text)).ToString();
                    //    if (Convert.ToInt32(TBO_StartDay.Text) + Convert.ToInt32(TBO_ChangedDay.Text) <= DateTime.MaxValue.Day)
                    //    {
                    //        TBO_EndDay.Text = (Convert.ToInt32(TBO_ChangedDay.Text) - Convert.ToInt32(TBO_StartDay.Text)).ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    if (Convert.ToInt32(TBO_StartDay.Text) + Convert.ToInt32(TBO_ChangedDay.Text) <= DateTime.MaxValue.Day)
                    //    {
                            
                    //        TBO_EndDay.Text = (Convert.ToInt32(TBO_ChangedDay.Text) - Convert.ToInt32(TBO_StartDay.Text)).ToString();
                    //    }
                    //    else
                    //    {
                    //        TBO_EndMonth.Text = (Convert.ToInt32(TBO_EndMonth.Text) + 1).ToString();
                    //    }
                    //}
                    
                }
            }
        }

        private void DPI_StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TBO_StartYear.Text = Convert.ToDateTime(DPI_StartDate.Text).Year.ToString();
            TBO_StartMonth.Text = Convert.ToDateTime(DPI_StartDate.Text).Month.ToString();
            TBO_StartDay.Text = Convert.ToDateTime(DPI_StartDate.Text).Day.ToString();
        }

        private void DPI_ChangedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //TBO_ChangedYear.Text = Convert.ToDateTime(DPI_ChangedDate.Text).Year.ToString();
            //TBO_ChangedMonth.Text = Convert.ToDateTime(DPI_ChangedDate.Text).Month.ToString();
            //TBO_ChangedDay.Text = Convert.ToDateTime(DPI_ChangedDate.Text).Day.ToString();
        }

        private void BTN_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Escape_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Close();
        }
    }
}
