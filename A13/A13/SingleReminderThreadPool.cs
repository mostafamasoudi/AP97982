using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThreadPool : ISingleReminder
    {

        public int Delay { get; }
        public string Msg { get; }
        public event Action<string> Reminder;

        public SingleReminderThreadPool(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem((object o) => Reminder((string)o), Msg);
        }
    }
}