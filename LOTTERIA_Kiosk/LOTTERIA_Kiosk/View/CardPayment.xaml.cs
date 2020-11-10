using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using Newtonsoft.Json.Linq;

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// CardPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPayment : Page
    {
        Boolean isRecognition = false;
        List<string> userList = new List<string>();
        public CardPayment()
        {
            InitializeComponent();
            tbNotUser.Visibility = Visibility.Hidden;

            userList.Add("신희송");
            userList.Add("정재덕");
            userList.Add("크리스");

            webcam.CameraIndex = 0;
            btn_Pay.Visibility = Visibility.Hidden;
            tbTotalPrice.Text = GetTotalPrice().ToString();
            webcam.QrDecoded += webcam_QrDecoded;


        }

        private void webcam_QrDecoded(object sender, string e) {

            isRecognition = true;
            
            bool isUser = false;

            btn_Pay.Visibility = Visibility.Hidden;


            foreach (string i in userList)
            {
                if(e == i)
                {
                    tbNotUser.Visibility = Visibility.Hidden;
                    tbRecog.Text = e;
                    btn_Pay.Visibility = Visibility.Visible;
                    isUser = true;
                }
            }
            if (!isUser)
            {
                tbNotUser.Visibility = Visibility.Visible;
                //MessageBox.Show("등록되지 않은 회원입니다.", "롯데리아");
            }
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
