using LiveCharts;
using LiveCharts.Wpf;
using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// MenuStats.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuStats : Page
    {
        /*public MenuStats()
        {
            InitializeComponent();

            Loaded += MenuStats_Loaded;

            DataContext = this;
        }

        private void MenuStats_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.Load();
            InitChart();
        }

        public SeriesCollection SeriesCollection { get; set; }

        private string[] _label;
        public string[] Labels
        {
            get => _label;
            set => _label = value;
        }
        public Func<double, string> Formatter { get; set; }

        void InitChart()
        {
            if (App.FoodData.foodList == null)
                return;
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "버거",
                    Values = new ChartValues<double> { 4500, 14500, 25000, 50000 }
                }
            };

            //foreach (Food food in App.FoodData.foodList)
            //{
            //    Labels.Append(food.Name);
            //}

            Labels = new[]
            {
                "Shea Ferriera",
                "Maurita Powel",
                "Scottie Brogdon",
                "Teresa Kerman",
                "Nell Venuti",
                "Anibal Brothers",
                "Anderson Dillman"
            };

            Formatter = value => value.ToString("N");

            DataContext = this;

        }
        */
        public MenuStats()
        {

        }
    }

}
