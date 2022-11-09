using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class MessagePrinter : IAlarmSubscriber
    {
        private int _count = 0;
        public void OnTimeEvent(object? sender, int timeElapsed)
        {
            Console.WriteLine($"{_count++} - {timeElapsed} seconds passed");
        }
    }
}
