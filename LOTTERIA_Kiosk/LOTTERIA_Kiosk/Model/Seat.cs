using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class Seat
    {
        /// <summary>
        /// 좌석 번호
        /// </summary>
        public int Number { get; set; } 

        /// <summary>
        /// 사용 여부
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// 결제 시간
        /// </summary>
        public DateTime PaymentTime { get; set; }

        /// <summary>
        /// 메뉴 판매 기록 (관리자 메뉴용)
        /// </summary>
        public List<Food> FoodLog { get; set; }
    }
}
