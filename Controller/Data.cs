using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    static class Data
    {
       static Competition Competition { get; set; }
       public static void initialize()
       {
            Competition = new Competition();
       }
        public static void AddDriver()
        {
            Driver driver1 = new Driver();
            Driver driver2 = new Driver();
            Driver driver3 = new Driver();
            Driver driver4 = new Driver();

            Competition.Participants.Add(driver1);
            Competition.Participants.Add(driver2);
            Competition.Participants.Add(driver3);
            Competition.Participants.Add(driver4);

        }
        public static void AddTrack()
        {
            Track track1 = new Track();
            Track track2 = new Track();
            Competition.Tracks.Enqueue(track1);
            Competition.Tracks.Enqueue(track2);
        }
    }
}
