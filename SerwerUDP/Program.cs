using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SerwerUDP
{
    class Program
    {
        private const int listenPort = 3301;
    
        static void Main(string[] args)
        {
            bool done = false;

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, listenPort);
            while (!done)
            {
                byte[] messageByte= listener.Receive(ref endPoint);

                string message = Encoding.UTF8.GetString(messageByte);
                Console.WriteLine("Odebrano: " + message);

                int test = listener.Send(messageByte, messageByte.Length, endPoint);
 
            }
            listener.Close();
        }
    }
}
