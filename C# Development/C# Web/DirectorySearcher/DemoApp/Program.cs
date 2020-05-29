namespace DemoApp
{
    using SIS.HTTP;
    using SIS.HTTP.Logging;
    using SIS.HTTP.Response;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            var routes = new List<Route>();
            var logger = new ConsoleLogger();

            var files = File.ReadAllText("./../../../wwwroot/Styles.css");

            routes.Add(new Route(HttpMethodType.Get, "/", (HttpRequest request) =>
             {
                 var html = $"Hello {request.SessionData["Name"]}. <br></br><a href='/user/logout'>Logout</a><br><form method='POST' action='/user/directory'><input type='text' name='directory'><br><button type='submit' method='POST' href='/user/directory'>Submit</button></form>";

                 if (request.SessionData["Name"] == null)
                 {
                     html = $"You should be logged in <a href='/user/forms/login'>Login</a>.";
                 }

                 HttpResponse response = new HtmlResponse($"<h1>{html}<h1>");
                 return response;
             }));

            routes.Add(new Route(HttpMethodType.Get, "/favicon.ico", (HttpRequest request) =>
            {
                var faviconBytes = File.ReadAllBytesAsync("./../../../favicon.ico").GetAwaiter().GetResult();
                var fileResponse = new FileResponse(faviconBytes, "image/x-icon");
                return fileResponse;
            }));

            routes.Add(new Route(HttpMethodType.Get, "/user/forms/login", (HttpRequest request) =>
            {
                //request.SessionData["Name"] = "Todor";

                string html = "<form method='POST' action='/user/login'> " +
                                  "<label for= 'fname' > First name:</label><br>" +
                                   "<input type = 'text' id = 'fname' name = 'fname'><br>" +
                                   "<label for= 'lname' > Last name:</label><br>" +
                                    "<input type = 'text' id = 'lname' name = 'lname'><br><br>" +
                                    "<input type='submit' value='Submit'>" +
                              "</form>";

                var response = new HtmlResponse(html);

                return response;
            }));

            routes.Add(new Route(HttpMethodType.Post, "/user/login", (HttpRequest request) =>
            {
                request.SessionData["Name"] = request.FormData["fname"];

                var response = new RedirectResponse("/");

                return response;
            }));

            routes.Add(new Route(HttpMethodType.Get, "/user/logout", (HttpRequest request) =>
            {
                request.SessionData["Name"] = null;

                var rediurectResponse = new RedirectResponse("/");

                return rediurectResponse;
            }));

            routes.Add(new Route(HttpMethodType.Post, "/user/directory", (HttpRequest request) =>
            {
                var rediurectResponse = new HtmlResponse(GenerateHtml(request.FormData["directory"]).ToString());

                return rediurectResponse;
            }));

            var server = new HttpServer(80, routes, logger);

            await server.StartAsync();
        }

        private static FileInfo[] GetDirectoryFiles(string directory)
        {
            FileInfo[] files = null;

            try
            {
                DirectoryInfo d = new DirectoryInfo(directory);//Assuming Test is your Folder
                files = d.GetFiles(".", SearchOption.AllDirectories); //Getting Text files
            }
            catch (Exception)
            {
                return new FileInfo[0];
            }

            return files;
        }

        private static StringBuilder GenerateHtml(string directory)
        {
            var sb = new StringBuilder();

            string css = "<!DOCTYPE html>" +
                           "<html>" +
                           "<head>" +
                           "<style>" +
                           "table {" +
                           "font-family: arial, sans-serif;" +
                           "border-collapse: collapse;" +
                           "width: 100%;" +
                           "}" +

                                            "td, th {" +
                                                "border: 1px solid #dddddd;" +
                               "text-align: left;" +
                                                "padding: 8px;" +
                                            "}" +

                                            "tr:nth-child(even) {" +
                                                "background-color: #dddddd;" +
                           "}" +
                           "</style>" +
                           "</head>";

            string table = css +
                           "<body>" +
                           "<table>" +
                           "<tr>" +
                           "<th>FileName</th>" +
                           "<th>FileLength</th>" +
                           "<th>FileCreationTime</th>" +
                           "</tr>";

            sb.Append(table);

            foreach (var file in GetDirectoryFiles(directory))
            {
                sb.Append("<tr>");

                sb.Append("<td>");
                sb.Append(file.Name);
                sb.Append("<td>");

                sb.Append("<td>");
                sb.Append(file.Length);
                sb.Append("</td>");

                sb.Append("<td>");
                sb.Append(file.CreationTime);
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("</body>");
            }

            sb.Append("</table>");

            return sb;
        }
    }
}