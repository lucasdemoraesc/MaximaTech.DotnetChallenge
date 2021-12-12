using System;
using System.Collections.Generic;
using System.Threading;

namespace MaximaTech.DotnetChallenge.Api.Utils
{
    public class TaskScheduler
    {
        private static TaskScheduler _instance;
        private List<Timer> timers = new List<Timer>();

        private TaskScheduler()
        {
        }

        public static TaskScheduler Instance =>
            _instance ??= new TaskScheduler();

        public void ScheduleTask(int hour, int minutes, double interval, Action task)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, minutes, 0);

            if (now > firstRun)
                firstRun = firstRun.AddDays(1);

            TimeSpan timeToGo = firstRun - now;

            if (timeToGo <= TimeSpan.Zero)
                timeToGo = TimeSpan.Zero;

            var timer = new Timer(
                x => { task.Invoke(); },
                null,
                timeToGo,
                TimeSpan.FromHours(interval));

            timers.Add(timer);
        }
    }
}
