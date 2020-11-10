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

        IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse("10.80.163.112"), 0);

        IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("10.80.162.152"), 80);
        public Home()
        {
            InitializeComponent();

            this.startMedia.Play();
            this.startMedia.MediaEnded += new RoutedEventHandler(startMedia_MediaEnded);

            ConnServer();         

        }
        private void startMedia_MediaEnded(object sender, RoutedEventArgs e)

        {

            this.startMedia.Stop();

            this.startMedia.Position = TimeSpan.FromSeconds(0);

            this.startMedia.Play();

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/View/Order.xaml", UriKind.Relative));
            var json = new JObject();
            var jarray = new JArray();

            json.Add("MSGType", 0);
            json.Add("Id", "2113");
            json.Add("Content", "");
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Menus", jarray);

            byte[] a = Encoding.UTF8.GetBytes(json.ToString());

        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Manager/Manager.xaml", UriKind.Relative));
        }

        private void ConnServer()
        {
            try
            {

                TcpClient client = new TcpClient(clientAddress);
                

                client.Connect(serverAddress);
            }
            catch
            {
                MessageBox.Show("예외발생!", "롯데리아");
            }
        }
        private void Send(Socket client, String data)
        {
            var json = new JObject();
            var jarray = new JArray();

            json.Add("MSGType", 0);
            json.Add("Id", "2113");
            json.Add("Content", "");
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Menus", jarray);

            byte[] a = Encoding.UTF8.GetBytes(json.ToString());

            client.Send(a);
            //client.BeginSend(a, 0, a.Length, 0, new AsyncCallback(SendCallback), client);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                //sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
