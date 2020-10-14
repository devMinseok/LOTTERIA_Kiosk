using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class OrderInfo
    {
        /// <summary>
        /// 주문 번호
        /// </summary>
        public int OrderNumber { get; set; } 

        /// <summary>
        /// 주문자 정보
        /// </summary>
        public User UserInfo { get; set; }

        /// <summary>
        /// 주문한 음식 목록
        /// </summary>
        public List<Food> OrderedFoodList { get; set; }

        /// <summary>
        /// 선택한 좌석
        /// </summary>
        public Seat SelectedSeat { get; set; }
    }
}
