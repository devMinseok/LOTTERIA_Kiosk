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

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// Manager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Manager : Page
    {
        public Manager()
        {
            InitializeComponent();

            CartesianChart ch = new CartesianChart();
            ch.Series = new SeriesCollection
       {
           new LineSeries
           {
               Title = "Series 1",
               Values = new ChartValues<double> { 1, 1, 2, 3 ,5 }
           }
       };
            TestGrid.Children.Add(ch);
        }
    }
}
