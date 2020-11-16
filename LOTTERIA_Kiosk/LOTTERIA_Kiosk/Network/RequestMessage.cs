using LOTTERIA_Kiosk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LOTTERIA_Kiosk.Network
{
    public class RequestMessage
    {
        public MessageType MSGType { get; set; }
        public string Id { get; set; }
        public string Content { get; set; }
        public string ShopName { get; set; }
        public string OrderNumber { get; set; }
        public bool Group { get; set; }
        public List<OrderMenu> Menus = new List<OrderMenu>();
    }
    public class OrderMenu
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
