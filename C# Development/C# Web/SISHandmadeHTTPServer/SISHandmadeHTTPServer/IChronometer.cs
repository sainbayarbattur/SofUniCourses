namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IChronometer
    {
        string GetTime { get; set; }

        List<string> Laps { get; set; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
