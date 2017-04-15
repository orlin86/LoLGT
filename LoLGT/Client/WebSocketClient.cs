using System;
using WebSocketSharp;

namespace App1
{
    public class WebSocketClient
    {
        public WebSocket ws { get; set; }

        public WebSocketClient(string path)
        {
            ws = new WebSocket(path);
            ws.EmitOnPing = true;
            ws.WaitTime = TimeSpan.FromSeconds(10);
        }

        public void Connect()
        {
            if (ws!=null)
            {
                ws.ConnectAsync();
            }
        }

        public void Send(string data)
        {
            ws.Send(data);
        }

        public void Close()
        {
            ws.Close();
        }




    }
}