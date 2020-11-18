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
        private double price;
        public double Price {
            get
            {
                double discountRateDecimal = (double)DiscountRate / 100;
                double value = price * discountRateDecimal;
                double result = price - value;
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

        /// <summary>
        /// 할인 여부
        /// </summary>
        public bool IsDiscount
        {
            get
            {
                return DiscountRate > 0;
            }
            set
            {

            }
        }

        /// <summary>
        /// 품절 여부
        /// </summary>
        public bool IsSoldOut { get; set; }

    }
}
