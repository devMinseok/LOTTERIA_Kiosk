using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LOTTERIA_Kiosk.View
{
    /// <summary>
    /// CardPayment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPayment : Page
    {
        public CardPayment()
        {
            InitializeComponent();

            this.startMedia.Play();
            this.startMedia.MediaEnded += new RoutedEventHandler(startMedia_MediaEnded);

        }
        private void startMedia_MediaEnded(object sender, RoutedEventArgs e)

        {

            this.startMedia.Stop();

            this.startMedia.Position = TimeSpan.FromSeconds(0);

            this.startMedia.Play();

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Order/Order.xaml", UriKind.Relative));
        }
    }
}
