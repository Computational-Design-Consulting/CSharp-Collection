using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E0_FileSystemWatcher
{
    class Program
    {
        ///<summary>
        ///Watches a folder for content changes
        ///</summary>
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: WatchForChanges[FolderToWatch]");
                return;
            }

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[0];
            watcher.NotifyFilter = NotifyFilters.Size |
            NotifyFilters.FileName |
            NotifyFilters.DirectoryName |
            NotifyFilters.CreationTime;

            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;

            watcher.Changed += watcher_Change;
            watcher.Created += watcher_Change;
            watcher.Deleted += watcher_Change;

            watcher.Renamed += watcher_Renamed;

            //watcher.Renamed +=
            //new RenamedEventHandler(watcher_Renamed);

            Console.WriteLine(
              "Manipulate files in {0} to see activity...", args[0]);
            watcher.EnableRaisingEvents = true;
            while (true) { Thread.Sleep(1000); }
        }

        static void watcher_Change(object sender, FileSystemEventArgs e)=>
            Console.WriteLine($"{e.Name} changed({e.ChangeType})");

        static void watcher_Renamed(object sender, RenamedEventArgs e)=>
            Console.WriteLine($"{e.OldFullPath} renamed to {e.FullPath}");
    }
}
