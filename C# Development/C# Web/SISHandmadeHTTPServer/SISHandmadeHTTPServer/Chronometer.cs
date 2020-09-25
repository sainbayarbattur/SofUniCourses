using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public string GetTime { get; set; }

        public List<string> Laps { get; set; }

        public string Lap()
        {
            var elapsedTime = this.stopwatch.Elapsed;
            var currLap = $"{elapsedTime.Minutes} : {elapsedTime.Seconds} : {elapsedTime.Milliseconds}";

            this.Laps.Add(currLap);

            return currLap;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
