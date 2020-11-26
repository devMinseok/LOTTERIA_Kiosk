using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Model
{
    public class Seat: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 좌석 번호
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 사용 여부
        /// </summary>
        private bool _isUsed = false;
        public bool IsUsed
        {
            get => _isUsed;
            set
            {
                _isUsed = value;
                NotifyPropertyChanged(nameof(IsUsed));
            }
        }

        /// <summary>
        /// 결제 시간
        /// </summary>
        public DateTime PaymentTime { get; set; }
    }
}
