using System;
using System.IO;

namespace A13
{

    public class SingleFileWatcher: IDisposable
    {
        private string FileName;
        private FileSystemWatcher Watcher;
        public Action NewAction;

        public SingleFileWatcher(string fileName)
        {
            this.FileName = fileName;
            Watcher=new FileSystemWatcher(Path.GetDirectoryName(fileName),Path.GetFileName(fileName));
            Watcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Register(Action notify)
        {
            NewAction += notify;
            Watcher.Changed += registering;
        }

        private void registering(object sender, FileSystemEventArgs e)
        {
            NewAction();
        }

        public void Unregister(Action notify)
        {
            Watcher.Changed -= registering;
            NewAction -= notify;
        }
    }
}