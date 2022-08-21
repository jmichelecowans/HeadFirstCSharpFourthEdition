using System;

namespace ChainedEventHandlersExample
{
    class Talker
    {
        public event EventHandler<TalkEventArgs> TalkToMe;

        public void OnTalkToMe(string message) => TalkToMe?.Invoke(this, new TalkEventArgs(message));
    }
}
