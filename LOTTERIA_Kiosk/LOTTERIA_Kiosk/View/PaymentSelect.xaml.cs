using LOTTERIA_Kiosk.Model;
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
    /// PaymentSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PaymentSelect : Page
    {
        public PaymentSelect()
        {
            InitializeComponent();

            menuList.ItemsSource = App.SelectedMenuList;
            tbTotalPrice.Text = GetTotalPrice().ToString();
        }

        private int GetTotalPrice()
        {
            int total = 0;
            foreach (Food food in App.SelectedMenuList)
            {
                total += food.Count * food.Price;
            }

            return total;
        }

        private void btn_cashpay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/CashPayment.xaml", UriKind.Relative));
        }

        private void btn_cardpay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/CardPayment.xaml", UriKind.Relative));
        }

        private void btn_before_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void btn_before_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
