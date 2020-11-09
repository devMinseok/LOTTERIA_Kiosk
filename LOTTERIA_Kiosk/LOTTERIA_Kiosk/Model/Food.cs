using LOTTERIA_Kiosk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class Food
    {
        /// <summary>
        /// 음식명
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 음식 가격
        /// 할인율, 갯수를 반영한 값을 반환
        /// </summary>
        private int price;
        public int Price {
            get
            {
                int discountRateDecimal = DiscountRate / 100;
                int value = price * discountRateDecimal;
                int result = price - value;
                return result * Count;
            }
            set
            {
                price = value;
            }
        }

        /// <summary>
        /// 음식 주문 갯수
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 음식 이미지 경로
        /// </summary>
        public String ImagePath { get; set; }

        /// <summary>
        /// 음식 카테고리
        /// </summary>
        public MenuCategory Category { get; set; }

        /// <summary>
        /// 음식 할인율
        /// </summary>
        public int DiscountRate { get; set; }
    }
}
