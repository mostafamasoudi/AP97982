using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;

        public int Delay { get; }

        public string Msg { get; }

        public event Action<string> Reminder;

        public SingleReminderTask(string msg, int delay)
        {
            this.Msg = msg;
            this.Delay = delay;
        }

        public void Start()
        {
            ReiminderTask = new Task(() => Reminder(Msg));
            ReiminderTask.Start();
        }
    }
}