using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;
        
        public int Delay { get; }
        public string Msg { get; }
        public event Action<string> Reminder;

        public SingleReminderThread(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        public void Start()
        {
            ReiminderThread = new Thread(() => Reminder(Msg));
            ReiminderThread.Start();
        }
    }
}