using LiveCharts;
using LiveCharts.Wpf;
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
    /// Manager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManagerPage: Page
    {
        public ManagerPage()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "버거",
                    Values = new ChartValues<double> { 4500, 14500, 25000, 50000 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "와퍼",
                Values = new ChartValues<double> { 1100, 56000, 42000, 12000 }
            });

            //also adding values updates and animates the chart automatically

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void stats_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
