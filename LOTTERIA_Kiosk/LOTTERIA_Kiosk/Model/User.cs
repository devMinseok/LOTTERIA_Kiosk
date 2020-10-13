using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    class User
    {
        // 사용자 아이디
        public String Id { get; set; }

        // 사용자명
        public String Name { get; set; }

        // 사용자 카드번호
        public String Card { get; set; }

        // 사용자 현금 영수증 카드번호
        public String CashReceiptCard { get; set; }

        // 여태까지 주문한 메뉴목록 (관리자 메뉴용)
        public List<Food> FoodHistory { get; set; }
    }
}
