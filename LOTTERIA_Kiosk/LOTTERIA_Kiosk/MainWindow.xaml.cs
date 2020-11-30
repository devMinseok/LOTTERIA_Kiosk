using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Network;
using LOTTERIA_Kiosk.Properties;
using Newtonsoft.Json;
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
using System.Windows.Threading;

namespace LOTTERIA_Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;

            //App.tcpnet.StartClient();

            //if (!App.isLogin)
            //{
            //    frame_content.Source = new Uri("/View/LoginPage.xaml", UriKind.Relative);
            //}
            //App.tcpnet.ReceiveThread = new Thread(new ThreadStart(App.tcpnet.Receive));
            //App.tcpnet.ReceiveThread.Start();

            DatabaseMana
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("Assets/logo.png");
            splashScreen.Show(true);
            Thread.Sleep(100);

            App.FoodData.Load();
            App.SeatData.Load();

            SetTimer();

            splashScreen.Show(false);
        }

        private void loginClient()
        {
            RequestMessage requestJson = new RequestMessage
            {
                MSGType = MessageType.로그인,
                Id = "2113",
                Content = "로그인",
                ShopName = "",
                OrderNumber = "",
                Group = false,
                Menus = null
            };

            string json = JsonConvert.SerializeObject(requestJson);
            App.tcpnet.Send(json);
        }


        private void Timer_tick(object sender, EventArgs e)
        {
            currentTimeTB.Text = DateTime.Now.ToString("F");
        }

        // 시간 표시 함수
        private void SetTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_tick;
            timer.Start();
        }

        private void DevButtonClick(object sender, RoutedEventArgs e)
        {
            Button buttonSender = sender as Button;
            switch (buttonSender.Content)
            {
                case "Home":
                    frame_content.Source = new Uri("/View/Home.xaml", UriKind.Relative);
                    break;

                case "Order":
                    frame_content.Source = new Uri("/View/Order.xaml", UriKind.Relative);
                    break;

                case "MealPlaceSelect":
                    frame_content.Source = new Uri("/View/MealPlaceSelect.xaml", UriKind.Relative);
                    break;

                case "SeatSelect":
                    frame_content.Source = new Uri("/View/SeatSelect.xaml", UriKind.Relative);
                    break;

                case "PaymentSelect":
                    frame_content.Source = new Uri("/View/PaymentSelect.xaml", UriKind.Relative);
                    break;

                case "CashPayment":
                    frame_content.Source = new Uri("/View/CashPayment.xaml", UriKind.Relative);
                    break;

                case "CardPayment":
                    frame_content.Source = new Uri("/View/CardPayment.xaml", UriKind.Relative);
                    break;

                case "PaymentCompleted":
                    frame_content.Source = new Uri("/View/PaymentCompleted.xaml", UriKind.Relative);
                    break;

                case "Manager":
                    frame_content.Source = new Uri("/View/Manager/Manager.xaml", UriKind.Relative);
                    break;

                default:
                    break;
            }

        }
        
        
    }
}
