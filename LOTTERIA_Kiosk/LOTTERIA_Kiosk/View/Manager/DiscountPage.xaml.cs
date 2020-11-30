using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// DiscountPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DiscountPage : Page
    {
        Food selectedFood = new Food();
        public DiscountPage()
        {
            InitializeComponent();
            Loaded += Order_Loaded;
            lbMenuCategory.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(lbMenuCategory_MouseLeftButtonDown), true);
        }
        private void Order_Loaded(object sender, RoutedEventArgs e)
        {
            lbMenus.ItemsSource = App.FoodData.foodList;

            LoadCategoryButton();
        }
        public void LoadCategoryButton()
        {
            InitializeComponent();
            Array valArray = typeof(MenuCategory).GetEnumValues();
            foreach (MenuCategory menuCategory in valArray)
            {
                lbMenuCategory.Items.Add(menuCategory);
            }
            SetLbMenusItem(MenuCategory.햄버거); // 초기 선택

        }
        private void lbMenuCategory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuCategory selectedCategory = (MenuCategory)lbMenuCategory.SelectedValue;

            SetLbMenusItem(selectedCategory);
        }
        private void SetLbMenusItem(MenuCategory category)
        {
            lbMenus.ItemsSource = App.FoodData.foodList.FindAll(x => x.Category == category);
        }
        private void lbMenus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedFood = lbMenus.SelectedItem as Food;

            if (selectedFood != null)
            {
                SelectedImage.DataContext = selectedFood;
                SelectedText.DataContext = selectedFood;
                SelectedPrice.DataContext = selectedFood;
                SelectedDiscount.DataContext = selectedFood;
            }
        }

        private void SelectedDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_applyDiscount_Click(object sender, RoutedEventArgs e)
        {
            selectedFood.DiscountRate = int.Parse(SelectedDiscount.Text);
        }

        private void btn_soldOut_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFood.IsSoldOut)
            {
                selectedFood.IsSoldOut = false;
            }
            else
            {
                selectedFood.IsSoldOut = true;
            }
        }
    }
}
