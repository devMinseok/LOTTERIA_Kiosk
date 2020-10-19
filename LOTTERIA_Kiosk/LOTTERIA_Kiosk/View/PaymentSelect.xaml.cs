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
            App.SelectedMenuList.Add(new Food() { Name = "불고기버거", Count = 3, Price = 4000 });
            App.SelectedMenuList.Add(new Food() { Name = "니얼굴버거", Count = 2, Price = 12354 });
            App.SelectedMenuList.Add(new Food() { Name = "덩기덕쿵더러러", Count = 6, Price = 122112 });
            App.SelectedMenuList.Add(new Food() { Name = "대취타하라던데", Count = 1, Price = 116122 });

            menuList.ItemsSource = App.SelectedMenuList;
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
    }
}
