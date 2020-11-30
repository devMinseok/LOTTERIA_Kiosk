using LOTTERIA_Kiosk.Common;
using LOTTERIA_Kiosk.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
    /// Home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Page
    {
        
        public Home()
        {
            InitializeComponent();

            this.startMedia.Play();
            this.startMedia.MediaEnded += new RoutedEventHandler(startMedia_MediaEnded);

            //tcpnet.StartClient();
            //loginClient();

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            App.tcpnet.Receive();
        }

        public void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                NavigationService.Navigate(new Uri("/View/Manager/Manager.xaml", UriKind.Relative));
            }
        }

        private void startMedia_MediaEnded(object sender, RoutedEventArgs e)
        {

            this.startMedia.Stop();

            this.startMedia.Position = TimeSpan.FromSeconds(0);

            this.startMedia.Play();

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Order.xaml", UriKind.Relative));
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Manager/Manager.xaml", UriKind.Relative));
        }

        
        private void loginClient()
        {
            RequestMessage requestJson = new RequestMessage();

            requestJson.MSGType = 0;
            requestJson.Id = "2113";
            requestJson.Content = "";
            requestJson.ShopName = "";
            requestJson.OrderNumber = "";
            requestJson.Menus = null;

            string json = JsonConvert.SerializeObject(requestJson);
            App.tcpnet.Send(json);
        }
    }
}
