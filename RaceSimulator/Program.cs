using System;
using System.Threading;
using Controller;

namespace RaceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize();
            Data.CurrentRace.DriversChanged += Visualisatie.OnDriversChanged;
            Visualisatie.Race = Data.CurrentRace;
            Visualisatie.DrawTrack(Data.CurrentRace.Track);

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}
