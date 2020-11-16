using LOTTERIA_Kiosk.Model;
using LOTTERIA_Kiosk.Network;
using Newtonsoft.Json;
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
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Page
    {
        Home home = new Home();
        public LoginPage()
        {
            InitializeComponent();
            App.tcpnet.StartClient();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string idText = tb_Id.Text;
            if (tb_Pwd.Text == "1234")
            {
                if (idText == "2101" || idText == "2105" || idText == "2113")
                {
                    NavigationService.Navigate(new Uri("/View/Home.xaml", UriKind.Relative));
                    loginClient();

                    App.isLogin = true;
                }
                else
                {
                    MessageBox.Show("등록되지 않은 유저입니다.", "롯데리아");
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.", "롯데리아");
            }
        }
        private void loginClient()
        {
            RequestMessage requestJson = new RequestMessage();

            requestJson.MSGType = 0;
            requestJson.Id = "2113";
            requestJson.Content = "로그인";
            requestJson.ShopName = "";
            requestJson.OrderNumber = "";
            requestJson.Menus = null;
            string json = JsonConvert.SerializeObject(requestJson);
            App.tcpnet.Send(json);
        }
    }
}
