using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
            lbMenuCategory.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(lbMenuCategory_MouseLeftButtonDown), true);
        }

        public static int Page = 1;
        public static int Cell = 9;
        static List<Food> FoodData = App.FoodData.foodList;

        private void Order_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryButton();

            LoadMenuList();
        }

        private void lbMenus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Food food = lbMenus.SelectedItem as Food;
            
            if (food != null) {
                AddSelectedMenu(food);
                lbMenus.SelectedIndex = -1;
            }
        }

        private void lbMenuCategory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Page = 1;
            MenuCategory selectedCategory = (MenuCategory)lbMenuCategory.SelectedValue;

            SetLbMenusItem(selectedCategory);
        }

        private void SetLbMenusItem(MenuCategory category)
        {
            FoodData = App.FoodData.foodList.FindAll(x => x.Category == category);
            LoadLbMenus();
            LoadMenuList();
        }

        public void AddSelectedMenu(Food food)
        {
            if (App.SelectedMenuList.Exists(x => x.Name == food.Name))
            {
                App.SelectedMenuList.Find(x => x.Name == food.Name).Count++;
            }
            else
            {
                Food selectedFood = new Food();
                selectedFood.Name = food.Name;
                selectedFood.ImagePath = food.ImagePath;
                Console.WriteLine(food.Price);
                selectedFood.Price = food.Price;
                selectedFood.Category = food.Category;
                selectedFood.Count = food.Count;

                App.SelectedMenuList.Add(selectedFood);
            }

            LoadMenuList();
        }

        public void LoadLbMenus()
        {
            lbMenus.Items.Clear();

            int start = (Page - 1) * Cell;
            int end = start + 9;

            for (int i = start; i < end; i++)
            {
                if (i <= FoodData.Count - 1)
                {
                    lbMenus.Items.Add(FoodData[i]);
                } else
                {
                    return;
                }
            }
        }

    public void LoadMenuList()
        {
            lvOrderList.ItemsSource = App.SelectedMenuList;
            lvOrderList.Items.Refresh();
            tbTotalPrice.Text = GetTotalPrice().ToString();
        }

        public void LoadCategoryButton()
        {
            InitializeComponent();
            lbMenuCategory.ItemsSource = typeof(MenuCategory).GetEnumValues();
            SetLbMenusItem(MenuCategory.햄버거); // 초기 선택
        }

        private static Food ListView_GetItem(RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while(!(dep is System.Windows.Controls.ListViewItem))
            {
                try
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                catch 
                {
                    return null;
                }
            }
            ListViewItem item = (ListViewItem)dep;
            Food content = (Food)item.Content;
            return content;
        }

        private void MinusMenuCount(object sender, RoutedEventArgs e)
        {
            Food food = ListView_GetItem(e);
            food.Count -= 1;

            if (food.Count < 1)
            {
                App.SelectedMenuList.Remove(food);
                food.Count = 1;
            }

            LoadMenuList();
        }

        private void PlusFoodCount(object sender, RoutedEventArgs e)
        {
            Food food = ListView_GetItem(e);
            food.Count += 1;
            LoadMenuList();
        }

        private double GetTotalPrice()
        {
            double total = 0;
            foreach (Food food in App.SelectedMenuList)
            {
                total += food.Price;
            }

            return total;
        }

        private void OrderReset(object sender, RoutedEventArgs e)
        {
            if (App.SelectedMenuList.Count < 1)
            {
                MessageBox.Show("먼저 메뉴를 선택해주세요.", "롯데리아");
                return;
            }

            if (MessageBox.Show("주문 내용을 전부 삭제하시겠습니까?", "롯데리아", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.SelectedMenuList.Clear();

                LoadMenuList();

                MessageBox.Show("삭제되었습니다.", "롯데리아");
            }
            else
            {
                MessageBox.Show("취소되었습니다.", "롯데리아");
            }
        }

        private void OrderCancel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("주문을 취소하시겠습니까?", "롯데리아", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Uri("/View/Home.xaml", UriKind.Relative));
                App.SelectedMenuList.Clear();
            } else
            {
                MessageBox.Show("취소되었습니다.", "롯데리아");
            }
        }

        private void OrderNext(object sender, RoutedEventArgs e)
        {
            if (App.SelectedMenuList.Count == 0)
            {
                MessageBox.Show("먼저 메뉴를 선택해주세요.", "롯데리아");
            } else
            {
                NavigationService.Navigate(new Uri("/View/MealPlaceSelect.xaml", UriKind.Relative));
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page -= 1;
                LoadLbMenus();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (FoodData.Count >= Page * Cell)
            {
                Page += 1;
                LoadLbMenus();
            }
        }
    }
}
