using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;

namespace LOTTERIA_Kiosk.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string time;

        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public MainWindowViewModel()
        {
            CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
            Time = DateTime.Now.ToString(string.Format("yyyy년 MM월 dd일 ddd요일 tthh시 mm분 ", cultures));
        }

        // HomeCommand
        private ICommand homeCommand;
        public ICommand HomeCommand
        {
            get { return (this.homeCommand) ?? (this.homeCommand = new DelegateCommand(NavigateHome)); }
        }
        private void NavigateHome()
        {
            // 홈 화면 이동 로직
        }


    }
}
