using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.DataSource
{
    public class MenuDataSource
    {
        bool isLoaded = false;
        public List<Food> foodList = null;
        public int todaySales = 0;

        public void Load()
        {
            if (isLoaded)
            {
                return;
            }

            foodList = new List<Food>()
            {
                // 햄버거
                new Food() { Category = MenuCategory.햄버거, Name = "AZ버거", Price = 6600, ImagePath = @"/Assets/Menu/Hamburger/AZ버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "T-Rex", Price = 3700, ImagePath = @"/Assets/Menu/Hamburger/T-Rex.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "더블X2", Price =  5500, ImagePath = @"/Assets/Menu/Hamburger/더블X2.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "데리버거", Price = 2500, ImagePath = @"/Assets/Menu/Hamburger/데리버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "리아미라클버거", Price = 5600, ImagePath = @"/Assets/Menu/Hamburger/리아미라클버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "모짜렐라 인 더 버거", Price = 6000, ImagePath = @"/Assets/Menu/Hamburger/모짜렐라 인 더 버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "밀리터리 버거", Price = 6400, ImagePath = @"/Assets/Menu/Hamburger/밀리터리 버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "불고기 버거", Price = 3900, ImagePath = @"/Assets/Menu/Hamburger/불고기버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "빅불", Price = 5800, ImagePath = @"/Assets/Menu/Hamburger/빅불.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "새우버거", Price = 3900, ImagePath = @"/Assets/Menu/Hamburger/새우버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "와규에디션II", Price = 5800, ImagePath = @"/Assets/Menu/Hamburger/와규에디션II.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "치킨버거", Price = 2900, ImagePath = @"/Assets/Menu/Hamburger/치킨버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "클래식 치즈버거", Price = 4400, ImagePath = @"/Assets/Menu/Hamburger/클래식 치즈버거.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "폴더버거 비프", Price = 5700, ImagePath = @"/Assets/Menu/Hamburger/폴더버거 비프.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "폴더버거 핫치킨", Price = 5700, ImagePath = @"/Assets/Menu/Hamburger/폴더버거 핫치킨.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "한우불고기", Price = 7000, ImagePath = @"/Assets/Menu/Hamburger/한우불고기.jpg" },
                new Food() { Category = MenuCategory.햄버거, Name = "핫크리스피버거", Price = 4900, ImagePath = @"/Assets/Menu/Hamburger/핫크리스피버거.jpg" },

                // 음료수
                new Food() { Category = MenuCategory.음료수, Name = "레몬에이드", Price = 2500, ImagePath = @"/Assets/Menu/Drink/레몬에이드.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "밀크쉐이크(딸기)", Price = 2100, ImagePath = @"/Assets/Menu/Drink/밀크쉐이크(딸기).jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "밀크쉐이크(바닐라)", Price = 2100, ImagePath = @"/Assets/Menu/Drink/밀크쉐이크(바닐라).jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "밀크쉐이크(초코)", Price = 2100, ImagePath = @"/Assets/Menu/Drink/밀크쉐이크(초코).jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "사이다", Price = 1700, ImagePath = @"/Assets/Menu/Drink/사이다.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "아메리카노", Price = 2000, ImagePath = @"/Assets/Menu/Drink/아메리카노.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "아이스 아메리카노", Price = 2000, ImagePath = @"/Assets/Menu/Drink/아이스 아메리카노.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "아이스 카페라떼", Price = 2400, ImagePath = @"/Assets/Menu/Drink/아이스 카페라떼.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "아이스티", Price = 2200, ImagePath = @"/Assets/Menu/Drink/아이스티.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "오렌지주스", Price = 2500, ImagePath = @"/Assets/Menu/Drink/오렌지주스.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "우유", Price = 1500, ImagePath = @"/Assets/Menu/Drink/우유.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "카페라떼", Price = 2400, ImagePath = @"/Assets/Menu/Drink/카페라떼.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "콜라", Price = 1700, ImagePath = @"/Assets/Menu/Drink/콜라.jpg" },
                new Food() { Category = MenuCategory.음료수, Name = "핫초코", Price = 2000, ImagePath = @"/Assets/Menu/Drink/핫초코.jpg" },    

                // 디저트
                new Food() { Category = MenuCategory.디저트, Name = "롱 치즈스틱", Price = 1800, ImagePath = @"/Assets/Menu/Desert/롱 치즈스틱.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "선데이아이스크림(스트로베리)", Price = 1500, ImagePath = @"/Assets/Menu/Desert/선데이아이스크림(스트로베리).jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "소프트콘", Price = 700, ImagePath = @"/Assets/Menu/Desert/소프트콘.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "쉑쉑치킨", Price = 2500, ImagePath = @"/Assets/Menu/Desert/쉑쉑치킨.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "양념감자", Price = 2000, ImagePath = @"/Assets/Menu/Desert/양념감자.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "오징어링", Price = 2200, ImagePath = @"/Assets/Menu/Desert/오징어링.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "지파이 고소한맛", Price = 3400, ImagePath = @"/Assets/Menu/Desert/지파이 고소한맛.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "지파이 하바네로", Price = 4300, ImagePath = @"/Assets/Menu/Desert/지파이 하바네로.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "찐氷", Price = 3800, ImagePath = @"/Assets/Menu/Desert/찐氷.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "치즈스틱", Price = 2000, ImagePath = @"/Assets/Menu/Desert/치즈스틱.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "치즈인더에그", Price = 3000, ImagePath = @"/Assets/Menu/Desert/치즈인더에그.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "치킨 너겟", Price = 1200, ImagePath = @"/Assets/Menu/Desert/치킨 너겟.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "콘샐러드", Price = 1700, ImagePath = @"/Assets/Menu/Desert/콘샐러드.jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "토네이도(녹차)", Price = 2300, ImagePath = @"/Assets/Menu/Desert/토네이도(녹차).jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "토네이도(스트로베리)", Price = 2400, ImagePath = @"/Assets/Menu/Desert/토네이도(스트로베리).jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "토네이도(초코쿠키)", Price = 2300, ImagePath = @"/Assets/Menu/Desert/토네이도(초코쿠기).jpg" },
                new Food() { Category = MenuCategory.디저트, Name = "포테이토", Price = 1500, ImagePath = @"/Assets/Menu/Desert/포테이토.jpg" },

                // 치킨
                new Food() { Category = MenuCategory.치킨, Name = "1인혼닭", Price = 10000, ImagePath = @"/Assets/Menu/Chicken/1인혼닭.jpg" },
                new Food() { Category = MenuCategory.치킨, Name = "치킨1조각", Price = 2300, ImagePath = @"/Assets/Menu/Chicken/치킨1조각.jpg" },
                new Food() { Category = MenuCategory.치킨, Name = "치킨휠레", Price = 4500, ImagePath = @"/Assets/Menu/Chicken/치킨휠레.jpg" },
                new Food() { Category = MenuCategory.치킨, Name = "화이어윙", Price = 4500, ImagePath = @"/Assets/Menu/Chicken/화이어윙.jpg" }
            };
        }
    }
}
