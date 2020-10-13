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

            this.DataContext = new ViewModels.MainWindowViewModel();
        }


        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Button buttonSender = sender as Button;

            switch (buttonSender.Content)
            {
                case "Home":
                    frame_content.Source = new Uri("/Views/Home/Home.xaml", UriKind.Relative);
                    break;
                case "Order":
                    frame_content.Source = new Uri("/Views/Order/Order.xaml", UriKind.Relative);
                    break;

                case "MealPlaceSelect":
                    frame_content.Source = new Uri("/Views/MealPlaceSelect/MealPlaceSelect.xaml", UriKind.Relative);
                    break;

                case "SeatSelect":
                    frame_content.Source = new Uri("/Views/SeatSelect/SeatSelect.xaml", UriKind.Relative);
                    break;

                case "PaymentSelect":
                    frame_content.Source = new Uri("/Views/PaymentSelect/PaymentSelect.xaml", UriKind.Relative);
                    break;

                case "CashPayment":
                    frame_content.Source = new Uri("/Views/CashPayment/CashPayment.xaml", UriKind.Relative);
                    break;

                case "CardPayment":
                    frame_content.Source = new Uri("/Views/CardPayment/CardPayment.xaml", UriKind.Relative);
                    break;

                case "PaymentCompleted":
                    frame_content.Source = new Uri("/Views/PaymentCompleted/PaymentCompleted.xaml", UriKind.Relative);
                    break;

                case "Manager":
                    frame_content.Source = new Uri("/Views/Manager/Manager.xaml", UriKind.Relative);
                    break;

                default:
                    break;
            }

        }



    }
}
