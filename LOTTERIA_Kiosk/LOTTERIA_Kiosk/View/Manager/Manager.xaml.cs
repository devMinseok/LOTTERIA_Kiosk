using LiveCharts.Wpf;
using LiveCharts;
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

namespace LOTTERIA_Kiosk.View.Manager
{
    /// <summary>
    /// ManagerPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
        }
        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttonSender = sender as Button;
            switch (buttonSender.Name)
            {
                case "btn_MenuStats":
                    frame_stats.Source = new Uri("MenuStats.xaml", UriKind.Relative);
                    break;

                case "btn_CategoryStats":
                    frame_stats.Source = new Uri("CategoryStats.xaml", UriKind.Relative);
                    break;

                case "btn_DateStats":
                    frame_stats.Source = new Uri("DateStats.xaml", UriKind.Relative);
                    break;

                case "btn_TodayStats":
                    frame_stats.Source = new Uri("TodayStats.xaml", UriKind.Relative);
                    break;

                case "btn_UserStats":
                    frame_stats.Source = new Uri("UserStats.xaml", UriKind.Relative);
                    break;
            }
        }
    }
}
