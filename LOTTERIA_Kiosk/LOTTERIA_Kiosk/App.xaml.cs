using LOTTERIA_Kiosk.DataSource;
using LOTTERIA_Kiosk.Model;
using LOTTERIA_Kiosk.Network;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LOTTERIA_Kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 주문 화면에서 선택한 메뉴 리스트
        /// </summary>
        public static List<Food> SelectedMenuList = new List<Food>();

        /// <summary>
        /// 좌석 데이터 소스
        /// </summary>
        public static SeatDataSource SeatData = new SeatDataSource();

        /// <summary>
        /// 메뉴 데이터 소스
        /// </summary>
        public static MenuDataSource FoodData = new MenuDataSource();

        /// <summary>
        /// 주문 정보 데이터
        /// </summary>
        public static List<OrderInfo> OrderInfoData = new List<OrderInfo>();
        
        /// <summary>
        /// 현재 사용자 데이터
        /// </summary>
        public static User CurrentUser = new User();

        /// <summary>
        /// 현재 사용자 데이터
        /// </summary>
        public static bool isLogin = false;

        public static TCPNet tcpnet = new TCPNet();

    }
}
