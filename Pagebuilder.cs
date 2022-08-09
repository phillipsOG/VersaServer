

namespace VersaServer
{
    internal class Pagebuilder
    {
        internal string html = "";
        public string getHTML(string source)
        {
            html = @"<!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>EN Leaderboard</title>
            </head>
            <body>
            <table>
            <tr><th>Name</th><th>Kills</th></tr>";
            html += source;
            html += @"</table>
            </body>
            </html>";

            return html;
        }
    }
}
