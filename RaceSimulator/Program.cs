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
            Visualisatie.Initialize(Data.CurrentRace);

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}
