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
        /// </summary>
        public int Price { get; set; }

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
    }
}
