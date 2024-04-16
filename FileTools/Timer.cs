using System;


namespace WanXiang.FileTools
{
    internal class Timer
    {
        private static TimeSpan Interval { get; set; } = TimeSpan.FromMilliseconds(2048);
        DateTimeOffset now,now2;
        public Timer() {
            now = DateTimeOffset.Now;
            now2 = now.DateTime;
            Console.WriteLine(Interval.ToString());
            Console.WriteLine(now);
            Console.WriteLine((now+Interval).ToString());
            Console.WriteLine(now2);
            Console.WriteLine((now2+Interval).ToString());

        }
    }
}
