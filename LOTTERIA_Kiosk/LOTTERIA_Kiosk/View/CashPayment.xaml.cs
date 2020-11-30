using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// CashPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashPayment : Page
    {
        List<string> barcodeValList = new List<string>();
        public CashPayment()
        {
            InitializeComponent();
            barcodeValList.Add("2112345678900");
            barcodeValList.Add("02345673");
            barcodeValList.Add("9790260532113");
            barcode_text.Focus();
            tbTotalPrice.Text = GetTotalPrice().ToString();
        }
        private double GetTotalPrice()
        {
            double total = 0;
            foreach (Food food in App.SelectedMenuList)
            {
                total += food.Count * food.Price;
            }

            return total;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                foreach (string i in barcodeValList)
                {
                    if (i == barcode_text.Text)
                    {
                        App.CurrentUser.CashReceiptCard = barcode_text.Text;
                        NavigationService.Navigate(new Uri("/View/PaymentCompleted.xaml", UriKind.Relative));
                    }
                    else
                    {
                        
                    }
                }
                barcode_text.Text = "";
            }
        }
    }
}
