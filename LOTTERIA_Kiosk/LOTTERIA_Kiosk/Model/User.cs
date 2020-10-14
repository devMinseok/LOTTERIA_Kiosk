using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class User
    {
        /// <summary>
        /// 사용자 아이디
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 사용자명
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 사용자 카드번호
        /// </summary>
        public String Card { get; set; }

        /// <summary>
        /// 사용자 현금 영수증 카드번호
        /// </summary>
        public String CashReceiptCard { get; set; }

        /// <summary>
        /// 여태까지 주문한 메뉴목록 (관리자 메뉴용)
        /// </summary>
        public List<Food> FoodHistory { get; set; }
    }
}
