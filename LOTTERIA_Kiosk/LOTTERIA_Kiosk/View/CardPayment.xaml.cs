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
    /// CardPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPayment : Page
    {
        Boolean isRecognition = false;
        public CardPayment()
        {
            InitializeComponent();

            webcam.CameraIndex = 0;
            tbTotalPrice.Text = GetTotalPrice().ToString();
        }

        private void webcam_QrDecoded(object sender, string e) {
            isRecognition = true;
            tbRecog.Text = e;
        }



        private void btn_before_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
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

        private void btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            if(!isRecognition)
            {
                MessageBox.Show("QR코드를 인식해주세요.", "롯데리아");
            }
            else
            {
                NavigationService.Navigate(new Uri("/View/PaymentCompleted.xaml", UriKind.Relative));
            }
        }
    }
}
