using LOTTERIA_Kiosk.Common;
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
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();

            Loaded += Order_Loaded;
        }

        private void Order_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.Load();
            App.SeatData.Load();

            lbMenus.ItemsSource = App.FoodData.foodList;
        }

        private void SetLvFoodItem(MenuCategory category)
        {
            lbMenus.ItemsSource = App.FoodData.foodList.FindAll(x => x.Category == category);
        }

    }
}
