using System;

namespace ChainedEventHandlersExample
{
    class TalkEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public TalkEventArgs(string message) => Message = message;
    }
}
