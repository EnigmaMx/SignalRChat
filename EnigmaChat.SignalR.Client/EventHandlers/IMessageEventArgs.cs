using System;
using System.Collections.Generic;
using System.Text;

namespace EnigmaChat.SignalR.Client.EventHandlers
{
    public interface IMessageEventArgs
    {
        string Message { get; }
    }
}
