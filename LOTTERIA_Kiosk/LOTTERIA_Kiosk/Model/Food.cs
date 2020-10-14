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
        // 음식명
        public String Name { get; set; }

        // 음식 가격
        public int Price { get; set; }

        // 음식 주문 갯수
        public int Count { get; set; }

        // 음식 이미지 경로
        public String ImagePath { get; set; }

        // 음식 카테고리
        public MenuCategory Category { get; set; }
    }
}
