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
using System.Windows.Threading;

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// PaymentCompleted.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PaymentCompleted : Page
    {
        System.Windows.Threading.DispatcherTimer TimerClock = new System.Windows.Threading.DispatcherTimer();
        int timerValue = 4;
        public PaymentCompleted()
        {
            InitializeComponent();
            tbTotalPrice.Text = GetTotalPrice().ToString();
            //text.Text = App.CurrentUser.CashReceiptCard;
            App.SelectedMenuList.Clear();
            tb_orderNumber.Text = "002";
            autoMoveValue.Text = "5";
            StartTimer();
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

        private void btn_GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Home.xaml", UriKind.Relative));
            TimerClock.Stop();
            
        }

        private void StartTimer()
        {
            TimerClock.Interval = new TimeSpan(0, 0, 0, 0, 1000);

            TimerClock.IsEnabled = true;

            TimerClock.Tick += new EventHandler(TimerClock_Tick);

        }
        void TimerClock_Tick(object sender, EventArgs e)

        {

            if(timerValue == 0)
            {
                NavigationService.Navigate(new Uri("/View/Home.xaml", UriKind.Relative));
                TimerClock.Stop();
            }

            else
            {
                autoMoveValue.Text = timerValue--.ToString();
            }
        }
    }
}
