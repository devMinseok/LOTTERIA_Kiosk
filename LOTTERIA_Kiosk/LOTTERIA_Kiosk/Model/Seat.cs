using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class Seat
    {
        // 좌석 번호
        public int Number { get; set; } 

        // 사용 여부
        public bool IsUsed { get; set; }

        // 결제 시간
        public DateTime PaymentTime { get; set; }

        // 메뉴 판매 기록 (관리자 메뉴용)
        public List<Food> FoodLog { get; set; }
    }
}
