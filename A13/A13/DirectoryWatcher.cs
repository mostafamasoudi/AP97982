using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    { 
        private FileSystemWatcher Watcher;
        public Action<string> notify = null;

        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir, "*.txt");
            Watcher.EnableRaisingEvents = true;
        }

        public void Register(Action<string> notifyMe, ObserverType newevent)
        {
            if (newevent == ObserverType.Create)
                Watcher.Created += Watcher_Created;
            else if(newevent==ObserverType.Delete)
                Watcher.Deleted += Watcher_Deleted;

            notify += notifyMe;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            notify(e.FullPath);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            notify(e.FullPath);
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Unregister(Action<string> notifyMe, ObserverType newevent)
        {
            if (newevent == ObserverType.Create)
                Watcher.Created -= Watcher_Created;
            else if (newevent == ObserverType.Delete)
                Watcher.Deleted -= Watcher_Deleted;
        }
    }
}