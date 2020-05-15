namespace HttpRequester
{
    using System;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                using NetworkStream networkStream = tcpClient.GetStream();

                byte[] requestBytes = new byte[1000000];
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                Console.WriteLine(request);

                string response = 
                "HTTP/1.1 200 OK"
                    + "\r\n" + "Server: Softuni/1.0"
                    + "\r\n" + "Content-Type: text/html"
                    + "\r\n"
                    + "\r\n"
                    + "<h1>Hello</h1>";

                var responseBytes = Encoding.UTF8.GetBytes(response);

                networkStream.Write(responseBytes, 0, responseBytes.Length);
            }

            //var client = new HttpClient();
            //var responseHtml = await client.GetAsync("https://softuni.bg/");

            //var html = await responseHtml.Content.ReadAsStringAsync();

            //File.WriteAllText("./../../../index.html", html);
        }
    }
}