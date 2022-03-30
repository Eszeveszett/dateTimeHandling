using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dateTimeHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DateChangeWindow DCW = new DateChangeWindow();
        public MainWindow()
        {
            InitializeComponent();

            //DateTime most = DateTime.Now;

            TBO_ActualDate.Text = DateTime.Now.Date.ToString();
            DateChangeWindow DCW = new DateChangeWindow();
            DCW.ShowDialog();
        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            TBO_ActualDate.Text = DateTime.Now.ToString();

            TBO_ActualYear.Text = DateTime.Now.Year.ToString();
            TBO_ActualMonth.Text = DateTime.Now.Month.ToString();
            TBO_ActualMonthString.Text = DateTime.Now.ToString("MMMM");
            TBO_ActualDay.Text = DateTime.Now.Day.ToString();
            TBO_ActualDayString.Text = DateTime.Now.ToString("dddd");
            TBO_ActualHour.Text = DateTime.Now.Hour.ToString();
            TBO_ActualMinute.Text = DateTime.Now.Minute.ToString();
            TBO_ActualSecond.Text = DateTime.Now.Second.ToString();
        }

        private void BTN_DateChange_Click(object sender, RoutedEventArgs e)
        {
            DateChangeWindow DCW = new DateChangeWindow();
            DCW.ShowDialog();
        }

        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
