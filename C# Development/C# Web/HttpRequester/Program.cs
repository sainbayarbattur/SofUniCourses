namespace HttpRequester
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Program
    {
        static Dictionary<string, int> SessionStore = new Dictionary<string, int>();

        public static async Task Main()
        {
            const string newLine = "\r\n";

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

                //string responseText = "<img src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/1200px-Cat03.jpg\" />>";

                //var catBytes = await File.ReadAllBytesAsync("./../../../Cat03.jpg");
                //var responseTextBytes = Encoding.UTF8.GetBytes(responseText);

                var sid = Regex.Match(request, @"sid=[^\n]*\n").Value?.Replace("sid=", string.Empty).Trim();
                Console.WriteLine(sid);
                var newSid = Guid.NewGuid().ToString();
                var count = 0;
                if (SessionStore.ContainsKey(sid))
                {
                    SessionStore[sid]++;
                    count = SessionStore[sid];
                }
                else
                {
                    sid = null;
                    SessionStore[newSid] = 1;
                    count = 1;
                }
                string responseText = $"<h1>{count}<h1>";
                var responceBytes = Encoding.UTF8.GetBytes(responseText);

                string response =
                    "HTTP/1.1 200 OK"
                        + newLine + "Server: Softuni/1.0"
                        + newLine + "Content-Type: text/html"
                        + newLine + $"Content-Length: {responceBytes.Count()}"
                        + newLine + (string.IsNullOrWhiteSpace(sid) ?
                                ("Set-Cookie: sid=" + newSid + newLine)
                                : string.Empty)
                        + newLine
                        + newLine
                        + responseText;

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