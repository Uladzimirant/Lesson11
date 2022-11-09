using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Person : IAlarmSubscriber
    {
        public string Name { get; private set; }
        public string MessageToSay { get; set; }

        public Person(string name, string messageToSay = "")
        {
            Name = name;
            MessageToSay = messageToSay;
        }

        public void OnTimeEvent(object? sender, int timeElapsed)
        {
            Console.WriteLine(Name + (!string.IsNullOrEmpty(MessageToSay) ? ": " + MessageToSay : ""));
        }
    }
}
