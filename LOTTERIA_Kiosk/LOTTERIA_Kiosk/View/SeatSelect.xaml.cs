using System;
using LOTTERIA_Kiosk.View;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Navigation;
using System.Timers;
using LOTTERIA_Kiosk.Model;

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// SeatSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeatSelect : Page
    {
        int table = 0;

        bool first = true;

        System.Windows.Threading.DispatcherTimer TimerClock = new System.Windows.Threading.DispatcherTimer();
        public SeatSelect()
        {
            InitializeComponent();
            Loaded += SeatSelect_Loaded;
        }

        private void SeatSelect_Loaded(object sender, RoutedEventArgs e)
        {
            lvTable.ItemsSource = App.SeatData.listSeat;
        }

        private void lvTableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedTable = (Seat)lvTable.SelectedItem;
            if (selectedTable.IsUsed && !first)
            {
                MessageBox.Show("사용중인 테이블 입니다.");
                return;
            }
            
            else if (table != 0)
            {
                first = false;
                App.SeatData.listSeat[table - 1].IsUsed = false;
                selectedTable.IsUsed = true;
                table = selectedTable.Number;
            }
            else
            {
                //first = false;
                selectedTable.IsUsed = true;
                table = selectedTable.Number;
                table = selectedTable.Number;
            }

        }

        public void Before_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            App.SeatData.listSeat[table - 1].IsUsed = false;
        }

    public void Next_Click(object sender, RoutedEventArgs e)
    {
            if (table == 0)
            {
                MessageBox.Show("테이블을 선택하세요.");
                
            }
            //App.OrderInfoData[App.OrderInfoData.Count - 1].SelectedSeat.Number = table;
        NavigationService.Navigate(new Uri("/View/PaymentSelect.xaml", UriKind.Relative));
    }
        /*private void StartTimer()
        {
            
            TimerClock.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 200 milliseconds
            TimerClock.IsEnabled = true;
            TimerClock.Tick += new EventHandler(TimerClock_Tick);

        }*/


        /* 시간 표시 함수
        private void SetTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_tick;
            timer.Start();
        }*/

        void TimerClock_Tick(object sender, EventArgs e)
        {
            //1분 타이머
        }

    }
}
 