using LOTTERIA_Kiosk.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LOTTERIA_Kiosk.Network
{
    public class TCPNet
    {

        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        public static String response = String.Empty;
        readonly Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public Thread ReceiveThread;


        public void StartClient()
        {
            try
            {
                client.BeginConnect("10.80.162.152", 80, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                Thread thread = new Thread(Receive);
                thread.Start();

                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void CloseClient()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                client.EndConnect(ar);
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void waitForReceive()
        {
            sendDone.WaitOne();

            Receive();
            receiveDone.WaitOne();
        }

        public void Receive()
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = client;

                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceive(ar);
                Thread.Sleep(1);

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);

                    receiveDone.Set();

                    int CheckIndex = state.sb.ToString().IndexOf("총매출");
                    int CheckIndex2 = state.sb.ToString().IndexOf("총 매출");

                    if (CheckIndex != -1 || CheckIndex2 != -1)
                    {
                        RequestMessage requestJson = new RequestMessage();
                        requestJson.MSGType = MessageType.일반메시지;
                        requestJson.Id = "2113";
                        requestJson.Content = "2조 7249억 8700만원";
                        requestJson.ShopName = "";
                        requestJson.OrderNumber = "";
                        requestJson.Group = false;
                        requestJson.Menus = null;
                        string json = JsonConvert.SerializeObject(requestJson);
                        App.tcpnet.Send(json);
                    }
                    else if (state.sb.ToString() != "200")
                    {
                        if (state.sb.ToString() != null)
                        {
                            Console.WriteLine(state.sb.ToString());
                            MessageBox.Show(state.sb.ToString(), "공지사항");
                        }
                    }
                }
                else
                {
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Send(String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);

            waitForReceive();
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
