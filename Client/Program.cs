using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static int port = 8888;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            Console.Write("Connected to the server. Please enter message:");
            string message = Console.ReadLine();
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);


            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;


            bytes = socket.Receive(data, data.Length, 0);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));


            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }
    }
}
