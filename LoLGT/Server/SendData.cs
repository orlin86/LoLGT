﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class SendData : WebSocketBehavior
    {
        public SendData()
        {
        }

        protected override void OnOpen()
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
        }

        // To send data to a client from wssv:
        // Send()

        // To send to all clients:
        // wssv.WebSocketServices["/SendData"].Sessions.Broadcast();
    }
}
