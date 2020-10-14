using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    class OrderInfo
    {
        // 주문 번호
        public int OrderNumber { get; set; } 

        // 주문자 정보
        public User UserInfo { get; set; }

        // 주문한 음식 목록
        public List<Food> OrderedFoodList { get; set; }

        // 선택한 좌석
        public Seat SelectedSeat { get; set; }
    }
}
