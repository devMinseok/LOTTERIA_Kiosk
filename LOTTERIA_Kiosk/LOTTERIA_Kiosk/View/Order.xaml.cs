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

        /// <summary>
        /// 메뉴 리스트박스 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMenus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Food food = lbMenus.SelectedItem as Food;
            
            if (food != null) {
                AddSelectedMenu(food);
                lbMenus.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 메뉴 카테고리 리스트박스 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMenuCategory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Page = 1;
            MenuCategory selectedCategory = (MenuCategory)lbMenuCategory.SelectedValue;

            SetLbMenusItem(selectedCategory);
        }

        /// <summary>
        /// 메뉴 리스트박스 아이템 설정
        /// </summary>
        /// <param name="category"></param>
        private void SetLbMenusItem(MenuCategory category)
        {
            FoodData = App.FoodData.foodList.FindAll(x => x.Category == category);
            LoadLbMenus();
            LoadMenuList();
        }

        /// <summary>
        /// 선택한 메뉴 추가
        /// </summary>
        /// <param name="food"></param>
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

        /// <summary>
        /// 메뉴 리스트박스 로드
        /// </summary>
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
        
        /// <summary>
        /// 선택한 메뉴 리스트 로드
        /// </summary>
        public void LoadMenuList()
        {
            lvOrderList.ItemsSource = App.SelectedMenuList;
            lvOrderList.Items.Refresh();
            tbTotalPrice.Text = GetTotalPrice().ToString();
        }
        
        /// <summary>
        /// 메뉴 카테고리 버튼 로드
        /// </summary>
        public void LoadCategoryButton()
        {
            InitializeComponent();
            lbMenuCategory.ItemsSource = typeof(MenuCategory).GetEnumValues();
            SetLbMenusItem(MenuCategory.햄버거); // 초기 선택
        }

        /// <summary>
        /// 리스트뷰의 선택한 아이템을 가져오는 메서드
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 선택한 메뉴의 수량을 감소시키는 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 선택한 메뉴의 수량을 증가시키는 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusFoodCount(object sender, RoutedEventArgs e)
        {
            Food food = ListView_GetItem(e);
            food.Count += 1;
            LoadMenuList();
        }

        /// <summary>
        /// 선택한 메뉴의 총 가격을 반환하는 메서드
        /// </summary>
        /// <returns></returns>
        private double GetTotalPrice()
        {
            double total = 0;
            foreach (Food food in App.SelectedMenuList)
            {
                total += food.Price;
            }

            return total;
        }

        /// <summary>
        /// 선택한 메뉴 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 주문 취소 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 다음 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 메뉴리스트 이전
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page -= 1;
                LoadLbMenus();
            }
        }

        /// <summary>
        /// 메뉴리스트 다음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
