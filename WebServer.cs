using System;
using System.Net;

namespace VersaServer
{
    public class WebServer
    {
        private int port;
        private HttpListener _listener;
        private Pagebuilder _pb;

        public WebServer(int port)
        {
            _listener = new HttpListener();
            _pb = new Pagebuilder();
            this.port = port;
        }

        public void Start()
        {
            _listener.Prefixes.Add($"http://*:{port.ToString()}/");
            _listener.Start();
            accept();
            Plugin.Logger.LogWarning($"Webserver running on port {port}");
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private void accept()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private void ListenerCallback(IAsyncResult result)
        {
            HttpListenerContext context = _listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            Plugin.Logger.LogWarning($"Got a connection from {request.RemoteEndPoint}");

            string responseString = _pb.getHTML("test data");

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();

            if (_listener.IsListening)
            {
                accept();
            }
        }
    }
}