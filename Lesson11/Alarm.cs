using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Alarm
    {
        private int _speedPerSecond;
        public int SpeedPerSecond { 
            get { return _speedPerSecond; }
            set 
            { 
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(SpeedPerSecond), "Must be positive");
                _speedPerSecond = value;
            }
        }

        private SortedSet<int> _timepoints = new SortedSet<int>();
        private event EventHandler<int>? _timeEvent;

        public Alarm(int speedPerSecondInMilliseconds = 1000)
        {
            SpeedPerSecond = speedPerSecondInMilliseconds;
        }

        public void Subscribe(IAlarmSubscriber subscriber)
        {
            _timeEvent += subscriber.OnTimeEvent;
        }

        public void Subscribe(EventHandler<int> function)
        {
            _timeEvent += function;
        }

        public void SubscribeOnTime(IAlarmSubscriber subscriber, int time)
        {
            SubscribeOnTime((self) => subscriber.OnTimeEvent(self, time), time);
        }
        public void SubscribeOnTime(Action<object> function, int time)
        {
            EventHandler<int> l = null;
            l = (self, t) => {
                if (t == time)
                {
                    function(t);
                    _timeEvent -= l;
                }
            };
            _timeEvent += l;
            _timepoints.Add(time);
        }

        public void RegisterTimepoint(int seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds), "Must not be negative");
            _timepoints.Add(seconds);
        }

        public void BeginClock()
        {
            if (_timepoints.Count == 0) return;
            int beforeTimepoint = 0;
            foreach (var timepoint in _timepoints)
            {
                Thread.Sleep((timepoint - beforeTimepoint) * SpeedPerSecond);
                _timeEvent?.Invoke(this, timepoint);
                beforeTimepoint = timepoint;
            }
        }
    }
}
