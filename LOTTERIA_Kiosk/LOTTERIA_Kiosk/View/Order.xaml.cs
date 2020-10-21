using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Model;
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

        private void lbMenus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Food food = lbMenus.SelectedItem as Food;
            
            AddSelectedMenu(food);
        }

        public void AddSelectedMenu(Food food)
        {
            if (App.SelectedMenuList.Exists(x => x.Name == food.Name))
            {
                App.SelectedMenuList.Find(x => x.Name == food.Name).Count++;
            }
            else
            {
                food.Count = 1;
                App.SelectedMenuList.Add(food);
            }

            LoadMenuList();
        }

        public void LoadMenuList()
        {
            lvOrderList.ItemsSource = App.SelectedMenuList;
            lvOrderList.Items.Refresh();
        }

        public void MinusMenuCount(object sender, RoutedEventArgs e)
        {

        }

        public void PlusFoodCount(object sender, RoutedEventArgs e)
        {

        }


    }
}
