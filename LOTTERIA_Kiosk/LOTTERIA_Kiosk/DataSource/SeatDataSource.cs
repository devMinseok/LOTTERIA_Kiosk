using LOTTERIA_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.DataSource
{
    public class SeatDataSource
    {
        bool isLoaded = false;
        public List<Seat> listSeat = null;
        readonly int NUMBER_OF_TABLE = 9;

        public void Load()
        {
            if (isLoaded)
            {
                return;
            }

            listSeat = new List<Seat>();
            for (int i = 0; i < NUMBER_OF_TABLE; i++)
            {
                Seat seat = new Seat();
                seat.Number = i;
                seat.IsUsed = false;

                listSeat.Add(seat);
            }

            isLoaded = true;
        }
    }
}
