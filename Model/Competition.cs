using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        static List<IParticipant> Participants { get; set; }
        Queue<Track> Tracks { get; set; }
        public Competition()
        {
            Participants = new List<IParticipant>();
            Tracks = new Queue<Track>();
        }
        public static void addDriver()
        {
            Driver driver1 = new Driver();
            Participants.Add(driver1);
        }
        public static void addTrack()
        {
        }
    }
}