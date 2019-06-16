using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A13
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var a in actions)
                a();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<Task> taskList = new List<Task>();
            stopwatch.Start();
            foreach (var a in actions)
            {
                taskList.Add(Task.Run(() => a()));
            }
            Task.WaitAll(taskList.ToArray());
            return stopwatch.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            throw new NotImplementedException();
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
           throw new NotImplementedException();
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
           throw new NotImplementedException();
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
			throw new NotImplementedException();
        }
    }
}