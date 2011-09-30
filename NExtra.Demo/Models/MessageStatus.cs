using System;

namespace NExtra.Demo.Models
{
    [Flags]
    public enum MessageStatus
    {
        New = 1,
        Sent = 2,
        Received = 4
    }
}
