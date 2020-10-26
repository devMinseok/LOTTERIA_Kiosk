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

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// SeatSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeatSelect : Page
    {
        public SeatSelect()
        {
            InitializeComponent();
        }
        private void Before_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/MealPlaceSelect.xaml", UriKind.Relative));
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/PaymentSelect.xaml", UriKind.Relative));
        }
        
        

        private void Button_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void Click_Seat(object sender, RoutedEventArgs e)
        {

        }
    }
}
